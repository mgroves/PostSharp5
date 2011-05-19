using System;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace LoggingAuditing
{
    [Serializable]
    public class TransactionAuditAttribute : OnMethodBoundaryAspect
    {
        private string _methodName;
        private Type _className;
        private int _amountParameterIndex = -1;

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            _methodName = method.Name;
            _className = method.DeclaringType;

            var parameters = method.GetParameters();
            for(int i=0;i<parameters.Length;i++)
            {
                if(parameters[i].Name == "amount")
                {
                    _amountParameterIndex = i;
                }
            }
        }

        public override bool CompileTimeValidate(MethodBase method)
        {
            if (_amountParameterIndex == -1)
            {
                Message.Write(SeverityType.Warning, "999",
                              "TransactionAudit was unable to find an 'amount' to audit in {0}.{1}", _className, _methodName);
                return false;
            }
            return true;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (_amountParameterIndex != -1)
            {
                Logger.Write(_className + "." + _methodName + ", amount: " + args.Arguments[_amountParameterIndex]);
            }
        }
    }
}