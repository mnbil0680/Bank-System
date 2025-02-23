using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using static System.Net.WebRequestMethods;
using System.Runtime.Intrinsics;

namespace Bank_System
{
    internal class clsBankClient : clsPerson
    {
        internal enum enMode { EmptyMode, UpdateMode, AddNewMode }
        private enMode _Mode;
        private string _AccountNumber;
        private string _PinCode;
        private float _AccountBalance;
        private bool _MarkedForDelete = false;

        private static clsBankClient _ConvertLinetoClientObject(string Line, string Seperator = "#//#")
        {
            List<string> lClientData; // FirstName#//#LastName#//#Email#//#Phone#//#AccounNumber#//#PinCode#//#AccountBalance
            lClientData = clsString.Split(Line, Seperator);

            return new clsBankClient(enMode.UpdateMode, lClientData[0], lClientData[1], lClientData[2], lClientData[3], lClientData[4], lClientData[5], float.Parse(lClientData[6], System.Globalization.CultureInfo.InvariantCulture));
        }

        private static clsBankClient _GetEmptyClientObject()
        {
            return new clsBankClient(enMode.EmptyMode, "", "", "", "", "", "", 0);
        }

        private static string _ConverClientObjectToLine(clsBankClient Client, string Seperator = "#//#")
        {

            string stClientRecord = "";
            stClientRecord += Client.FirstName + Seperator;
            stClientRecord += Client.LastName + Seperator;
            stClientRecord += Client.Email + Seperator;
            stClientRecord += Client.Phone + Seperator;
            stClientRecord += Client.AccountNumber() + Seperator;
            stClientRecord += Client.PinCode + Seperator;
            stClientRecord += Convert.ToString(Client.AccountBalance);

            return stClientRecord;
        }

