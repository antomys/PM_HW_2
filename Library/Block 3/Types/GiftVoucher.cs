using System;
using System.Text.RegularExpressions;

namespace Library.Types
{
    public class GiftVoucher: PaymentMethodBase,ISupportDeposit
    {
        public GiftVoucher()
        {
            Name = "GiftVoucher";
        }
        public void StartDeposit(decimal amount, string currency)
        {
            //Console.WriteLine("Please enter gift voucher price");
            var voucherNumber = "";
            if (amount == 100 || amount == 500 || amount == 1000)
            {
                Console.WriteLine("Please enter 10-digit gift voucher number");
                var expression = new Regex(@"^\d{10}$");
                do
                {
                    voucherNumber = Console.In.ReadLine();
                    if(!expression.IsMatch(voucherNumber))
                        Console.WriteLine("Wrong number. Please try again.");
                } while (!expression.IsMatch(voucherNumber));

                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Please try again. Invalid voucher price");
                Environment.Exit(1);
            }
        }
    }
}