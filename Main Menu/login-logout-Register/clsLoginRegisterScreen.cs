using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsLoginRegisterScreen : clsScreen
    {
        private static void PrintLoginRegisterRecordLine(clsUser.stLoginRegisterRecord LoginRegisterRecord)
        {
            Console.WriteLine($"{"",-8}| {LoginRegisterRecord.DateTime,-35} | {LoginRegisterRecord.UserName,-20} | {LoginRegisterRecord.Password,-20} | {LoginRegisterRecord.Permissions,-10}");
        }

        public static void ShowLoginRegisterScreen()
        {
            List<clsUser.stLoginRegisterRecord> loginRegisterRecords = clsUser.GetLoginRegisterList();

            string title = "\tLogin Register List Screen";
            string subTitle = $"\t\t({loginRegisterRecords.Count}) Record(s).";

            _DrawScreenHeader(title, subTitle);

            Console.WriteLine($"\n\t________________________________________________________________________________________________\n");

            Console.WriteLine($"{"",-8}| {"Date/Time",-35} | {"UserName",-20} | {"Password",-20} | {"Permissions",-10}");
            Console.WriteLine($"\n\t________________________________________________________________________________________________\n");
            if (loginRegisterRecords.Count == 0)
                Console.WriteLine("\t\t\t\tNo Logins Available In the System!");
            else
            {
                foreach (var record in loginRegisterRecords)
                {
                    PrintLoginRegisterRecordLine(record);
                }
            }

            Console.WriteLine($"\n\t________________________________________________________________________________________________\n");
        }
    }

}

