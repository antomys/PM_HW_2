namespace Library
{
    public interface IClassAccount
    {
        void Deposit(decimal amount, string сurrency);
        void Withdraw(decimal amount, string сurrency);
        decimal GetBalance(string сurrency);
    }
}