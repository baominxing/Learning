using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MDCDataService;
using MDCSingleDLL.DBHelper;
using MDCSingleDLL.Protocol;
using Net4Logger;

namespace MDCSingleDLL.Process
{
    /// <summary>
    /// State object for reading client data asynchronously
    /// </summary>
    public class StateObject
    {
        public StateObject(IDbHelper dbHelper)
        {
            Machine = new Machine();
            DataItems = new List<DataItem>();
            Package = new BasicPackage();
            DbHelper = dbHelper;
        }
        // Client  socket.
        public Socket WorkSocket;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] Buffer = new byte[BufferSize];
        //映射数据项的个数
        public int MappedFieldCount;
        //入库的数据
        public int InsertedCount;
        //设备编号
        public string MachineCode = string.Empty;
        //采集数据项的个数
        public int CollectDataCount;
        //设备制造厂商编号
        public int TenantId = -1;
        //登录机器的用户名(0~255)
        public byte UserName = 0xff;
        //登录机器的密码
        public string Password = "";
        //是否登录成功
        public bool IsLogined;
        //存放零时字节数组
        public List<byte> ResultBytes = new List<byte>();
        //命令包
        public BasicPackage Package;
        //要读取的字节长度
        public int Length;
        //数据项编号
        internal ushort Did;
        //数据项类型
        internal byte Dt;
        //数据项值
        internal byte[] Value;
        //设备对象
        public Machine Machine { get; set; }
        //接收的数据项集合
        public List<DataItem> DataItems { get; set; }
        //数据库对象辅助对象
        public IDbHelper DbHelper { get; set; }
        //用于记录最后接收时间点
        public DateTime ActiveDateTime = DateTime.Now;
        //是否支持数据推送功能
        internal bool IsSupported;
        //数据包大小
        internal int Size;
        //ConnectedIPAddress
        internal string ConnectedIpAddress { get; set; }
    }
    public class ActiveProccess : IProcess
    {
        #region Conifg

        private const int ALPVERSION = 0x1000;
        private AsyncSocketServer _asyncSocketServer;
        private Socket _listener;
        private IPEndPoint _localEndPoint;
        private DaemonThread _daemonThread;
        private List<string> _machineCodeCaches = new List<string>();
        private readonly ILogManager _logManager;

        public ActiveProccess(ILogManager logManager)
        {
            _logManager = logManager;
        }

        public void Run(string address, int port)
        {
            _logManager.Info($"{MessageType.Info}{DateTime.Now} - 开启守护线程检测超时连接");
            _asyncSocketServer = new AsyncSocketServer(_logManager);
            _daemonThread = new DaemonThread(_asyncSocketServer);
            StartListening(address, port);
        }

        private void StartListening(string address, int port)
        {
            // Establish the local endpoint for the socket.
            _localEndPoint = new IPEndPoint(IPAddress.Any, port);
            // Create a TCP/IP socket.
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Bind the socket to the local endpoint and listen for incoming connections.
            _logManager.Info($"{MessageType.Info}{DateTime.Now} - 开始监听http://{address}:{port}");
            try
            {
                _listener.Bind(_localEndPoint);
                _listener.Listen(1000);
                _listener.BeginAccept(AcceptCallback, _listener);
            }
            catch (SocketException e)
            {
                _daemonThread.Close();
                _logManager.Error($"{MessageType.Error}{e}");
            }
            catch (Exception e)
            {
                _daemonThread.Close();
                _logManager.Error($"{MessageType.Error}{e}");
            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            StateObject state = null;
            try
            {
                var listener = (Socket)ar.AsyncState;
                var handler = listener.EndAccept(ar);
                _logManager.Info($"{MessageType.Info}{DateTime.Now} - 收到来自{handler.RemoteEndPoint}的连接");
                state = new StateObject(new MongoHelper())
                {
                    WorkSocket = handler,
                    ConnectedIpAddress = handler.RemoteEndPoint.ToString()
                };
                if (_machineCodeCaches.Count == 0)
                {
                    _machineCodeCaches = state.DbHelper.UpdateMachineCodeCache();
                }
                _asyncSocketServer.RemoveDisconnectedSession(state);
                //发送确认数据
                state.Package.CID = FuncCode.Ensure;
                Send(state);
                //接受下一次连接
                listener.BeginAccept(AcceptCallback, listener);
            }
            catch (SocketException e)
            {
                //接受下一次连接
                _listener.BeginAccept(AcceptCallback, _listener);
                _logManager.Error($"{MessageType.Error}{e}");
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level2);
            }
            catch (ObjectDisposedException e)
            {
                _logManager.Error($"{MessageType.Error}{e}");
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level2);
            }
            catch (Exception e)
            {
                //接受下一次连接
                _listener.BeginAccept(AcceptCallback, _listener);
                _logManager.Error($"{MessageType.Error}{e}");
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level2);
            }
        }
        #endregion

        #region Send
        private void Send(StateObject state)
        {
            try
            {
                var byteData = PrepareSendData(state);
                if (state == null || !state.WorkSocket.Connected) return;

                _logManager.Error($"{MessageType.Info}发送数据长度{byteData.Length}");

                state.WorkSocket.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, state);
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        private byte[] PrepareSendData(StateObject state)
        {
            byte[] result = null;
            switch (state.Package.CID)
            {
                case FuncCode.Ensure:
                    _logManager.Info($"{MessageType.Send} => 确认报文");
                    var package = new EnsurePackage
                    {
                        PID = SocketHelper.HostToNetwork((ushort)0x0000),
                        CID = SocketHelper.HostToNetwork(FuncCode.Ensure),
                        ST = 0,
                        UID = 0,
                        VER = SocketHelper.HostToNetwork((ushort)0x1000),
                        IPAddress = "".PadRight(20, '\0'),
                        Port = SocketHelper.HostToNetwork((uint)0)
                    };
                    result = SocketHelper.StructToBytes(package);
                    _logManager.Info($"{MessageType.Send} => {PrintReceivebytes(result)}");
                    break;
                case FuncCode.Redirect:
                    _logManager.Info($"{MessageType.Send} => 重定向报文");
                    var package2 = new EnsurePackage
                    {
                        PID = SocketHelper.HostToNetwork((ushort)0x0000),
                        CID = SocketHelper.HostToNetwork(FuncCode.Redirect),
                        ST = 0,
                        UID = 0,
                        VER = SocketHelper.HostToNetwork((ushort)0x1000),
                        IPAddress = "127.0.0.1".PadRight(20, '\0'),
                        Port = SocketHelper.HostToNetwork((uint)11000)
                    };
                    result = SocketHelper.StructToBytes(package2);
                    break;
                case FuncCode.Close:
                    _logManager.Info($"{MessageType.Send} => 关闭报文");
                    var package3 = new EnsurePackage
                    {
                        PID = SocketHelper.HostToNetwork((ushort)0x0000),
                        CID = SocketHelper.HostToNetwork(FuncCode.Close),
                        ST = 0,
                        UID = 0,
                        VER = SocketHelper.HostToNetwork((ushort)0x1000),
                        IPAddress = "".PadRight(20, '\0'),
                        Port = SocketHelper.HostToNetwork((uint)0)
                    };
                    result = SocketHelper.StructToBytes(package3);
                    break;
                case FuncCode.Login:
                    _logManager.Info($"{MessageType.Login}{state.Machine.MachineCode} => 登录报文");
                    var package4 = new LoginPackage
                    {
                        PID = SocketHelper.HostToNetwork((ushort)0x0000),
                        CID = SocketHelper.HostToNetwork(FuncCode.Login),
                        ST = 0,
                        UID = Convert.ToByte(state.UserName),
                        VER = SocketHelper.HostToNetwork((ushort)0x1000),
                        Password = state.Password.PadRight(8, '\0')
                    };
                    result = SocketHelper.StructToBytes(package4);
                    _logManager.Info($"{MessageType.Send} => {PrintReceivebytes(result)}");
                    break;
                case FuncCode.EnumAllData:
                    _logManager.Info($"{MessageType.RequireDataItem}{state.Machine.MachineCode} => 枚举请求报文");
                    var package5 = new BasicPackage
                    {
                        PID = SocketHelper.HostToNetwork((ushort)0x0000),
                        CID = SocketHelper.HostToNetwork(FuncCode.EnumAllData),
                        ST = 0,
                        UID = Convert.ToByte(state.UserName),
                        VER = SocketHelper.HostToNetwork((ushort)0x1000)
                    };
                    result = SocketHelper.StructToBytes(package5);
                    break;
                case FuncCode.RequestForPush:
                    _logManager.Info($"{MessageType.RequireDataItem}{state.Machine.MachineCode} => 推送请求报文");
                    var package6 = new RequestPushPackage
                    {
                        PID = SocketHelper.HostToNetwork((ushort)0x0000),
                        CID = SocketHelper.HostToNetwork(FuncCode.RequestForPush),
                        UID = state.UserName,
                        ST = 0,
                        VER = SocketHelper.HostToNetwork((ushort)0x1000),
                        RV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    result = SocketHelper.StructToBytes(package6);
                    _logManager.Info($"{MessageType.Send} => {PrintReceivebytes(result)}");
                    break;
                case FuncCode.NullCommandReply:
                    _logManager.Info($"{MessageType.KeepAlive}{state.Machine.MachineCode} => 心跳包回复报文");
                    var package7 = new BasicPackage
                    {
                        PID = SocketHelper.HostToNetwork((ushort)0x0000),
                        CID = SocketHelper.HostToNetwork(FuncCode.NullCommandReply),
                        ST = 0,
                        UID = Convert.ToByte(state.UserName),
                        VER = SocketHelper.HostToNetwork((ushort)0x1000)
                    };
                    result = SocketHelper.StructToBytes(package7);
                    _logManager.Info($"{MessageType.Send} => {PrintReceivebytes(result)}");
                    break;
                case FuncCode.PushDataReply:
                    _logManager.Info($"{MessageType.Send}{state.Machine.MachineCode} => 推送回复报文");
                    var package8 = new BasicPackage
                    {
                        PID = SocketHelper.HostToNetwork((ushort)0x0000),
                        CID = SocketHelper.HostToNetwork(FuncCode.PushDataReply),
                        ST = 0,
                        UID = Convert.ToByte(state.UserName),
                        VER = SocketHelper.HostToNetwork((ushort)0x1000)
                    };
                    result = SocketHelper.StructToBytes(package8);
                    _logManager.Info($"{MessageType.Send} => {PrintReceivebytes(result)}");
                    break;
            }
            return result;
        }

        private void SendCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            try
            {
                if (state != null && state.WorkSocket.Connected)
                {
                    _logManager.Error($"{MessageType.Info}发送成功,准备接收数据...");
                    state.WorkSocket.EndSend(ar);

                    switch (state.Package.CID)
                    {
                        case FuncCode.Ensure:
                        case FuncCode.Login:
                        case FuncCode.EnumAllData:
                        case FuncCode.RequestForPush:
                        case FuncCode.NullCommandReply:
                        case FuncCode.PushDataReply:
                            ReceiveHead(state);
                            break;
                        case FuncCode.Redirect:
                        case FuncCode.Close:
                            _asyncSocketServer.CloseAndDisposeConnection(state, new Exception("重定向/关闭"), ErrorLevel.Level1);
                            break;
                    }
                }

            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }
        #endregion

        #region Receive
        private void ReceiveHead(StateObject state)
        {
            state.ActiveDateTime = DateTime.Now;
            try
            {
                if (state.WorkSocket.Connected)
                {
                    //读取8字节命令部分
                    state.WorkSocket.BeginReceive(state.Buffer, 0, 8, 0, ReceiveHeadCallback, state);
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        private void ReceiveHeadCallback(IAsyncResult ar)
        {
            var state = (StateObject)ar.AsyncState;
            state.ActiveDateTime = DateTime.Now;
            try
            {
                if (!state.WorkSocket.Connected) return;

                var bytesRead = state.WorkSocket.EndReceive(ar);

                if (bytesRead <= 0) return;

                state.ResultBytes = state.ResultBytes.Concat(state.Buffer.Take(bytesRead).ToArray()).ToList();

                if (state.ResultBytes.Count < 8)
                {
                    state.WorkSocket.BeginReceive(state.Buffer, 0, 8 - state.ResultBytes.Count, 0, ReceiveHeadCallback, state);
                }
                else
                {
                    _logManager.Info($"{MessageType.Receive} => {PrintReceivebytes(state.ResultBytes.ToArray())}");
                    var package = SocketHelper.BytesToStruct<BasicPackage>(state.ResultBytes.ToArray());
                    package.PID = SocketHelper.NetworkToHost(package.PID);
                    package.CID = SocketHelper.NetworkToHost(package.CID);
                    package.VER = SocketHelper.NetworkToHost(package.VER);

                    if (package.VER == ALPVERSION)
                    {
                        state.Package = package;
                        state.ResultBytes.Clear();
                        //解析命令
                        ParseCommand(state);
                    }
                    else
                    {
                        _asyncSocketServer.CloseAndDisposeConnection(state, new Exception($"协议版本错误，当前版为:{package.VER},需求版本为：{ALPVERSION}"), ErrorLevel.Level1);
                    }
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        /// <summary>
        /// 解析命令
        /// </summary>
        /// <param name="state"></param>
        private void ParseCommand(StateObject state)
        {
            try
            {
                switch (state.Package.CID)
                {
                    case FuncCode.Bootstrap:
                        state.Length = 32;
                        state.WorkSocket.BeginReceive(state.Buffer, 0, state.Length, 0, ReceiveBodyCallback, state);
                        break;
                    case FuncCode.Login:
                        state.Length = 8;
                        state.WorkSocket.BeginReceive(state.Buffer, 0, state.Length, 0, ReceiveBodyCallback, state);
                        break;
                    case FuncCode.EnumAllData:
                        state.Length = 8;
                        state.WorkSocket.BeginReceive(state.Buffer, 0, state.Length, 0, ReceiveBodyCallback, state);
                        break;
                    case FuncCode.RequestForPush:
                        state.Length = 8;
                        state.WorkSocket.BeginReceive(state.Buffer, 0, state.Length, 0, ReceiveBodyCallback, state);
                        break;
                    case FuncCode.PushData:
                        state.Length = 8;
                        state.WorkSocket.BeginReceive(state.Buffer, 0, state.Length, 0, ReceiveBodyCallback, state);
                        break;
                    case FuncCode.UpdateMachineCodeCache:
                        UpdateMachineCodeCache(state);
                        break;
                    case FuncCode.StopCollectData:
                        StopCollectData(state);
                        break;
                    case FuncCode.NullCommand:
                        state.Package.CID = FuncCode.NullCommandReply;
                        Send(state);
                        break;
                    case FuncCode.Close:
                        _asyncSocketServer.CloseAndDisposeConnection(state, new Exception("关闭"), ErrorLevel.Level1);
                        break;
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }

        }
        private void ReceiveBodyCallback(IAsyncResult ar)
        {
            var state = (StateObject)ar.AsyncState;
            state.ActiveDateTime = DateTime.Now;
            try
            {
                // Read data from the remote device.
                if (!state.WorkSocket.Connected) return;

                var bytesRead = state.WorkSocket.EndReceive(ar);

                if (bytesRead <= 0) return;

                // There might be more data, so store the data received so far.
                state.ResultBytes = state.ResultBytes.Concat(state.Buffer.Take(bytesRead).ToArray()).ToList();
                if (state.ResultBytes.Count < state.Length)
                {
                    // Get the rest of the data.
                    state.WorkSocket.BeginReceive(state.Buffer, 0, state.Length - state.ResultBytes.Count, 0, ReceiveBodyCallback, state);
                }
                else
                {
                    switch (state.Package.CID)
                    {
                        case FuncCode.Bootstrap:
                            ProcessBootstrap(state);
                            break;
                        case FuncCode.Login:
                            ProcessLogin(state);
                            break;
                        case FuncCode.EnumAllData:
                            ProcessEnumAllData(state);
                            break;
                        case FuncCode.RequestForPush:
                            ProcessRequestForPush(state);
                            break;
                        case FuncCode.PushData:
                            ProcessPushData(state);
                            break;
                        case FuncCode.UpdateMachineCodeCache:
                            UpdateMachineCodeCache(state);
                            break;
                    }
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        /// <summary>
        /// 处理设备自举
        /// </summary>
        /// <param name="state"></param>
        private void ProcessBootstrap(StateObject state)
        {
            try
            {
                _logManager.Info($"{MessageType.Receive} => {PrintReceivebytes(state.ResultBytes.ToArray())}");
                var package = SocketHelper.BytesToStruct<MacBootstrapPackage>(state.ResultBytes.ToArray());
                //根据自举得设备Id获取数据库里存储的登录用户名和密码
                state.Machine.MachineCode = Encoding.ASCII.GetString(package.DID);
                GetMacLoginInfo(state);
                _logManager.Info($"{MessageType.Info}处理{state.Machine.MachineCode}自举数据");
                state.ResultBytes.Clear();
                //发送登录包
                state.Package.CID = FuncCode.Login;
                Send(state);
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        /// <summary>
        /// 处理登录返回信息
        /// </summary>
        /// <param name="state"></param>
        private void ProcessLogin(StateObject state)
        {
            try
            {
                if (state.Package.ST == 0)
                {
                    //asyncSocketServer.RemoveDisconnectedSession(state);
                    _logManager.Info($"{MessageType.Login}{state.Machine.MachineCode} => 登录成功");
                    state.IsLogined = true;
                    state.ResultBytes.Clear();
                    state.Package.CID = FuncCode.EnumAllData;
                    Send(state);
                }
                else
                {
                    //登录失败，关闭此次会话
                    _logManager.Info($"{MessageType.Login}{state.Machine.MachineCode} => 登录失败,关闭此次会话");
                    LoginResultPackage package = SocketHelper.BytesToStruct<LoginResultPackage>(state.ResultBytes.ToArray());
                    package.ERR = SocketHelper.NetworkToHost(package.ERR);
                    package.RV = SocketHelper.NetworkToHost(package.RV);
                    state.IsLogined = false;
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        /// <summary>
        /// 处理枚举数据项返回结果
        /// </summary>
        /// <param name="state"></param>
        private void ProcessEnumAllData(StateObject state)
        {
            try
            {
                _logManager.Info($"{MessageType.Info}{state.Machine.MachineCode} => " + PrintReceivebytes(state.ResultBytes.ToArray()));
                EnumPackage package = SocketHelper.BytesToStruct<EnumPackage>(state.ResultBytes.ToArray());
                _logManager.Info($"{MessageType.Info}{state.Machine.MachineCode} => 枚举数据项{package.Count}个");
                package.Count = SocketHelper.NetworkToHost(package.Count);
                _logManager.Info($"{MessageType.Info}{state.Machine.MachineCode} => 枚举数据项{package.Count}个");
                state.ResultBytes.Clear();
                //如果机器没有枚举数据项则直接发送推送数据请求
                if (package.Count == 0)
                {
                    //发送推送数据请求
                    state.Package.CID = FuncCode.RequestForPush;
                    Send(state);
                }
                else
                {
                    state.MappedFieldCount = package.Count;
                    state.Size = PackgeSize.EnumDataPackageSize * state.MappedFieldCount;
                    if (state.Size > 1024 * 10)
                    {
                        _logManager.Info($"{MessageType.Error}{state.Machine.MachineCode} => 非法数据包(大小{state.Size})");
                        _asyncSocketServer.CloseAndDisposeConnection(state, new Exception("非法数据包,大小为:" + state.Size + ""), ErrorLevel.Level1);
                    }
                    else
                    {
                        state.WorkSocket.BeginReceive(state.Buffer, 0, PackgeSize.EnumDataPackageSize, 0, ReceiveEnumDataCallback, state);
                    }
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        /// <summary>
        /// 解析枚举数据明细记录
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveEnumDataCallback(IAsyncResult ar)
        {
            var state = (StateObject)ar.AsyncState;
            try
            {
                if (state == null || !state.WorkSocket.Connected) return;

                var bytesRead = state.WorkSocket.EndReceive(ar);

                if (bytesRead <= 0) return;

                state.ResultBytes = state.ResultBytes.Concat(state.Buffer.Take(bytesRead).ToArray()).ToList();
                if (state.ResultBytes.Count < PackgeSize.EnumDataPackageSize)
                {
                    state.WorkSocket.BeginReceive(state.Buffer, 0, PackgeSize.EnumDataPackageSize - state.ResultBytes.Count, 0, ReceiveEnumDataCallback, state);
                }
                else
                {
                    var package = SocketHelper.BytesToStruct<EnumDataRecordPackage>(state.ResultBytes.ToArray());
                    package.DID = SocketHelper.NetworkToHost(package.DID);
                    _logManager.Info($"{MessageType.ResponseDataItem}{state.Machine.MachineCode} => 枚举数据项编号{package.DID},内容为{package.NAME}");
                    state.Machine.Map.MapArray.Add(new MapArray() { Id = package.DID.ToString(), Value = package.NAME });
                    state.InsertedCount++;
                    state.ResultBytes.Clear();
                    if (state.InsertedCount < state.MappedFieldCount)
                    {
                        state.WorkSocket.BeginReceive(state.Buffer, 0, PackgeSize.EnumDataPackageSize, 0, ReceiveEnumDataCallback, state);
                    }
                    else
                    {
                        state.DbHelper.InsertMappedFiled(state.Machine);
                        state.InsertedCount = 0;
                        state.Package.CID = FuncCode.RequestForPush;
                        Send(state);
                    }
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        /// <summary>
        /// 处理推送数据返回结果
        /// </summary>
        /// <param name="state"></param>
        private void ProcessRequestForPush(StateObject state)
        {
            try
            {
                if (state.Package.ST == 0)
                {
                    //支持推送数据
                    state.IsSupported = true;
                    state.ResultBytes.Clear();
                    //开始接受数据
                    ReceiveHead(state);
                }
                else
                {
                    //登录失败，关闭此次会话
                    var package = SocketHelper.BytesToStruct<ErrorPackage>(state.ResultBytes.ToArray());
                    package.ERR = SocketHelper.NetworkToHost(package.ERR);
                    package.RV = SocketHelper.NetworkToHost(package.RV);
                    state.IsSupported = false;
                    _asyncSocketServer.CloseAndDisposeConnection(state, new Exception("不支持推送数据,错误代码为" + package.ERR), ErrorLevel.Level1);
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        /// <summary>
        /// 处理接收到的数据项
        /// </summary>
        /// <param name="state"></param>
        private void ProcessPushData(StateObject state)
        {
            try
            {
                // All the data has arrived; put it in response.
                var package = SocketHelper.BytesToStruct<PushHeadPackage>(state.ResultBytes.ToArray());
                package.Count = SocketHelper.NetworkToHost(package.Count);
                _logManager.Info($"{MessageType.ResponseDataItem}{state.Machine.MachineCode} => 推送数据项{package.Count}个");
                state.CollectDataCount = package.Count;
                state.ResultBytes.Clear();
                if (package.Count == 0)
                {
                    state.Package.CID = FuncCode.PushDataReply;
                    Send(state);
                }
                else
                {
                    state.WorkSocket.BeginReceive(state.Buffer, 0, 8, 0, ReceiveRecordHeadCallback, state);
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        private void ReceiveRecordHeadCallback(IAsyncResult ar)
        {
            var state = (StateObject)ar.AsyncState;
            try
            {
                if (state == null || !state.WorkSocket.Connected) return;

                var bytesRead = state.WorkSocket.EndReceive(ar);

                if (bytesRead <= 0) return;

                state.ResultBytes = state.ResultBytes.Concat(state.Buffer.Take(bytesRead).ToArray()).ToList();
                if (state.ResultBytes.Count < 8)
                {
                    state.WorkSocket.BeginReceive(state.Buffer, 0, 8 - state.ResultBytes.Count, 0, ReceiveRecordHeadCallback, state);
                }
                else
                {
                    var package = SocketHelper.BytesToStruct<PushBodyPackage>(state.ResultBytes.Take(8).ToArray());
                    package.DID = SocketHelper.NetworkToHost(package.DID);
                    package.DLEN = SocketHelper.NetworkToHost(package.DLEN);
                    state.Did = package.DID;
                    state.Length = package.DLEN;
                    state.Dt = package.DT;
                    state.ResultBytes.Clear();
                    state.WorkSocket.BeginReceive(state.Buffer, 0, package.DLEN, 0, ReceiveRecordBodyCallback, state);
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        private void ReceiveRecordBodyCallback(IAsyncResult ar)
        {
            var state = (StateObject)ar.AsyncState;
            try
            {
                if (state == null || !state.WorkSocket.Connected) return;

                var bytesRead = state.WorkSocket.EndReceive(ar);

                if (bytesRead <= 0) return;

                state.ResultBytes = state.ResultBytes.Concat(state.Buffer.Take(bytesRead).ToArray()).ToList();
                if (state.ResultBytes.Count < state.Length)
                {
                    state.WorkSocket.BeginReceive(state.Buffer, 0, state.Length - state.ResultBytes.Count, 0, ReceiveRecordBodyCallback, state);
                }
                else
                {
                    var bytes = string.Empty;
                    for (var i = 0; i < state.ResultBytes.Count; i++)
                    {
                        bytes += "," + state.ResultBytes[i];
                    }
                    state.Value = state.ResultBytes.ToArray();
                    var item = new DataItem() { Id = state.Did, Type = state.Dt, Value = state.Value };
                    var value = string.Empty;
                    var firstOrDefault = state.Machine.Map.MapArray.FirstOrDefault(t => t.Id == state.Did.ToString());
                    if (firstOrDefault != null)
                    {
                        value = firstOrDefault.Value.Trim();
                    }
                    _logManager.Info($"{MessageType.Receive}{state.Machine.MachineCode} => {value}({Enum.GetName(typeof(DataType), state.Dt)},Id {state.Did}): {GetValueByType(item)}<{bytes.Trim(',')}>");
                    state.DataItems.Add(item);
                    state.InsertedCount++;
                    state.ResultBytes.Clear();
                    if (state.InsertedCount < state.CollectDataCount)
                    {
                        state.WorkSocket.BeginReceive(state.Buffer, 0, 8, 0, ReceiveRecordHeadCallback, state);
                    }
                    else
                    {
                        state.DbHelper.InsertValueToMongo(state.Machine, state.DataItems);
                        state.DataItems.Clear();
                        state.InsertedCount = 0;
                        state.Package.CID = FuncCode.PushDataReply;
                        Send(state);
                    }
                }
            }
            catch (SocketException e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
            catch (Exception e)
            {
                _asyncSocketServer.CloseAndDisposeConnection(state, e, ErrorLevel.Level1);
            }
        }

        /// <summary>
        /// 更新设备Code缓存
        /// </summary>
        /// <param name="state"></param>
        private void UpdateMachineCodeCache(StateObject state)
        {
            _machineCodeCaches.Clear();
            _machineCodeCaches = state.DbHelper.UpdateMachineCodeCache();
            state.WorkSocket.Close();
        }

        /// <summary>
        /// 停止采集设备
        /// </summary>
        /// <param name="state"></param>
        private void StopCollectData(StateObject state)
        {
            var value = new byte[1024];
            state.WorkSocket.Receive(value);
            var machineCode = Encoding.ASCII.GetString(value).Replace("\0", "");
            _logManager.Error($"停用设备:{machineCode}");
            var machine = _asyncSocketServer.AsyncSocketUserTokenList.FirstOrDefault(s => s.Machine.MachineCode == machineCode);
            if (machine != null)
            {
                //设置此时设备是离线状态
                var item = new StateArray() { Code = "4", CreationTime = DateTime.Now.ToString("yyyyMMddHHmmss") };
                machine.DbHelper.InsertStateData(
                    machine.Machine.TenantId,
                    machine.Machine.MachineCode,
                    item);
                machine.WorkSocket.Close();
                _asyncSocketServer.AsyncSocketUserTokenList.Remove(machine);
            }
            state.WorkSocket.Close();
        }

        #endregion

        #region Help Method

        /// <summary>
        /// 获取设备登录用户名和密码@-_-@
        /// </summary>
        /// <param name="state"></param>
        private void GetMacLoginInfo(StateObject state)
        {
            if (_machineCodeCaches.Contains(state.Machine.MachineCode))
            {
                var result = state.DbHelper.GetMacLoginInfo(state.Machine);
                if (!string.IsNullOrEmpty(result))
                {
                    try
                    {
                        state.UserName = Convert.ToByte(result.Split(',')[0]);
                        state.Password = result.Split(',')[1];
                        state.TenantId = Convert.ToInt32(result.Split(',')[2]);
                        state.Machine.Uid = state.UserName;
                        state.Machine.Password = state.Password;
                        state.Machine.TenantId = state.TenantId;
                    }
                    catch (Exception)
                    {
                        throw new Exception($@"该设备{state.Machine.MachineCode}的用户名密码不匹配.");
                    }
                }
                else
                {
                    throw new Exception($@"该设备{state.Machine.MachineCode}的用户名密码未配置");
                }
            }
            else
            {
                throw new Exception($@"该设备{state.Machine.MachineCode}的没有启用,请先启用");
            }
        }

        private static object GetValueByType(DataItem item)
        {
            object result;
            switch (item.Type & 0x0F)
            {
                case 0:
                    if (item.Id == 2)
                    {
                        var tempBytes = new List<byte>();
                        for (var i = 0; i < item.Value.Length; i++)
                        {
                            //如果字符串遇到0则表示结束
                            if (item.Value[i] == 0)
                            {
                                break;
                            }
                            tempBytes.Add(item.Value[i]);
                        }
                        result = Encoding.GetEncoding("GB2312").GetString(tempBytes.ToArray()).Trim('\0');
                    }
                    else
                    {
                        var tempBytes = new List<byte>();
                        for (var i = 0; i < item.Value.Length; i++)
                        {
                            //如果字符串遇到0则表示结束
                            if (item.Value[i] == 0)
                            {
                                break;
                            }
                            tempBytes.Add(item.Value[i]);
                        }
                        result = Encoding.ASCII.GetString(tempBytes.ToArray()).Trim('\0');
                    }
                    break;
                case 1:
                    if (item.Value.Length < 8)
                    {
                        throw new Exception("尝试转换为double数据失败，长的为" + item.Value.Length);
                    }
                    result = BitConverter.ToDouble(item.Value, 0);
                    break;
                case 2:
                    if (item.Value.Length < 4)
                    {
                        throw new Exception("尝试转换为int数据失败，长的为" + item.Value.Length);
                    }
                    result = SocketHelper.NetworkToHost(BitConverter.ToInt32(item.Value, 0));
                    break;
                case 3:
                    result = item.Value[0];
                    break;
                case 4:
                    result = BitConverter.ToBoolean(item.Value, 0);
                    break;
                case 5:
                    result = item.Value;
                    break;
                default:
                    result = BitConverter.ToString(item.Value);
                    break;
            }
            return result;
        }

        private static string PrintReceivebytes(byte[] bytes)
        {
            var result = string.Empty;
            for (var i = 0; i < bytes.Length; i++)
            {
                result += bytes[i] + ",";
            }
            return result;
        }

        public void End()
        {
            _listener.Close();
            _daemonThread.Close();
            _asyncSocketServer.Close();
        }
        #endregion
    }
}
