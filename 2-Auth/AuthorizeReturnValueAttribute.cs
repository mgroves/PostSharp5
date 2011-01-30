using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;

namespace Auth
{
    [Serializable]
    [AspectRoleDependency(AspectDependencyAction.Order, AspectDependencyPosition.After, StandardRoles.Caching)]
    public class AuthorizeReturnValueAttribute : OnMethodBoundaryAspect
    {
        [NonSerialized] private IAuth Auth;

        public override void RuntimeInitialize(System.Reflection.MethodBase method)
        {
            Auth = new AuthService();
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            var singleForm = args.ReturnValue as GovtForm;
            if (singleForm != null)
            {
                if(Auth.CurrentUserHasPermission(singleForm, Permission.Read))
                {
                    MessageBox.Show("You are not authorized to view the details of that form", "Authorization Denied!");
                    args.ReturnValue = null;
                }
                return;
            }

            var formCollection = args.ReturnValue as IEnumerable<GovtForm>;
            if (formCollection != null)
            {
                args.ReturnValue = formCollection.Where(f => Auth.CurrentUserHasPermission(f, Permission.Read));
                return;
            }
        }
    }

    [Serializable]
    [ProvideAspectRole(StandardRoles.Caching)]
    public class CachingAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            // do caching stuff
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            // do caching stuff
        }
    }
}