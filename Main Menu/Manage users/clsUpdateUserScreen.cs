using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsUpdateUserScreen : clsScreen
    {
        private static void _ReadUserInfo(ref clsUser user)
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
            user.Permissions = _ReadPermissionsToSet();
        }

        private static void _PrintUser(clsUser user)
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

        private static int _ReadPermissionsToSet()
        {
            int permissions = 0;
            Console.Write("\nDo you want to give full access? (y/n): ");
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (char.ToUpper(answer) == 'Y')
            {
                return -1;
            }

            Console.WriteLine("\nSelect permissions: ");
            permissions += _AskPermission("Show Client List", clsUser.enPermissions.pListClients);
            permissions += _AskPermission("Add New Client", clsUser.enPermissions.pAddNewClient);
            permissions += _AskPermission("Delete Client", clsUser.enPermissions.pDeleteClient);
            permissions += _AskPermission("Update Client", clsUser.enPermissions.pUpdateClients);
            permissions += _AskPermission("Find Client", clsUser.enPermissions.pFindClient);
            permissions += _AskPermission("Transactions", clsUser.enPermissions.pTranactions);
            permissions += _AskPermission("Manage Users", clsUser.enPermissions.pManageUsers);

            return permissions;
        }

        private static int _AskPermission(string permissionName, clsUser.enPermissions permission)
        {
            Console.Write($"\n{permissionName}? (y/n): ");
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return char.ToUpper(answer) == 'Y' ? (int)permission : 0;
        }

        public static void ShowUpdateUserScreen()
        {
            _DrawScreenHeader("\tUpdate User Screen");

            Console.Write("\nPlease Enter User UserName: ");
            string userName = Console.ReadLine();

            while (!clsUser.IsUserExist(userName))
            {
                Console.Write("\nUser is not found, choose another one: ");
                userName = Console.ReadLine();
            }

            clsUser user1 = clsUser.Find(userName);
            _PrintUser(user1);

            Console.Write("\nAre you sure you want to update this User (y/n)? ");
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (char.ToUpper(answer) == 'Y')
            {
                Console.WriteLine("\n\nUpdate User Info:");
                Console.WriteLine("____________________\n");

                _ReadUserInfo(ref user1);

                clsUser.enSaveResults saveResult = user1.Save();

                switch (saveResult)
                {
                    case clsUser.enSaveResults.svSucceeded:
                        Console.WriteLine("\nUser Updated Successfully :-)\n");
                        _PrintUser(user1);
                        break;

                    case clsUser.enSaveResults.svFailedEmptyObject:
                        Console.WriteLine("\nError: User was not saved because it's empty.");
                        break;
                }
            }
        }
    }

}

