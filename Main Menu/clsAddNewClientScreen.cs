using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsAddNewClientScreen : clsScreen
    {
   
        private static void _ReadClientInfo(ref clsBankClient client)
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
            client.AccountBalance = (float)clsInputValidate.ReadDbNumber();
        }

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

        public static void ShowAddNewClientScreen()
        {
            
            _DrawScreenHeader("\t  Add New Client Screen");

            Console.Write("\nPlease Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            while (clsBankClient.IsClientExist(accountNumber))
            {
                Console.Write("\nAccount Number is already used, choose another one: ");
                accountNumber = Console.ReadLine();
            }

            clsBankClient newClient = clsBankClient.GetAddNewClientObject(accountNumber);

            _ReadClientInfo(ref newClient);

            clsBankClient.enSaveResults saveResult = newClient.Save();

            switch (saveResult)
            {
                case clsBankClient.enSaveResults.svSucceeded:
                    Console.WriteLine("\nAccount Added Successfully :-)\n");
                    _PrintClient(newClient);
                    break;

                case clsBankClient.enSaveResults.svFaildEmptyObject:
                    Console.WriteLine("\nError: Account was not saved because it's empty.");
                    break;

                case clsBankClient.enSaveResults.svFaildAccountNumberExists:
                    Console.WriteLine("\nError: Account was not saved because account number is already used!\n");
                    break;
            }
        }
    }

}

