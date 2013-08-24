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
            AddNewUser(new MOCKUser("John Smith", UserType.ADMIN));
            AddNewUser(new MOCKUser("Pen Vide", UserType.DENTIST));
            AddNewUser(new MOCKUser("Home River", UserType.DENTIST));
        }

        public void LoadTimeSlots()
        {
            var day = 8;
            var month = 10;
            var year = 2013;
            var startTime = 8;
            var endTime = 17;

            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, startTime, 0, 0), 2));
            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, startTime, 0, 0), 2));
            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, startTime, 0, 0), 2));
            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, startTime, 0, 0), 2));
            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, startTime, 0, 0), 2));
            AddNewTimeSlot(new MOCKTimeSlot(new DateTime(year, month, day, startTime, 0, 0), new DateTime(year, month, day++, startTime, 0, 0), 2));
        }

        public void AddExistingUser(User user)
        {
            users.Add(user.GetUserID(), user);
        }

        public void AddNewUser(User user)
        {
            var ID = usersID++;
            var newUser = new MOCKUser(ID, user.GetUsername(), user.GetUserType());
            users.Add(ID, newUser);
        }

        public void DeleteDentist(int userID)
        {
            users.Remove(userID);
        }

        public void AddNewTimeSlot(TimeSlot timeSlot)
        {
            var ID = timeSlotsID++;
            var newTimeSlot = new MOCKTimeSlot(ID, timeSlot.GetStartTime(), timeSlot.GetEndTime(), timeSlot.GetUserID());
            timeSlots.Add(ID, newTimeSlot);
        }

        public void AddExistingTimeSlot(TimeSlot timeSlot)
        {
            timeSlots.Add(timeSlot.GetTimeSlotID(), new MOCKTimeSlot(timeSlot.GetTimeSlotID(), timeSlot.GetStartTime(), timeSlot.GetEndTime(), timeSlot.GetUserID()));
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
            return timeSlots;
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
