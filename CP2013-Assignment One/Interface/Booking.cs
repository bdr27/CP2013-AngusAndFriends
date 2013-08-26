using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Enum;

namespace CP2013_Assignment_One.Interface
{
    public interface Booking
    {
        int GetBookingID();
        int GetTimeSlotID();
        int GetUserID();
        AppointmentType GetAppontmentType();
    }
}
