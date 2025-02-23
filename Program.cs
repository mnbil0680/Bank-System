using System.Text;
using System.Threading.Channels;
using static Bank_System.clsInputValidate;
using System.Collections.Generic;


namespace Bank_System
{
    internal class Program
    {
        static void ReadClientInfo(clsBankClient Client)
{
    Console.Write("\nEnter FirstName: ");
    Client.FirstName = clsInputValidate.ReadString();

    Console.Write("\nEnter LastName: ");
    Client.LastName = clsInputValidate.ReadString();

    Console.Write("\nEnter Email: ");
    Client.Email = clsInputValidate.ReadString();

    Console.Write("\nEnter Phone: ");
    Client.Phone = clsInputValidate.ReadString();

    Console.Write("\nEnter PinCode: ");
    Client.PinCode = clsInputValidate.ReadString();

    Console.Write("\nEnter Account Balance: ");
    Client.AccountBalance =  (float)clsInputValidate.ReadDbNumber();
}

        static void UpdateClient()
{
    string accountNumber;

    Console.Write("\nPlease Enter client Account Number: ");
    accountNumber = clsInputValidate.ReadString();

    while (!clsBankClient.IsClientExist(accountNumber))
    {
        Console.Write("\nAccount number is not found, choose another one: ");
        accountNumber = clsInputValidate.ReadString();
    }

    clsBankClient client1 = clsBankClient.Find(accountNumber);
    client1.Print();

    Console.WriteLine("\n\nUpdate Client Info:");
    Console.WriteLine("\n____________________\n");

    ReadClientInfo(client1);

    clsBankClient.enSaveResults saveResult = client1.Save();

    switch (saveResult)
    {
        case clsBankClient.enSaveResults.svSucceeded:
            Console.WriteLine("\nAccount Updated Successfully :-)\n");
            client1.Print();
            break;

        case clsBankClient.enSaveResults.svFaildEmptyObject:
            Console.WriteLine("\nError: account was not saved because it's empty.");
            break;
    }
}
        static void AddNewClient()
        {
            string AccountNumber = "";

            Console.WriteLine("Please Enter Account Number: ");

            AccountNumber = clsInputValidate.ReadString();

            while (clsBankClient.IsClientExist(AccountNumber))
            {
                Console.WriteLine("Account Number is already used, Choose another one: ");
                AccountNumber = clsInputValidate.ReadString();
            }

            clsBankClient NewClient = clsBankClient.GetAddNewClientObject(AccountNumber);

            ReadClientInfo(NewClient);

            clsBankClient.enSaveResults SaveResult;

            SaveResult = NewClient.Save();

            switch (SaveResult)
            {
                case clsBankClient.enSaveResults.svSucceeded:
                    Console.WriteLine("Account added successfully :-)\n");
                    NewClient.Print();
                    break;
                case clsBankClient.enSaveResults.svFaildEmptyObject:
                    Console.WriteLine("Error account was not saved because it's Empty");
                    break;
                case clsBankClient.enSaveResults.svFaildAccountNumberExists:
                    Console.WriteLine("Account Number is already used");
                    break;
            }
        }

        static void DeleteClient()
        {
            string AccountNumber = "";
            Console.WriteLine("Please Enter the account number: ");
            AccountNumber = clsInputValidate.ReadString();
            while (!clsBankClient.IsClientExist(AccountNumber))
            {
                Console.WriteLine("Account Number is not found, choose another one");
                AccountNumber = ReadString();
            }
            clsBankClient Client1 = clsBankClient.Find(AccountNumber);
            Client1.Print();

            Console.WriteLine("Are you sure you want to delete this client y/n");
            string answer = "n";
            answer = Console.ReadLine();
            answer.ToLower();
            if (answer == "y")
            {
                if (Client1.Delete())
                {
                    Console.WriteLine("Client deleted successfully");
                    Client1.Print();

                }
                else
                {
                    Console.WriteLine("erro client was not deleted");
                }

            }


        }

        public static void PrintClientRecordLine(clsBankClient client)
        {
            Console.WriteLine($"| {client.AccountNumber(),-15}" +
                              $"| {client.FullName(),-20}" +
                              $"| {client.Phone,-12}" +
                              $"| {client.Email,-20}" +
                              $"| {client.PinCode,-10}" +
                              $"| {client.AccountBalance,-12}");
        }

        public static void ShowClientsList()
        {
            List<clsBankClient> clients = clsBankClient.GetClientsList();

            Console.WriteLine($"\n\t\t\t\t\tClient List ({clients.Count}) Client(s).");
            Console.WriteLine("________________________________________________________________________________________________\n");

            Console.WriteLine($"| {"Account Number",-15}" +
                              $"| {"Client Name",-20}" +
                              $"| {"Phone",-12}" +
                              $"| {"Email",-20}" +
                              $"| {"Pin Code",-10}" +
                              $"| {"Balance",-12}");

            Console.WriteLine("________________________________________________________________________________________________\n");

            // if no clients
            if (clients.Count == 0)
            {
                Console.WriteLine("\t\t\t\tNo Clients Available In the System!");
            }
            else
            {
                foreach (var client in clients)
                {
                    PrintClientRecordLine(client);
                    
                }
            }

            Console.WriteLine("________________________________________________________________________________________________\n");
        }


        public static void ShowTotalBalances()
        {
            List<clsBankClient> clients = clsBankClient.GetClientsList();

            Console.WriteLine($"\n\t\t\t\t\tBalances List ({clients.Count}) Client(s).");
            Console.WriteLine("__________________________________________________________________________________________\n");

            Console.WriteLine($"| {"Account Number",-15}" +
                              $"| {"Client Name",-40}" +
                              $"| {"Balance",-12}");

            Console.WriteLine("__________________________________________________________________________________________\n");

            double totalBalances = clsBankClient.GetTotalBalances();

            if (clients.Count == 0)
            {
                Console.WriteLine("\t\t\t\tNo Clients Available In the System!");
            }
            else
            {
                foreach (var client in clients)
                {
                    PrintClientRecordBalanceLine(client);
                   
                }
            }

            Console.WriteLine("__________________________________________________________________________________________\n");
            Console.WriteLine($"\t\t\t\t\t   Total Balances = {totalBalances}");
            Console.WriteLine($"\t\t\t\t\t   ( {clsUtil.NumberToText((int)totalBalances)} )");
        }

        public static void PrintClientRecordBalanceLine(clsBankClient client)
        {
            Console.WriteLine($"| {client.AccountNumber(),-15}" +
                              $"| {client.FullName(),-40}" +
                              $"| {client.AccountBalance,-12}");
        }
    


    static void Main(string[] args)
        {
            clsMainScreen.ShowMainMenu();


        }
    }
}
