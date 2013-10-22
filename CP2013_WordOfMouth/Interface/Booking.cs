using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Enum;

namespace CP2013_WordOfMouth.Interface
{
    public interface Booking
    {
        int GetBookingID();
        int GetTimeSlotID();
        int GetUserID();
        AppointmentType GetAppontmentType();
    }
}
