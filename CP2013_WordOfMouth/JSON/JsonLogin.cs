using CP2013_Assignment_One.Exceptions;
using CP2013_Assignment_One.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_Assignment_One.JSON
{
    public class JsonLogin : TemplateJson
    {
        public override string GetJson(object o)
        {
            var l = o as Login;
            CheckNull(l);
            return JsonConvert.SerializeObject(new LoginConvert(l.GetUsername(), l.GetPassword()));
        }

        public override object GetObject(string json)
        {
            var lc =  JsonConvert.DeserializeObject<LoginConvert>(json);
            CheckValidParams(lc.email, lc.password);
            return new Login(lc.email, lc.password);
        }

        private class LoginConvert
        {
            public string email { get; set; }
            public string password { get; set; }

            public LoginConvert(string email, string password)
            {
                this.email = email;
                this.password = password;
            }
        }
    }
}
