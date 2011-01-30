using System.Collections.Generic;

namespace TransactionManagement
{
    public interface ILogService
    {
        void AddLogMessage(string message);
        IEnumerable<string> GetAllLogMessages();
        void ClearLog();
    }
}