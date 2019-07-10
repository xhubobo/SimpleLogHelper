using System;
using System.Reflection;
using SimpleLogHelper;

namespace test
{
    internal static class LogHelper
    {
        public static void AddLog(Exception e, MsgType type = MsgType.Error)
        {
            AddLog(e.Message, type);
        }

        public static void AddLog(string msg, MsgType type = MsgType.Information)
        {
            var log = new LogHelperInstance();
            log.AddLog(msg, type);
        }

        private class LogHelperInstance : SimpleLogHelperTemplate
        {
            protected override string AssemblyName { get; } = Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}
