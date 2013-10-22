using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonTimeSlot : TemplateJson
    {
        public override string GetJson(object o)
        {
            var t = o as TimeSlot;
            CheckNull(t);
            var d = t.GetDentist();
            var dc = new ConverterDentist(d.GetID(), d.GetName(), d.GetEmail(), d.GetPhone());
            return JsonConvert.SerializeObject(new TimeSlotConverter(t.GetID(), dc, t.GetHour(), t.GetMin(), t.GetDay()));
        }

        public override object GetObject(string json)
        {
            var ts = JsonConvert.DeserializeObject<TimeSlotConverter>(json);
            CheckValidParams(ts.id, ts.dentist, ts.hour, ts.minute, ts.day);
            var dc = ts.dentist;
            var d = new Dentist(dc.id, dc.name, dc.email, dc.phone);
            return new TimeSlot(ts.id, d, ts.hour, ts.minute, ts.day);
        }

        private class TimeSlotConverter
        {
            public int id { get; set; }
            public ConverterDentist dentist { get; set; }
            public int hour { get; set; }
            public int minute { get; set; }
            public int day { get; set; }

            public TimeSlotConverter(int id, ConverterDentist dentist, int hour, int min, int day)
            {
                this.id = id;
                this.dentist = dentist;
                this.hour = hour;
                this.minute = min;
                this.day = day;
            }
        }
    }
}
