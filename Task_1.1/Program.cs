using System;
using Library;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.\n");
            Console.WriteLine("Creating first account (EUR):");
            Class_Account EURaccount = new Class_Account("EUR");
            Console.WriteLine($"Created with {EURaccount._Id}");
            
            Console.WriteLine("Creating second account (USD):");
            Class_Account USDaccount = new Class_Account("USD");
            Console.WriteLine($"Created with {USDaccount._Id}");
            
            Console.WriteLine("Creating third account (UAH):");
            Class_Account UAHaccount = new Class_Account("UAH");
            Console.WriteLine($"Created with {UAHaccount._Id}");

            Console.WriteLine("\n2.\n");
            Console.WriteLine("Adding 10 EUR to EUR account");
            EURaccount.Deposit(10,"EUR");
            Console.WriteLine($"Account with {EURaccount._Id} has {EURaccount.GetBalance("EUR")}" +
                              $" EUR");

            Console.WriteLine("\n3.\n");
            Console.WriteLine("WIthdraw 3 UAH from EUR account");
            EURaccount.Withdraw(3,"UAH");
            Console.WriteLine($"Account with {EURaccount._Id} has {EURaccount.GetBalance("EUR")}" +
                              $" EUR");
            
            Console.WriteLine("\n4.\n");
            Console.WriteLine("Adding 121 USD to UAH account");
            UAHaccount.Deposit(121,"USD");
            Console.WriteLine($"Account with {UAHaccount._Id} has {UAHaccount.GetBalance("UAH")}" +
                              $" UAH");
            
            Console.WriteLine("\n5.\n");
            Console.WriteLine("Withdrawing 5 USD from USD account");
            try
            {
                USDaccount.Withdraw(5,"USD");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            Console.WriteLine("\n6.\n");
            Console.WriteLine("Creating account with PLN");
            try
            {
                Class_Account classAccount = new Class_Account("PLN");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            Console.WriteLine("\n7.\n");
            Console.WriteLine("All balances:");
            USDaccount.GetBalance("USD");
            Console.WriteLine($"Account with currency {EURaccount._Currency} has " +
                              $"{EURaccount.GetBalance(EURaccount._Currency)} balance\n");
            Console.WriteLine($"Account with currency {USDaccount._Currency} has " +
                              $"{USDaccount.GetBalance(USDaccount._Currency)} balance\n");
            Console.WriteLine($"Account with currency {UAHaccount._Currency} has " +
                              $"{UAHaccount.GetBalance(UAHaccount._Currency)} balance\n");
        }
    }
}