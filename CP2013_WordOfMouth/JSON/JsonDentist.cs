using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonDentist : TemplateJson
    {
        public override string GetJson(object o)
        {
            var d = o as Dentist;
            CheckNull(d);
            return JsonConvert.SerializeObject(new ConverterDentist(d.GetID(), d.GetName(), d.GetEmail(), d.GetPhone()));
        }

        public override object GetObject(string json)
        {
            var d = JsonConvert.DeserializeObject<ConverterDentist>(json);
            CheckValidParams(d.dentistID, d.name, d.email, d.phone);
            return new Dentist(d.dentistID, d.name, d.email, d.phone);
        }
    }
}
