using System;
using System.Collections;
using System.Windows.Forms;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using Message = PostSharp.Extensibility.Message;

namespace LazyLoading_CompileTimeInitialize
{
    public partial class UserForm : Form
    {
        [LoadDependency] private IUserService _userService;

        // a non-interface
        //[LoadDependency] DateTime invalidDependency1;

        // an interface with no defined mapping
        //[LoadDependency] IEnumerable invalidDependency2;

        // I'm making this a public property only so that
        // the LoadDependency can write to it for demonstration purposes
        public ListBox LogListBox { get { return _logListBox; } }

        public UserForm()
        {
            InitializeComponent();

            LogListBox.Items.Add(_userService.AuthenticateUser("mgroves", "swordfish"));
            LogListBox.Items.Add(_userService.AuthenticateUser("gael", "12345"));
            LogListBox.Items.Add(_userService.AuthenticateUser("britt", "password"));
            LogListBox.Items.Add(_userService.AuthenticateUser("billg", "win95rules"));
            LogListBox.Items.Add(_userService.AuthenticateUser("shorn", "ilikepie"));
        }
    }

    [Serializable]
    public sealed class LoadDependency : LocationInterceptionAspect
    {
        private Type _type;

        public override bool CompileTimeValidate(LocationInfo locationInfo)
        {
            if (!locationInfo.LocationType.IsInterface)
            {
                Message.Write(SeverityType.Error, "001", "LoadDependency can only be used on Interfaces in {0}.{1}", locationInfo.DeclaringType, locationInfo.Name);
                return false;
            }

            _type = ObjectFactory.GetInstanceType(locationInfo.LocationType);
            if (_type == null)
            {
                Message.Write(SeverityType.Error, "002", "A concrete type was not found for {0}.{1}", locationInfo.DeclaringType, locationInfo.Name);
                return false;
            }
            return true;
        }

        public override void OnGetValue(LocationInterceptionArgs args)
        {
            var form = (UserForm)args.Instance;  // this form is only used here to write to a listbox for demonstration

            args.ProceedGetValue();
            if (args.Value == null)
            {
                form.LogListBox.Items.Add("Instantiating UserService");
                args.SetNewValue(Activator.CreateInstance(_type));
                args.ProceedGetValue();
            }
            else
            {
                form.LogListBox.Items.Add("Using a UserService that has already been created");
            }
        }
    }

    // this is just a "dummy" objectfactory
    // use the IoC service locator of your choice (like StructureMap) instead
    internal static class ObjectFactory
    {
        public static Type GetInstanceType(Type locationType)
        {
            // note that this is a very silly service locator
            // since it returns a ProductRepository no matter
            // what Type is passed in
            if (locationType == typeof(IUserService))
            {
                return typeof(UserService);
            }
            return null;
        }
    }

    // another "dummy" interface and service
    // plug in your own real services/interfaces
    public interface IUserService
    {
        string AuthenticateUser(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly Random _rand;

        public UserService()
        {
            _rand = new Random(DateTime.Now.Millisecond);
        }

        public string AuthenticateUser(string username, string password)
        {
            return username + " was logged in: " + (_rand.NextDouble() < 0.5);
        }
    }
}
