using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonAllAppointmentTypes : TemplateJson
    {
        public override string GetJson(object o)
        {
            var lap = o as List<AppointmentType>;
            CheckNull(lap);
            var lcap = new List<ConverterAppointmentType>();
            foreach (var a in lap)
            {
                lcap.Add(new ConverterAppointmentType(a.GetID(), a.GetDescription(), a.GetCost()));
            }
            return JsonConvert.SerializeObject(lcap);
        }

        public override object GetObject(string json)
        {
            var capt = JsonConvert.DeserializeObject<List<ConverterAppointmentType>>(json);
            var lat = new List<AppointmentType>();
            foreach (var a in capt)
            {
                CheckValidParams(a.id, a.description, a.cost);
                lat.Add(new AppointmentType(a.id, a.description, a.cost));
            }
            return lat;
        }
    }
}
