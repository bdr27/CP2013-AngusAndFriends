using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_Assignment_One.Interface
{
    public interface FileHandler
    {
        void AddDentist(User user);
        void DeleteDentist(int userID);
        void AddBookingTime(TimeSlot bookingTime);
    }
}
