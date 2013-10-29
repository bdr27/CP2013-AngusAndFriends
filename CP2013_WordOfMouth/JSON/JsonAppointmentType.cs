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
            return JsonConvert.SerializeObject(new ConverterAppointmentType(a.GetID(), a.GetDescription(), a.GetCost()));
        }

        public override object GetObject(string json)
        {
            var a = JsonConvert.DeserializeObject<ConverterAppointmentType>(json);
            CheckValidParams(a.id, a.description, a.cost);
            return new AppointmentType(a.id, a.description, a.cost);
        }
    }
}
