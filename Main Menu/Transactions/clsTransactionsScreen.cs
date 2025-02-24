using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsTransactionsScreen : clsScreen
    {
        private enum enTransactionsMenuOptions
        {
            Deposit = 1,
            Withdraw = 2,
            ShowTotalBalance = 3,
            Transfer=4,
            ShowMainMenu = 5
        }

        private static short ReadTransactionsMenuOption()
        {
            Console.Write("Choose what do you want to do? [1 to 5]? ");
            return clsInputValidate.ReadShortNumberBetween(1, 5, "Enter Number between 1 to 5: ");
        }

        private static void _ShowDepositScreen()
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            clsDepositScreen.ShowDepositScreen();
        }

        private static void _ShowWithdrawScreen()
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            clsWithdrawScreen.ShowWithdrawScreen();
        }

        private static void _ShowTotalBalancesScreen()
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            clsTotalBalancesScreen.ShowTotalBalances();
        }

        private static void _GoBackToTransactionsMenu()
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            Console.WriteLine("\n\nPress any key to go back to Transactions Menu...");
            Console.ReadKey();
            ShowTransactionsMenu();
        }

        private static void _ShowTransferScreen()
        {
            clsTransferScreen.ShowTransferScreen();
        }
        
        private static void _PerformTransactionsMenuOption(enTransactionsMenuOptions transactionOption)
        {
            
            switch (transactionOption)
            {
                case enTransactionsMenuOptions.Deposit:
                    Console.Clear();
                    _ShowDepositScreen();
                    _GoBackToTransactionsMenu();
                    break;
                case enTransactionsMenuOptions.Withdraw:
                    Console.Clear();
                    _ShowWithdrawScreen();
                    _GoBackToTransactionsMenu();
                    break;
                case enTransactionsMenuOptions.ShowTotalBalance:
                    Console.Clear();
                    _ShowTotalBalancesScreen();
                    _GoBackToTransactionsMenu();
                    break;
                case enTransactionsMenuOptions.Transfer:
                    Console.Clear();
                    _ShowTransferScreen();
                    _GoBackToTransactionsMenu();
                    break;
                case enTransactionsMenuOptions.ShowMainMenu:

                    // Main menu will handle this case
                    break;
            }
        }

        public static void ShowTransactionsMenu()
        {
            Console.Clear();
            _DrawScreenHeader("\t  Transactions Screen");

            Console.WriteLine("\t\t\t\t\t===========================================");
            Console.WriteLine("\t\t\t\t\t\t  Transactions Menu");
            Console.WriteLine("\t\t\t\t\t===========================================");
            Console.WriteLine("\t\t\t\t\t[1] Deposit.");
            Console.WriteLine("\t\t\t\t\t[2] Withdraw.");
            Console.WriteLine("\t\t\t\t\t[3] Total Balances.");
            Console.WriteLine("\t\t\t\t\t[4] Transfer.");
            Console.WriteLine("\t\t\t\t\t[5] Main Menu.");
            Console.WriteLine("\t\t\t\t\t===========================================\n");

            _PerformTransactionsMenuOption((enTransactionsMenuOptions)ReadTransactionsMenuOption());
        }
    }

}

