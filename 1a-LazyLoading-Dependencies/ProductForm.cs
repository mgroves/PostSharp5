using System;
using System.Windows.Forms;
using PostSharp.Aspects;

namespace WindowsFormsApplication1
{
    public partial class ProductForm : Form
    {
        [LoadDependency] private IProductRepository _productRepository;

        // I'm making this a public property only so that
        // the LoadDependencyAttribute can write to it for demonstration purposes
        public ListBox LogListBox { get { return _logListBox; } }

        public ProductForm()
        {
            InitializeComponent();

            LogListBox.Items.Add(_productRepository.GetProductDescription("washing powder"));
            LogListBox.Items.Add(_productRepository.GetProductDescription("can of tuna fish"));
            LogListBox.Items.Add(_productRepository.GetProductDescription("soda"));
            LogListBox.Items.Add(_productRepository.GetProductDescription("book"));
            LogListBox.Items.Add(_productRepository.GetProductDescription("water bottle"));
        }
    }

    // this is just a "dummy" objectfactory
    // use the IoC service locator of your choice (like StructureMap) instead
    internal static class ObjectFactory
    {
        public static object GetInstance(Type locationType)
        {
            // note that this is a very silly service locator
            // since it returns a ProductRepository no matter
            // what Type is passed in
            return new ProductRepository();
        }
    }

    // this is just a "dummy" repository and interface
    // use your own domain's services/repositories instead
    public interface IProductRepository
    {
        string GetProductDescription(string productName);
    }

    public class ProductRepository : IProductRepository
    {
        public string GetProductDescription(string productName)
        {
            return "Product: " + productName;
        }
    }

    [Serializable]
    public sealed class LoadDependencyAttribute : LocationInterceptionAspect
    {
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            var form = (ProductForm) args.Instance; // this form is only used here to write to a listbox for demonstration

            args.ProceedGetValue(); // this actually fetches the field and populates the args.Value
            if (args.Value == null)
            {
                form.LogListBox.Items.Add("Instantiating ProductService");
                var locationType = args.Location.LocationType;
                var instantiation = ObjectFactory.GetInstance(locationType);

                if (instantiation != null)
                {
                    args.SetNewValue(instantiation);
                }
                args.ProceedGetValue();
            }
            else
            {
                form.LogListBox.Items.Add("Using a ProductService that has already been instantiated");
            }
        }
    }
}
