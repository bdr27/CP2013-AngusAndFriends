using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.DTO
{
    public class Booking
    {
        private int sessionID;
        private int appointmentType;
        private int dentist;
        private int day;
        private string time;

        public Booking(int sessionID, int appointmentType, int dentist, int day, string time)
        {
            this.sessionID = sessionID;
            this.appointmentType = appointmentType;
            this.dentist = dentist;
            this.day = day;
            this.time = time;
        }

        public int GetSessionID()
        {
            return sessionID;
        }

        public int GetAppointmentType()
        {
            return appointmentType;
        }

        public int GetDentist()
        {
            return dentist;
        }

        public int GetDay()
        {
            return day;
        }

        public string GetTime()
        {
            return time;
        }
    }
}
