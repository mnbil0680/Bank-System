using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsScreen
    {
        protected static void _DrawScreenHeader(string title, string subTitle = "")
        {
            Console.WriteLine("\t\t\t\t\t______________________________________");
            Console.WriteLine($"\n\n\t\t\t\t\t  {title}");

            if (!string.IsNullOrEmpty(subTitle))
            {
                Console.WriteLine($"\n\t\t\t\t\t  {subTitle}");
            }

            Console.WriteLine("\n\t\t\t\t\t______________________________________\n\n");
        }
    }


}
