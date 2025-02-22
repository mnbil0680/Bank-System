using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsInputValidate
    {
        public static bool IsNumberBetween(int Num, int From, int To)
        {
            if (Num >= From && Num <= To)
            {
                return true;
            }
            return false;
        }
        public static bool IsNumberBetween(float Num, float From, float To)
        {
            if (Num >= From && Num <= To)
            {
                return true;
            }
            return false;
        }
        public static bool IsNumberBetween(double Num, double From, double To)
        {
            if (Num >= From && Num <= To)
            {
                return true;
            }
            return false;
        }
        public static bool IsNumberBetween(decimal Num, decimal From, decimal To)
        {
            if (Num >= From && Num <= To)
            {
                return true;
            }
            return false;
        }

        public static bool IsDateBetween(DateTime Date, DateTime From, DateTime To)
        {
            if (Date >= From && Date <= To)
            {
                return true;
            }
            return false;
        }
        
        public static int ReadNumber(string ErrorMessage="Inavlid Input, Please enter integer number")
        {
            int Num;
            while (!int.TryParse(Console.ReadLine(), out Num))
            {
                Console.WriteLine(ErrorMessage);
            }
            return Num;
        }
        
        public static int ReadNumberBetween(int From, int To, string ErrorMessage="Inavlid Input, Please enter an integer number")
        {
            int Num = ReadNumber();

            while (!IsNumberBetween(Num, From, To))
            {
                Console.WriteLine($"Invalid Input, Please enter number between {From} and {To}");
                Num = ReadNumber();
            }
            
            return Num;
        }

        public static double ReadDbNumber(string ErrorMessage = "Inavlid Input, Please enter double number")
        {
            double dbNum;
            while (!double.TryParse(Console.ReadLine(), out dbNum))
            {
                Console.WriteLine(ErrorMessage);
            }
            return dbNum;

        }
        
        public static double ReadDbNumberBetween(double From, double To, string ErrorMessage="Inavlid Input, Please enter a double number")
        {
            double dbNum = ReadDbNumber();
            while (!IsNumberBetween(dbNum, From, To))
            {
                Console.WriteLine($"Invalid Input, Please enter number between {From} and {To}");
                dbNum = ReadDbNumber();
            }
            return dbNum;
        }

        public static string ReadString()
        {
            return Console.ReadLine()?.Trim() ?? "";
        }

       



    }
}
