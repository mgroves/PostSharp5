using System;
using System.Text;
using System.Windows.Forms;

namespace TransactionManagement
{
    public partial class CharityManager : Form
    {
        // aside: hardcoding dependencies like this is not usually a good idea
        // (see the blog post in the series on Lazy Loading dependencies)
        public ICharityService CharityService = new CharityService();
        public ILogService LogService = new LogService();

        public CharityManager()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshCharities();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error, please try again later", "Error Message for user");
            }
            RefreshLog();
        }

        private void simulateButton_Click(object sender, EventArgs e)
        {
            try
            {
                CharityService.UpdateACharity();
                RefreshCharities();
            }
            catch(Exception)
            {
                MessageBox.Show("There was an error, please try again later", "Error Message for user");
            }
            RefreshLog();
        }

        private void RefreshCharities()
        {
            charityListView.Items.Clear();
            var charities = CharityService.GetAllWhoResponded();
            foreach (var charity in charities)
            {
                charityListView.Items.Add(MapCharityToListViewItem(charity));
            }
        }

        private void RefreshLog()
        {
            var sb = new StringBuilder();
            foreach (var message in LogService.GetAllLogMessages())
            {
                sb.AppendLine(message);
            }
            logTextbox.Text = sb.ToString();
        }

        private static ListViewItem MapCharityToListViewItem(Charity charity)
        {
            return new ListViewItem(new [] { charity.Name, charity.CIN, charity.CountyName });
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            LogService.ClearLog();
            RefreshLog();
        }
    }
}
