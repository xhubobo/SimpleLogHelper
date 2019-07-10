namespace SimpleLogHelper
{
    public abstract class SimpleLogHelperTemplate
    {
        protected abstract string AssemblyName { get; }

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
    }
}
