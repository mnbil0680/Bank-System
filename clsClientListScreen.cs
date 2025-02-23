using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsClientListScreen : clsScreen
    {
       

        private static void _PrintClientRecordLine(clsBankClient client)
        {
            Console.WriteLine($"| {client.AccountNumber(),-15} | {client.FullName(),-20} | {client.Phone,-12} | {client.Email,-20} | {client.PinCode,-10} | {client.AccountBalance,-12}");
        }

        public static void ShowClientsList()
        {
            List<clsBankClient> clients = clsBankClient.GetClientsList();
            string title = "\t  Client List Screen";
            string subTitle = $"\t    ({clients.Count}) Client(s).";

            _DrawScreenHeader(title, subTitle);

            Console.WriteLine("\n________________________________________________________________________________________________________");
            Console.WriteLine("| Account Number   | Client Name         | Phone       | Email               | Pin Code  | Balance     |");
            Console.WriteLine("________________________________________________________________________________________________________\n");

            if (clients.Count == 0)
            {
                Console.WriteLine("\t\t\t\tNo Clients Available In the System!");
            }
            else
            {
                foreach (clsBankClient client in clients)
                {
                    _PrintClientRecordLine(client);
                }
            }

            Console.WriteLine("\n________________________________________________________________________________________________________\n");
        }
    }

}

