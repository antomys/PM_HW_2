using System;
using Library;

namespace Task_4._2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                Exceptions();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void Exceptions()
        {
            PaymentService paymentService = new PaymentService();
            Console.WriteLine("Please enter currency. Available: UAH,USD,EUR");
            var currency = Console.ReadLine().ToUpper();
            if (currency != "USD" && currency != "EUR" && currency != "UAH")
            {
                Console.WriteLine("Try again.");
                Exceptions();
            }
            Console.WriteLine("Please enter amount");
            decimal amount = 0m;
            Decimal.TryParse(Console.ReadLine(), out amount);
            paymentService.StartDeposit(amount,currency);
        }
    }
}