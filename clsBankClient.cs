using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsBankClient :  clsPerson
    {
        private enum enMode { EmptyMode, UpdateMode}
        private enMode _Mode;
        private string _AccountNumber;
        private string _PinCode;
        private float _AccountBalance;


        // constructor
        public clsBankClient(string FirstName, string LastName, string Email, string Phone, enMode Mode,string AccountNumber, string PinCode, float AccountBalance) : base(FirstName, LastName, Email, Phone)
        {
            _Mode = Mode;
            _AccountNumber = AccountNumber;
            _PinCode = PinCode;
            _AccountBalance = AccountBalance;
            
        }
    }
}
