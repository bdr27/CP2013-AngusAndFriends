using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonAppointment : TemplateJson
    {

        public override string GetJson(object o)
        {
            var a = o as Appointment;
            CheckNull(a);
            return JsonConvert.SerializeObject(new AppointmentConverter(a.GetID(), a.GetDescription(), a.GetCost()));
        }

        public override object GetObject(string json)
        {
            var a = JsonConvert.DeserializeObject<AppointmentConverter>(json);
            CheckValidParams(a.id, a.description, a.cost);
            return new Appointment(a.id, a.description, a.cost);
        }

        private class AppointmentConverter
        {
            public int id { set; get; }
            public string description { set; get; }
            public double cost { set; get; }

            public AppointmentConverter(int id, string description, double cost)
            {
                this.id = id;
                this.description = description;
                this.cost = cost;
            }
        }
    }
}
