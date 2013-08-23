using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Enum;

namespace CP2013_Assignment_One.Utility
{
    class MOCKUser : User
    {
        private int userID;
        private string username;
        private int userType;

        public MOCKUser(int userID, string username, int userType)
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
    }
}
