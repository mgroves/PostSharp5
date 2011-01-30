using System;
using System.Linq;
using System.Windows.Forms;

namespace Caching
{
    public partial class CarDealership : Form
    {
        // aside: hardcoding dependencies like this is not usually a good idea
        // (see the blog post in the series on Lazy Loading dependencies)
        public IBlueBookService BlueBookService = new BlueBookService();

        public CarDealership()
        {
            InitializeComponent();

            PopulateDropDowns();
        }

        private void PopulateDropDowns()
        {
            var years = Enumerable.Range(DateTime.Now.Year - 30, 31).ToList();
            years.ForEach(y => yearDropdown.Items.Add(y));

            makemodelDropdown.Items.Add(CarMakeAndModel.FordExplorer);
            makemodelDropdown.Items.Add(CarMakeAndModel.HondaAccord);
            makemodelDropdown.Items.Add(CarMakeAndModel.ToyotaCamry);
        }

        private void bluebookButton_Click(object sender, EventArgs e)
        {
            txtBluebookValue.Text = "";
            if (yearDropdown.SelectedItem != null && makemodelDropdown.SelectedItem != null)
            {
                var year = (int) yearDropdown.SelectedItem;
                var makeModel = (CarMakeAndModel) makemodelDropdown.SelectedItem;
                var value = BlueBookService.GetCarValue(year, makeModel);
                txtBluebookValue.Text = value.ToString("c");
                MessageBox.Show("Done!");
            }
            else
            {
                MessageBox.Show("Please select a Make and Model and a year");
            }
        }
    }
}
