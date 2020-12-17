using System;
using System.Collections.Generic;

namespace Library
{
    
    public class Player
    {
        private readonly Dictionary<int, Player> _dictionary;
        public Player(string firstName, string lastName, string email, string password, string currency)
        {
            Account = new Account(currency);
            Id = new Random().Next(100000,100000000);
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            _dictionary=new Dictionary<int, Player> { { Id, this } };
        }
        private int Id { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }
        public Account Account { get; set; }

        public bool IsPasswordValid(string passord)
        {
            if (_dictionary[Id].Password == passord)
                return true;
            return false;
        }

        public void Deposit(decimal amount, string currency)
        {
            var PlayerCurrency = _dictionary[Id].Account.Currency;
            var PlayerAmount = _dictionary[Id].Account.Amount;
            if (PlayerCurrency == currency)
                _dictionary[Id].Account.Amount = PlayerAmount + amount;
            else
            {
                var converted = OutsideToInside(amount, currency);
                _dictionary[Id].Account.Amount = converted + PlayerAmount;
            }
        }
        public void Withdraw(decimal amount, string currency)
        {
            var convertedCurrency = OutsideToInside(amount,currency);
            if(_dictionary[Id].Account.Amount - convertedCurrency <=0)
                throw new InvalidOperationException($"Not enough money on {_dictionary[Id]} account!");
            _dictionary[Id].Account.Amount -= convertedCurrency;
        }
        
        public decimal GetBalance(string сurrency)
        {
            var convertCurrency = Converter(_dictionary[Id].Account.Amount,сurrency);
            //Console.WriteLine($"Your ID: {_dictionary[_Id]} and your balance is {convertCurrency} {Currency}");
            return Math.Round(convertCurrency,2);
        }
        
        private decimal Converter(decimal amount,string currency)
        {
            if(currency != _dictionary[Id].Account.Currency)
                switch (_dictionary[Id].Account.Currency)
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
        
        private decimal OutsideToInside(decimal outsideAmount,string outsideCurrency)
        {
            if(outsideCurrency != _dictionary[Id].Account.Currency)
                switch (_dictionary[Id].Account.Currency)
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
    }
}