using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsMainScreen : clsScreen
    {

  

        private enum enMainMenueOptions
        {
            ListClients = 1, AddNewClient, DeleteClient, UpdateClient,
            FindClient, ShowTransactionsMenu, ManageUsers, Exit
        }

        private static short _ReadMainMenuOption()
        {
            Console.Write("\nChoose what do you want to do? [1 to 8]: ");
            return clsInputValidate.ReadShortNumberBetween(1, 8, "Enter a number between 1 and 8: ");
        }

        private static void _GoBackToMainMenu()
        {
            Console.WriteLine("\nPress any key to go back to Main Menu...");
            Console.ReadKey();
            ShowMainMenu();
        }

        private static void _ShowAllClientsScreen() => Console.WriteLine("\nClient List Screen Will be here...");
        private static void _ShowAddNewClientsScreen() => Console.WriteLine("\nAdd New Client Screen Will be here...");
        private static void _ShowDeleteClientScreen() => Console.WriteLine("\nDelete Client Screen Will be here...");
        private static void _ShowUpdateClientScreen() => Console.WriteLine("\nUpdate Client Screen Will be here...");
        private static void _ShowFindClientScreen() => Console.WriteLine("\nFind Client Screen Will be here...");
        private static void _ShowTransactionsMenu() => Console.WriteLine("\nTransactions Menu Will be here...");
        private static void _ShowManageUsersMenu() => Console.WriteLine("\nUsers Menu Will be here...");
        private static void _ShowEndScreen() => Console.WriteLine("\nEnd Screen Will be here...");

        private static void _PerformMainMenuOption(enMainMenueOptions mainMenuOption)
        {
            Console.Clear();
            switch (mainMenuOption)
            {
                case enMainMenueOptions.ListClients:
                    _ShowAllClientsScreen();
                    _GoBackToMainMenu();
                    break;
                case enMainMenueOptions.AddNewClient:
                    _ShowAddNewClientsScreen();
                    _GoBackToMainMenu();
                    break;
                case enMainMenueOptions.DeleteClient:
                    _ShowDeleteClientScreen();
                    _GoBackToMainMenu();
                    break;
                case enMainMenueOptions.UpdateClient:
                    _ShowUpdateClientScreen();
                    _GoBackToMainMenu();
                    break;
                case enMainMenueOptions.FindClient:
                    _ShowFindClientScreen();
                    _GoBackToMainMenu();
                    break;
                case enMainMenueOptions.ShowTransactionsMenu:
                    _ShowTransactionsMenu();
                    _GoBackToMainMenu();
                    break;
                case enMainMenueOptions.ManageUsers:
                    _ShowManageUsersMenu();
                    _GoBackToMainMenu();
                    break;
                case enMainMenueOptions.Exit:
                    _ShowEndScreen();
                    break;
            }
        }

        public static void ShowMainMenu()
        {
            Console.Clear();
            _DrawScreenHeader("Main Screen");

            Console.WriteLine("\t\t\t\t\t===========================================");
            Console.WriteLine("\t\t\t\t\t\t\tMain Menu");
            Console.WriteLine("\t\t\t\t\t===========================================");
            Console.WriteLine("\t\t\t\t\t[1] Show Client List.");
            Console.WriteLine("\t\t\t\t\t[2] Add New Client.");
            Console.WriteLine("\t\t\t\t\t[3] Delete Client.");
            Console.WriteLine("\t\t\t\t\t[4] Update Client Info.");
            Console.WriteLine("\t\t\t\t\t[5] Find Client.");
            Console.WriteLine("\t\t\t\t\t[6] Transactions.");
            Console.WriteLine("\t\t\t\t\t[7] Manage Users.");
            Console.WriteLine("\t\t\t\t\t[8] Logout.");
            Console.WriteLine("\t\t\t\t\t===========================================\n");

            _PerformMainMenuOption((enMainMenueOptions)_ReadMainMenuOption());
        }
    }

}

