using System.Text;
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

        static void Main(string[] args)
        {

            UpdateClient();
            
        }
    }
}
