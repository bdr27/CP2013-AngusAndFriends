using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_Assignment_One.Interface;
using Newtonsoft.Json;

namespace CP2013_Assignment_One.Utility
{
    public class OldLogin : ReqJson 
    {
        public string email {get; set;}
        public string password {get; set;}

        public OldLogin(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        #region ReqJson Members

        public string GetJson()
        {            
            return JsonConvert.SerializeObject(this);
        }

        #endregion

    }
}
