using System;
using System.Collections.Generic;
using System.Net.Sockets;
using MDCSingleDLL.DBHelper;
using MDCSingleDLL.Protocol;
using Net4Logger;

namespace MDCSingleDLL.Process
{
    using System.Linq;

    public class AsyncSocketServer
    {
        public double SocketTimeOutMs;
        public List<StateObject> AsyncSocketUserTokenList;
        public ILogManager LogManager;

        public AsyncSocketServer(ILogManager logManager)
        {
            LogManager = logManager;
            AsyncSocketUserTokenList = new List<StateObject>();
            SocketTimeOutMs = 30;
        }

        public void CloseAndDisposeConnection(StateObject state, Exception e, ErrorLevel level)
        {
            if (state?.WorkSocket == null) return;

            try
            {
                var exception = e as SocketException;
                if (exception != null)
                {
                    LogSocketDetailErrorMessage(exception);
                }
                else
                {
                    LogManager.Error(
                        $"{MessageType.Error}{state.ConnectedIpAddress}{e.Message},{e.InnerException?.Message}");
                }

                if (state.IsLogined)
                {
                    LogManager.Info($"{MessageType.Info}设置此时设备是离线状态");
                    var item = new StateArray() { Code = "4", CreationTime = DateTime.Now.ToString("yyyyMMddHHmmss") };
                    state.DbHelper.InsertStateData(state.Machine.TenantId, state.Machine.MachineCode, item);

                    LogManager.Info($"{MessageType.Info}初始化Mongo数据库MachineInfo集合,并更新当前报警的结束时间为离线时间");
                    state.DbHelper.ClearCurrentAlarms(state.Machine.TenantId, state.Machine.MachineCode);

                    state.DbHelper.WriteExceptionToDb(state.Machine.MachineCode ?? "", e.Message, level);

                    state.IsLogined = !state.IsLogined;

                    state.WorkSocket.Close();
                }

                LogManager.Info($"{MessageType.Info}关闭{state.ConnectedIpAddress}的连接,释放本次会话的缓存数据");
            }
            catch (Exception ex)
            {
                LogManager.Info($"{MessageType.Info}关闭连接发生错误{ex.Message}");
            }
            finally
            {
                AsyncSocketUserTokenList.Remove(state);
            }
        }

        public void RemoveDisconnectedSession(StateObject state)
        {
            if (state?.WorkSocket == null) return;

            var removedItem = AsyncSocketUserTokenList.Find(s => s.Machine.MachineCode == state.Machine.MachineCode);
            if (removedItem != null)
            {
                LogManager.Info($"{MessageType.Info}剔除上一个连接");
                AsyncSocketUserTokenList.Remove(removedItem);
                removedItem.WorkSocket.Close();
            }
            LogManager.Info($"{MessageType.Info}添加StateObject对象到队列中");
            AsyncSocketUserTokenList.Add(state);
        }

        private void LogSocketDetailErrorMessage(SocketException e)
        {
            LogManager.Info($"{MessageType.Error}\r\nMessage:{e.Message}\r\nErrorCode:{e.ErrorCode}\r\nInnerExceptionMessage:{e.InnerException?.Message}\r\nNativeErrorCode:{e.NativeErrorCode}\r\nSocketErrorCode:{e.SocketErrorCode.ToString()}");
        }

        internal void Close()
        {
            try
            {
                for (var i = 0; i < AsyncSocketUserTokenList.Count; i++)
                {
                    var state = AsyncSocketUserTokenList[i];
                    if (state?.WorkSocket == null) continue;
                    state.WorkSocket.Close();
                    AsyncSocketUserTokenList.Remove(state);
                }

            }
            catch (Exception ex)
            {
                LogManager.Info($"{MessageType.Error}" + ex);
            }
        }
    }
}