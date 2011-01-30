using System;
using System.Data;
using PostSharp.Aspects;

namespace TransactionManagement
{
    [Serializable]
    public class TransactionScopeAttribute : MethodInterceptionAspect
    {
        [NonSerialized] private ICharityService _charityService;
        [NonSerialized] private ILogService _logService;

        private int _maxRetries;
        private string _methodName;
        private string _className;

        public override void CompileTimeInitialize(System.Reflection.MethodBase method, AspectInfo aspectInfo)
        {
            _methodName = method.Name;
            _className = method.DeclaringType.Name;
        }

        public override void RuntimeInitialize(System.Reflection.MethodBase method)
        {
            _charityService = new CharityService();
            _logService = new LogService();
            _maxRetries = 4;            // you could load this from XML instead
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var retries = 1;
            while (retries <= _maxRetries)
            {
                try
                {
                    _charityService.BeginTransaction();
                    args.Proceed();
                    _charityService.CommitTransaction();
                    break;
                }
                catch (DataException)
                {
                    _charityService.RollbackTransaction();
                    if (retries <= _maxRetries)
                    {
                        _logService.AddLogMessage(string.Format("[{3}] Retry #{2} in {0}.{1}", _methodName, _className, retries, DateTime.Now));
                        retries++;
                    }
                    else
                    {
                        _logService.AddLogMessage(string.Format("[{2}] Max retries exceeded in {0}.{1}", _methodName, _className, DateTime.Now));
                        _logService.AddLogMessage("------------------------------------------");
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    _charityService.RollbackTransaction();
                    _logService.AddLogMessage(string.Format("[{3}] {2} in {0}.{1}", _methodName, _className, ex.GetType().Name, DateTime.Now));
                    _logService.AddLogMessage("------------------------------------------");
                    throw;
                }
            }
            _logService.AddLogMessage("------------------------------------------");
        }
    }
}