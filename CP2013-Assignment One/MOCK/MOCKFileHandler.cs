using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Enum;
using CP2013_Assignment_One.Interface;

namespace CP2013_Assignment_One.MOCK
{
    public class MOCKFileHandler : FileHandler
    {
        int timeSlotsID;
        int usersID;
        Dictionary<int, TimeSlot> timeSlots;
        Dictionary<int, User> users;

        public MOCKFileHandler()
        {
            usersID = 1;
            timeSlotsID = 1;
            users = new Dictionary<int, User>();
            timeSlots = new Dictionary<int, TimeSlot>();
            LoadUsers();
            LoadTimeSlots();
        }

        #region FileHandler Members

        public void LoadUsers()
        {
            users.Add(usersID, new MOCKUser(usersID++, "John Smith", UserType.ADMIN));
            users.Add(usersID, new MOCKUser(usersID++, "Pen Vide", UserType.DENTIST));
            users.Add(usersID, new MOCKUser(usersID++, "Home River", UserType.DENTIST));
        }

        public void LoadTimeSlots()
        {
           
        }

        public void AddUser(User user)
        {
            users.Add(user.GetUserID(), user);
        }

        public void DeleteDentist(int userID)
        {
            users.Remove(userID);
        }

        public void AddTimeSlot(TimeSlot timeSlot)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, User> GetDentists()
        {
            var dentists = new Dictionary<int, User>();
            foreach (int userID in users.Keys)
            {
                var user = users[userID];
                if (user.GetType().Equals(UserType.DENTIST))
                {
                    dentists.Add(userID, user);
                }
            }
            return dentists;
        }

        public Dictionary<int, TimeSlot> GetTimeSlots()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, User> GetAllUsers()
        {
            return users;
        }

        public User GetDentist(int userID)
        {
            return users[userID];
        }

        #endregion
    }
}
