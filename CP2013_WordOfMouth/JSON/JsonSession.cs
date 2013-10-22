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
    public class JsonSession : TemplateJson
    {
        public override string GetJson(object o)
        {
            var s = o as Session;
            CheckNull(s);
            return JsonConvert.SerializeObject(new SessionConvert(s.GetSessionID(), s.GetUsername(), s.GetAdmin()));
        }

        public override object GetObject(string json)
        {
            var sc = JsonConvert.DeserializeObject<SessionConvert>(json);
            CheckValidParams(sc.admin, sc.seshID, sc.user_name);
            return new Session(sc.seshID, sc.user_name, sc.admin);
        }

        private class SessionConvert
        {
            public int seshID { get; set; }
            public string user_name { get; set; }
            public bool admin { get; set; }

            public SessionConvert(int seshID, string user_name, bool admin)
            {
                this.seshID = seshID;
                this.user_name = user_name;
                this.admin = admin;
            }
        }
    }
}
