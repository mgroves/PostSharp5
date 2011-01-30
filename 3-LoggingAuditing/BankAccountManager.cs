using System;
using System.Linq;
using System.Windows.Forms;

namespace LoggingAuditing
{
    public partial class BankAccountManager : Form
    {
        public BankAccountManager()
        {
            InitializeComponent();

            RefreshBalance();
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            BankAccount.Deposit(decimal.Parse(this.amountTextbox.Text));
            RefreshBalance();
        }

        [TransactionAudit]
        private void withdrawlButton_Click(object sender, EventArgs e)
        {
            BankAccount.Withdrawl(decimal.Parse(this.amountTextbox.Text));
            RefreshBalance();
        }

        private void creditButton_Click(object sender, EventArgs e)
        {
            BankAccount.Credit(decimal.Parse(this.amountTextbox.Text));
            RefreshBalance();
        }

        private void feeButton_Click(object sender, EventArgs e)
        {
            BankAccount.Fee(decimal.Parse(this.amountTextbox.Text));
            RefreshBalance();
        }

        private void RefreshBalance()
        {
            this.balanceLabel.Text = BankAccount.Balance.ToString("c");

            RefreshLog();
        }

        public void RefreshLog()
        {
            this.logListbox.Items.Clear();
            this.logListbox.Items.AddRange(Logger.Log.ToArray());
        }
    }
}
