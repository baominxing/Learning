using System;

namespace Keyword_Delegate
{
    /// <summary>
    /// 用于演示委托的使用和特性
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            #region 委托与命名方法
            Sample1.Demonstration();
            #endregion

            #region 委托与匿名方法
            Sample2.Demonstration();
            #endregion

            #region 委托与Lambda表达式，委托与Func,Action,Predicate,EventHandler关系
            Sample3.Demonstration();
            #endregion

            #region 委托链
            Sample4.Demonstration();
            #endregion

            Console.ReadKey();
        }
    }

    class Sample1
    {

        public delegate string/*委托返回类型*/ GetTelphone(string message);/*委托方法名称*/　　//用来得到联系方式的

        internal static void Demonstration()
        {
            var Sex = "男";
            var del = Sex == "男" ? new GetTelphone(GetGirlTel) : new GetTelphone(GetBoyTel);
            GetTel(del);
        }
        public string Sex { get; set; }

        public static void GetTel(GetTelphone getTelphone)
        {
            Console.WriteLine(getTelphone.Invoke("媒婆"));
        }

        /// <summary>
        /// 命名方法
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetGirlTel(string message)
        {
            return $"{message}得到菇凉的电话";
        }

        /// <summary>
        /// 命名方法
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetBoyTel(string message)
        {
            return $"{message}得到男屌丝的电话";
        }
    }

    class Sample2
    {
        public delegate string/*委托返回类型*/ GetTelphone(string message);/*委托方法名称*/　　//用来得到联系方式的

        internal static void Demonstration()
        {
            var del = (GetTelphone)delegate (string message) { return $"{message}得到屌丝的电话"; };
            GetTel(del);
        }
        public string Sex { get; set; }

        public static void GetTel(GetTelphone getTelphone)
        {
            Console.WriteLine(getTelphone.Invoke("媒婆"));
        }
    }

    class Sample3
    {
        public delegate string/*委托返回类型*/ GetTelphone(string message);/*委托方法名称*/　　//用来得到联系方式的

        internal static void Demonstration()
        {
            var del = (GetTelphone)((message) => { return $"delegate {message}得到屌丝的电话"; });
            var del2 = (Func<string, string>)((message) => { return $"Func {message}得到屌丝的电话"; });
            var del3 = (Action<string>)((message) => { Console.WriteLine($"Action {message}得到屌丝的电话"); });
            var del4 = (Predicate<string>)((message) => { Console.WriteLine($"Predicate {message}得到屌丝的电话"); return false; });
            var del5 = (EventHandler<string>)((sender, message) => { Console.WriteLine($"EventHandler {message}得到屌丝的电话"); });

            GetTel(del);
            GetTel2(del2);
            GetTel3(del3);
            GetTel4(del4);
            GetTel5(del5);
        }
        public string Sex { get; set; }

        public static void GetTel(GetTelphone getTelphone)
        {
            Console.WriteLine(getTelphone.Invoke("媒婆"));
        }

        public static void GetTel2(Func<string, string> getTelphone)
        {
            Console.WriteLine(getTelphone.Invoke("媒婆"));
        }

        public static void GetTel3(Action<string> getTelphone)
        {
            getTelphone.Invoke("媒婆");
        }

        public static void GetTel4(Predicate<string> getTelphone)
        {
            Console.WriteLine(getTelphone.Invoke("媒婆"));
        }

        public static void GetTel5(EventHandler<string> getTelphone)
        {
            getTelphone.Invoke(null, "媒婆");
        }
    }

    class Sample4
    {
        public delegate void/*委托返回类型*/ GetTelphone(string message);/*委托方法名称*/　　//用来得到联系方式的

        internal static void Demonstration()
        {
            var del = (GetTelphone)((message) => { Console.WriteLine($"delegate {message}得到屌丝的电话"); });
            var del2 = (GetTelphone)((message) => { Console.WriteLine($"Func {message}得到屌丝的电话"); });
            var del3 = (GetTelphone)((message) => { Console.WriteLine($"Action {message}得到屌丝的电话"); });
            var del4 = (GetTelphone)((message) => { Console.WriteLine($"Predicate {message}得到屌丝的电话"); });
            var del5 = (GetTelphone)((message) => { Console.WriteLine($"EventHandler {message}得到屌丝的电话"); });
            GetTelphone instance = null;

            instance += del;
            instance += del2;
            instance += del3;
            instance += del4;
            instance += del5;

            instance.Invoke("媒婆");
        }
        public string Sex { get; set; }
    }
}
