using System;
using System.Reflection;
using SimpleLogHelper;

namespace TestModule
{
    internal class LogHelper
    {
        private static readonly LogHelperInstance LogInstance = new LogHelperInstance();

        public static void InitLogPath()
        {
            LogInstance.InitLogPath();
        }

        public static void Stop()
        {
            LogInstance.Stop();
        }

        public static void AddLog(Exception e, MsgType type = MsgType.Error)
        {
            AddLog(e.Message, type);
        }

        public static void AddLog(string msg, MsgType type = MsgType.Information)
        {
            LogInstance.AddLog(msg, type);
        }

        private class LogHelperInstance : SimpleLogHelperTemplate
        {
            protected override Assembly CurrentAssembly => Assembly.GetExecutingAssembly();
        }
    }
}
