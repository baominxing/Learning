using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SendApplicationMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //演示调用微信接口发送应用消息
                Sample1.Denomination();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }

    public class Sample1
    {
        public static void Denomination()
        {
            Task.Run(async () =>
           {
               var token = "V5wnVeSDr5JvVY2MWPu5tuDqUu_o2aXHZliIgVJz31Cuf2IDm2zz-e0_USjdHTVuKmqcp7-BHurhf-O3dFBUakpIcIjnG1Xe2IJ8rP5xxihQqO83V1OV0oVzL8-Sp4DRxBm2accTGCBNEPuEE41gdjdUMFtpZ75cRmsLUStjzWq_8jQFsm1mmFaKwHK6Oakw7Z4L38wt-BNkEufltAabSg";// GetAccessToken();
               var url = @"https://qyapi.weixin.qq.com/cgi-bin/message/send";
               var sendDto = new SendDto
               {
                   touser = "minxing.bao|chengjie.zhang",
                   toparty = "",
                   totag = "",
                   msgtype = "text",
                   agentid = 5,
                   text = new TextDto { content = "设备名称+设备报警号+设备报警信息+时间；例：数控卧式车床001-171：MC3200 设备紧急停止；2020-9-10 15:26" },
                   safe = 0,
                   enable_id_trans = 0,
                   enable_duplicate_check = 0,
                   duplicate_check_interval = 1800
               };

               var result = await url.SetQueryParam("access_token", token).PostJsonAsync(sendDto).ReceiveJson<JObject>();

               Console.WriteLine(result);
           });
        }

        public static string GetAccessToken()
        {
            const string ACCESS_TOKEN = "ACCESS_TOKEN";

            var token = CacheHelper.Get<string>(ACCESS_TOKEN);

            if (string.IsNullOrEmpty(token))
            {
                var corpid = "wxbca1442bc00eeef3";
                var corpsecret = "YT5RUCxtjfsiv3-Yao02BHM6GPD-XLVLgtNHzUYSN6Q";

                var url = @"https://qyapi.weixin.qq.com/cgi-bin/gettoken";

                var result = url.SetQueryParams(new { corpid = corpid, corpsecret = corpsecret }).GetAsync().ReceiveJson<JObject>().Result;

                token = result.Value<string>("access_token")?.ToString() ?? string.Empty;

                CacheHelper.Set(ACCESS_TOKEN, token);
            }

            return token;
        }

        public class SendDto
        {
            public string touser { get; set; }

            public string toparty { get; set; }

            public string totag { get; set; }

            public string msgtype { get; set; }

            public int agentid { get; set; }

            public TextDto text { get; set; }

            public int safe { get; set; }

            public int enable_id_trans { get; set; }

            public int enable_duplicate_check { get; set; }

            public int duplicate_check_interval { get; set; }
        }

        public class TextDto
        {
            public string content { get; set; }
        }

    }

    public static class CacheHelper
    {
        public static void Set(string key, object obj, int seconds = 7200)
        {
            var cache = MemoryCache.Default;

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(seconds)
            };

            cache.Set(key, obj, policy);
        }

        public static T Get<T>(string key) where T : class
        {
            var cache = MemoryCache.Default;

            try
            {
                return (T)cache[key];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }
    }
}
