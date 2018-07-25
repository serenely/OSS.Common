﻿
using System;
using System.IO;
using System.Text;
using OSS.Common.ComUtils;

namespace OSS.Common.Plugs.LogPlug
{
    /// <summary>
    /// 系统默认写日志模块
    /// </summary>
    public class DefaultLogPlug : ILogPlug
    {
        private readonly string _logBaseDirPath = null;
        private const string _logFormat = "{0:T}    Code:{1}    Key:{2}   Detail:{3}\r\n";

        /// <summary>
        /// 构造函数
        /// </summary>
        public DefaultLogPlug()
        {
            // todo  测试地址是否ok
#if NETFW
            _logBaseDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"log");
#else
            _logBaseDirPath = Path.Combine(AppContext.BaseDirectory, "log");
#endif
            if (!Directory.Exists(_logBaseDirPath))
                Directory.CreateDirectory(_logBaseDirPath); 
        }

        private string getLogFilePath(string module, LogLevelEnum level)
        {
            var dirPath = Path.Combine(_logBaseDirPath,string.Concat(module,"_",level) ,DateTime.Now.ToString("yyMM"));//string.Format(@"{0}\{1}\{2}\",_logBaseDirPath, module, level);

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            return Path.Combine(dirPath, DateTime.Now.ToString("yyyyMMddHH")+".txt");
        }

        private readonly object obj = new object();

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="info"></param>
        public void WriteLog(LogInfo info)
        {
            lock (obj)
            {
                var filePath = getLogFilePath(info.ModuleName, info.Level);
#if NETFW
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
#else
                using (StreamWriter sw = new StreamWriter(new FileStream(filePath,FileMode.Append,FileAccess.Write), Encoding.UTF8))
#endif
                {
                    sw.WriteLine( _logFormat,
                         DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                         info.LogCode,
                         info.MsgKey,
                         info.Msg);
                  
                }
            }
        }
        
        /// <summary>
        /// 生成错误编号
        /// </summary>
        /// <returns></returns>
        public void SetLogCode(LogInfo log)
        {
            // 0.1 毫秒
            log.LogCode=NumUtil.TimeMilliNum().ToCode();
        }

    }
}
