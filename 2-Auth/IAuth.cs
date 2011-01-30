namespace Auth
{
    public interface IAuth
    {
        string GetCurrentUsername();
        bool CurrentUserHasPermission(GovtForm singleForm, Permission permission);
    }
}