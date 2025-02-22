using System.Text;
using static Bank_System.clsInputValidate;


namespace Bank_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            clsBankClient Client1 = clsBankClient.Find("A101");  // Find client by account number

            if (!Client1.IsEmpty())
            {
                Console.WriteLine("\nClient Found :-)\n");
            }
            else
            {
                Console.WriteLine("\nClient Was not Found :-(\n");
            }

            Client1.Print();  // Print client details

            clsBankClient Client2 = clsBankClient.Find("A101", "1234"); // Find client with account number & password

            if (!Client2.IsEmpty())
            {
                Console.WriteLine("\nClient Found :-)\n");
            }
            else
            {
                Console.WriteLine("\nClient Was not Found :-(\n");
            }

            Client2.Print();

            Console.WriteLine("\nIs Client Exist? " + clsBankClient.IsClientExist("A101"));

        }
    }
}
