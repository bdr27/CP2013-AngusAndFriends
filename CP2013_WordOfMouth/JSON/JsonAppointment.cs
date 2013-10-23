using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonAppointmentType : TemplateJson
    {

        public override string GetJson(object o)
        {
            var a = o as AppointmentType;
            CheckNull(a);
            return JsonConvert.SerializeObject(new AppointmentTypeConverter(a.GetID(), a.GetDescription(), a.GetCost()));
        }

        public override object GetObject(string json)
        {
            var a = JsonConvert.DeserializeObject<AppointmentTypeConverter>(json);
            CheckValidParams(a.id, a.description, a.cost);
            return new AppointmentType(a.id, a.description, a.cost);
        }

        private class AppointmentTypeConverter
        {
            public int id { set; get; }
            public string description { set; get; }
            public double cost { set; get; }

            public AppointmentTypeConverter(int id, string description, double cost)
            {
                this.id = id;
                this.description = description;
                this.cost = cost;
            }
        }
    }
}
