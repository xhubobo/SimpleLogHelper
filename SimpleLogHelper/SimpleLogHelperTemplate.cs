using System;
using System.IO;
using System.Reflection;

namespace SimpleLogHelper
{
    public abstract class SimpleLogHelperTemplate
    {
        protected abstract Assembly CurrentAssembly { get; }
        private string AssemblyName => CurrentAssembly.GetName().Name;

        public void AddLog(Exception e)
        {
            AddLog(e.Message, MsgType.Error);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="msg">日志消息</param>
        /// <param name="type">日志类型</param>
        /// <remarks>日志最终形式：{datetime}{'\t'}{Type}{'\t'}[{AssemblyName}]{'\t'}{msg}{'\n'}</remarks>
        public void AddLog(string msg, MsgType type = MsgType.Information)
        {
            SimpleLogProxy.Instance.AddLog($"[{AssemblyName}]{'\t'}{msg}", type);
        }

        public void AddErrorLog(string msg)
        {
            AddLog(msg, MsgType.Error);
        }

        /// <summary>
        /// 初始化日志路径
        /// </summary>
        /// <remarks>仅在程序入口处调用</remarks>
        public void InitLogPath()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Log\\");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, $"{AssemblyName}\\");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            SimpleLogProxy.Instance.SetLogPath(path);
        }

        public void Stop()
        {
            SimpleLogProxy.Instance.Stop();
        }
    }
}
