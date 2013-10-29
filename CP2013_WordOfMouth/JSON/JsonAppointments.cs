using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    class JsonAppointments : TemplateJson
    {
        public override string GetJson(object o)
        {
            var a = o as Appointment;
            CheckNull(a);
            return JsonConvert.SerializeObject(new ConverterAppointment(a.GetID(), a.GetAppointmentType(), a.GetTimeSlot(), a.GetExpectedDate()));
        }

        public override object GetObject(string json)
        {
            var a = JsonConvert.DeserializeObject<ConverterAppointment>(json);
            CheckValidParams(a.id, a.cDentist, a.cAppointmentType, a.cTimeSlot, a.expectedDate);
            var cDen = a.cDentist;
            var cApp = a.cAppointmentType;
            var cTim = a.cTimeSlot;

            var den = new Dentist(cDen.id, cDen.name, cDen.email, cDen.phone);
            var app = new AppointmentType(cApp.id, cApp.description, cApp.cost);
            var time = new TimeSlot(cTim.id, den, cTim.hour, cTim.minute, cTim.day);

            return new Appointment(a.id, app, time, a.expectedDate);
        }


    }
}
