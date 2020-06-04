using System;
using System.Threading;
using MDCSingleDLL.Protocol;
using Net4Logger;

namespace MDCSingleDLL.Process
{
    public class DaemonThread : object
    {
        private readonly Thread _thread;
        private readonly AsyncSocketServer _asyncSocketServer;
        private readonly ILogManager _logManager;
        public DaemonThread(AsyncSocketServer asyncSocketServer)
        {
            _asyncSocketServer = asyncSocketServer;
            _logManager = asyncSocketServer.LogManager;
            _thread = new Thread(DaemonThreadStart);
            _thread.Start();
        }

        public void DaemonThreadStart()
        {
            while (_thread.IsAlive)
            {
                for (var i = 0; i < _asyncSocketServer.AsyncSocketUserTokenList.Count; i++)
                {
                    if (!_thread.IsAlive)
                    {
                        break;
                    }

                    try
                    {
                        var currentDateTime = DateTime.Now;
                        if ((currentDateTime - _asyncSocketServer.AsyncSocketUserTokenList[i].ActiveDateTime).TotalSeconds > _asyncSocketServer.SocketTimeOutMs) //超时Socket断开
                        {
                            lock (_asyncSocketServer.AsyncSocketUserTokenList[i])
                            {
                                _logManager.Error($"{MessageType.OverTime}{_asyncSocketServer.AsyncSocketUserTokenList[i].MachineCode} => 当前时间为{currentDateTime},最后通讯时间为{_asyncSocketServer.AsyncSocketUserTokenList[i].ActiveDateTime}");
                                _asyncSocketServer.CloseAndDisposeConnection(_asyncSocketServer.AsyncSocketUserTokenList[i], new Exception("连接超时"), ErrorLevel.Level1);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _logManager.Error($"{MessageType.Error}{e.Message}");
                    }
                }

                for (int i = 0; i < 6; i++) //每分钟检测一次
                {
                    _logManager.Info($"{MessageType.Info}当前连接数:{_asyncSocketServer.AsyncSocketUserTokenList.Count}");
                    if (!_thread.IsAlive)
                        break;
                    Thread.Sleep(10000);
                }
            }
        }

        public void Close()
        {
            _thread.Abort();
            _thread.Join();
        }
    }
}
