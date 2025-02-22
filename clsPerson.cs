using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsPerson
    {
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Phone;

        // constructor
        public clsPerson(string FirstName, string LastName, string Email, string Phone)
        {
            _FirstName = FirstName;
            _LastName = LastName;
            _Email = Email;
            _Phone = Phone;
        }
        // default constructor
        public clsPerson()
        {
            _FirstName = "";
            _LastName = "";
            _Email = "";
            _Phone = "";
        }

        // getters and setters for private fields
        public string FirstName
        {
            get => _FirstName;
            set => _FirstName = value;
        }
        public string LastName
        {
            get => _LastName;
            set => _LastName = value;
        }
        public string Email
        {
            get => _Email;
            set => _Email = value;
        }
        public string Phone
        {
            get => _Phone;
            set => _Phone = value;
        }

        public string FullName()
        {
            return _FirstName + " " + _LastName;
        }

        public void Print()
        {
            Console.WriteLine("\nInfo:");
            Console.WriteLine("\n___________________");
            Console.WriteLine($"\nFirstName:    {_FirstName}");
            Console.WriteLine($"\nLastName :    {_LastName}");
            Console.WriteLine($"\nFull Name:    {FullName()}");
            Console.WriteLine($"\nEmail    :    {_Email}");
            Console.WriteLine($"\nPhone    :    {_Phone}");
            Console.WriteLine($"\n__________________\n");

        }
    }
}
