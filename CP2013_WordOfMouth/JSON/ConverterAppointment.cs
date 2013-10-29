using CP2013_WordOfMouth.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    class ConverterAppointment
    {
        public int id { get; set; }
        public ConverterAppointmentType type { get; set; }        
        public ConverterTimeSlot timeSlot { get; set; }
        public long expectedDate { get; set; }

        public ConverterAppointment(int id, ConverterAppointmentType apt, ConverterTimeSlot ts, long expectedDate)
        {
            this.id = id;
            this.expectedDate = expectedDate;
            type = apt;
            timeSlot = ts;
       //     type = new ConverterAppointmentType(apt.GetID(), apt.GetDescription(), apt.GetCost()); // { cost = apt.GetCost(), description = apt.GetDescription(), id = apt.GetID() };
       //     var den = ts.GetDentist();
       //     var dentist = new ConverterDentist(den.GetID(), den.GetName(), den.GetEmail(), den.GetPhone()); // {email = den.GetEmail(), id = den.GetID(), name = den.GetName(), phone = den.GetPhone()};
       //     timeSlot = new ConverterTimeSlot(ts.GetID(), dentist, ts.GetHour(), ts.GetMin(), ts.GetDay()); // { day = ts.GetDay(), dentist = cDentist, hour = ts.GetHour(), id = ts.GetID(), minute = ts.GetMin() };
        }
    }
}
