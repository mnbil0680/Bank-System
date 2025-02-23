using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsFindUserScreen : clsScreen
    {
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

        public static void ShowFindUserScreen()
        {
            _DrawScreenHeader("\tFind User Screen");

            Console.Write("\nPlease Enter UserName: ");
            string userName = Console.ReadLine().Trim();

            while (!clsUser.IsUserExist(userName))
            {
                Console.Write("\nUser is not found, choose another one: ");
                userName = Console.ReadLine().Trim();
            }

            clsUser user1 = clsUser.Find(userName);

            if (!user1.IsEmpty)
            {
                Console.WriteLine("\nUser Found :-)\n");
            }
            else
            {
                Console.WriteLine("\nUser Was Not Found :-(\n");
            }

            _PrintUser(user1);
        }
    }

}