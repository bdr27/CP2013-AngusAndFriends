using CP2013_Assignment_One.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_Assignment_One.JSON
{
    public class JsonSignUp : TemplateJson
    {
        public override string GetJson(object o)
        {
            var su = o as SignUp;
            CheckNull(su);
            return JsonConvert.SerializeObject(new SignUpConvert(su.GetEmail(), su.GetPassword(), su.GetReEnterEmail(), su.GetReEnterPassword(), su.GetPhone(), su.GetFirstName(), su.GetLastName()));
        }

        public override object GetObject(string json)
        {
            var suc = JsonConvert.DeserializeObject<SignUpConvert>(json);
            CheckValidParams(suc.email, suc.password, suc.reentered_email, suc.reentered_password, suc.phone, suc.first_name, suc.last_name);
            return new SignUp(suc.email, suc.password, suc.reentered_email, suc.reentered_password, suc.phone, suc.first_name, suc.last_name);
        }

        private class SignUpConvert
        {
            public string email {get; set;}
            public string password { get; set; }
            public string reentered_email { get; set; }
            public string reentered_password { get; set; }
            public string phone { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }

            public SignUpConvert(string email, string password, string reentered_email, string reentered_password, string phone, string first_name, string last_name)
            {
                // TODO: Complete member initialization
                this.email = email;
                this.password = password;
                this.reentered_email = reentered_email;
                this.reentered_password = reentered_password;
                this.phone = phone;
                this.first_name = first_name;
                this.last_name = last_name;
            }
        }
    }
}
