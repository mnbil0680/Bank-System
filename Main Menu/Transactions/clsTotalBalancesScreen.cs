using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsTotalBalancesScreen : clsScreen
    {
        private static void PrintClientRecordBalanceLine(clsBankClient Client)
        {
            Console.Write($"{Client.AccountNumber(),-15} | ");
            Console.Write($"{Client.FullName(),-40} | ");
            Console.WriteLine($"{Client.AccountBalance,-12}");
        }

        public static void ShowTotalBalances()
        {
            List<clsBankClient> vClients = clsBankClient.GetClientsList();

            string Title = "\t  Balances List Screen";
            string SubTitle = $"\t    ({vClients.Count}) Client(s).";

            _DrawScreenHeader(Title, SubTitle);

            Console.WriteLine("\n______________________________________________________________________________");

            Console.WriteLine("| Accout Number  | Client Name                               | Balance       |");
            Console.WriteLine("______________________________________________________________________________");


            double TotalBalances = clsBankClient.GetTotalBalances();

            if (vClients.Count == 0)
                Console.WriteLine("\t\t\t\tNo Clients Available In the System!");
            else
            {
                foreach (clsBankClient Client in vClients)
                {
                    PrintClientRecordBalanceLine(Client);
                }
            }

            Console.WriteLine("_______________________________________________________________________________\n");
           

            Console.WriteLine($"\t\t\t\t\t\t     Total Balances = {TotalBalances}");
            Console.WriteLine($"\t\t\t\t  ( {clsUtil.NumberToText((int)TotalBalances)} )");
        }
    }

}

