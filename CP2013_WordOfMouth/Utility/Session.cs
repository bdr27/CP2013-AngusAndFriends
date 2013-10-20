using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Interface;
using Newtonsoft.Json;

namespace CP2013_Assignment_One.Utility
{
    public class Session : ReqJson
    {
        public bool admin { get; set; }
        public int seshID { get; set; }
        public string user_name { get; set; }

        public Session(bool admin, int seshID, string user_name)
        {
            this.admin = admin;
            this.seshID = seshID;
            this.user_name = user_name;
        }

        #region ReqJson Members

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion
    }
}
