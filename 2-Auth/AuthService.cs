using System;

namespace Auth
{
    public class AuthService : IAuth
    {
        public string GetCurrentUsername()
        {
            return Environment.UserName;
        }

        public bool CurrentUserHasPermission(GovtForm singleForm, Permission permission)
        {
            return singleForm.UserName == GetCurrentUsername();
        }
    }
}