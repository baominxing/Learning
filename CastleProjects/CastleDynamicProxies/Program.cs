using Castle.DynamicProxy;
using System;
using System.Collections.Generic;

namespace CastleDynamicProxies
{
    class Program
    {
        static void Main(string[] args)
        {
            var rex = Freezable.MakeFreezable<Pet>();
            rex.Name = "Rex";
            Console.WriteLine(Freezable.IsFreezable(rex)
                ? "Rex is freezable!"
                : "Rex is not freezable. Something is not working");
            Console.WriteLine(rex.ToString());
            Console.WriteLine("Add 50 years");
            rex.Age += 50;
            Console.WriteLine("Age: {0}", rex.Age);
            rex.Deceased = true;

            Console.WriteLine("Deceased: {0}", rex.Deceased);
            Freezable.Freeze(rex);
            try
            {
                rex.Age++;
            }
            catch (ObjectFrozenException)
            {
                Console.WriteLine("Oops. it's frozen. Can't change that anymore");
            }


            var list = rex as IList<string>;

            list.Add("1111");

            Console.WriteLine("--- press enter to close");
            Console.ReadLine();
        }

        private static IDeepThought GetSuperComputer()
        {
            return new SuperComputer();
        }
    }

    public interface IAnsweringEngine
    {
        int GetAnswer(string s);
    }

    public interface IDeepThought
    {
        void SetAnsweringEngine(IAnsweringEngine answeringEngine);
    }

    public class SuperComputer : IDeepThought
    {
        public void SetAnsweringEngine(IAnsweringEngine answeringEngine)
        {
            answeringEngine.GetAnswer("");
        }
    }

    public class Pet
    {
        public Pet()
        {

        }

        public Pet(string name, int age, bool deceased)
        {

        }

        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual bool Deceased { get; set; }

        public virtual string NonVirtualProperty { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Deceased: {Deceased}";
        }

        public void NonVirtualMethod()
        {
        }
    }

    public interface ITimeHelper
    {
        int GetHour(string dateTime);
        int GetMinute(string dateTime);
        int GetSecond(string dateTime);
    }

    public sealed class TimeHelper : ITimeHelper
    {
        public int GetHour(string dateTime)
        {
            DateTime time = DateTime.Parse(dateTime);
            return time.Hour;
        }

        public int GetMinute(string dateTime)
        {
            DateTime time = DateTime.Parse(dateTime);
            return time.Minute;
        }

        public int GetSecond(string dateTime)
        {
            DateTime time = DateTime.Parse(dateTime);
            return time.Second;
        }
    }

    public class TimeFix
    {
        private ProxyGenerator _generator = new ProxyGenerator();
        private ProxyGenerationOptions _options = new ProxyGenerationOptions { Selector = new TimeFixSelector() };

        public ITimeHelper Fix(ITimeHelper item)
        {
            return (ITimeHelper)_generator.CreateInterfaceProxyWithTarget(typeof(ITimeHelper), item, _options);
        }
    }
}
