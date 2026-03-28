using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        private clsPerson _Person;
        private int _Person_ID;
        public int User_ID { get; set; }
        public int Person_ID
        {
            get { return _Person_ID; }
            set
            {
                _Person_ID = value;
                this.PersonInfo = clsPerson.Find(value);
            }
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsPerson PersonInfo
        {
            get
            {
                if (_Person == null && this.Person_ID != -1)
                    _Person = clsPerson.Find(this.Person_ID);

                return _Person;
            }
            set { _Person = value; }
        }
        public clsUser()
        {
            this.User_ID = -1;
            this.Person_ID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = false;
        }
        private clsUser(int User_ID, int Person_ID, string Username, string Password, bool IsActive)
        {

            this.User_ID = User_ID;
            this.Person_ID = Person_ID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }
        public static clsUser Find(int User_ID)
        {
            int Person_ID = -1; string Username = "", Password = ""; bool IsActive = false;
            if (clsUserData.GetUserByID(User_ID, ref Person_ID, ref Username, ref Password, ref IsActive))
            {
                return new clsUser(User_ID, Person_ID, Username, Password, IsActive);
            }
            return null;
        }
        public static clsUser FindByUsernameAndPassword(string Username, string Password)
        {
            int Person_ID = -1, User_ID = -1; bool IsActive = false;
            if (clsUserData.GetUserByUserNameAndPassword(Username, Password , ref User_ID,ref Person_ID, ref IsActive))
            {
                return new clsUser(User_ID, Person_ID, Username, Password, IsActive);
            }
            return null;
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;
            if (clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        public static DataTable GetAllUsers() => clsUserData.GetAllUsers();

        private bool _AddNewUser()
        {
            if (this.PersonInfo != null && this.Person_ID == -1)
            {
                if (this.PersonInfo.Save()) 
                {
                    this.Person_ID = this.PersonInfo.PersonID;
                }
                else return  false;
              
            }
            this.User_ID = clsUserData.AddNewUser(this.Person_ID, this.Username, this.Password, this.IsActive);
            return (this.User_ID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.User_ID, this.Person_ID, this.Username, this.Password, this.IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();

                default:
                    return false;
            }

        }
        public static bool DeleteUser(int User_ID) => clsUserData.DeleteUser(User_ID);

        public static bool IsUserExist(int User_ID) => clsUserData.IsUserExist(User_ID);
        public static bool IsUserExist(string Username) => clsUserData.IsUserExist(Username);
        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }
    }
}
