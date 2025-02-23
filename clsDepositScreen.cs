using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsDepositScreen : clsScreen
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

        public static void ShowDepositScreen()
        {
            _DrawScreenHeader("\t   Deposit Screen");

            string AccountNumber = _ReadAccountNumber();

            while (!clsBankClient.IsClientExist(AccountNumber))
            {
                Console.WriteLine($"\nClient with [{AccountNumber}] does not exist.");
                AccountNumber = _ReadAccountNumber();
            }

            clsBankClient Client1 = clsBankClient.Find(AccountNumber);
            _PrintClient(Client1);

            Console.Write("\nPlease enter deposit amount? ");
            double Amount = clsInputValidate.ReadDbNumber();

            Console.Write("\nAre you sure you want to perform this transaction? (Y/N) ");
            char Answer = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (Answer == 'Y')
            {
                Client1.Deposit(Amount);
                Console.WriteLine("\nAmount Deposited Successfully.");
                Console.WriteLine($"\nNew Balance Is: {Client1.AccountBalance}");
            }
            else
            {
                Console.WriteLine("\nOperation was cancelled.");
            }
        }
    }

}

