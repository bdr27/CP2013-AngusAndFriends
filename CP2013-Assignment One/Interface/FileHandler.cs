using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_Assignment_One.Interface
{
    public interface FileHandler
    {
        void LoadUsers();
        void LoadTimeSlots();
        void AddUser(User user);
        void DeleteDentist(int userID);
        void AddTimeSlot(TimeSlot timeSlot);
        Dictionary<int, User> GetDentists();
        Dictionary<int, TimeSlot> GetTimeSlots();
        Dictionary<int, User> GetAllUsers();
        User GetDentist(int userID);
    }
}
