using System;
using System.Reflection;
using System.Windows.Forms;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using Message = PostSharp.Extensibility.Message;

namespace LoggingAuditing
{
    [Serializable]
    public class ExceptionLoggerAttribute : OnExceptionAspect
    {
        private string _methodName;
        private Type _className;

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            _methodName = method.Name;
            _className = method.DeclaringType;
        }

        public override bool CompileTimeValidate(MethodBase method)
        {
            if(!typeof(Form).IsAssignableFrom(method.DeclaringType))
            {
                Message.Write(SeverityType.Error, "003", "ExceptionLogger can only be used on methods in a Form class in {0}.{1}", method.DeclaringType.BaseType, method.Name);
                return false;
            }
            return true;
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Logger.Write(_className + "." + _methodName + " - " + args.Exception);
            MessageBox.Show("There was an error!");
            var form = (BankAccountManager) args.Instance;
            form.RefreshLog();
            args.FlowBehavior = FlowBehavior.Return;
        }
    }
}