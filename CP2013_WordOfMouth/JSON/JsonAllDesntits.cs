using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonAllDentists : TemplateJson
    {
        public override string GetJson(object o)
        {
            var dentists = o as List<Dentist>;
            CheckNull(dentists);
            var d = new List<ConverterDentist>();
            foreach (var dentist in dentists)
            {
                d.Add(new ConverterDentist(dentist.GetID(), dentist.GetName(), dentist.GetEmail(), dentist.GetPhone()));
            }
            return JsonConvert.SerializeObject(d);
        }

        public override object GetObject(string json)
        {
            var dentists = JsonConvert.DeserializeObject<List<ConverterDentist>>(json);
            var d = new List<Dentist>();
            foreach (var dentist in dentists)
            {
                CheckValidParams(dentist.dentistID, dentist.name);
                d.Add(new Dentist(dentist.dentistID, dentist.name, dentist.email, dentist.phone));
            }
            return d;
        }
    }
}
