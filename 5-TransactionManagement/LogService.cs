using System.Collections.Generic;

namespace TransactionManagement
{
    public class LogService : ILogService
    {
        private static readonly IList<string> _log = new List<string>();

        public void AddLogMessage(string message)
        {
            _log.Add(message);
        }

        public IEnumerable<string> GetAllLogMessages()
        {
            return _log;
        }

        public void ClearLog()
        {
            _log.Clear();
        }
    }
}