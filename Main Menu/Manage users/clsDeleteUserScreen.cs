using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsDeleteUserScreen : clsScreen
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

        public static void ShowDeleteUserScreen()
        {
            _DrawScreenHeader("\tDelete User Screen");

            string userName;
            Console.Write("\nPlease Enter UserName: ");
            userName = Console.ReadLine();

            while (!clsUser.IsUserExist(userName))
            {
                Console.Write("\nUser is not found, choose another one: ");
                userName = Console.ReadLine();
            }

            clsUser user1 = clsUser.Find(userName);
            _PrintUser(user1);

            Console.Write("\nAre you sure you want to delete this User (y/n)? ");
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Move to a new line

            if (char.ToUpper(answer) == 'Y')
            {
                if (user1.Delete())
                {
                    Console.WriteLine("\nUser Deleted Successfully :-)\n");
                    _PrintUser(user1);
                }
                else
                {
                    Console.WriteLine("\nError: User was not deleted.\n");
                }
            }
        }
    }

}

