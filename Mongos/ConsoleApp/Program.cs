using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ConsoleApp.Sample1;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 演示调用mongo数据的一个表
            Sample1.Demonstration();
            #endregion

            Console.ReadKey();
        }
    }

    public class Sample1
    {
        public static void Demonstration()
        {
            try
            {
                for (int i = 0; i < 49; i++)
                {
                    Task.Run(() =>
                    {
                        while (true)
                        {
                            var col = GetCollection(MongoMachine.GetCollectionName());
                            var filter = Builders<MongoMachine>.Filter.Where(s => s.MachineCode == "M001");
                            var result = col.Find(filter).FirstOrDefault();

                            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}:" + result.MachineCode);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [BsonIgnoreExtraElements]
        public class MongoMachine
        {
            public ObjectId Id { get; set; }

            public int MachineId { get; set; }

            public string MachineCode { get; set; }

            public string ProgramName { get; set; }

            public int OrderId { get; set; }

            public int ProcessId { get; set; }

            public int ProductId { get; set; }

            public string PartNo { get; set; }

            public string PartNoEntryTime { get; set; }

            public int MachinesShiftDetailId { get; set; }

            public long UserId { get; set; }

            public int UserShiftDetailId { get; set; }

            public int DateKey { get; set; }

            public string CreationTime { get; set; }
            public string Name { get; set; }

            public bool IsActive { get; set; }

            [BsonIgnore]
            public string LastModificationTime { get; set; }

            public ICollection<MachineAlarm> Alarm { get; set; } = new List<MachineAlarm>();

            public MachineState State { get; set; } = new MachineState();

            public MachineCapacity Capacity { get; set; } = new MachineCapacity();

            public IDictionary<string, object> Parameter { get; set; } = new Dictionary<string, object>();

            public static string GetCollectionName()
            {
                return "Machine";
            }

            public class MachineAlarm
            {
                public string Code { get; set; }

                public string CreationTime { get; set; }

                public string Message { get; set; }
            }

            public class MachineState
            {
                public string Code { get; set; }

                public string CreationTime { get; set; }
            }

            public class MachineCapacity
            {
                public int Yield { get; set; }

                public int CurrentProgramCount { get; set; }

                public int OriginalCount { get; set; }

                public int AccumulateCount { get; set; }

                public string CreationTime { get; set; }
            }
        }

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        private static IMongoCollection<MongoMachine> GetCollection(string collectionName)
        {
            var client = new MongoClient("mongodb://btlsystem:123qwe@127.0.0.1:27017/YJYZ_MC");
            var db = client.GetDatabase("YJYZ_MC");
            return db.GetCollection<MongoMachine>(collectionName);
        }
    }
}
