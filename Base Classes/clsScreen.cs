using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsScreen
    {
        protected static void _DrawScreenHeader(string title, string subTitle = "")
        {
            DateOnly d = new DateOnly();
            Console.WriteLine("\t\t\t\t\t______________________________________");
            Console.WriteLine($"\n\n\t\t\t\t\t  {title}");

            if (!string.IsNullOrEmpty(subTitle))
            {
                Console.WriteLine($"\n\t\t\t\t\t  {subTitle}");
            }

            Console.WriteLine("\t\t\t\t\t______________________________________\n");
            Console.WriteLine($"\t\t\t\t\tUser: {clsGlobal.CurrentUser.UserName}");
            Console.WriteLine($"\t\t\t\t\tDate: {DateTime.Now.ToString("dddd, MMMM dd, yyyy", CultureInfo.InvariantCulture)}\n\n");

        }
        public static bool CheckAccessRights(clsUser.enPermissions Permission)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(Permission))
            {
               
                Console.WriteLine("\t\t\t\t\t______________________________________");
                Console.WriteLine("\n\n\t\t\t\t\t  Access Denied! Contact your Admin.");
                Console.WriteLine("\t\t\t\t\t______________________________________\n");
                Console.WriteLine($"\t\t\t\t\tUser: {clsGlobal.CurrentUser.UserName}");
                Console.WriteLine($"\t\t\t\t\tDate: {DateTime.Now.ToString("dddd, MMMM dd, yyyy", CultureInfo.InvariantCulture)}\n\n");



                return false;
            }

            return true;
        }

    }


}
