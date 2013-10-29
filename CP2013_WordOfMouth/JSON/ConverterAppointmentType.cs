using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.JSON
{
    class ConverterAppointmentType
    {
        public int id { set; get; }
        public string description { set; get; }
        public double cost { set; get; }

        public ConverterAppointmentType(int id, string description, double cost)
        {
            this.id = id;
            this.description = description;
            this.cost = cost;
        }
    }
}
