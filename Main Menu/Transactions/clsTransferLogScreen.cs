using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsTransferLogScreen : clsScreen
    {
        private static void PrintTransferLogRecordLine(clsBankClient.stTrnsferLogRecord transferLogRecord)
        {
            Console.WriteLine("{0,-8} | {1,-23} | {2,-8} | {3,-8} | {4,-8} | {5,-10} | {6,-10} | {7,-8}",
                "", transferLogRecord.DateTime, transferLogRecord.SourceAccountNumber,
                transferLogRecord.DestinationAccountNumber, transferLogRecord.Amount,
                transferLogRecord.srcBalanceAfter, transferLogRecord.destBalanceAfter,
                transferLogRecord.UserName);
        }

        public static void ShowTransferLogScreen()
        {
            List<clsBankClient.stTrnsferLogRecord> transferLogRecords = clsBankClient.GetTransfersLogList();

            string title = "\tTransfer Log List Screen";
            string subTitle = $"\t    ({transferLogRecords.Count}) Record(s).";

            _DrawScreenHeader(title, subTitle);

            Console.WriteLine("\n\t________________________________________________________________________________________________\n");


            Console.WriteLine("{0,-8} | {1,-23} | {2,-8} | {3,-8} | {4,-8} | {5,-10} | {6,-10} | {7,-8}","", "Date/Time", "s.Acct", "d.Acct", "Amount", "s.Balance", "d.Balance", "User");

            Console.WriteLine("\t________________________________________________________________________________________________\n");


            if (transferLogRecords.Count == 0)
                Console.WriteLine("\t\t\t\tNo Transfers Available In the System!");
            else
            {
                foreach (var record in transferLogRecords)
                {
                    PrintTransferLogRecordLine(record);
                }
            }

            Console.WriteLine("\n\t________________________________________________________________________________________________\n");

        }
    }

}

