﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FastDev.Config;

namespace FastDev.Log
{
    /// <summary>
    /// 提供写日志的入口，多个重载
    /// 处理日志内容，拼接为有效的字符串形式
    /// 日志文件默认存储在Logs下面，若要修改日志默认存储地址需要修改Textwriter和loghelper
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 单例实现
        /// </summary>
        private static object obj = new object();
        /// <summary>
        /// 用于控制是否执行写日志
        /// </summary>
        private static int _writeLogLevel = ConfigHelper.GetConfigToInt("WriteLogLevel");

        /// <summary>
        /// 返回配置文件中设置写日志的级别，未设置折设置为最低 ，值越小级别越高
        /// 控制是否写日志
        /// </summary>
        private static LogLevel WriteLogLevel
        {
            get
            {
                if (_writeLogLevel < 0 || _writeLogLevel > 7)
                {
                    return LogLevel.H调试信息;
                }
                return (LogLevel)_writeLogLevel;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remark">备注信息</param>
        public static void WriteLog(string remark, LogLevel logLevel = LogLevel.H调试信息)
        {
            if(logLevel> WriteLogLevel)
            {
                return;
            }
            WriteLog(null, remark, "", logLevel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="remark"></param>
        public static void WriteLog(Exception ex, string remark, LogLevel logLevel = LogLevel.H调试信息)
        {
            if (logLevel > WriteLogLevel)
            {
                return;
            }
            WriteLog(ex, remark, "", logLevel);
        }
        /// <summary>
        /// filepath为Logs下的指定文件夹（默认是logs下的文件夹只需文件夹名称）
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="remark"></param>
        /// <param name="filepath">只传文件夹名称</param>
        public static void WriteLog(Exception ex, string remark, string filepath, LogLevel logLevel = LogLevel.H调试信息)
        {
            lock (obj)
            {
                //控制是否写日志
                if (logLevel > WriteLogLevel)
                {
                    return;
                }
                string content = remark;
                if (ex != null)
                {
                    content = GetLogContent(ex, remark);
                }
                if (!string.IsNullOrEmpty(filepath))
                {
                    TextWriter textWriter = new TextWriter(filepath);
                    textWriter.WriteLog("=====================" + Environment.NewLine +
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + logLevel.ToString() + Environment.NewLine + content
                                + Environment.NewLine);
                }
                else
                {
                    TextWriter textWriter = new TextWriter();
                    textWriter.WriteLog("=====================" + Environment.NewLine +
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + logLevel.ToString() + Environment.NewLine + content
                                + Environment.NewLine);
                }
            }
        }
        /// <summary>
        /// build the log content
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        private static string GetLogContent(Exception ex, string remark)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("************************Exception Start************************");
            string newLine = Environment.NewLine;
            stringBuilder.Append(newLine);
            stringBuilder.AppendLine("Exception Remark：" + remark);
            Exception innerException = ex.InnerException;
            stringBuilder.AppendFormat("Exception Date:{0}{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Environment.NewLine);
            if (innerException != null)
            {
                stringBuilder.AppendFormat("Inner Exception Type:{0}{1}", innerException.GetType(), newLine);
                stringBuilder.AppendFormat("Inner Exception Message:{0}{1}", innerException.Message, newLine);
                stringBuilder.AppendFormat("Inner Exception Source:{0}{1}", innerException.Source, newLine);
                stringBuilder.AppendFormat("Inner Exception StackTrace:{0}{1}", innerException.StackTrace, newLine);
            }
            stringBuilder.AppendFormat("Exception Type:{0}{1}", ex.GetType(), newLine);
            stringBuilder.AppendFormat("Exception Message:{0}{1}", ex.Message, newLine);
            stringBuilder.AppendFormat("Exception Source:{0}{1}", ex.Source, newLine);
            stringBuilder.AppendFormat("Exception StackTrace:{0}{1}", ex.StackTrace, newLine);
            stringBuilder.Append("************************Exception End**************************");
            stringBuilder.Append(newLine);
            return stringBuilder?.ToString() ?? string.Empty;
        }
    }
}
