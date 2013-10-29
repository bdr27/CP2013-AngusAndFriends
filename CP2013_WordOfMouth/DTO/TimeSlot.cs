using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.DTO
{
    public class TimeSlot
    {
        private int id;
        private Dentist dentist;
        private int hour;
        private int min;
        private int day;

        public TimeSlot(int id, Dentist dentist, int hour, int min, int day)
        {
            this.id = id;
            this.dentist = dentist;
            this.hour = hour;
            this.min = min;
            this.day = day;
        }

        public int GetID()
        {
            return this.id;
        }

        public Dentist GetDentist()
        {
            return this.dentist;
        }

        public int GetHour()
        {
            return this.hour;
        }

        public int GetMin()
        {
            return this.min;
        }

        public int GetDay()
        {
            return this.day;
        }

        public override string ToString()
        {
            var returnString = GetHour() + ":";
            if (GetMin() < 10)
                returnString += "0" + GetMin();
            else
                returnString += GetMin();
            return returnString;
        }
    }
}
