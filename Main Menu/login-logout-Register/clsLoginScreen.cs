using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsLoginScreen : clsScreen
    {
        private static bool _Login()
        {
            bool loginFailed = false;
            short FaildLoginCount = 0;
            string username, password;

            do
            {
                if (loginFailed)
                {
                    FaildLoginCount++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Username/Password!");
                    Console.WriteLine($"You have {3 - FaildLoginCount} trial(s) left to login.\n");
                    Console.ResetColor();
                }

                if (FaildLoginCount == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nYou are locked after 3 failed attempts.");
                    Console.ResetColor();
                    Console.WriteLine("\n\n");
                    return false;
                }


                Console.Write("Enter Username: ");
                username = Console.ReadLine().Trim();

                Console.Write("Enter Password: ");
                password = Console.ReadLine().Trim();

                clsGlobal.CurrentUser = clsUser.Find(username, password);

                loginFailed = clsGlobal.CurrentUser.IsEmpty;

            } while (loginFailed);
            clsGlobal.CurrentUser.RegisterLogIn();
            clsMainScreen.ShowMainMenu();
            return true;
        }

        public static void ShowLoginScreen()
        {
            Console.Clear();
            _DrawScreenHeader("\t  Login Screen");
            _Login();
        }
    }

}

