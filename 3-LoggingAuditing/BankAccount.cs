namespace LoggingAuditing
{
    [TransactionAudit]
    public class BankAccount
    {
        static BankAccount()
        {
            Balance = 0;
        }
        public static decimal Balance { get; private set; }

        public static void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public static void Withdrawl(decimal amount)
        {
            Balance -= amount;
        }

        public static void Credit(decimal amount)
        {
            Balance += amount;
        }

        public static void Fee(decimal amount)
        {
            Balance -= amount;
        }
    }
}