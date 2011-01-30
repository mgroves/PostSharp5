using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using Message = PostSharp.Extensibility.Message;

namespace LazyLoading_CompileTimeInitialize
{
    public partial class UserForm : Form
    {
        [LazyLoad]
        private IUserService _userService;

        // I'm making this a public property only so that
        // the LazyLoadAttribute can write to it for demonstration purposes
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

    // another "dummy" interface and service
    // plug in your own real services/interfaces
    public interface IUserService
    {
        string AuthenticateUser(string username, string password);
    }

    public class UserService : IUserService
    {
        public string AuthenticateUser(string username, string password)
        {
            var r = new Random(DateTime.Now.Millisecond);
            return username + " was logged in: " + (r.NextDouble() < 0.5);
        }
    }

    [Serializable]
    public sealed class LazyLoadAttribute : LocationInterceptionAspect
    {
        private Type _type;

        public override bool CompileTimeValidate(PostSharp.Reflection.LocationInfo locationInfo)
        {
            if (!locationInfo.LocationType.IsInterface)
            {
                Message.Write(SeverityType.Error, "001", "LazyLoad can only be used on Interfaces in {0}.{1}", locationInfo.DeclaringType, locationInfo.Name);
                return false;
            }

            _type = DependencyMap.GetConcreteType(locationInfo.LocationType);
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

    // this DependencyMap only contains one interface<->dependency mapping
    // but more can be easily added
    public static class DependencyMap
    {
        public static Type GetConcreteType(Type locationType)
        {
            var dict = new Dictionary<Type, Type>();
            // dict.Add(interface type, dependency type)
            dict.Add(typeof(IUserService), typeof(UserService));

            if (dict.ContainsKey(locationType))
            {
                return dict[locationType];
            }
            return null;
        }
    }
}
