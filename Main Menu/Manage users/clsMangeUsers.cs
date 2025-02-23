using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsMangeUsers : clsScreen
    {
        private enum enManageUsersMenueOptions
        {
            eListUsers = 1,
            eAddNewUser = 2,
            eDeleteUser = 3,
            eUpdateUser = 4,
            eFindUser = 5,
            eMainMenue = 6
        }

        private static short ReadManageUsersMenueOption()
        {
            Console.Write("Choose what do you want to do? [1 to 6]? ");
            return clsInputValidate.ReadShortNumberBetween(1, 6, "Enter Number between 1 to 6? ");
        }

        private static void _GoBackToManageUsersMenue()
        {
            Console.WriteLine("\n\nPress any key to go back to Manage Users Menu...");
            Console.ReadKey();
            ShowManageUsersMenue();
        }

        private static void _ShowListUsersScreen()
        {
            clsUsersListScreen.ShowUsersList();
        }

        private static void _ShowAddNewUserScreen()
        {
            clsAddNewUserScreen.ShowAddNewUserScreen();
        }

        private static void _ShowDeleteUserScreen()
        {
            clsDeleteUserScreen.ShowDeleteUserScreen();
        }

        private static void _ShowUpdateUserScreen()
        {
            clsUpdateUserScreen.ShowUpdateUserScreen();
        }

        private static void _ShowFindUserScreen()
        {
            clsFindUserScreen.ShowFindUserScreen();
        }

        private static void _PerformManageUsersMenueOption(enManageUsersMenueOptions ManageUsersMenueOption)
        {
            

            switch (ManageUsersMenueOption)
            {
                case enManageUsersMenueOptions.eListUsers:
                    Console.Clear();
                    _ShowListUsersScreen();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersMenueOptions.eAddNewUser:
                    Console.Clear();
                    _ShowAddNewUserScreen();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersMenueOptions.eDeleteUser:
                    Console.Clear();
                    _ShowDeleteUserScreen();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersMenueOptions.eUpdateUser:
                    Console.Clear();
                    _ShowUpdateUserScreen();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersMenueOptions.eFindUser:
                    Console.Clear();
                    _ShowFindUserScreen();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersMenueOptions.eMainMenue:
                    // Do nothing, main menu will handle it.
                    break;
            }
        }

        public static void ShowManageUsersMenue()
        {
            Console.Clear();
            _DrawScreenHeader("\t Manage Users Screen");

            Console.WriteLine("\t\t\t\t\t=========================================");
            Console.WriteLine("\t\t\t\t\t\t  Manage Users Menu");
            Console.WriteLine("\t\t\t\t\t=========================================");
            Console.WriteLine("\t\t\t\t\t  [1] List Users.");
            Console.WriteLine("\t\t\t\t\t  [2] Add New User.");
            Console.WriteLine("\t\t\t\t\t  [3] Delete User.");
            Console.WriteLine("\t\t\t\t\t  [4] Update User.");
            Console.WriteLine("\t\t\t\t\t  [5] Find User.");
            Console.WriteLine("\t\t\t\t\t  [6] Main Menu.");
            Console.WriteLine("\t\t\t\t\t=========================================");

            _PerformManageUsersMenueOption((enManageUsersMenueOptions)ReadManageUsersMenueOption());
        }
    }

}

