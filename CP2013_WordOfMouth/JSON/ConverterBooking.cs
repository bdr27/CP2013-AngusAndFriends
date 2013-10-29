using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    class ConverterBooking
    {
        public long seshID { get; set; }
        public int appointment_type { get; set; }
        public int dentist { get; set; }
        public int day { get; set; }
        public string time { get; set; }

        public ConverterBooking(long seshID, int appointment_type, int dentist, int day, string time)
        {
            this.seshID = seshID;
            this.appointment_type = appointment_type;
            this.dentist = dentist;
            this.day = day;
            this.time = time;
        }
    }
}
