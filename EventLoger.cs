using System.Diagnostics;

namespace Logger
{
    public static class EventLoger
    {
        private static EventLog _log;

        public enum EType
        {
            Error,
            Failure,
            Inform,
            Success,
            Warning
        }

        public static void ConfigEventlog(string logName, string source)
        {
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source,logName);
                }

            _log = new EventLog(logName, ".", source);
        }

        public static void SetEvent(string message, EType eType, int eveId)
        {
            EventLogEntryType type;
            switch(eType)
            {
                case EType.Error: type = EventLogEntryType.Error;
                    break;
                case EType.Failure : type = EventLogEntryType.FailureAudit;
                    break;
                case EType.Inform : type = EventLogEntryType.Information;
                    break;
                case EType.Success : type = EventLogEntryType.SuccessAudit;
                    break;
                case EType.Warning : type = EventLogEntryType.Warning;
                    break;
                default : type = EventLogEntryType.Error;
                    break;
            }
            _log.WriteEntry(message, type, eveId);
        }

        }

    }

