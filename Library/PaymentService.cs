using System;
using Library.Block_3.Types;
using Library.Types;

namespace Library
{
    public class PaymentService
    {
        private readonly PaymentMethodBase[] _availablePaymentMethod;

        public PaymentService()
        {
            _availablePaymentMethod = new PaymentMethodBase[]
            {
                new CreditCard(), new Privet48(), new Stereobank(), new GiftVoucher()
            };
        }

        public void StartDeposit(decimal amount, string currency)
        {
            short input;
            Console.WriteLine("Please choose Payment Method:");
            for (int i = 0; i < _availablePaymentMethod.Length; i++)
            {
                if(_availablePaymentMethod[i] is ISupportDeposit)
                    Console.WriteLine($"{i+1}. {_availablePaymentMethod[i].Name}");
            }
            do
            {
                Int16.TryParse(Console.In.ReadLine(), out input);
                input -= 1;
                if(input < 0 || input > _availablePaymentMethod.Length)
                    Console.WriteLine("Invalid. Please try again");
            } while (input < 0 && input > _availablePaymentMethod.Length);
            
            var deposit = (ISupportDeposit)_availablePaymentMethod[input];
            deposit.StartDeposit(amount,currency);

        }
        public void StartWithdraw(decimal amount, string currency)
        {
            short input;
            Console.WriteLine("Please choose Payment Method:");
            for (int i = 0; i < _availablePaymentMethod.Length; i++)
            {
                if(_availablePaymentMethod[i] is ISupportWithdrawal)
                    Console.WriteLine($"{i+1}. {_availablePaymentMethod[i].Name}");
            }
            do
            {
                Int16.TryParse(Console.In.ReadLine(), out input);
                input -= 1;
                if(input < 0 || input > _availablePaymentMethod.Length)
                    Console.WriteLine("Invalid. Please try again");
            } while (input < 0 && input > _availablePaymentMethod.Length);
            var withdraw = (ISupportWithdrawal)_availablePaymentMethod[input];
            withdraw.StartWithdrawal(amount,currency);
        }
    }
}