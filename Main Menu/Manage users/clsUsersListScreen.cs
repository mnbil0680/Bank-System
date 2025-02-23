using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsUsersListScreen : clsScreen
    {
        private static void PrintUserRecordLine(clsUser user)
        {
            Console.Write($"| {user.UserName,-12}");
            Console.Write($"| {user.FullName(),-25}");
            Console.Write($"| {user.Phone,-12}");
            Console.Write($"| {user.Email,-20}");
            Console.Write($"| {user.Password,-10}");
            Console.Write($"| {user.Permissions,-12}");
            Console.WriteLine("|");
        }

        public static void ShowUsersList()
        {
            List<clsUser> users = clsUser.GetUsersList();

            string title = "\t  User List Screen";
            string subTitle = $"\t    ({users.Count}) User(s).";

            DrawScreenHeader(title, subTitle);

            Console.WriteLine("\n\t_______________________________________________________________________________________________");
            Console.WriteLine("\t| UserName    | Full Name               | Phone       | Email               | Password  | Permissions  |");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------");

            if (users.Count == 0)
            {
                Console.WriteLine("\t\t\t\tNo Users Available In the System!");
            }
            else
            {
                foreach (clsUser user in users)
                {
                    PrintUserRecordLine(user);
                }
            }

            Console.WriteLine("\t_______________________________________________________________________________________________\n");
        }

        private static void DrawScreenHeader(string title, string subTitle)
        {
            Console.WriteLine(title);
            Console.WriteLine(subTitle);
            Console.WriteLine(new string('-', 80));
        }
    }

}

