using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CP2013_WordOfMouth.JSON
{
    class ConverterDentist
    {
        public int dentistID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public ConverterDentist(int id, string name, string email, string phone)
        {
            this.dentistID = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
        }
    }
}
