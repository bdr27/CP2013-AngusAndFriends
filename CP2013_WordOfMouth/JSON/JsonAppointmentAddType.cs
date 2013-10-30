using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    public class JsonAppointmentAddType : TemplateJson
    {
        public override string GetJson(object o)
        {
            var a = o as AppointmentType;
            CheckNull(a);
            return JsonConvert.SerializeObject(new ConverterAppointmentAddType(a.GetDescription(), a.GetCost()));
        }

        public override object GetObject(string json)
        {
            var a = JsonConvert.DeserializeObject<ConverterAppointmentAddType>(json);
            CheckValidParams(a.description, a.price);
            return new AppointmentType(0, a.description, a.price);
        }

        private class ConverterAppointmentAddType
        {
            public string description {get;set;}
            public double price {get;set; }

            public ConverterAppointmentAddType(string description, double price)
            {
                this.description = description;
                this.price = price;
            }
        }
    }
}
