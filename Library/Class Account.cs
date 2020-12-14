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
        private readonly Class_Account[] _accounts;

        public AccountManager(Class_Account[] accounts)
        {
            _accounts = accounts;
        }
        public Class_Account[] GetSortedAccounts()
        {
            Class_Account[] arr = this._accounts;
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

    public class Class_Account : IClassAccount
    {
        private Class_Account[] _accounts;
        private readonly Random _random = new Random();
        
        Dictionary<int,AccountDetails> _dictionary = new Dictionary<int,AccountDetails>();
        private readonly decimal _amount;

        public Class_Account(string Currency)
        {
            _Id = _random.Next(100000,100000000);
            try
            {
                if (Currency == "EUR" || Currency == "USD" || Currency == "UAH")
                    _Currency = Currency;
                else
                {
                    throw new NotSupportedException(nameof(Currency));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception in constructor of Class_Amount. Not supported currency");
            }
            _amount = 0;
            _dictionary.Add(_Id,new AccountDetails{ Amount = _Amount, Currency = _Currency});
        }

        public int _Id { get; set; }
        public string _Currency { get; set; }

        private decimal _Amount => _amount;

        public void Deposit(decimal amount, string Currency)
        {
            if(Currency != _Currency)
                switch (Currency)
                {
                    case "EUR":
                        if (_Currency == "USD")
                            amount = Decimal.Multiply(amount,1.19m);
                        else if (_Currency == "UAH")
                            amount = Decimal.Multiply(amount, 33.63m);
                        break;
                    case "USD":
                        if (_Currency == "UAH")
                            amount = Decimal.Multiply(amount, 28.36m);
                        else if (_Currency == "EUR")
                            amount = Decimal.Divide(amount, 1.19m);
                        break;
                    case "UAH":
                        if (_Currency == "EUR")
                            amount = Decimal.Divide(amount, 33.63m);
                        else if (_Currency == "USD")
                            amount = Decimal.Divide(amount, 28.36m);
                        break;
                }
            _dictionary[_Id].Amount = amount;
        }

        public void Withdraw(decimal amount, string Currency)
        {
            var convertedCurrency = OutsideToInside(amount,Currency);
            if(_dictionary[_Id].Amount - convertedCurrency <=0)
                throw new InvalidOperationException($"Not enough money on {_dictionary[_Id]} account!");
            _dictionary[_Id].Amount = _dictionary[_Id].Amount - convertedCurrency;
        }

        public decimal GetBalance(string Currency)
        {
            var convertCurrency = Converter(_dictionary[_Id].Amount,Currency);
            //Console.WriteLine($"Your ID: {_dictionary[_Id]} and your balance is {convertCurrency} {Currency}");
            return convertCurrency;
        }

        public Class_Account[] GetSortedAccounts(Class_Account[] arr)
        {
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

        public void GetAccount(int ID)
        {
            throw new NotImplementedException();
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

        private decimal Converter(decimal amount,string Currency)
        {
            if(Currency != _Currency)
                switch (_Currency)
                {
                    case "EUR":
                        if (Currency == "USD")
                            return Decimal.Multiply(amount,1.19m);
                        else if (Currency == "UAH")
                            return Decimal.Multiply(amount, 33.63m);
                        break;
                    case "USD":
                        if (Currency == "UAH")
                            return Decimal.Multiply(amount, 28.36m);
                        else if (Currency == "EUR")
                            return Decimal.Divide(amount, 1.19m);
                        break;
                    case "UAH":
                        if (Currency == "EUR")
                            return Decimal.Divide(amount, 33.63m);
                        else if (Currency == "USD")
                            return Decimal.Divide(amount, 28.36m);
                        break;
                }

            return amount;
        }
    }
}