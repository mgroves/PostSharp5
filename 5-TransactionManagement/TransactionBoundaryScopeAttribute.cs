using System;
using PostSharp.Aspects;

namespace TransactionManagement
{
    [Serializable]
    public class TransactionBoundaryScopeAttribute : OnMethodBoundaryAspect
    {
        [NonSerialized] private ICharityService _charityService;
        private string _methodName;
        private string _className;

        public override void CompileTimeInitialize(System.Reflection.MethodBase method, AspectInfo aspectInfo)
        {
            _className = method.DeclaringType.Name;
            _methodName = method.Name;
        }

        public override void RuntimeInitialize(System.Reflection.MethodBase method)
        {
            // in practice, the begin/rollback/commit might be in a more general service
            // but for convenience in this demo, they reside in CharityService alongside
            // the normal repository methods
            _charityService = new CharityService();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _charityService.BeginTransaction();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            _charityService.RollbackTransaction();
            var loggingMessage = string.Format("exception in {0}.{1}", _className, _methodName);
            // do some logging
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _charityService.CommitTransaction();
        }
    }
}