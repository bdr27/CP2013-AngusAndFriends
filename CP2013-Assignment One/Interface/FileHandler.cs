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
        void AddExistingUser(User user);
        void AddNewUser(User user);
        void DeleteDentist(int userID);
        void AddNewTimeSlot(TimeSlot timeSlot);
        void AddExistingTimeSlot(TimeSlot timeSlot);
        void AddNewBooking(Booking booking);
        void AddExistingBooking(Booking booking);
        void DeleteBooking(int bookingID);
        Dictionary<int, TimeSlot> GetUserTimeSlots(int userID); 
        Dictionary<int, TimeSlot> GetAvaliableTimeSlots();
        Dictionary<int, Booking> GetAllBookings();
        Dictionary<int, Booking> GetUserBookings(int userID);
        Dictionary<int, User> GetDentists();
        Dictionary<int, TimeSlot> GetTimeSlots();
        Dictionary<int, User> GetAllUsers();
        User GetDentist(int userID);
    }
}
