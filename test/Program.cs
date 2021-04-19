using System;
using SimpleLogHelper;
using TestModule;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            LogHelper.InitLogPath();

            //添加常规日志
            LogHelper.AddLog("Add log in Main");

            //在类库中添加常规日志
            TestClass.AddNormalLog();

            //添加异常日志
            LogHelper.AddLog(new Exception("Add Exception in Main"));

            //在类库中添加异常日志
            TestClass.AddExceptionLog();

            Console.ReadKey();

            //停止日志
            LogHelper.Stop();
        }
    }
}
