using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsDeleteClientScreen : clsScreen
    {
       
        private static void _PrintClient(clsBankClient client)
        {
            Console.WriteLine("\nClient Card:");
            Console.WriteLine("___________________");
            Console.WriteLine($"First Name   : {client.FirstName}");
            Console.WriteLine($"Last Name    : {client.LastName}");
            Console.WriteLine($"Full Name    : {client.FullName()}");
            Console.WriteLine($"Email        : {client.Email}");
            Console.WriteLine($"Phone        : {client.Phone}");
            Console.WriteLine($"Acc. Number  : {client.AccountNumber()}");
            Console.WriteLine($"Password     : {client.PinCode}");
            Console.WriteLine($"Balance      : {client.AccountBalance}");
            Console.WriteLine("___________________\n");
        }

        public static void ShowDeleteClientScreen()
        {
            _DrawScreenHeader("\tDelete Client Screen");

            Console.Write("\nPlease Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            while (!clsBankClient.IsClientExist(accountNumber))
            {
                Console.Write("\nAccount number is not found, choose another one: ");
                accountNumber = Console.ReadLine();
            }

            clsBankClient client = clsBankClient.Find(accountNumber);
            _PrintClient(client);

            Console.Write("\nAre you sure you want to delete this client (y/n)? ");
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (answer == 'y' || answer == 'Y')
            {
                if (client.Delete())
                {
                    Console.WriteLine("\nClient Deleted Successfully :-)");
                    _PrintClient(client);
                }
                else
                {
                    Console.WriteLine("\nError: Client Was Not Deleted");
                }
            }
        }
    }

}

