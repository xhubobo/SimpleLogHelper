﻿using System;
using System.Reflection;
using SimpleLogHelper;

namespace test
{
    internal static class LogHelper
    {
        private static readonly string AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

        public static void AddLog(Exception e, MsgType type = MsgType.Error)
        {
            AddLog(e.Message, type);
        }

        public static void AddLog(string msg, MsgType type = MsgType.Information)
        {
            SimpleLogProxy.Instance.AddLog($"[{AssemblyName}]{'\t'}{msg}", type);
        }
    }
}