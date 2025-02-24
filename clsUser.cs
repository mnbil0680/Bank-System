using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using static Bank_System.clsUser;

namespace Bank_System
{
    internal class clsUser : clsPerson
    {

        internal enum enMode { EmptyMode = 0, UpdateMode = 1, AddNewMode = 2 }
        private enMode _Mode;
        private string _UserName;
        private string _Password;
        private int _Permissions;
        private bool _MarkedForDelete = false;

        private static clsUser _ConvertLineToUserObject(string line, string separator = "#//#")
        {
            string[] userData = line.Split(new string[] { separator }, StringSplitOptions.None);
            return new clsUser(enMode.UpdateMode, userData[0], userData[1], userData[2],
                               userData[3], userData[4], userData[5], int.Parse(userData[6]));
        }

        private static string _ConvertUserObjectToLine(clsUser user, string separator = "#//#")
        {
            return $"{user.FirstName}{separator}{user.LastName}{separator}{user.Email}{separator}" +
                   $"{user.Phone}{separator}{user.UserName}{separator}{user.Password}{separator}" +
                   $"{user.Permissions}";
        }

        private static List<clsUser> _LoadUsersDataFromFile()
        {
            string PathName = @"D:\Bank System\Users.txt";
            List<clsUser> lUsers = new List<clsUser>();
            FileStream FS = System.IO.File.OpenRead(PathName);
            StreamReader SR = new StreamReader(FS, Encoding.UTF8);
            if (System.IO.File.Exists(PathName))
            {
                try
                {

                    string Line = "";
                    while ((Line = SR.ReadLine()) != null)
                    {
                        // Process line
                        clsUser User = _ConvertLineToUserObject(Line);
                        if (User != null)
                        {
                            lUsers.Add(User);
                        }

                    }
                    FS.Close();
                    return lUsers;

                }
                catch (Exception e)
                {

                    FS.Close();
                    return lUsers;



                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
                return lUsers;
            }
        }

        private static void _SaveUsersDataToFile(List<clsUser> users)
        {
            // path of the file that we want to create
            string PathName = @"D:\Bank System\Users.txt";

            if (System.IO.File.Exists(PathName))
            {
                try
                {


                    string DataLine = "";

                    System.IO.File.WriteAllText(PathName, String.Empty);
                    foreach (clsUser C in users)
                    {
                        if (C.MarkedForDeleted() == false)
                        {

                            DataLine += "\n";
                            DataLine = _ConvertUserObjectToLine(C);


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

                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
            }
        }

        private void _Update()
        {
            List<clsUser> _vUsers = _LoadUsersDataFromFile(); // Load clients from file

            for (int i = 0; i < _vUsers.Count; i++)
            {
                if (_vUsers[i].UserName == UserName)  // Match account number
                {
                    _vUsers[i] = this;  // Update the object
                    break;
                }
            }

            _SaveUsersDataToFile(_vUsers); // Save updated list to file
        }


        private void _AddDataLineToFile(string stDataLine)
        {
            // path of the file that we want to create
            string PathName = @"D:\Bank System\Users.txt";


            if (System.IO.File.Exists(PathName))
            {
                try
                {

                    // write but clear all content

                    System.IO.File.AppendAllText(PathName, '\n' + stDataLine);



                }
                catch (Exception e)
                {


                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
            }




        }


        private void _AddNew()
        {
            _AddDataLineToFile(_ConvertUserObjectToLine(this));
        }

        private static clsUser _GetEmptyUserObject()
        {
            return new clsUser(enMode.EmptyMode, "", "", "", "", "", "", 0);
        }

        public enum enPermissions
        {
            // Store Permissions in Binary system
            eAll = -1,          // 1111111
            pListClients = 1,   // 0000001
            pAddNewClient = 2,  // 0000010
            pDeleteClient = 4,  // 0000100
            pUpdateClients = 8, // 0001000
            pFindClient = 16,   // 0010000
            pTranactions = 32,  // 0100000
            pManageUsers = 64   // 1000000
        };

        public clsUser(enMode mode, string firstName, string lastName, string email,
                       string phone, string userName, string password, int permissions)
            : base(firstName, lastName, email, phone)
        {
            _Mode = mode;
            _UserName = userName;
            _Password = password;
            _Permissions = permissions;
        }

        public bool IsEmpty => _Mode == enMode.EmptyMode;
        public bool MarkedForDeleted()
        {
            return _MarkedForDelete;
        }

        public string UserName
        {
            get => _UserName;
            set => _UserName = value;
        }

        public string Password
        {
            get => _Password;
            set => _Password = value;
        }

        public int Permissions
        {
            get => _Permissions;
            set => _Permissions = value;
        }

        public static clsUser Find(string UserName)
        {

            // path of the file that we want to create
            string PathName = @"D:\Bank System\Users.txt";
            FileStream FS = System.IO.File.OpenRead(PathName);
            StreamReader SR = new StreamReader(FS, Encoding.UTF8);
            if (System.IO.File.Exists(PathName))
            {
                try
                {


                    string Line = "";
                    while ((Line = SR.ReadLine()) != null)
                    {
                        // Process line
                        clsUser User = _ConvertLineToUserObject(Line);
                        if (User.UserName == UserName)
                        {
                            FS.Close();
                            return User;
                        }

                    }
                    FS.Close();

                }
                catch (Exception e)
                {

                    FS.Close();
                    return _GetEmptyUserObject();

                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
                return _GetEmptyUserObject();
            }


            return _GetEmptyUserObject();
        }

        public static clsUser Find(string UserName, string Password)
        {

            // path of the file that we want to create
            string PathName = @"D:\Bank System\Users.txt";
            FileStream FS = System.IO.File.OpenRead(PathName);
            StreamReader SR = new StreamReader(FS, Encoding.UTF8);
            if (System.IO.File.Exists(PathName))
            {
                try
                {

                    string Line = "";
                    while ((Line = SR.ReadLine()) != null)
                    {
                        // Process line
                        clsUser User = _ConvertLineToUserObject(Line);
                        if (User.UserName == UserName && User.Password == Password)
                        {
                            FS.Close();
                            return User;
                        }

                    }
                    FS.Close();

                }
                catch (Exception e)
                {

                    FS.Close();
                    return _GetEmptyUserObject();

                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
                return _GetEmptyUserObject();
            }


            return _GetEmptyUserObject();
        }


        public enum enSaveResults { svFailedEmptyObject = 0, svSucceeded = 1, svFailedUserExists = 2 }

        public enSaveResults Save()
        {
            switch (_Mode)
            {
                case enMode.EmptyMode:
                    return enSaveResults.svFailedEmptyObject;

                case enMode.UpdateMode:
                    _Update();
                    return enSaveResults.svSucceeded;

                case enMode.AddNewMode:
                    if (IsUserExist(_UserName))
                    {
                        return enSaveResults.svFailedUserExists;
                    }
                    else
                    {
                        _AddNew();
                        _Mode = enMode.UpdateMode;
                        return enSaveResults.svSucceeded;
                    }
            }
            return enSaveResults.svFailedEmptyObject;
        }

        public static bool IsUserExist(string userName)
        {
            return !Find(userName).IsEmpty;
        }

        public bool Delete()
        {
            List<clsUser> users = _LoadUsersDataFromFile();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName == _UserName)
                {
                    users[i]._MarkedForDelete = true;
                    break;
                }
            }
            _SaveUsersDataToFile(users);
            return true;
        }

        public static clsUser GetAddNewUserObject(string userName)
        {
            return new clsUser(enMode.AddNewMode, "", "", "", "", userName, "", 0);
        }

        public static List<clsUser> GetUsersList()
        {
            return _LoadUsersDataFromFile();
        }
        public string lUserName()
        {
            return _UserName;
        }

        public bool CheckAccessPermission(enPermissions Permission)
        {
            if (this.Permissions == (int)enPermissions.eAll)
                return true;

            return ( (int)Permission & this.Permissions) == (int)Permission;
        }
        string _PrepareLogInRecord(string Seperator = "#//#")
        {
            string LoginRecord = "";
            LoginRecord += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) + Seperator;
            LoginRecord += UserName + Seperator;
            LoginRecord += Password + Seperator;
            LoginRecord += Permissions.ToString();
            return LoginRecord;
        }
        public void RegisterLogIn()
        {
            // path of the file that we want to create
            string PathName = @"D:\Bank System\LoginRegister.txt";
            string stDataLine = _PrepareLogInRecord();


            if (System.IO.File.Exists(PathName))
            {
                try
                {

                    // write but clear all content

                    System.IO.File.AppendAllText(PathName, '\n' + stDataLine);



                }
                catch (Exception e)
                {


                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
            }
        }
        public struct stLoginRegisterRecord
        {
            public string DateTime;
            public string UserName;
            public string Password;
            public int Permissions;

        };
        private static stLoginRegisterRecord _ConvertLoginRegisterLineToRecord(string Line, string Seperator = "#//#")
        {
            stLoginRegisterRecord LoginRegisterRecord;


            List<string> LoginRegisterDataLine = clsString.split(Line, Seperator);
            LoginRegisterRecord.DateTime = LoginRegisterDataLine[0];
            LoginRegisterRecord.UserName = LoginRegisterDataLine[1];
            LoginRegisterRecord.Password = LoginRegisterDataLine[2];
            LoginRegisterRecord.Permissions = Int32.Parse(LoginRegisterDataLine[3]);

            return LoginRegisterRecord;

        }

        
        public static List<stLoginRegisterRecord> GetLoginRegisterList()
        {
            List<stLoginRegisterRecord> vLoginRegisterRecord = new List<stLoginRegisterRecord>();
            stLoginRegisterRecord LoginRegisterRecord;
     
            string PathName = @"D:\Bank System\LoginRegister.txt";
            FileStream FS = System.IO.File.OpenRead(PathName);
            StreamReader SR = new StreamReader(FS, Encoding.UTF8);
            if (System.IO.File.Exists(PathName))
            {
                try
                {

                    string Line;
                    while ((Line = SR.ReadLine()) != null)
                    {
                        LoginRegisterRecord = _ConvertLoginRegisterLineToRecord(Line);
                        vLoginRegisterRecord.Add(LoginRegisterRecord);
                    }
                    FS.Close();
                    return vLoginRegisterRecord;
                }
                catch (Exception e)
                {
                    FS.Close();
                    return vLoginRegisterRecord;
                }
            }
            else
            {
                Console.WriteLine("Sorry, File Does not Exist ");
                return vLoginRegisterRecord;
            }
        }
    }

}

