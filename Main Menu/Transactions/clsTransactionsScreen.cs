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
            ShowMainMenu = 4
        }

        private static short ReadTransactionsMenuOption()
        {
            Console.Write("Choose what do you want to do? [1 to 4]? ");
            return clsInputValidate.ReadShortNumberBetween(1, 4, "Enter Number between 1 to 4: ");
        }

        private static void _ShowDepositScreen()
        {
            clsDepositScreen.ShowDepositScreen();
        }

        private static void _ShowWithdrawScreen()
        {
            clsWithdrawScreen.ShowWithdrawScreen();
        }

        private static void _ShowTotalBalancesScreen()
        {
            clsTotalBalancesScreen.ShowTotalBalances();
        }

        private static void _GoBackToTransactionsMenu()
        {
            Console.WriteLine("\n\nPress any key to go back to Transactions Menu...");
            Console.ReadKey();
            ShowTransactionsMenu();
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
            Console.WriteLine("\t\t\t\t\t[4] Main Menu.");
            Console.WriteLine("\t\t\t\t\t===========================================\n");

            _PerformTransactionsMenuOption((enTransactionsMenuOptions)ReadTransactionsMenuOption());
        }
    }

}

