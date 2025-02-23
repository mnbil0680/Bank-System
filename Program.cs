using System.Text;
using System.Threading.Channels;
using static Bank_System.clsInputValidate;


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

        static void Main(string[] args)
        {
            DeleteClient();


        }
    }
}
