namespace OSS.Common.Plugs.LogPlug
{
    /// <summary>
    /// 日志写实现接口
    /// </summary>
    public interface ILogPlug
    {
        /// <summary>
        ///   日志写功能
        /// </summary>
        ///<param name="info">日志实体</param>
        void WriteLog(LogInfo info);

        /// <summary>
        ///   设置日志编号
        /// </summary>
        /// <param name="info"></param>
        void SetLogCode(LogInfo info);
    }
}