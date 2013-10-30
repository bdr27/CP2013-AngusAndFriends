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

        public override string ToString()
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var completeDate = start.AddMilliseconds(expectedDate).ToLocalTime();
            var day = completeDate.Day + "/" + completeDate.Month + "/" + completeDate.Year;
            var time = timeSlot.GetHour() + ":";
            if (completeDate.Minute < 10)
                time += "0" + timeSlot.GetMin();
            else
                time += timeSlot.GetMin();
            return "ID: " + id + " \tDate: " + day + " " + time;
        }
    }
}
