using NLog;
using System;

namespace peano.mystocks.log.library
{
    public class LogService
    {
        // 使用不同的 Logger 来分配不同的日志目标
        private static readonly Logger infoLogger = LogManager.GetLogger("loginfo");
        private static readonly Logger warnLogger = LogManager.GetLogger("logwarn");
        private static readonly Logger errorLogger = LogManager.GetLogger("logerror");


        // 日志记录方法：记录信息级别的日志
        public static void LogInfo(string message)
        {
            LogEventInfo logEvent = LogEventInfo.Create(LogLevel.Info, null, message);
            infoLogger.Log(typeof(LogService),logEvent);
        }

        // 日志记录方法：记录警告级别的日志
        public static void LogWarn(string message)
        {
            LogEventInfo logEvent = LogEventInfo.Create(LogLevel.Warn, "logwarn", message);
            warnLogger.Log(typeof(LogService),logEvent);
        }

        // 日志记录方法：记录错误级别的日志
        public static void LogError(string message)
        {
            NLog.LogEventInfo logEvent = NLog.LogEventInfo.Create(NLog.LogLevel.Error, "logwarn", message);
            errorLogger.Log(typeof(LogService),logEvent);
        }
    }
}
