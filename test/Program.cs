using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            LogHelper.AddLog("test log");
            Console.ReadKey();
        }
    }
}
