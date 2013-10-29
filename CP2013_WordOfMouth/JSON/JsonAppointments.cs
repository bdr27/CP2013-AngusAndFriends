using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonAppointments : TemplateJson
    {
        public override string GetJson(object o)
        {
            var a = o as Appointment;
            CheckNull(a);
            var at = a.GetAppointmentType();
            var cat = new ConverterAppointmentType(at.GetID(), at.GetDescription(), at.GetCost());
            var ts = a.GetTimeSlot();
            var den = ts.GetDentist();
            var cDen = new ConverterDentist(den.GetID(), den.GetName(), den.GetEmail(), den.GetPhone());
            var cts = new ConverterTimeSlot(ts.GetID(), cDen, ts.GetHour(), ts.GetMin(), ts.GetDay());
            return JsonConvert.SerializeObject(new ConverterAppointment(a.GetID(), cat, cts, a.GetExpectedDate()));
        }

        public override object GetObject(string json)
        {
            var a = JsonConvert.DeserializeObject<ConverterAppointment>(json);
            CheckValidParams(a.id, a.type, a.timeSlot, a.expectedDate);
            var dentist = a.timeSlot.dentist;
            var type = a.type;
            var timeSlot = a.timeSlot;

            var den = new Dentist(dentist.id, dentist.name, dentist.email, dentist.phone);
            var app = new AppointmentType(type.id, type.description, type.cost);
            var time = new TimeSlot(timeSlot.id, den, timeSlot.hour, timeSlot.minute, timeSlot.day);

            return new Appointment(a.id, app, time, a.expectedDate);
        }
    }
}
