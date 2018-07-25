using System;
using OSS.Common.Plugs.CachePlug;
using OSS.Common.Plugs.DirConfigPlug;
using OSS.Common.Plugs.LogPlug;

namespace OSS.Common
{
    /// <summary>
    /// 基础配置模块
    /// </summary>
    public static class OsConfig
    {
        #region  Module初始化模块

        /// <summary>
        ///   日志模块提供者
        /// </summary>
        public static Func<string, ILogPlug> LogWriterProvider { get; set; }

        /// <summary>
        ///   缓存模块提供者
        /// </summary>
        public static Func<string, ICachePlug> CacheProvider { get; set; }
        
        /// <summary>
        ///   配置信息模块提供者
        /// </summary>
        public static Func<string, IDirConfigPlug> DirConfigProvider { get; set; }
        #endregion


    }
}
