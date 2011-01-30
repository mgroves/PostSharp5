using System;
using System.Windows.Forms;

namespace Auth
{
    public partial class MainGovernmentForm : Form
    {
        // aside: hardcoding dependencies like this is not usually a good idea
        // (see the first blog post in the series on Lazy Loading dependencies)
        public IGovtFormService GovtFormService = new GovtFormService();
        public IAuth Auth = new AuthService();

        public MainGovernmentForm()
        {
            InitializeComponent();

            RefreshGovtForms();
        }

        private void RefreshGovtForms()
        {
            allformsListview.Items.Clear();
            var allForms = GovtFormService.GetAllForms();
            foreach (var govtForm in allForms)
            {
                allformsListview.Items.Add(
                    new ListViewItem(new[]
                                         {
                                             govtForm.FormId.ToString(),
                                             govtForm.UserName
                                         }));
            }
        }

        private void submitformButton_Click(object sender, EventArgs e)
        {
            var formToSubmit = new GovtForm {FormInformation = formTextbox.Text, UserName = Auth.GetCurrentUsername()};
            GovtFormService.SubmitForm(formToSubmit);
            RefreshGovtForms();
            formTextbox.Text = "";
            MessageBox.Show("Your form has been submitted!");
        }

        private void viewformButton_Click(object sender, EventArgs e)
        {
            if(allformsListview.SelectedItems.Count == 1)
            {
                var guidText = allformsListview.SelectedItems[0].Text;
                var guid = Guid.Parse(guidText);
                var govtForm = GovtFormService.GetFormById(guid);
                if (govtForm != null)
                {
                    MessageBox.Show(govtForm.FormInformation, "Form Details");
                }
            }
        }
    }
}