        private static List<clsBankClient> _LoadClientsDataFromFile()
        {
            string PathName = @"D:\Bank System\Clients.txt";
            List<clsBankClient> lClients = new List<clsBankClient>();
            FileStream FS = System.IO.File.OpenRead(PathName);
            StreamReader SR = new StreamReader(FS, Encoding.UTF8);
            if (System.IO.File.Exists(PathName))
            {
                try
                {
                    
                    string Line;
                    while ((Line = SR.ReadLine()) != null)
                    {
                        // Process line
                        clsBankClient Client = _ConvertLinetoClientObject(Line);
                        if (Client != null)
                        {
                            lClients.Add(Client);
                        }

                    }
                    FS.Close();
                    return lClients;

                }
                catch (Exception e)
                {
                    Console.WriteLine($"There is an Error :{e.Message}");
                    FS.Close();
                    return lClients;



                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
                return lClients;
            }
        }

        private static void _SaveCleintsDataToFile(List<clsBankClient> lClients)
        {
            // path of the file that we want to create
            string PathName = @"D:\Bank System\Clients.txt";
            
            if (System.IO.File.Exists(PathName))
            {
                try
                {


                    string DataLine = "";

                    System.IO.File.WriteAllText(PathName, String.Empty);
                    foreach (clsBankClient C in lClients)
                    {
                        if (C.MarkedForDeleted() == false)
                        { 
                        
                        DataLine += "\n";
                        DataLine = _ConverClientObjectToLine(C);


                        // write to file
                        using (FileStream fs = new FileStream(PathName, FileMode.Append, FileAccess.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.WriteLine(DataLine);
                            }
                        }


                        }
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine($"There is an Error :{e.Message}");
                   
                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
            }
        }

        private void _Update()
        {
            List<clsBankClient> _vClients = _LoadClientsDataFromFile(); // Load clients from file

            for (int i = 0; i < _vClients.Count; i++)
            {
                if (_vClients[i].AccountNumber() == AccountNumber())  // Match account number
                {
                    _vClients[i] = this;  // Update the object
                    break;
                }
            }

            _SaveCleintsDataToFile(_vClients); // Save updated list to file
        }

        private void _AddDataLineToFile(string stDataLine)
        {
            // path of the file that we want to create
            string PathName = @"D:\Bank System\Clients.txt";
          
                    
            if (System.IO.File.Exists(PathName))
            {
                try
                {
                    
                    // write but clear all content

                    System.IO.File.AppendAllText(PathName, '\n'+stDataLine );

                    

                }
                catch (Exception e)
                {
                    Console.WriteLine($"There is an Error :{e.Message}");
                   
                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
            }




        }

        private void _AddNew()
        {
            _AddDataLineToFile(_ConverClientObjectToLine(this));
        }

        private void _CopyFrom(clsBankClient other)
        {
            if (other == null) return; // Avoid null reference errors

            this._AccountNumber = other._AccountNumber;
            this.FirstName = other.FirstName;
            this.LastName = other.LastName;
            this.Email = other.Email;
            this.Phone = other.Phone;
            this.PinCode = other.PinCode;
            this.AccountBalance = other.AccountBalance;
            this._MarkedForDelete = other._MarkedForDelete;
        }


        // constructor
        public clsBankClient(enMode Mode, string FirstName, string LastName, string Email, string Phone, string AccountNumber, string PinCode, float AccountBalance) : base(FirstName, LastName, Email, Phone)
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
        bool MarkedForDeleted()
        {
            return _MarkedForDelete;
        }

        public string AccountNumber()
        {
            return _AccountNumber;
        }

        public string PinCode
        {
            get => _PinCode;
            set => _PinCode = value;
        }

        public float AccountBalance
        {
            get => _AccountBalance;
            set => _AccountBalance = value;
        }
        public void Print()
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


        public static clsBankClient Find(string AccountNumber)
        {

            // path of the file that we want to create
            string PathName = @"D:\Bank System\Clients.txt";
            FileStream FS = System.IO.File.OpenRead(PathName);
            StreamReader SR = new StreamReader(FS, Encoding.UTF8);
            if (System.IO.File.Exists(PathName))
            {
                try
                {
                    
                    
                    string Line;
                    while ((Line = SR.ReadLine()) != null)
                    {
                        // Process line
                        clsBankClient Client = _ConvertLinetoClientObject(Line);
                        if (Client.AccountNumber() == AccountNumber)
                        {
                            FS.Close();
                            return Client;
                        }

                    }
                    FS.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine($"There is an Error :{e.Message}");
                    FS.Close();
                    return _GetEmptyClientObject();

                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
                return _GetEmptyClientObject();
            }


            return _GetEmptyClientObject();
        }

        public static clsBankClient Find(string AccountNumber, string PinCode)
        {

            // path of the file that we want to create
            string PathName = @"D:\Bank System\Clients.txt";
            FileStream FS = System.IO.File.OpenRead(PathName);
            StreamReader SR = new StreamReader(FS, Encoding.UTF8);
            if (System.IO.File.Exists(PathName))
            {
                try
                {
                    
                    string Line;
                    while ((Line = SR.ReadLine()) != null)
                    {
                        // Process line
                        clsBankClient Client = _ConvertLinetoClientObject(Line);
                        if (Client.AccountNumber() == AccountNumber && Client.PinCode == PinCode)
                        {
                            FS.Close();
                            return Client;
                        }

                    }
                    FS.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine($"There is an Error :{e.Message}");
                    FS.Close();
                    return _GetEmptyClientObject();

                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
                return _GetEmptyClientObject();
            }


            return _GetEmptyClientObject();
        }


        public static bool IsClientExist(string AccountNumber)
        {

            clsBankClient Client1 = Find(AccountNumber);

            return (!Client1.IsEmpty());
        }

        public enum enSaveResults { svFaildEmptyObject , svSucceeded, svFaildAccountNumberExists };

        public enSaveResults Save()
        {

            switch (_Mode)
            {
                case enMode.EmptyMode:
                    {
                        return enSaveResults.svFaildEmptyObject;
                    }

                case enMode.UpdateMode:
                    {

                        _Update();

                        return enSaveResults.svSucceeded;
                    }
                case enMode.AddNewMode:
                    {
                        if (clsBankClient.IsClientExist(_AccountNumber))
                        {
                            return enSaveResults.svFaildAccountNumberExists;
                        }
                        else
                        {
                            _AddNew();
                            _Mode = enMode.UpdateMode;
                            return enSaveResults.svSucceeded;


                        }
                        break;
                    }
            }
            return enSaveResults.svFaildEmptyObject;
        }

        public static clsBankClient GetAddNewClientObject(string AccountNumber)
        {
            return new clsBankClient(enMode.AddNewMode,"","","","",AccountNumber,"",0);
        }

        public bool Delete()
        {
            List<clsBankClient> _lClients = _LoadClientsDataFromFile(); 

            foreach (clsBankClient c in _lClients )
            {
                if (c.AccountNumber() == _AccountNumber )
                {
                    c._MarkedForDelete = true;
                    break;
                }
            }
            _SaveCleintsDataToFile(_lClients);
            this._CopyFrom(_GetEmptyClientObject());



            return true;
        }

        public static List<clsBankClient> GetClientsList()
        {
            return _LoadClientsDataFromFile();
        }

        public static double GetTotalBalances()
        {
            List<clsBankClient> clients = clsBankClient.GetClientsList();
            return clients.Sum(client => client.AccountBalance);
        }

    }
}
