using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<clsUser> users = new List<clsUser>();
            if (File.Exists("Users.txt"))
            {
                string[] lines = File.ReadAllLines("Users.txt");
                foreach (string line in lines)
                {
                    users.Add(_ConvertLineToUserObject(line));
                }
            }
            return users;
        }

        private static void _SaveUsersDataToFile(List<clsUser> users)
        {
            List<string> lines = new List<string>();
            foreach (clsUser user in users)
            {
                if (!user.MarkedForDeleted)
                {
                    lines.Add(_ConvertUserObjectToLine(user));
                }
            }
            File.WriteAllLines("Users.txt", lines);
        }

        private void _Update()
        {
            List<clsUser> users = _LoadUsersDataFromFile();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName == UserName)
                {
                    users[i] = this;
                    break;
                }
            }
            _SaveUsersDataToFile(users);
        }
        

        private void _AddNew()
        {
            File.AppendAllText("Users.txt", _ConvertUserObjectToLine(this) + Environment.NewLine);
        }

        private static clsUser _GetEmptyUserObject()
        {
            return new clsUser(enMode.EmptyMode, "", "", "", "", "", "", 0);
        }

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
        public bool MarkedForDeleted => _MarkedForDelete;

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

        public static clsUser Find(string userName)
        {
            if (File.Exists("Users.txt"))
            {
                foreach (string line in File.ReadLines("Users.txt"))
                {
                    clsUser user = _ConvertLineToUserObject(line);
                    if (user.UserName == userName)
                    {
                        return user;
                    }
                }
            }
            return _GetEmptyUserObject();
        }

        public static clsUser Find(string userName, string password)
        {
            if (File.Exists("Users.txt"))
            {
                foreach (string line in File.ReadLines("Users.txt"))
                {
                    clsUser user = _ConvertLineToUserObject(line);
                    if (user.UserName == userName && user.Password == password)
                    {
                        return user;
                    }
                }
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
    }

}

