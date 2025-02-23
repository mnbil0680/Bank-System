using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsFindClientScreen : clsScreen
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

        public static void ShowFindClientScreen()
        {
            _DrawScreenHeader("\tFind Client Screen");

            Console.Write("\nPlease Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            while (!clsBankClient.IsClientExist(accountNumber))
            {
                Console.Write("\nAccount number is not found, choose another one: ");
                accountNumber = Console.ReadLine();
            }

            clsBankClient client = clsBankClient.Find(accountNumber);

            if (!client.IsEmpty())
            {
                Console.WriteLine("\nClient Found :-)\n");
            }
            else
            {
                Console.WriteLine("\nClient Was Not Found :-(\n");
            }

            _PrintClient(client);
        }
    }
}
