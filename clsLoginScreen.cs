using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsLoginScreen : clsScreen
    {
        private static void _Login()
        {
            bool loginFailed = false;
            string username, password;

            do
            {
                if (loginFailed)
                {
                    Console.WriteLine("\nInvalid Username/Password!\n");
                }

                Console.Write("Enter Username: ");
                username = Console.ReadLine().Trim();

                Console.Write("Enter Password: ");
                password = Console.ReadLine().Trim();

                clsGlobal.CurrentUser = clsUser.Find(username, password);

                loginFailed = clsGlobal.CurrentUser.IsEmpty;

            } while (loginFailed);

            clsMainScreen.ShowMainMenu();
        }

        public static void ShowLoginScreen()
        {
            Console.Clear();
            _DrawScreenHeader("\t  Login Screen");
            _Login();
        }
    }

}

