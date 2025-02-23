using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsWithdrawScreen : clsScreen
    {
        private static void _PrintClient(clsBankClient Client)
        {
            Console.WriteLine("\nClient Card:");
            Console.WriteLine("___________________");
            Console.WriteLine($"FirstName   : {Client.FirstName}");
            Console.WriteLine($"LastName    : {Client.LastName}");
            Console.WriteLine($"Full Name   : {Client.FullName()}");
            Console.WriteLine($"Email       : {Client.Email}");
            Console.WriteLine($"Phone       : {Client.Phone}");
            Console.WriteLine($"Acc. Number : {Client.AccountNumber()}");
            Console.WriteLine($"Password    : {Client.PinCode}");
            Console.WriteLine($"Balance     : {Client.AccountBalance}");
            Console.WriteLine("___________________\n");
        }

        private static string _ReadAccountNumber()
        {
            Console.Write("\nPlease enter Account Number? ");
            return Console.ReadLine();
        }

        public static void ShowWithdrawScreen()
        {
            _DrawScreenHeader("\t   Withdraw Screen");

            string AccountNumber = _ReadAccountNumber();

            while (!clsBankClient.IsClientExist(AccountNumber))
            {
                Console.WriteLine($"\nClient with [{AccountNumber}] does not exist.");
                AccountNumber = _ReadAccountNumber();
            }

            clsBankClient Client1 = clsBankClient.Find(AccountNumber);
            _PrintClient(Client1);

            Console.Write("\nPlease enter Withdraw amount? ");
            double Amount = clsInputValidate.ReadDbNumber();

            Console.Write("\nAre you sure you want to perform this transaction? (Y/N) ");
            char Answer = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (Answer == 'Y')
            {
                if (Client1.Withdraw(Amount))
                {
                    Console.WriteLine("\nAmount Withdrawn Successfully.");
                    Console.WriteLine($"\nNew Balance Is: {Client1.AccountBalance}");
                }
                else
                {
                    Console.WriteLine("\nCannot withdraw, Insufficient Balance!");
                    Console.WriteLine($"\nAmount to withdraw is: {Amount}");
                    Console.WriteLine($"\nYour Balance is: {Client1.AccountBalance}");
                }
            }
            else
            {
                Console.WriteLine("\nOperation was cancelled.");
            }
        }
    }

}

