namespace Bank_System
{
    internal class clsTransferScreen : clsScreen
    {
        private static void PrintClient(clsBankClient Client)
        {
            Console.WriteLine("\nClient Card:");
            Console.WriteLine("\n___________________\n");
            Console.WriteLine($"Full Name   : {Client.FullName()}");
            Console.WriteLine($"Acc. Number : {Client.AccountNumber()}");
            Console.WriteLine($"Balance     : {Client.AccountBalance}");
            Console.WriteLine("\n___________________\n");
        }

        private static string ReadAccountNumber(bool dist)
        {
            string accountNumber;
            if (dist)
            {
                Console.Write("\nPlease Enter Account Number to Transfer To: ");
            }
            else
            {
                Console.Write("\nPlease Enter Account Number to Transfer From: ");

            }
            accountNumber = clsInputValidate.ReadString();

            while (!clsBankClient.IsClientExist(accountNumber))
            {
                Console.Write("\nAccount number is not found, choose another one: ");
                accountNumber = clsInputValidate.ReadString();
            }

            return accountNumber;
        }

        private static double ReadAmount(clsBankClient sourceClient)
        {
            double amount;

            Console.Write("\nEnter Transfer Amount? ");
            amount = clsInputValidate.ReadDbNumber();

            while (amount > sourceClient.AccountBalance)
            {
                Console.Write("\nAmount Exceeds the available Balance, Enter another Amount? ");
                amount = clsInputValidate.ReadDbNumber();
            }

            return amount;
        }

        public static void ShowTransferScreen()
        {
            _DrawScreenHeader("\tTransfer Screen");

            clsBankClient sourceClient = clsBankClient.Find(ReadAccountNumber(false));
            PrintClient(sourceClient);

            clsBankClient destinationClient = clsBankClient.Find(ReadAccountNumber(true));
            PrintClient(destinationClient);

            double amount = ReadAmount(sourceClient);

            Console.Write("\nAre you sure you want to perform this operation? y/n? ");
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (answer == 'Y' || answer == 'y')
            {
                if (sourceClient.Transfer(amount, ref destinationClient, clsGlobal.CurrentUser.ToString()))
                {
                    Console.WriteLine("\nTransfer done successfully\n");
                }
                else
                {
                    Console.WriteLine("\nTransfer Failed\n");
                }
            }

            PrintClient(sourceClient);
            PrintClient(destinationClient);
        }
    }

}

