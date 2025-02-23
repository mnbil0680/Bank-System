using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsUpdateClientScreen : clsScreen
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

        private static void ReadClientInfo(clsBankClient client)
        {
            Console.Write("\nEnter First Name: ");
            client.FirstName = Console.ReadLine();

            Console.Write("\nEnter Last Name: ");
            client.LastName = Console.ReadLine();

            Console.Write("\nEnter Email: ");
            client.Email = Console.ReadLine();

            Console.Write("\nEnter Phone: ");
            client.Phone = Console.ReadLine();

            Console.Write("\nEnter Pin Code: ");
            client.PinCode = Console.ReadLine();

            Console.Write("\nEnter Account Balance: ");
            client.AccountBalance = float.Parse(Console.ReadLine());
        }

        public static void ShowUpdateClientScreen()
        {
            _DrawScreenHeader("\tUpdate Client Screen");

            Console.Write("\nPlease Enter Client Account Number: ");
            string accountNumber = Console.ReadLine();

            while (!clsBankClient.IsClientExist(accountNumber))
            {
                Console.Write("\nAccount number is not found, choose another one: ");
                accountNumber = Console.ReadLine();
            }

            clsBankClient client = clsBankClient.Find(accountNumber);
            _PrintClient(client);

            Console.Write("\nAre you sure you want to update this client (y/n)? ");
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (answer == 'y' || answer == 'Y')
            {
                Console.WriteLine("\n\nUpdate Client Info:");
                Console.WriteLine("____________________");

                ReadClientInfo(client);

                var saveResult = client.Save();

                switch (saveResult)
                {
                    case clsBankClient.enSaveResults.svSucceeded:
                        Console.WriteLine("\nAccount Updated Successfully :-)");
                        _PrintClient(client);
                        break;

                    case clsBankClient.enSaveResults.svFaildEmptyObject:
                        Console.WriteLine("\nError: Account was not saved because it's empty.");
                        break;
                }
            }
        }
    }

}

