using System.Collections.Generic;
using MDCSingleDLL.Protocol;

namespace MDCSingleDLL.DBHelper
{
    public interface IDbHelper
    {
        /// <summary>
        /// 获取登录用户名和密码
        /// </summary>
        string GetMacLoginInfo(Machine machine);
        /// <summary>
        /// 将获取到的参数映射表插入的Mongo数据库中
        /// </summary>
        /// <param name="machine"></param>
        void InsertMappedFiled(Machine machine);
        /// <summary>
        /// 检测设备是否有重连
        /// </summary>
        /// <returns></returns>
        bool CheckIfDeviceReConnect(Machine machine, double socketTimeOutMs);

        /// DT：1 字节整数，数据类别,最高位表示是否可写入[0=只读，1=读写]，其它位数值表示数据类别[0=字符串,1=双精度浮
        /// 点数,2=整数(32 位),3=字节,4=布尔值,5=字节块]
        /// <summary>
        /// 将采集到数据根据设备类型和字段Id插入到Mongo数据库中
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="dataItems"></param>
        void InsertValueToMongo(Machine machine, List<DataItem> dataItems);
        /// <summary>
        /// 状态
        /// </summary>
        void InsertStateData(int tenantId, string machineCode, StateArray item);

        /// <summary>
        /// 把错误信息写到数据库中
        /// </summary>
        /// <param name="machineCode"></param>
        /// <param name="message"></param>
        /// <param name="errorLevel"></param>
        void WriteExceptionToDb(string machineCode, string message, ErrorLevel errorLevel);
        /// <summary>
        /// 更新设备Code缓存
        /// </summary>
        List<string> UpdateMachineCodeCache();
        /// <summary>
        /// 清空当前报警信息
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="machineCode"></param>
        void ClearCurrentAlarms(int tenantId, string machineCode);
        /// <summary>
        /// 初始化MachineInfo数据
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="machineCode"></param>
        void InitializeMachineInfo(int tenantId, string machineCode);
    }
}
