using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    class ConverterTimeSlot
    {
        public int id { get; set; }
        public ConverterDentist dentist { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int day { get; set; }

        public ConverterTimeSlot(int id, ConverterDentist dentist, int hour, int min, int day)
        {
            this.id = id;
            this.dentist = dentist;
            this.hour = hour;
            this.minute = min;
            this.day = day;
        }
    }
}
