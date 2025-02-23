using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsAddNewUserScreen : clsScreen
    {
    
        private static void ReadUserInfo(clsUser user)
        {
            Console.Write("\nEnter First Name: ");
            user.FirstName = Console.ReadLine();

            Console.Write("\nEnter Last Name: ");
            user.LastName = Console.ReadLine();

            Console.Write("\nEnter Email: ");
            user.Email = Console.ReadLine();

            Console.Write("\nEnter Phone: ");
            user.Phone = Console.ReadLine();

            Console.Write("\nEnter Password: ");
            user.Password = Console.ReadLine();

            Console.Write("\nEnter Permission: ");
            user.Permissions = ReadPermissionsToSet();
        }

        private static void PrintUser(clsUser user)
        {
            Console.WriteLine("\nUser Card:");
            Console.WriteLine("___________________");
            Console.WriteLine($"First Name   : {user.FirstName}");
            Console.WriteLine($"Last Name    : {user.LastName}");
            Console.WriteLine($"Full Name    : {user.FullName()}");
            Console.WriteLine($"Email        : {user.Email}");
            Console.WriteLine($"Phone        : {user.Phone}");
            Console.WriteLine($"User Name    : {user.UserName}");
            Console.WriteLine($"Password     : {user.Password}");
            Console.WriteLine($"Permissions  : {user.Permissions}");
            Console.WriteLine("___________________\n");
        }

        private static int ReadPermissionsToSet()
        {
            int permissions = 0;
            Console.Write("\nDo you want to give full access? (y/n): ");
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (char.ToLower(answer) == 'y')
            {
                return -1; // Full access
            }

            Console.WriteLine("\nDo you want to give access to: \n");

            if (AskPermission("Show Client List"))
                permissions |= (int)clsUser.enPermissions.pListClients;

            if (AskPermission("Add New Client"))
                permissions |= (int)clsUser.enPermissions.pAddNewClient;

            if (AskPermission("Delete Client"))
                permissions |= (int)clsUser.enPermissions.pDeleteClient;

            if (AskPermission("Update Client"))
                permissions |= (int)clsUser.enPermissions.pUpdateClients;

            if (AskPermission("Find Client"))
                permissions |= (int)clsUser.enPermissions.pFindClient;

            if (AskPermission("Transactions"))
                permissions |= (int)clsUser.enPermissions.pTranactions;

            if (AskPermission("Manage Users"))
                permissions |= (int)clsUser.enPermissions.pManageUsers;

            return permissions;
        }

        private static bool AskPermission(string action)
        {
            Console.Write($"\n{action}? (y/n): ");
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return char.ToLower(answer) == 'y';
        }

        public static  void ShowAddNewUserScreen()
        {
            _DrawScreenHeader("\t  Add New User Screen");

            string userName;
            do
            {
                Console.Write("\nPlease Enter UserName: ");
                userName = Console.ReadLine();
                if (clsUser.IsUserExist(userName))
                {
                    Console.WriteLine("\nUserName is already used, choose another one.");
                }
            } while (clsUser.IsUserExist(userName));

            clsUser newUser = clsUser.GetAddNewUserObject(userName);

            ReadUserInfo(newUser);

            clsUser.enSaveResults saveResult = newUser.Save();

            switch (saveResult)
            {
                case clsUser.enSaveResults.svSucceeded:
                    Console.WriteLine("\nUser added successfully! :-)\n");
                    PrintUser(newUser);
                    break;

                case clsUser.enSaveResults.svFailedEmptyObject:
                    Console.WriteLine("\nError: User was not saved because it's empty.");
                    break;

                case clsUser.enSaveResults.svFailedUserExists:
                    Console.WriteLine("\nError: User was not saved because the username is already used!\n");
                    break;
            }
        }

        
    }


}
