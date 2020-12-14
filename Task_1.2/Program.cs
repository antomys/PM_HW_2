

using System;
using Library;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Class_Account[] accounts = new Class_Account[100];
            for (var i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Class_Account("UAH");
            }
            var accManager = new AccountManager(accounts);

            accManager.GetSortedAccounts();
            
            Console.WriteLine("First ten accounts are: \n");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ID:{accounts[i]._Id}");
            }
            
            Console.WriteLine("Last ten accounts are: \n");
            for (int i = accounts.Length-10; i < accounts.Length; i++)
            {
                Console.WriteLine($"ID:{accounts[i]._Id}");
            }
        }
    }
}