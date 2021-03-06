using asp_net_webpack.Domain.Enum.Log;
using System;

namespace asp_net_webpack.Core.Request.Log
{
    public class LogFilterRequest : BaseRequestPaged<LogOrderByEnum>
    {
        public long LogId { get; set; }
        public LogLevelEnum LogLevel { get; set; }
        public LogTypeEnum LogType { get; set; }
        public DateTime LogDate { get; set; }
        public long UserId { get; set; }
    }

    public enum LogOrderByEnum
    {
        LogLevel = 1,
        LogType = 2,
        LogDate = 3,
    }
}
