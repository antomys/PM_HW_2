using System;
using System.Collections.Generic;

namespace Library
{
    class AccountDetails
    {
        public decimal Amount;
        public string Currency;
    }

    public class AccountManager
    {
        private readonly Account[] _accounts;

        public AccountManager(Account[] accounts)
        {
            _accounts = accounts;
        }
        public Account[] GetSortedAccounts()
        {
            Account[] arr = this._accounts;
            int n = arr.Length; 
            for (int i = 0; i < n - 1; i++) 
            for (int j = 0; j < n - i - 1; j++) 
                if (arr[j]._Id > arr[j + 1]._Id) 
                { 
                    // swap temp and arr[i] 
                    int temp = arr[j]._Id; 
                    arr[j]._Id = arr[j + 1]._Id; 
                    arr[j + 1]._Id = temp; 
                }

            return arr;
        }
    }

    public class Account : IClassAccount
    {
        private Dictionary<int, AccountDetails> _dictionary;
        private readonly decimal _amount;

        public Account(string сurrency)
        {
            _Id = new Random().Next(100000,100000000);
            try
            {
                if (сurrency == "EUR" || сurrency == "USD" || сurrency == "UAH")
                    _Сurrency = сurrency;
                else
                {
                    throw new NotSupportedException(nameof(сurrency));
                }
            }
            catch
            {
                Console.WriteLine($"Exception in constructor of Class_Amount. Not supported currency");
            }
            _amount = 0;
            _dictionary=new Dictionary<int, AccountDetails> { { _Id, new AccountDetails { Amount = _Amount, Currency = _Сurrency } } };
        }

        public int _Id { get; set; }
        public string _Сurrency { get;}

        private decimal _Amount => _amount;

        public void Deposit(decimal amount, string сurrency)
        {
            if(сurrency != _Сurrency)
                switch (сurrency)
                {
                    case "EUR":
                        if (_Сurrency == "USD")
                            amount = Decimal.Multiply(amount,1.19m);
                        else if (_Сurrency == "UAH")
                            amount = Decimal.Multiply(amount, 33.63m);
                        break;
                    case "USD":
                        if (_Сurrency == "UAH")
                            amount = Decimal.Multiply(amount, 28.36m);
                        else if (_Сurrency == "EUR")
                            amount = Decimal.Divide(amount, 1.19m);
                        break;
                    case "UAH":
                        if (_Сurrency == "EUR")
                            amount = Decimal.Divide(amount, 33.63m);
                        else if (_Сurrency == "USD")
                            amount = Decimal.Divide(amount, 28.36m);
                        break;
                }
            _dictionary[_Id].Amount = amount;
        }

        public void Withdraw(decimal amount, string сurrency)
        {
            var convertedCurrency = OutsideToInside(amount,сurrency);
            if(_dictionary[_Id].Amount - convertedCurrency <=0)
                throw new InvalidOperationException($"Not enough money on {_dictionary[_Id]} account!");
            _dictionary[_Id].Amount = _dictionary[_Id].Amount - convertedCurrency;
        }

        public decimal GetBalance(string сurrency)
        {
            var convertCurrency = Converter(_dictionary[_Id].Amount,сurrency);
            //Console.WriteLine($"Your ID: {_dictionary[_Id]} and your balance is {convertCurrency} {Currency}");
            return convertCurrency;
        }
        private decimal OutsideToInside(decimal outsideAmount,string outsideCurrency)
        {
            if(outsideCurrency != _dictionary[_Id].Currency)
                switch (_dictionary[_Id].Currency)
                {
                    case "EUR":
                        if (outsideCurrency == "USD")
                            return Decimal.Divide(outsideAmount,1.19m);
                        else if (outsideCurrency == "UAH")
                            return Decimal.Divide(outsideAmount, 33.63m);
                        break;
                    case "USD":
                        if (outsideCurrency == "UAH")
                            return Decimal.Divide(outsideAmount, 28.36m);
                        else if (outsideCurrency == "EUR")
                            return Decimal.Multiply(outsideAmount, 1.19m);
                        break;
                    case "UAH":
                        if (outsideCurrency == "EUR")
                            return Decimal.Multiply(outsideAmount, 33.63m);
                        else if (outsideCurrency == "USD")
                            return Decimal.Multiply(outsideAmount, 28.36m);
                        break;
                    default:
                        return 0;
                }
            return outsideAmount;
        }

        private decimal Converter(decimal amount,string currency)
        {
            if(currency != _Сurrency)
                switch (_Сurrency)
                {
                    case "EUR":
                        if (currency == "USD")
                            return Decimal.Multiply(amount,1.19m);
                        else if (currency == "UAH")
                            return Decimal.Multiply(amount, 33.63m);
                        break;
                    case "USD":
                        if (currency == "UAH")
                            return Decimal.Multiply(amount, 28.36m);
                        else if (currency == "EUR")
                            return Decimal.Divide(amount, 1.19m);
                        break;
                    case "UAH":
                        if (currency == "EUR")
                            return Decimal.Divide(amount, 33.63m);
                        else if (currency == "USD")
                            return Decimal.Divide(amount, 28.36m);
                        break;
                }

            return amount;
        }
    }
}