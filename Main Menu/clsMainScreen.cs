﻿using System;
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
            FindClient, ShowTransactionsMenu, ManageUsers, LoginRegister, Exit
        }

        private static short _ReadMainMenuOption()
        {
            Console.Write("\nChoose what do you want to do? [1 to 9]: ");
            return clsInputValidate.ReadShortNumberBetween(1, 9, "Enter a number between 1 and 9: ");
        }

        private static void _GoBackToMainMenu()
        {
            Console.WriteLine("\nPress any key to go back to Main Menu...");
            Console.ReadKey();
            ShowMainMenu();
        }

        private static void _ShowAllClientsScreen()
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            
            clsClientListScreen.ShowClientsList();
        }
        private static void _ShowAddNewClientsScreen()
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            clsAddNewClientScreen.ShowAddNewClientScreen();
        }
        private static void _ShowDeleteClientScreen()
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            clsDeleteClientScreen.ShowDeleteClientScreen();
        }
        private static void _ShowUpdateClientScreen() 
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            clsUpdateClientScreen.ShowUpdateClientScreen();
        }
        private static void _ShowFindClientScreen() 
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            clsFindClientScreen.ShowFindClientScreen();
        } 
        private static void _ShowTransactionsMenu()
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            clsTransactionsScreen.ShowTransactionsMenu();
        }
        private static void _ShowManageUsersMenu() 
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            clsMangeUsers.ShowManageUsersMenue();
        }
        private static void _ShowLoginRegisterScreen()
        {
            if (!CheckAccessRights(clsUser.enPermissions.pListClients))
            {
                return;// this will exit the function and it will not continue
            }
            clsLoginRegisterScreen.ShowLoginRegisterScreen();
        }
        private static void _Logout()
        {
            clsGlobal.CurrentUser = clsUser.Find("", "");
            
            //then it will go back to main function.
        }
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
                case enMainMenueOptions.LoginRegister:
                    _ShowLoginRegisterScreen();
                    _GoBackToMainMenu();
                    break;
                case enMainMenueOptions.Exit:
                    Console.Clear();
                    clsGlobal.CurrentUser = clsUser.Find("", "");
                    clsLoginScreen.ShowLoginScreen();
                    break;
            }
        }

        public static void ShowMainMenu()
        {
            Console.Clear();
            _DrawScreenHeader("\t\tMain Screen");

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
            Console.WriteLine("\t\t\t\t\t[8] LoginRegister.");
            Console.WriteLine("\t\t\t\t\t[9] Logout.");
            Console.WriteLine("\t\t\t\t\t===========================================\n");

            _PerformMainMenuOption((enMainMenueOptions)_ReadMainMenuOption());
        }
    }

}

