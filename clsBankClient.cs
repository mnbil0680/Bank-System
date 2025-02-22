using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Bank_System
{
    internal class clsBankClient : clsPerson
    {
        internal enum enMode { EmptyMode, UpdateMode }
        private enMode _Mode;
        private string _AccountNumber;
        private string _PinCode;
        private float _AccountBalance;
        
        private static clsBankClient _ConvertLinetoClientObject(string Line, string Seperator = "#//#")
        {
            List<string> lClientData; // FirstName#//#LastName#//#Email#//#Phone#//#AccounNumber#//#PinCode#//#AccountBalance
            lClientData =
        }

        /*
          static clsBankClient _ConvertLinetoClientObject(string Line, string Seperator = "#//#")
    {
        vector<string> vClientData;
        vClientData = clsString::Split(Line, Seperator);

        return clsBankClient(enMode::UpdateMode, vClientData[0], vClientData[1], vClientData[2],
            vClientData[3], vClientData[4], vClientData[5], stod(vClientData[6]));

    }

    static clsBankClient _GetEmptyClientObject()
    {
        return clsBankClient(enMode::EmptyMode, "", "", "", "", "", "", 0);
    }
         
         */

        // constructor
        public clsBankClient(string FirstName, string LastName, string Email, string Phone, enMode Mode, string AccountNumber, string PinCode, float AccountBalance) : base(FirstName, LastName, Email, Phone)
        {
            _Mode = Mode;
            _AccountNumber = AccountNumber;
            _PinCode = PinCode;
            _AccountBalance = AccountBalance;

        }

        public bool IsEmpty()
        {
            return _Mode == enMode.EmptyMode;
        }

        public string AccountNumber()
        {
            return _AccountNumber;
        }

        public string PinCode
        {
            get=>_PinCode;
            set => _PinCode = value;
        }

        public float AccountBalance
        {
            get => _AccountBalance;
            set => _AccountBalance = value;
        }
        override public void Print()
        {

            Console.WriteLine("Client Card:");
            Console.WriteLine("____________________________");
            Console.WriteLine($"FirstName   :  {FirstName}");
            Console.WriteLine($"LastName    :  {LastName}");
            Console.WriteLine($"Full Name   :  {FullName()}");
            Console.WriteLine($"Email       :  {Email}");
            Console.WriteLine($"Phone       :  {Phone}");
            Console.WriteLine($"Acc. Number :  {_AccountNumber}");
            Console.WriteLine($"Password    :  {_PinCode}");
            Console.WriteLine($"Balance     :  {_AccountBalance}");
            Console.WriteLine("____________________________\n");
        }
        
        static clsBankClient Find(string AccountNumber )
        {

            // path of the file that we want to create
            string PathName = @"D:\Bank System\Clients.txt";
            if (File.Exists(PathName))
            {
                try
                {
                    FileStream FS = File.OpenRead(PathName);
                    StreamReader SR = new StreamReader(FS,Encoding.UTF8);
                    string line;
                    while ((line = SR.ReadLine()) != null)
                    {
                        // Process line
                        clsBankClient Client = _ConvertLinetoClientObject(Line);
                        line
                    }
                    
                    return

                }
                catch(Exception e)
                {
                    Console.WriteLine($"There is an Error :{e.Message}");
                    return
                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
            }
            

            return 
        }
        
    
    }
}
