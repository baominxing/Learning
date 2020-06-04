using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDCSingleDLL.Protocol;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MDCSingleDLL.DBHelper
{
    public class MongoHelper : IDbHelper
    {
        private static readonly string ConnectionString =
            System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        private static readonly string DatabaseName =
            System.Configuration.ConfigurationManager.AppSettings["DatabaseName"];

        private static readonly string MacConfigCollection =
            System.Configuration.ConfigurationManager.AppSettings["MacConfigCollection"];

        private static readonly string[] DefinitionCodes = { "1", "2", "3", "4" };

        private string _machineId;

        /// <summary>
        /// 获取登录用户名和密码
        /// </summary>
        public string GetMacLoginInfo(Machine machine)
        {
            var returnResult = "";
            var collection = GetCollection(MacConfigCollection);
            var filter =
                Builders<BsonDocument>.Filter.Eq("MachineCode", machine.MachineCode)
                &
                Builders<BsonDocument>.Filter.Eq("IsActive", true);
            var result = collection.Find(filter).ToList();
            if (result.Count <= 0) return returnResult;
            returnResult = result[0]["UId"] + "," + result[0]["Password"] + "," + result[0]["TenantId"];
            _machineId = result[0]["MachineId"].ToString();
            return returnResult;
        }

        /// <summary>
        /// 将获取到的参数映射表插入的Mongo数据库中
        /// </summary>
        /// <param name="machine"></param>
        public void InsertMappedFiled(Machine machine)
        {
            var mapArray = new BsonArray();
            var document = new BsonDocument();

            foreach (var item in machine.Map.MapArray)
            {
                mapArray.Add(new BsonDocument() { { "Id", item.Id.Trim() }, { "Value", item.Value.Trim() } });
                if (Convert.ToInt32(item.Id.Trim()) > 20)
                {
                    document.Add(new BsonElement(item.Value.Trim(), ""));
                }
            }

            var collection = GetCollection(MacConfigCollection);

            var filter =
                    Builders<BsonDocument>.Filter.Eq("TenantId", machine.TenantId)
                    &
                    Builders<BsonDocument>.Filter.Eq("MachineCode", machine.MachineCode);

            var result = collection.Find(filter).FirstOrDefault();

            if (result == null)
            {
                throw new Exception("没有该设备的登录信息");
            }

            FieldDefinition<BsonDocument, BsonArray> targetField = "Map";
            var update = Builders<BsonDocument>.Update.Set(targetField, mapArray);
            collection.FindOneAndUpdate(filter, update);

            FieldDefinition<BsonDocument, BsonDocument> targetField2 = "Parameter";
            var update2 = Builders<BsonDocument>.Update.Set(targetField2, document);
            collection.FindOneAndUpdate(filter, update2);

            if (!result.Contains("Alarm"))
            {
                FieldDefinition<BsonDocument, BsonArray> targetField3 = "Alarm";
                var update3 = Builders<BsonDocument>.Update.Set(targetField3, new BsonArray());
                collection.FindOneAndUpdate(filter, update3);
            }

            if (!result.Contains("Capacity"))
            {
                FieldDefinition<BsonDocument, BsonDocument> targetField4 = "Capacity";
                var update4 = Builders<BsonDocument>.Update.Set(targetField4, new BsonDocument());
                collection.FindOneAndUpdate(filter, update4);
            }

            if (result.Contains("State")) return;

            FieldDefinition<BsonDocument, BsonDocument> targetField5 = "State";
            var update5 = Builders<BsonDocument>.Update.Set(targetField5, new BsonDocument());
            collection.FindOneAndUpdate(filter, update5);
        }

        /// <summary>
        /// 检测设备是否有重连
        /// </summary>
        /// <returns></returns>
        public bool CheckIfDeviceReConnect(Machine machine, double socketTimeOutMs)
        {
            var flag = false;
            var collection = GetCollection(MacConfigCollection);
            var filter =
                Builders<BsonDocument>.Filter.Eq("MachineCode", machine.MachineCode)
                &
                Builders<BsonDocument>.Filter.Eq("TenantId", machine.TenantId)
                &
                Builders<BsonDocument>.Filter.Gt("State.CreationTime", DateTime.Now.AddSeconds(-socketTimeOutMs).ToString("yyyyMMddHHmmss"));
            if (collection.Find(filter).Count() > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// DT：1 字节整数，数据类别,最高位表示是否可写入[0=只读，1=读写]，其它位数值表示数据类别[0=字符串,1=双精度浮
        /// 点数,2=整数(32 位),3=字节,4=布尔值,5=字节块]
        /// <summary>
        /// 将采集到数据根据设备类型和字段Id插入到Mongo数据库中
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="dataItems"></param>
        public void InsertValueToMongo(Machine machine, List<DataItem> dataItems)
        {
            var creationTime = this.GetCreationTime(dataItems);

            //判读是否有采集到离线状态,如果有则过滤其他数据项,只需保存状态记录
            if (!CheckIfNeedSaveDataItem(machine, dataItems, creationTime)) return;

            var alarmIds = new[] { (ushort)ConfigField.AlarmCode, (ushort)ConfigField.AlarmMsg };

            //是否同时存在报警编号和报警内容
            if (dataItems.Count(i => alarmIds.Contains(i.Id)) > 1)
            {
                //取出报警编号和报警内容
                var alarmCode = GetValueByType(dataItems.FirstOrDefault(i => i.Id == ((ushort)ConfigField.AlarmCode))).ToString();
                var alarmMessage = GetValueByType(dataItems.FirstOrDefault(i => i.Id == ((ushort)ConfigField.AlarmMsg))).ToString();
                //插入到数据库
                InsertAlarmData(machine.TenantId, machine.MachineCode, new AlarmArray { Code = alarmCode, Message = alarmMessage, CreationTime = creationTime });
                //剔除已取得的数据
                dataItems = dataItems.Where(i => alarmIds.Contains(i.Id) == false).ToList();
            }
            //获得最新程序号
            var procNo = GetNewestProcNo(machine, dataItems);
            var parameters = new List<BsonElement>();
            foreach (var t in dataItems)
            {
                if (t == null) continue;
                switch (t.Id)
                {
                    case 1:
                        //单报警号,需要取得上次的报警内容
                        var alarmCode = GetValueByType(dataItems.FirstOrDefault(item => item.Id == ((ushort)ConfigField.AlarmCode))).ToString();// Encoding.Default.GetString(.Value);
                        var filter =
                            Builders<BsonDocument>.Filter.Eq("TenantId", machine.TenantId)
                            &
                            Builders<BsonDocument>.Filter.Eq("MachineCode", machine.MachineCode);
                        var sort = Builders<BsonDocument>.Sort.Descending("CreationTime");
                        var collection = GetCollection("Alarm");
                        var cursorToResults = collection.Find(filter).Sort(sort);
                        var lastAlarmMessage = cursorToResults.FirstOrDefault() == null ? "" : cursorToResults.FirstOrDefault()["Message"].AsString;
                        //插入到数据库
                        InsertAlarmData(machine.TenantId, machine.MachineCode, new AlarmArray { Code = alarmCode, Message = lastAlarmMessage, CreationTime = creationTime });
                        break;
                    case 2:
                        //单报警内容，报警为Unknown
                        //var alarmMessage = GetValueByType(dataItems.FirstOrDefault(item => item.Id == ((ushort)ConfigField.AlarmMsg))).ToString();
                        //插入到数据库
                        //InsertAlarmData(machine.TenantId, machine.MachineCode, new AlarmArray { Code = "Unknown", Message = alarmMessage, CreationTime = creationTime });
                        break;
                    case 3:
                        //设备状态
                        var statusCode = GetValueByType(dataItems.FirstOrDefault(item => item.Id == ((ushort)ConfigField.StateCode))).ToString();
                        //如果采集到的状态是在定义范围之内的则插入数据库,否则过滤
                        if (DefinitionCodes.Contains(statusCode))
                        {
                            //插入到数据库
                            InsertStateData(machine.TenantId, machine.MachineCode, new StateArray { Code = statusCode, CreationTime = creationTime });
                        }
                        break;
                    case 4:
                        //采集到的计数器值
                        var workCount = Convert.ToInt32(GetValueByType(t));
                        //从machineInfo集合取得产量累加值和OriginalCount
                        var filter2 =
                            Builders<BsonDocument>.Filter.Eq("TenantId", machine.TenantId)
                            &
                            Builders<BsonDocument>.Filter.Eq("MachineCode", machine.MachineCode);
                        var collection2 = GetCollection("MachineInfo");
                        var cursorToResults2 = collection2.Find(filter2).FirstOrDefault();
                        if (cursorToResults2 == null)
                        {
                            throw new Exception("没有该设备的登录信息");
                        }
                        //产量
                        var yield = 0;
                        //产量计数器
                        var originalCount = workCount;
                        //产量计数器累加值
                        var lastCount = 0;
                        var lastCurrentProgramCount = 0;
                        //判断MachineInfo中是否存在记录,如果不存在则说明该设备首次接入系统,则只记录采集到的设备产量计数器,产量为0
                        if (cursorToResults2["Capacity"].ToString().Contains("Yield"))
                        {
                            //取得最后一次当前程序产量
                            lastCurrentProgramCount = cursorToResults2["Capacity"]["CurrentProgramCount"].AsInt32;
                            //取得最后一次累加值
                            lastCount = cursorToResults2["Capacity"]["Count"].AsInt32;
                            //取得最后一次产量计数器值
                            var lastOriginalCount = cursorToResults2["Capacity"]["OriginalCount"].AsInt32;
                            //判读是否需要插入产量，与上一次计数器数值比较，如果小于上一次则视为，计数器清零,记录产量为0
                            if (workCount > lastOriginalCount)
                            {
                                //记录产量为这次产量计数器减去上一次产量计数器值
                                yield = workCount - lastOriginalCount;
                                //更新最后一次产量计数器值
                                originalCount = workCount;
                                //更新最后一次产量计数器累加值
                                lastCount += yield;
                            }
                            else
                            {
                                yield = 0;
                                originalCount = workCount;
                                lastCount += 0;
                            }
                            lastCurrentProgramCount += yield;
                        }
                        InsertCapacityData(machine.TenantId, machine.MachineCode, new CapacityArray { Count = lastCount, Yield = yield, OrginalCount = originalCount, ProgramName = procNo, CreationTime = creationTime, CurrentProgramCount = lastCurrentProgramCount });
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    case 14:
                        break;
                    case 15:
                        break;
                    case 16:
                        break;
                    case 17:
                        break;
                    case 18:
                        break;
                    case 19:
                        break;
                    case 20:
                        break;
                    default:
                        //InsertParameterData(machine.MachineCode, GetNameById(machine.MachineCode, dataItems[i]), GetValueByType(dataItems[i]), creationTime);
                        parameters.Add(new BsonElement(GetNameById(machine.MachineCode, t) ?? string.Empty, GetValueByType(t).ToString()));
                        break;
                }
            }
            //如果有接收到参数
            if (parameters.Count > 0)
            {
                //parameters.Add(new BsonElement("TenantId", machine.TenantId));
                //parameters.Add(new BsonElement("MachineCode", machine.MachineCode));
                InsertParameterData(machine.TenantId, machine.MachineCode, parameters, creationTime);
            }
        }

        /// <summary>
        /// 检查是否需要保存数据项
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="dataItems"></param>
        /// <param name="creationTime"></param>
        /// <returns></returns>
        public bool CheckIfNeedSaveDataItem(Machine machine, List<DataItem> dataItems, string creationTime)
        {
            bool flag;
            //判读是否有采集到状态数据项
            var dataItem = dataItems.FirstOrDefault(item => item.Id == ((ushort)ConfigField.StateCode));
            if (dataItem == null)
            {
                //没有采集到则正常保存采集到的数据项
                flag = true;
            }
            else
            {
                //判读是否是离线状态
                var statusCode = GetValueByType(dataItem).ToString();
                if (statusCode == "4")
                {
                    //状态是离线,过滤掉其他数据项
                    flag = false;
                    //插入到数据库
                    InsertStateData(machine.TenantId, machine.MachineCode, new StateArray { Code = statusCode, CreationTime = creationTime });
                }
                else
                {
                    //状态不是离线,正常保存数据项
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// 参数
        /// </summary>
        private void InsertParameterData(int tenantId, string machineCode, List<BsonElement> parameters, string creationTime)
        {
            var collection = GetCollection(MacConfigCollection);
            var filter =
                    Builders<BsonDocument>.Filter.Eq("TenantId", tenantId)
                    &
                    Builders<BsonDocument>.Filter.Eq("MachineCode", machineCode);
            //1.把采集到的数据项更新MachineInfo中Parameter字段
            for (var i = 0; i < parameters.Count; i++)
            {
                var update = Builders<BsonDocument>.Update.Set("Parameter." + parameters[i].Name, parameters[i].Value);
                collection.FindOneAndUpdate(filter, update);
            }
            //2.把更新完后的Parameter字段插入到Parameter集合中
            var document = collection.Find(filter).FirstOrDefault()["Parameter"].AsBsonDocument;
            //往Parameter集合中插入一笔数据
            var collectionName = "Parameter" + creationTime.Substring(0, 6);
            collection = GetCollection(collectionName);
            document.Add(new BsonElement("CreationTime", creationTime));
            document.Add(new BsonElement("TenantId", tenantId));
            document.Add(new BsonElement("MachineId", _machineId));
            document.Add(new BsonElement("MachineCode", machineCode));
            collection.InsertOne(document);
        }

        /// <summary>
        /// 产量
        /// </summary>
        private void InsertCapacityData(int tenantId, string machineCode, CapacityArray item)
        {
            var collection = GetCollection("Capacity");
            var document = new BsonDocument
                {
                    { "TenantId",tenantId},
                    { "MachineId",_machineId},
                    { "MachineCode",machineCode},
                    { "Count",item.Count },
                    { "Yield",item.Yield},
                    { "OriginalCount",item.OrginalCount},
                    { "ProgramName",item.ProgramName??string.Empty},
                    { "CreationTime",item.CreationTime??string.Empty }
                };
            collection.InsertOne(document);
            //将最新的记录更新到设备信息表
            var document2 = new BsonDocument
                {
                    { "Count",item.Count },
                    { "Yield",item.Yield},
                    { "OriginalCount",item.OrginalCount},
                    { "ProgramName",item.ProgramName??string.Empty},
                    { "CurrentProgramCount",item.CurrentProgramCount},
                    { "CreationTime",item.CreationTime??string.Empty }
                };
            collection = GetCollection(MacConfigCollection);
            var filter =
                    Builders<BsonDocument>.Filter.Eq("TenantId", tenantId)
                    &
                    Builders<BsonDocument>.Filter.Eq("MachineCode", machineCode);
            var count = collection.Find(filter).Count();
            if (count == 0)
            {
                throw new Exception("没有该设备的登录信息");
            }
            else
            {
                FieldDefinition<BsonDocument, BsonDocument> targetField = "Capacity";
                var update = Builders<BsonDocument>.Update.Set(targetField, document2);
                collection.FindOneAndUpdate(filter, update);
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public void InsertStateData(int tenantId, string machineCode, StateArray item)
        {
            var collection = GetCollection("State");
            var document = new BsonDocument
                {
                    { "TenantId",tenantId},
                    { "MachineId",_machineId},
                    { "MachineCode",machineCode },
                    { "Code",item.Code},
                    { "CreationTime",item.CreationTime }
                };
            collection.InsertOne(document);
            //将最新的记录更新到设备信息表
            var document2 = new BsonDocument
                {
                    { "Code",item.Code},
                    { "CreationTime",item.CreationTime }
                };
            collection = GetCollection(MacConfigCollection);
            var filter =
                    Builders<BsonDocument>.Filter.Eq("TenantId", tenantId)
                    &
                    Builders<BsonDocument>.Filter.Eq("MachineCode", machineCode);
            var count = collection.Find(filter).Count();
            if (count == 0)
            {
                throw new Exception("没有该设备的登录信息");
            }
            else
            {
                FieldDefinition<BsonDocument, BsonDocument> targetField = "State";
                var update = Builders<BsonDocument>.Update.Set(targetField, document2);
                collection.FindOneAndUpdate(filter, update);
            }
        }

        /// <summary>
        /// 报警
        /// </summary>
        private void InsertAlarmData(int tenantId, string machineCode, AlarmArray item)
        {
            var collection = GetCollection("Alarm");
            var document = new BsonDocument
                    {
                        { "TenantId",tenantId},
                        { "MachineId",_machineId},
                        { "MachineCode",machineCode },
                        { "Code",item.Code??string.Empty },
                        { "Message",item.Message??string.Empty },
                        { "CreationTime",item.CreationTime??string.Empty },
                        { "AlarmEndTime",string.Empty }
                    };
            var document2 = new BsonDocument
                    {
                        { "Code",item.Code??string.Empty },
                        { "Message",item.Message??string.Empty },
                        { "CreationTime",item.CreationTime??string.Empty }
                    };

            //如果报警编号为0或string.Empty,则视为所有报警结束,更新所有的报警记录
            if (item.Code != null && (item.Code == "0" || item.Code.Length == 0))
            {
                var filter =
                    Builders<BsonDocument>.Filter.Eq("TenantId", tenantId)
                    &
                    Builders<BsonDocument>.Filter.Eq("MachineCode", machineCode)
                    &
                    Builders<BsonDocument>.Filter.Eq("AlarmEndTime", "");
                var update = Builders<BsonDocument>.Update.Set("AlarmEndTime", DateTime.Now.ToString("yyyyMMddHHmmss"));
                collection.UpdateMany(filter, update);

                //将最新的记录更新到设备信息表
                collection = GetCollection(MacConfigCollection);
                var filter2 =
                        Builders<BsonDocument>.Filter.Eq("TenantId", tenantId)
                        &
                        Builders<BsonDocument>.Filter.Eq("MachineCode", machineCode);
                var count = collection.Find(filter2).Count();
                if (count == 0)
                {
                    throw new Exception("没有该设备的登录信息");
                }
                else
                {
                    FieldDefinition<BsonDocument, BsonArray> targetField = "Alarm";
                    var update2 = Builders<BsonDocument>.Update.Set(targetField, new BsonArray());
                    collection.FindOneAndUpdate(filter2, update2);
                }
            }
            else
            {
                collection.InsertOne(document);
                //将最新的记录更新到设备信息表
                collection = GetCollection(MacConfigCollection);
                var filter2 =
                        Builders<BsonDocument>.Filter.Eq("TenantId", tenantId)
                        &
                        Builders<BsonDocument>.Filter.Eq("MachineCode", machineCode);
                var count = collection.Find(filter2).Count();
                if (count == 0)
                {
                    throw new Exception("没有该设备的登录信息");
                }
                else
                {
                    FieldDefinition<BsonDocument, BsonArray> targetField = "Alarm";
                    var update2 = Builders<BsonDocument>.Update.Push(targetField, document2);
                    collection.FindOneAndUpdate(filter2, update2);

                }
            }

        }

        public void ClearCurrentAlarms(int tenantId, string machineCode)
        {

            var collection2 = GetCollection(MacConfigCollection);
            var filter2 =
                    Builders<BsonDocument>.Filter.Eq("TenantId", tenantId)
                    &
                    Builders<BsonDocument>.Filter.Eq("MachineCode", machineCode);
            var count = collection2.Find(filter2).Count();
            if (count == 0)
            {
                throw new Exception("没有该设备的登录信息");
            }
            else
            {
                var collection = GetCollection("Alarm");
                var filter =
                        Builders<BsonDocument>.Filter.Eq("TenantId", tenantId)
                        &
                        Builders<BsonDocument>.Filter.Eq("MachineCode", machineCode)
                        &
                        Builders<BsonDocument>.Filter.Eq("AlarmEndTime", "");

                var update = Builders<BsonDocument>.Update.Set("AlarmEndTime", DateTime.Now.ToString("yyyyMMddHHmmss"));

                collection.UpdateMany(filter, update);

                FieldDefinition<BsonDocument, BsonArray> targetField = "Alarm";
                var update2 = Builders<BsonDocument>.Update.Set(targetField, new BsonArray());
                collection2.FindOneAndUpdate(filter2, update2);
            }
        }

        public void InitializeMachineInfo(int tenantId, string machineCode)
        {
            var collection = GetCollection(MacConfigCollection);
            var filter =
                    Builders<BsonDocument>.Filter.Eq("TenantId", tenantId)
                    &
                    Builders<BsonDocument>.Filter.Eq("MachineCode", machineCode);
            var count = collection.Find(filter).Count();
            if (count == 0)
            {
                throw new Exception("没有该设备的登录信息");
            }
            else
            {
                var updateAlarm = Builders<BsonDocument>.Update.Set("Alarm", new BsonArray());
                collection.FindOneAndUpdate(filter, updateAlarm);
            }
        }

        /// <summary>
        /// 获取对应的集合
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        private IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            try
            {
                var client = new MongoClient(ConnectionString);
                var db = client.GetDatabase(DatabaseName);
                //1查询集合是否存在数据库里
                var filter = new BsonDocument("name", collectionName);
                //filter by collection name
                var collections = db.ListCollections(new ListCollectionsOptions { Filter = filter });
                //check for existence
                var count = collections.ToList().Count;
                if (count == 0)
                {
                    db.CreateCollection(collectionName);
                }
                var collection = db.GetCollection<BsonDocument>(collectionName);

                if (collectionName.Contains("Parameter") && count == 0)
                {
                    collection.Indexes.CreateOne(new BsonDocument("MachineId", 1).Add("CreationTime", -1));
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw new Exception($"连接Mongo数据库发生错误:{ex.Message}");
            }

        }

        #region Help Method
        /// <summary>
        /// 获得最新程序号
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        private string GetNewestProcNo(Machine machine, List<DataItem> dataItems)
        {
            string result = "";
            var filter =
                        Builders<BsonDocument>.Filter.Eq("TenantId", machine.TenantId)
                        &
                        Builders<BsonDocument>.Filter.Eq("MachineCode", machine.MachineCode);
            //是否有更新程序号
            if (CheckIfChangeProcNo(dataItems))
            {
                //更新当前程序号
                result = GetValueByType(dataItems.FirstOrDefault(i => i.Id == (ushort)ConfigField.ProgramName)).ToString();

                var collection = GetCollection(MacConfigCollection);

                FieldDefinition<BsonDocument, string> targetField = "ProgramName";

                var update = Builders<BsonDocument>.Update.Set(targetField, result);

                collection.FindOneAndUpdate(filter, update);

                //由于程序号更改,更新当前程序产量为0
                var update2 = Builders<BsonDocument>.Update.Set("Capacity.CurrentProgramCount", 0);
                collection.FindOneAndUpdate(filter, update2);
                //同步Capacity下的程序号
                var update3 = Builders<BsonDocument>.Update.Set("Capacity.ProgramName", result);
                collection.FindOneAndUpdate(filter, update3);
            }
            else
            {
                var collection = GetCollection(MacConfigCollection);
                var item = collection.Find(filter).FirstOrDefault();
                if (item != null)
                {
                    result = item["ProgramName"].ToString();
                }
            }
            return result ?? string.Empty;
        }

        private static bool CheckIfChangeProcNo(IEnumerable<DataItem> dataItems)
        {
            var flag = dataItems != null && dataItems.Any(i => i.Id == (ushort)ConfigField.ProgramName);
            return flag;
        }

        private string GetNameById(string machineCode, DataItem item)
        {
            var returnResult = string.Empty;
            var collection = GetCollection(MacConfigCollection);
            var filter = Builders<BsonDocument>.Filter.Eq("MachineCode", machineCode);
            var filter2 = Builders<BsonDocument>.Filter.Eq("Map.Id", item.Id.ToString());
            var result = collection.Find(filter & filter2).FirstOrDefault();
            if (result != null)
            {
                if (result["Map"].AsBsonArray.FirstOrDefault(s => s["Id"] == item.Id.ToString()) == null)
                    return returnResult.Trim();

                var firstOrDefault = result["Map"].AsBsonArray.FirstOrDefault(s => s["Id"] == item.Id.ToString());
                if (firstOrDefault != null)
                    returnResult = firstOrDefault["Value"].ToString();
            }
            else
            {
                returnResult = "Unknown";
            }
            return returnResult.Trim();
        }

        private static object GetValueByType(DataItem item)
        {
            object result = null;
            switch (item.Type & 0x0F)
            {
                case 0:
                    if (item.Id == 2)
                    {
                        var tempBytes = new List<byte>();
                        foreach (var t in item.Value)
                        {
                            if (t == 0)
                            {
                                break;
                            }
                            tempBytes.Add(t);
                        }
                        result = Encoding.GetEncoding("GB2312").GetString(tempBytes.ToArray()).Trim('\0').Trim();
                    }
                    else
                    {
                        var tempBytes = new List<byte>();
                        foreach (var t in item.Value)
                        {
                            if (t == 0)
                            {
                                break;
                            }
                            tempBytes.Add(t);
                        }
                        result = Encoding.ASCII.GetString(tempBytes.ToArray()).Trim('\0').Trim();
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
                    result = SocketHelper.NetworkToHost(BitConverter.ToInt32(item.Value, 0));
                    break;
                case 3:
                    result = item.Value[0];
                    break;
                case 4:
                    result = item.Value[0];
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

        /// <summary>
        /// 把错误信息写到数据库中
        /// </summary>
        /// <param name="machineCode" />
        /// <param name="message"></param>
        /// <param name="errorLevel"></param>
        public void WriteExceptionToDb(string machineCode, string message, ErrorLevel errorLevel)
        {
            //获取集合
            var collectionName = "Exception" + DateTime.Now.ToString("yyyyMM");
            var collection = GetCollection(collectionName);
            //check for existence
            var document = new BsonDocument()
                        {
                            { "MachineName", Environment.MachineName},
                            { "ProcessName", System.Diagnostics.Process.GetCurrentProcess().ProcessName},
                            { "MachineCode", machineCode },
                            { "Message", message},
                            { "ErrorLevel", errorLevel },
                            { "CreationTime", DateTime.Now.ToString("yyyyMMddHHmmss") }
                        };
            collection.InsertOne(document);
        }

        /// <summary>
        /// 更新设备Code缓存
        /// </summary>
        public List<string> UpdateMachineCodeCache()
        {
            var machineCodes = new List<string>(0);
            var collection = GetCollection(MacConfigCollection);
            var filter = Builders<BsonDocument>.Filter.Eq("IsActive", true);
            var result = collection.Find(filter).ToList();
            foreach (var t in result)
            {
                machineCodes.Add(t["MachineCode"].ToString());
            }
            return machineCodes;
        }

        private string GetCreationTime(List<DataItem> dataItems)
        {
            var returnValue = DateTime.Now.ToString("yyyyMMddHHmmss");
            //判读是否有采集到操作时间数据项
            var dataItem = dataItems.FirstOrDefault(item => item.Id == ((ushort)ConfigField.CreationTime));
            if (dataItem != null)
            {
                returnValue = GetValueByType(dataItem).ToString();
            }
            return returnValue;
        }
        #endregion
    }
}
