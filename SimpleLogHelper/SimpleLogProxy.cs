using System;

namespace SimpleLogHelper
{
    public class SimpleLogProxy
    {
        private readonly ThreadSafeLog _threadSafeLog;
        private bool _working = true;

        public void SetLogPath(string logPath)
        {
            _threadSafeLog.LogPathHelper.LogPath = logPath;
        }

        public void SetLogType(LogType logType)
        {
            _threadSafeLog.LogPathHelper.LogType = logType;
        }

        public void Stop()
        {
            (_threadSafeLog as IDisposable)?.Dispose();
            _working = false;
        }

        /// <summary>
        /// 写入新日志，根据指定的日志对象Msg
        /// </summary>
        /// <param name="msg">日志内容对象</param>
        private void AddLog(Msg msg)
        {
            if (_working)
            {
                _threadSafeLog.AddMessage(msg);
            }
        }


        public void AddLog(string text)
        {
            AddLog(new Msg(text));
        }

        public void AddLog(string text, MsgType type)
        {
            AddLog(new Msg(text, type));
        }

        public void AddLog(Exception e, MsgType type)
        {
            AddLog(new Msg(e.Message, type));
        }

        public void AddLog(DateTime dt, string text, MsgType type)
        {
            AddLog(new Msg(dt, text, type));
        }

        #region 单例模式

        private SimpleLogProxy()
        {
            _threadSafeLog = new ThreadSafeLog();
        }

        private static volatile SimpleLogProxy _instance;
        private static readonly object LockHelper = new object();

        public static SimpleLogProxy Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (LockHelper)
                {
                    _instance = _instance ?? new SimpleLogProxy();
                }

                return _instance;
            }
        }

        #endregion
    }
}
