using System;
using TestModule;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            //添加常规日志
            LogHelper.AddLog("Add log in Main");

            TestClass.AddNormalLog();

            //添加异常日志
            LogHelper.AddLog(new Exception("Add Exception in Main"));

            TestClass.AddExceptionLog();

            Console.ReadKey();
        }
    }
}
