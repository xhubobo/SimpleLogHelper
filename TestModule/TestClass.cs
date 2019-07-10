using System;

namespace TestModule
{
    public class TestClass
    {
        //添加常规日志
        public static void AddNormalLog()
        {
            LogHelper.AddLog("Add normal log in TestClass");
        }

        //添加异常日志
        public static void AddExceptionLog()
        {
            LogHelper.AddLog(new Exception("Add exception log in TestClass"));
        }
    }
}
