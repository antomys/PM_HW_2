namespace Library
{
    public interface IClassAccount
    {
        void Deposit(decimal amount, string Currency);
        void Withdraw(decimal amount, string Currency);
        decimal GetBalance(string Currency);
        Class_Account[] GetSortedAccounts(Class_Account[] a);
        void GetAccount(int ID);
    }
}