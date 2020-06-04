using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MDCDataService
{
    /// <summary>
    /// State object for receiving data from remote device.
    /// </summary>
    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
        public bool IsLogined = false;
        //存放零时字节数组
        public List<byte> resultBytes = new List<byte>();
        public int Yeild = 0;
        internal string MachineCode;
        internal int Index;
        public string MachineId = string.Empty;
        public string IP = string.Empty;
        public int Port = 11000;
    }

    /// <summary>
    /// 建立主动连接
    /// </summary>
    public class ActiveProcess : IProcess
    {
        private static string machineNoString = System.Configuration.ConfigurationManager.AppSettings["MachineCode"].ToString();
        private static int duration = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Duration"].ToString());
        // The port number for the remote device.114.55.172.95
        private string address = System.Configuration.ConfigurationManager.AppSettings["Address"].ToString();
        private static int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Port"].ToString());
        private static string userName = System.Configuration.ConfigurationManager.AppSettings["UserName"].ToString();
        private static string password = System.Configuration.ConfigurationManager.AppSettings["Password"].ToString();
        private static string lastStateCode = "";

        public void Run()
        {
            if (machineNoString == string.Empty)
            {
                Console.WriteLine("请提供设备");
                return;
            }
            else
            {
                var macs = machineNoString.Split(',');
                for (int i = 0; i < macs.Length; i++)
                {
                    StartClient(macs[i], address, port);
                }
            }
        }

        #region 开启连接
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        private static void StartClient(string machineCode, string address, int port)
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(address), port);
                // Create a TCP/IP socket.
                Socket handler = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                StateObject state = new StateObject();
                state.MachineId = machineCode;
                state.IP = address;
                state.Port = port;
                state.workSocket = handler;
                state.MachineCode = machineCode;
                // Connect to the remote endpoint.                
                handler.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ar"></param>
        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                StateObject state = (StateObject)ar.AsyncState;
                // Complete the connection.
                if (state.workSocket.Connected)
                {
                    state.workSocket.EndConnect(ar);
                    Console.WriteLine("Socket connected to {0}", state.workSocket.RemoteEndPoint.ToString());

                    state.workSocket.BeginReceive(state.buffer, 0, PackgeSize.EnsurePackageSize, 0,
                    new AsyncCallback(ParseConnectDataCallback), state);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region 解析确认包数据数据
        private static void ParseConnectDataCallback(IAsyncResult ar)
        {
            try
            {

                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                // Read data from the remote device.
                if (state.workSocket.Connected)
                {
                    int bytesRead = state.workSocket.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        // There might be more data, so store the data received so far.
                        state.resultBytes = state.resultBytes.Concat(state.buffer.Take(bytesRead).ToArray()).ToList();

                        if (state.resultBytes.Count < PackgeSize.EnsurePackageSize)
                        {
                            // Get the rest of the data.
                            state.workSocket.BeginReceive(state.buffer, 0, PackgeSize.EnsurePackageSize, 0,
                                new AsyncCallback(ParseConnectDataCallback), state);
                        }
                        else
                        {
                            // All the data has arrived; put it in response.
                            EnsurePackage package = SocketHelper.BytesToStruct<EnsurePackage>(state.resultBytes.ToArray());
                            package.PID = SocketHelper.NetworkToHost(package.PID);
                            package.CID = SocketHelper.NetworkToHost(package.CID);
                            package.VER = SocketHelper.NetworkToHost(package.VER);
                            package.Port = SocketHelper.NetworkToHost(package.Port);
                            state.resultBytes.Clear();
                            //需要重定向
                            if (package.CID == FuncCode.Redirect)
                            {
                                //关闭此次会话连接
                                state.workSocket.Shutdown(SocketShutdown.Both);
                                state.workSocket.Close();
                                StartClient(state.MachineCode, package.IPAddress, (int)package.Port);
                            }
                            //关闭连接
                            else if (package.CID == FuncCode.Close)
                            {
                                //关闭此次会话连接
                                state.workSocket.Shutdown(SocketShutdown.Both);
                                state.workSocket.Close();
                            }
                            else
                            {
                                // Convert the string data to byte data using ASCII encoding.
                                MacBootstrapPackage package2 = new MacBootstrapPackage();
                                package2.PID = SocketHelper.HostToNetwork((ushort)0x0000);
                                package2.CID = SocketHelper.HostToNetwork(FuncCode.Bootstrap);
                                package2.ST = 0;
                                package2.UID = 0;
                                package2.VER = SocketHelper.HostToNetwork((ushort)0x1000);
                                package2.DID = StringToByteArray(state.MachineCode, 32);
                                byte[] byteData = SocketHelper.StructToBytes(package2);
                                state.workSocket.BeginSend(byteData, 0, byteData.Length, 0,
                                    new AsyncCallback(SendMacInfoCallback), state);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region 设备自举
        private static void SendMacInfoCallback(IAsyncResult ar)
        {
            try
            {// Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                // Read data from the remote device.
                if (state.workSocket.Connected)
                {
                    state.workSocket.EndSend(ar);
                    state.workSocket.BeginReceive(state.buffer, 0, PackgeSize.LoginPackageSize, 0,
                    new AsyncCallback(ParseLoginDataCallback), state);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region 解析客户端的登录包 
        private static void ParseLoginDataCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                // Read data from the remote device.
                if (state.workSocket.Connected)
                {
                    int bytesRead = state.workSocket.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        // There might be more data, so store the data received so far.
                        state.resultBytes = state.resultBytes.Concat(state.buffer.Take(bytesRead)).ToList();

                        if (state.resultBytes.Count < PackgeSize.LoginPackageSize)
                        {
                            // Get the rest of the data.
                            state.workSocket.BeginReceive(state.buffer, 0, PackgeSize.LoginPackageSize, 0,
                                new AsyncCallback(ParseLoginDataCallback), state);
                        }
                        else
                        {
                            // All the data has arrived; put it in response.
                            LoginPackage package = SocketHelper.BytesToStruct<LoginPackage>(state.resultBytes.ToArray());
                            package.PID = SocketHelper.NetworkToHost(package.PID);
                            package.CID = SocketHelper.NetworkToHost(package.CID);
                            package.VER = SocketHelper.NetworkToHost(package.VER);
                            state.resultBytes.Clear();
                            //密码是否正确
                            if (package.Password.Trim() == password)
                            {
                                state.IsLogined = true;
                                // Convert the string data to byte data using ASCII encoding.
                                LoginResultPackage package2 = new LoginResultPackage();
                                package2.PID = SocketHelper.HostToNetwork((ushort)0x0000);
                                package2.CID = SocketHelper.HostToNetwork(FuncCode.Login);
                                package2.ST = 0;
                                package2.UID = 0;
                                package2.VER = SocketHelper.HostToNetwork((ushort)0x1000);
                                package2.ERR = SocketHelper.HostToNetwork(ErrorCode.Succeed);
                                package2.RV = SocketHelper.HostToNetwork(ErrorCode.Succeed);
                                byte[] byteData = SocketHelper.StructToBytes(package2);
                                state.workSocket.BeginSend(byteData, 0, byteData.Length, 0,
                                    new AsyncCallback(SendLoginResultCallback), state);
                            }
                            //关闭连接
                            else
                            {

                                LoginResultPackage package2 = new LoginResultPackage();
                                package2.PID = SocketHelper.HostToNetwork((ushort)0x0000);
                                package2.CID = SocketHelper.HostToNetwork(FuncCode.Login);
                                package2.ST = 1;
                                package2.UID = 0;
                                package2.VER = SocketHelper.HostToNetwork((ushort)0x1000);
                                package2.ERR = SocketHelper.HostToNetwork(ErrorCode.Succeed);
                                package2.RV = SocketHelper.HostToNetwork(ErrorCode.Succeed);
                                byte[] byteData = SocketHelper.StructToBytes(package2);
                                state.workSocket.BeginSend(byteData, 0, byteData.Length, 0,
                                    new AsyncCallback(SendLoginResultCallback), state);

                                state.IsLogined = false;
                                //关闭此次会话连接
                                state.workSocket.Shutdown(SocketShutdown.Both);
                                state.workSocket.Close();
                            }
                        }
                    }
                    else
                    {
                        state.workSocket.Shutdown(SocketShutdown.Both);
                        state.workSocket.Close();
                        Thread.Sleep(100);
                        StartClient(state.MachineId, state.IP, state.Port);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region 发送验证结果
        private static void SendLoginResultCallback(IAsyncResult ar)
        {
            try
            {// Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                // Read data from the remote device.
                if (state.workSocket.Connected)
                {
                    if (!state.IsLogined)
                    {
                        //登录失败，关闭连接
                        state.workSocket.Shutdown(SocketShutdown.Both);
                        state.workSocket.Close();
                    }
                    else
                    {
                        state.workSocket.BeginReceive(state.buffer, 0, PackgeSize.LoginPackageSize / 2, 0, new AsyncCallback(ParseEnumCallback), state);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region 解析枚举命令
        private static void ParseEnumCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                // Read data from the remote device.
                if (state.workSocket.Connected)
                {
                    int bytesRead = state.workSocket.EndReceive(ar);

                    if (bytesRead > 0)
                    {

                        // There might be more data, so store the data received so far.
                        state.resultBytes = state.resultBytes.Concat(state.buffer.Take(bytesRead).ToArray()).ToList();

                        if (state.resultBytes.Count < PackgeSize.LoginPackageSize / 2)
                        {
                            // Get the rest of the data.
                            state.workSocket.BeginReceive(state.buffer, 0, PackgeSize.LoginPackageSize / 2, 0,
                                new AsyncCallback(ParseConnectDataCallback), state);
                        }
                        else
                        {

                            // All the data has arrived; put it in response.
                            BasicPackage package = SocketHelper.BytesToStruct<BasicPackage>(state.resultBytes.ToArray());
                            package.PID = SocketHelper.NetworkToHost(package.PID);
                            package.CID = SocketHelper.NetworkToHost(package.CID);
                            package.VER = SocketHelper.NetworkToHost(package.VER);
                            state.resultBytes.Clear();
                            // Convert the string data to byte data using ASCII encoding.
                            EnumPackage package2 = new EnumPackage();
                            package2.PID = SocketHelper.HostToNetwork((ushort)0x0000);
                            package2.CID = SocketHelper.HostToNetwork(FuncCode.EnumAllData);
                            package2.ST = 0;
                            package2.UID = 0;
                            package2.VER = SocketHelper.HostToNetwork((ushort)0x1000);
                            package2.Count = SocketHelper.HostToNetwork((ushort)16);
                            package2.RV = new byte[6] { 1, 2, 3, 4, 5, 6 };
                            byte[] commandBytes = SocketHelper.StructToBytes(package2);
                            var byteData = commandBytes.Concat(PrepareDemoEnumData()).ToArray();
                            state.workSocket.BeginSend(byteData, 0, byteData.Length, 0,
                                new AsyncCallback(SendEnumCallback), state);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region 发送枚举数据
        private static void SendEnumCallback(IAsyncResult ar)
        {
            try
            {// Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                // Read data from the remote device.
                if (state.workSocket.Connected)
                {
                    state.workSocket.EndSend(ar);
                    state.workSocket.BeginReceive(state.buffer, 0, PackgeSize.RequestPushPackageSize, 0,
                    new AsyncCallback(ReceivePushRequestCallback), state);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region 接受推送命令请求
        private static void ReceivePushRequestCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                // Read data from the remote device.
                if (state.workSocket.Connected)
                {
                    int bytesRead = state.workSocket.EndReceive(ar);

                    if (bytesRead > 0)
                    {

                        // There might be more data, so store the data received so far.
                        state.resultBytes = state.resultBytes.Concat(state.buffer.Take(bytesRead).ToArray()).ToList();

                        if (state.resultBytes.Count < PackgeSize.RequestPushPackageSize)
                        {
                            // Get the rest of the data.
                            state.workSocket.BeginReceive(state.buffer, 0, PackgeSize.RequestPushPackageSize, 0,
                                new AsyncCallback(ReceivePushRequestCallback), state);
                        }
                        else
                        {
                            state.resultBytes.Clear();
                            ErrorPackage2 package2 = new ErrorPackage2();
                            package2.PID = SocketHelper.HostToNetwork((ushort)0x0000);
                            package2.CID = SocketHelper.HostToNetwork(FuncCode.RequestForPush);
                            package2.ST = 0x00;
                            package2.UID = 0;
                            package2.VER = SocketHelper.HostToNetwork((ushort)0x1000);
                            package2.ERR = SocketHelper.HostToNetwork(ErrorCode.Succeed);
                            package2.RV = SocketHelper.HostToNetwork(ErrorCode.Succeed);
                            byte[] byteData = SocketHelper.StructToBytes(package2);
                            state.workSocket.BeginSend(byteData, 0, byteData.Length, 0,
                                new AsyncCallback(SendPushRequestFeedBackCallback), state);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region 发送推送返回结果
        private static void SendPushRequestFeedBackCallback(IAsyncResult ar)
        {
            try
            {// Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                // Read data from the remote device.
                if (state.workSocket.Connected)
                {
                    state.workSocket.EndSend(ar);
                    SendData(state);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region 发送正式数据 SendRequestPushCallback
        private static void SendData(StateObject state)
        {
            try
            {
                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                //Socket handler = (Socket)ar.AsyncState;
                // Read data from the remote device.
                if (state.workSocket.Connected)
                {
                    int iSeed = 10;
                    Random ro = new Random(iSeed);
                    long tick = DateTime.Now.Ticks;
                    Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
                    Thread.Sleep(duration * 1000);
                    PushHeadPackage package = new PushHeadPackage();
                    package.PID = SocketHelper.HostToNetwork((ushort)0x0000);
                    package.CID = SocketHelper.HostToNetwork(FuncCode.PushData);
                    package.ST = 1;
                    package.UID = 0;
                    package.VER = SocketHelper.HostToNetwork((ushort)0x1000);
                    var dataCount = 0;
                    var bodyBytes = PrepareDemoPushData(ref dataCount, state);
                    package.Count = SocketHelper.HostToNetwork((ushort)dataCount);
                    package.RV = new byte[6] { 0, 0, 0, 0, 0, 0 };
                    byte[] headBytes = SocketHelper.StructToBytes(package);
                    var byteData = headBytes.Concat(bodyBytes.ToArray()).ToArray();
                    state.workSocket.BeginSend(byteData, 0, byteData.Length, 0,
                        new AsyncCallback(SendDataCallback), state);
                    Console.WriteLine("设备" + state.MachineCode + "发送第" + (++state.Index) + "次数据,发送个数为" + dataCount + ",数据长度为" + byteData.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private static void SendDataCallback(IAsyncResult ar)
        {
            try
            {// Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                // Read data from the remote device.
                if (state.workSocket.Connected)
                {
                    state.workSocket.EndSend(ar);
                    SendData(state);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region Help Method
        static byte[] StringToByteArray(string str, int length)
        {
            return Encoding.ASCII.GetBytes(str.PadRight(length, '\0'));
        }

        static byte[] PrepareDemoEnumData()
        {
            EnumDataRecordPackage command1 = new EnumDataRecordPackage();
            command1.DID = SocketHelper.HostToNetwork((ushort)1);
            command1.DT = 0x00;
            command1.NAME = "AlarmCode".PadRight(16, ' ');
            command1.ADDR = "".PadRight(64, '\0');
            command1.RATE = 0.5f;
            command1.UPL = 100;
            command1.LOL = 50;

            EnumDataRecordPackage command2 = new EnumDataRecordPackage();
            command2.DID = SocketHelper.HostToNetwork((ushort)2);
            command2.DT = 0x00;
            command2.NAME = "AlarmMsg".PadRight(16, ' ');
            command2.ADDR = "".PadRight(64, '\0');
            command2.RATE = 0.5f;
            command2.UPL = 100;
            command2.LOL = 50;

            EnumDataRecordPackage command3 = new EnumDataRecordPackage();
            command3.DID = SocketHelper.HostToNetwork((ushort)3);
            command3.DT = 0x00;
            command3.NAME = "StatusCode".PadRight(16, ' ');
            command3.ADDR = "".PadRight(64, '\0');
            command3.RATE = 0.5f;
            command3.UPL = 100;
            command3.LOL = 50;

            EnumDataRecordPackage command4 = new EnumDataRecordPackage();
            command4.DID = SocketHelper.HostToNetwork((ushort)4);
            command4.DT = 0x00;
            command4.NAME = "WorkCount".PadRight(16, ' ');
            command4.ADDR = "".PadRight(64, '\0');
            command4.RATE = 0.5f;
            command4.UPL = 100;
            command4.LOL = 50;

            EnumDataRecordPackage command5 = new EnumDataRecordPackage();
            command5.DID = SocketHelper.HostToNetwork((ushort)5);
            command5.DT = 0x00;
            command5.NAME = "ProgramName".PadRight(16, ' ');
            command5.ADDR = "".PadRight(64, '\0');
            command5.RATE = 0.5f;
            command5.UPL = 100;
            command5.LOL = 50;
            
            EnumDataRecordPackage command16 = new EnumDataRecordPackage();
            command16.DID = SocketHelper.HostToNetwork((ushort)6);
            command16.DT = 0x00;
            command16.NAME = "CreationTime".PadRight(16, ' ');
            command16.ADDR = "".PadRight(64, '\0');
            command16.RATE = 0.5f;
            command16.UPL = 100;
            command16.LOL = 50;

            EnumDataRecordPackage command6 = new EnumDataRecordPackage();
            command6.DID = SocketHelper.HostToNetwork((ushort)21);
            command6.DT = 0x00;
            command6.NAME = "spn_rate".PadRight(16, ' ');
            command6.ADDR = "".PadRight(64, '\0');
            command6.RATE = 0.5f;
            command6.UPL = 100;
            command6.LOL = 50;

            EnumDataRecordPackage command7 = new EnumDataRecordPackage();
            command7.DID = SocketHelper.HostToNetwork((ushort)22);
            command7.DT = 0x00;
            command7.NAME = "feed_rate".PadRight(16, ' ');
            command7.ADDR = "".PadRight(64, '\0');
            command7.RATE = 0.5f;
            command7.UPL = 100;
            command7.LOL = 50;

            EnumDataRecordPackage command8 = new EnumDataRecordPackage();
            command8.DID = SocketHelper.HostToNetwork((ushort)23);
            command8.DT = 0x00;
            command8.NAME = "s_feed_rate".PadRight(16, ' ');
            command8.ADDR = "".PadRight(64, '\0');
            command8.RATE = 0.5f;
            command8.UPL = 100;
            command8.LOL = 50;

            EnumDataRecordPackage command9 = new EnumDataRecordPackage();
            command9.DID = SocketHelper.HostToNetwork((ushort)24);
            command9.DT = 0x00;
            command9.NAME = "spn_speed".PadRight(16, ' ');
            command9.ADDR = "".PadRight(64, '\0');
            command9.RATE = 0.5f;
            command9.UPL = 100;
            command9.LOL = 50;

            EnumDataRecordPackage command10 = new EnumDataRecordPackage();
            command10.DID = SocketHelper.HostToNetwork((ushort)25);
            command10.DT = 0x00;
            command10.NAME = "feed_speed".PadRight(16, ' ');
            command10.ADDR = "".PadRight(64, '\0');
            command10.RATE = 0.5f;
            command10.UPL = 100;
            command10.LOL = 50;

            EnumDataRecordPackage command11 = new EnumDataRecordPackage();
            command11.DID = SocketHelper.HostToNetwork((ushort)26);
            command11.DT = 0x00;
            command11.NAME = "spnload".PadRight(16, ' ');
            command11.ADDR = "".PadRight(64, '\0');
            command11.RATE = 0.5f;
            command11.UPL = 100;
            command11.LOL = 50;

            EnumDataRecordPackage command12 = new EnumDataRecordPackage();
            command12.DID = SocketHelper.HostToNetwork((ushort)27);
            command12.DT = 0x00;
            command12.NAME = "temperature".PadRight(16, ' ');
            command12.ADDR = "".PadRight(64, '\0');
            command12.RATE = 0.5f;
            command12.UPL = 100;
            command12.LOL = 50;

            EnumDataRecordPackage command13 = new EnumDataRecordPackage();
            command13.DID = SocketHelper.HostToNetwork((ushort)28);
            command13.DT = 0x00;
            command13.NAME = "pressure".PadRight(16, ' ');
            command13.ADDR = "".PadRight(64, '\0');
            command13.RATE = 0.5f;
            command13.UPL = 100;
            command13.LOL = 50;

            EnumDataRecordPackage command14 = new EnumDataRecordPackage();
            command14.DID = SocketHelper.HostToNetwork((ushort)29);
            command14.DT = 0x00;
            command14.NAME = "onoffmechanism".PadRight(16, ' ');
            command14.ADDR = "".PadRight(64, '\0');
            command14.RATE = 0.5f;
            command14.UPL = 100;
            command14.LOL = 50;

            EnumDataRecordPackage command15 = new EnumDataRecordPackage();
            command15.DID = SocketHelper.HostToNetwork((ushort)30);
            command15.DT = 0x00;
            command15.NAME = "errorcode".PadRight(16, ' ');
            command15.ADDR = "".PadRight(64, '\0');
            command15.RATE = 0.5f;
            command15.UPL = 100;
            command15.LOL = 50;

            byte[] byteData = SocketHelper.StructToBytes(command1);
            byteData = byteData.Concat(SocketHelper.StructToBytes(command2)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command3)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command4)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command5)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command16)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command6)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command7)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command8)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command9)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command10)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command11)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command12)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command13)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command14)).ToArray();
            byteData = byteData.Concat(SocketHelper.StructToBytes(command15)).ToArray();
            return byteData;
        }

        static string[] AlaramCodes = new string[] { "0", "531", "411", "404", "72", "70" };
        static string[] AlarmMessages = new string[]
        {
            "Z轴负向软极限超程",
            "X轴运动时,位置误差超出设定值",
            "VRDY信号没有被关断,但位置控制器准备好信号(PRDY)被关断.正常情况下,VRDY和PRDY信号应同时存在",
            "程序存储器中程序的数量满",
            "程序存储器满"
        };
        static byte[] PrepareDemoPushData(ref int dataCount, StateObject state)
        {
            List<byte> result = new List<byte>();

            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            //报警编号
            //var random1 = new Random();
            if (ran.Next(1, 3) == 1)
            {
                dataCount++;
                string value1 = AlaramCodes[0];
                PushBodyPackage command1 = new PushBodyPackage();
                command1.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value1).Length);
                command1.DID = SocketHelper.HostToNetwork((ushort)1);
                command1.DT = 0x00;
                command1.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command1).Concat(Encoding.ASCII.GetBytes(value1).ToArray()).ToArray());
            }
            else
            {
                if (ran.Next(1, 3) == 1)
                {
                    dataCount++;
                    var index = ran.Next(0, 5);
                    string value1 = AlaramCodes[index];
                    PushBodyPackage command1 = new PushBodyPackage();
                    command1.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value1).Length);
                    command1.DID = SocketHelper.HostToNetwork((ushort)1);
                    command1.DT = 0x00;
                    command1.DRV = new byte[3] { 0, 0, 0 };
                    result.AddRange(SocketHelper.StructToBytes(command1).Concat(Encoding.ASCII.GetBytes(value1).ToArray()).ToArray());

                    dataCount++;
                    string value2 = AlarmMessages[index];
                    PushBodyPackage command2 = new PushBodyPackage();
                    command2.DID = SocketHelper.HostToNetwork((ushort)2);
                    command2.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.GetEncoding("GB2312").GetBytes(value2).Length);
                    command2.DT = 0x00;
                    command2.DRV = new byte[3] { 0, 0, 0 };
                    result.AddRange(SocketHelper.StructToBytes(command2).Concat(Encoding.GetEncoding("GB2312").GetBytes(value2).ToArray()).ToArray());
                }
            }

            //报警内容
            //var random2 = new Random();
            //if (ran.Next(1, 3) == 1)
            //{
            //    dataCount++;
            //    string value2 = "";
            //    value2 = "风扇报警";
            //    PushBodyPackage command2 = new PushBodyPackage();
            //    command2.DID = SocketHelper.HostToNetwork((ushort)2);
            //    command2.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.GetEncoding("GB2312").GetBytes(value2).Length);
            //    command2.DT = 0x00;
            //    command2.DRV = new byte[3] { 0, 0, 0 };
            //    result.AddRange(SocketHelper.StructToBytes(command2).Concat(Encoding.GetEncoding("GB2312").GetBytes(value2).ToArray()).ToArray());
            //}
            bool CalculateWorkCount = false;
            //状态编号
            //var random3 = new Random();
            if (ran.Next(1, 6) == 1)
            {
                string value3 = ran.Next(1, 4).ToString();
                if (value3 != "4")
                {
                    if (value3 != lastStateCode)
                    {
                        dataCount++;
                        lastStateCode = value3;
                        PushBodyPackage command3 = new PushBodyPackage();
                        command3.DT = 0x00;
                        command3.DID = SocketHelper.HostToNetwork((ushort)3);
                        command3.DRV = new byte[3] { 0, 0, 0 };
                        command3.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value3).Length);
                        result.AddRange(SocketHelper.StructToBytes(command3).Concat(Encoding.ASCII.GetBytes(value3).ToArray()).ToArray());
                    }

                    if (value3 == "2")
                    {
                        CalculateWorkCount = true;
                    }
                }
            }
            //计数器
            //var random4 = new Random();
            if (ran.Next(1, 1) == 1 && CalculateWorkCount)
            {
                dataCount++;
                string value4 = (++state.Yeild).ToString();
                PushBodyPackage command4 = new PushBodyPackage();
                command4.DID = SocketHelper.HostToNetwork((ushort)4);
                command4.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value4).Length);
                command4.DT = 0x00;
                command4.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command4).Concat(Encoding.ASCII.GetBytes(value4).ToArray()).ToArray());
            }
            //程序号
            if (ran.Next(1, 4) == 1)
            {
                var nameArray = new string[] { "5666", "8863", "2210" };
                dataCount++;
                string value5 = "O" + nameArray[ran.Next(0, 2)];
                PushBodyPackage command5 = new PushBodyPackage();
                command5.DID = SocketHelper.HostToNetwork((ushort)5);
                command5.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value5).Length);
                command5.DT = 0x00;
                command5.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command5).Concat(Encoding.ASCII.GetBytes(value5).ToArray()).ToArray());

            }

            //操作时间
            dataCount++;
            string value6 = "";
            value6 = DateTime.Now.Date.ToString("yyyyMMddHHmmss");
            PushBodyPackage command6 = new PushBodyPackage();
            command6.DID = SocketHelper.HostToNetwork((ushort)6);
            command6.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.GetEncoding("GB2312").GetBytes(value6).Length);
            command6.DT = 0x00;
            command6.DRV = new byte[3] { 0, 0, 0 };
            result.AddRange(SocketHelper.StructToBytes(command6).Concat(Encoding.GetEncoding("GB2312").GetBytes(value6).ToArray()).ToArray());

            //参数21 主轴倍率：0-120；单位5
            //var random21 = new Random();
            if (ran.Next(1, 4) == 1)
            {
                dataCount++;
                string value21 = (ran.Next(0, 24) * 5).ToString();
                PushBodyPackage command21 = new PushBodyPackage();
                command21.DID = SocketHelper.HostToNetwork((ushort)21);
                command21.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value21).Length);
                command21.DT = 0x00;
                command21.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command21).Concat(Encoding.ASCII.GetBytes(value21).ToArray()).ToArray());
            }
            //参数22 进给倍率：0-150；单位10
            //var random22 = new Random();
            if (ran.Next(1, 4) == 1)
            {
                dataCount++;
                string value22 = (ran.Next(0, 15) * 10).ToString();
                PushBodyPackage command22 = new PushBodyPackage();
                command22.DID = SocketHelper.HostToNetwork((ushort)22);
                command22.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value22).Length);
                command22.DT = 0x00;
                command22.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command22).Concat(Encoding.ASCII.GetBytes(value22).ToArray()).ToArray());
            }
            //参数23 快速进给倍率：0-100%；单位25%
            //var random23 = new Random();
            if (ran.Next(1, 4) == 1)
            {
                dataCount++;
                string value23 = (ran.Next(0, 4) * 25).ToString();
                PushBodyPackage command23 = new PushBodyPackage();
                command23.DID = SocketHelper.HostToNetwork((ushort)23);
                command23.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value23).Length);
                command23.DT = 0x00;
                command23.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command23).Concat(Encoding.ASCII.GetBytes(value23).ToArray()).ToArray());
            }
            //参数24 主轴转速：500-5000；单位100 
            //var random24 = new Random();
            if (ran.Next(1, 4) == 1)
            {
                dataCount++;
                string value24 = (ran.Next(5, 50) * 100).ToString();
                PushBodyPackage command24 = new PushBodyPackage();
                command24.DID = SocketHelper.HostToNetwork((ushort)24);
                command24.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value24).Length);
                command24.DT = 0x00;
                command24.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command24).Concat(Encoding.ASCII.GetBytes(value24).ToArray()).ToArray());
            }
            //参数25 进给速度：0 - 1000；单位5
            if (ran.Next(1, 4) == 1)
            {
                dataCount++;
                string value25 = (ran.Next(0, 200) * 5).ToString();
                PushBodyPackage command25 = new PushBodyPackage();
                command25.DID = SocketHelper.HostToNetwork((ushort)25);
                command25.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value25).Length);
                command25.DT = 0x00;
                command25.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command25).Concat(Encoding.ASCII.GetBytes(value25).ToArray()).ToArray());
            }

            //参数26 主轴负载：1%-5%；单位1%
            if (ran.Next(1, 5) == 1)
            {
                dataCount++;
                string value26 = ran.Next(1, 5).ToString();
                PushBodyPackage command26 = new PushBodyPackage();
                command26.DID = SocketHelper.HostToNetwork((ushort)26);
                command26.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value26).Length);
                command26.DT = 0x00;
                command26.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command26).Concat(Encoding.ASCII.GetBytes(value26).ToArray()).ToArray());
            }

            //参数27 温度
            if (ran.Next(1, 5) == 1)
            {
                dataCount++;
                string value27 = ran.Next(50, 70).ToString();
                PushBodyPackage command27 = new PushBodyPackage();
                command27.DID = SocketHelper.HostToNetwork((ushort)27);
                command27.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value27).Length);
                command27.DT = 0x00;
                command27.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command27).Concat(Encoding.ASCII.GetBytes(value27).ToArray()).ToArray());
            }

            //参数28 压力
            if (ran.Next(1, 5) == 1)
            {
                dataCount++;
                string value28 = ran.Next(100, 200).ToString();
                PushBodyPackage command28 = new PushBodyPackage();
                command28.DID = SocketHelper.HostToNetwork((ushort)28);
                command28.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value28).Length);
                command28.DT = 0x00;
                command28.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command28).Concat(Encoding.ASCII.GetBytes(value28).ToArray()).ToArray());
            }

            //参数27 开关机
            if (ran.Next(1, 5) == 1)
            {
                dataCount++;
                string value29 = ran.Next(0, 1).ToString();
                PushBodyPackage command29 = new PushBodyPackage();
                command29.DID = SocketHelper.HostToNetwork((ushort)27);
                command29.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value29).Length);
                command29.DT = 0x00;
                command29.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command29).Concat(Encoding.ASCII.GetBytes(value29).ToArray()).ToArray());
            }

            //参数28 错误代码
            if (ran.Next(1, 5) == 1)
            {
                dataCount++;
                string value30 = ran.Next(0, 9).ToString();
                PushBodyPackage command30 = new PushBodyPackage();
                command30.DID = SocketHelper.HostToNetwork((ushort)30);
                command30.DLEN = SocketHelper.HostToNetwork((ushort)Encoding.ASCII.GetBytes(value30).Length);
                command30.DT = 0x00;
                command30.DRV = new byte[3] { 0, 0, 0 };
                result.AddRange(SocketHelper.StructToBytes(command30).Concat(Encoding.ASCII.GetBytes(value30).ToArray()).ToArray());
            }

            return result.ToArray();
        }
        #endregion
    }
}
