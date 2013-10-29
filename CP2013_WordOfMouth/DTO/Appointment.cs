using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.DTO
{
    public class Appointment
    {
        private int id;
        private AppointmentType appointmentType;
        private TimeSlot timeSlot;
        private long expectedDate;

        public Appointment(int id, AppointmentType appointmentType, TimeSlot timeSlot, long expectedDate)
        {
            this.id = id;
            this.appointmentType = appointmentType;
            this.timeSlot = timeSlot;
            this.expectedDate = expectedDate;
        }

        public int GetID()
        {
            return id;
        }

        public AppointmentType GetAppointmentType()
        {
            return appointmentType;
        }

        public TimeSlot GetTimeSlot()
        {
            return timeSlot;
        }

        public long GetExpectedDate()
        {
            return expectedDate;
        }
    }
}
