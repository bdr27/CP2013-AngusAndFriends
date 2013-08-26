using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Enum;
using CP2013_Assignment_One.Interface;

namespace CP2013_Assignment_One.MOCK
{
    public class MOCKBooking : Booking
    {
        int bookingID;
        int timeSlotID;
        int userID;
        AppointmentType appointmentType;

        public MOCKBooking(int bookingID, int timeSlotID, int userID, AppointmentType appointmentType)
        {
            this.bookingID = bookingID;
            this.timeSlotID = timeSlotID;
            this.userID = userID;
            this.appointmentType = appointmentType;
        }

        #region Booking Members

        public int GetBookingID()
        {
            return bookingID;
        }

        public int GetTimeSlotID()
        {
            return timeSlotID;
        }

        public int GetUserID()
        {
            return userID;
        }

        public AppointmentType GetAppontmentType()
        {
            return appointmentType;
        }

        #endregion
    }
}
