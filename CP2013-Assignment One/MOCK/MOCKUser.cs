using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Enum;
using CP2013_Assignment_One.Interface;

namespace CP2013_Assignment_One.MOCK
{
    public class MOCKUser : User
    {
        private int userID;
        private string username;
        private UserType userType;

        public MOCKUser(string username, UserType userType)
        {
            this.username = username;
            this.userType = userType;
        }

        public MOCKUser(int userID, string username, UserType userType)
        {
            this.userID = userID;
            this.username = username;
            this.userType = userType;
        }

        #region User Members

        public int GetUserID()
        {
            return userID;
        }

        public string GetUsername()
        {
            return username;
        }

        public UserType GetUserType()
        {
            return userType;
        }

        #endregion

        public override string ToString()
        {
            return String.Format("ID: {0}, Username: {1}, UserType: {2}", userID, username, userType);
        }
    }
}
