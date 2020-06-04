using InfluxDB.Collector;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Influxdb_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Metrics.Collector = new CollectorConfiguration()
                    .WriteTo.InfluxDB("http://localhost:8086", "test")
                    .CreateCollector();

            Metrics.Write("MDCException",
                   new Dictionary<string, object>
                   {
                            {"EventTime", DateTime.Now},
                            {"Line", 1},
                            {"Frame", 1},
                            {"ParameterList", 1},
                            {"Message", 1},
                            {"StackTrace", 1},

                   }, new Dictionary<string, string>
                   {
                            {"Type", "1"},
                            {"File", "1"}
                   });
        }
    }
}
