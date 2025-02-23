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

        private static short ReadMainMenuOption()
        {
            Console.Write("\nChoose what do you want to do? [1 to 8]: ");
            return clsInputValidate.ReadShortNumberBetween(1, 8, "Enter a number between 1 and 8: ");
        }

        private static void GoBackToMainMenu()
        {
            Console.WriteLine("\nPress any key to go back to Main Menu...");
            Console.ReadKey();
            ShowMainMenu();
        }

        private static void ShowAllClientsScreen() => Console.WriteLine("\nClient List Screen Will be here...");
        private static void ShowAddNewClientsScreen() => Console.WriteLine("\nAdd New Client Screen Will be here...");
        private static void ShowDeleteClientScreen() => Console.WriteLine("\nDelete Client Screen Will be here...");
        private static void ShowUpdateClientScreen() => Console.WriteLine("\nUpdate Client Screen Will be here...");
        private static void ShowFindClientScreen() => Console.WriteLine("\nFind Client Screen Will be here...");
        private static void ShowTransactionsMenu() => Console.WriteLine("\nTransactions Menu Will be here...");
        private static void ShowManageUsersMenu() => Console.WriteLine("\nUsers Menu Will be here...");
        private static void ShowEndScreen() => Console.WriteLine("\nEnd Screen Will be here...");

        private static void PerformMainMenuOption(enMainMenueOptions mainMenuOption)
        {
            Console.Clear();
            switch (mainMenuOption)
            {
                case enMainMenueOptions.ListClients:
                    ShowAllClientsScreen();
                    GoBackToMainMenu();
                    break;
                case enMainMenueOptions.AddNewClient:
                    ShowAddNewClientsScreen();
                    GoBackToMainMenu();
                    break;
                case enMainMenueOptions.DeleteClient:
                    ShowDeleteClientScreen();
                    GoBackToMainMenu();
                    break;
                case enMainMenueOptions.UpdateClient:
                    ShowUpdateClientScreen();
                    GoBackToMainMenu();
                    break;
                case enMainMenueOptions.FindClient:
                    ShowFindClientScreen();
                    GoBackToMainMenu();
                    break;
                case enMainMenueOptions.ShowTransactionsMenu:
                    ShowTransactionsMenu();
                    break;
                case enMainMenueOptions.ManageUsers:
                    ShowManageUsersMenu();
                    break;
                case enMainMenueOptions.Exit:
                    ShowEndScreen();
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

            PerformMainMenuOption((enMainMenueOptions)ReadMainMenuOption());
        }
    }

}

