using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonDentistTimeSlots : TemplateJson
    {
        public override string GetJson(object o)
        {
            var lts = o as List<TimeSlot>;
            var cdl = new List<ConverterTimeSlot>();
            CheckNull(lts);
            foreach (var t in lts)
            {
                var d = t.GetDentist();
                var dc = new ConverterDentist(d.GetID(), d.GetName(), d.GetEmail(), d.GetPhone());
                cdl.Add(new ConverterTimeSlot(t.GetID(), dc, t.GetHour(), t.GetMin(), t.GetDay()));
            }
            return JsonConvert.SerializeObject(cdl);
        }

        public override object GetObject(string json)
        {
            var lts = JsonConvert.DeserializeObject<List<ConverterTimeSlot>>(json);
            var timeSlots = new List<TimeSlot>();
            foreach (var ts in lts)
            {
                CheckValidParams(ts.id, ts.dentist, ts.hour, ts.minute, ts.day);
                var dc = ts.dentist;
                var d = new Dentist(dc.id, dc.name, dc.email, dc.phone);
                timeSlots.Add(new TimeSlot(ts.id, d, ts.hour, ts.minute, ts.day));
            }
            return timeSlots;
        }
    }
}
