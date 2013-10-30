using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonDentistEditAdd : TemplateJson
    {
        public override string GetJson(object o)
        {
            var d = o as Dentist;
            CheckNull(d);
            return JsonConvert.SerializeObject(new ConverterDentistEditAdd(d.GetID(), d.GetName(), d.GetEmail(), d.GetPhone()));
        }

        public override object GetObject(string json)
        {
            var d = JsonConvert.DeserializeObject<ConverterDentistEditAdd>(json);
            CheckValidParams(d.dentistID, d.name, d.email, d.phone);
            return new Dentist(d.dentistID, d.name, d.email, d.phone);
        }

        private class ConverterDentistEditAdd
        {
            public int dentistID { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string phone { get; set; }

            public ConverterDentistEditAdd(int dentistID, string name, string email, string phone)
            {
                this.dentistID = dentistID;
                this.name = name;
                this.phone = phone;
                this.email = email;
            }
        }
    }
}
