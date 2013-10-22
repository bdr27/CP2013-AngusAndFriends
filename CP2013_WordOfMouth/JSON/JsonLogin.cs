using CP2013_WordOfMouth.JSON;
using CP2013_WordOfMouth.DTO;
using Newtonsoft.Json;

namespace CP2013_WordOfMouth.JSON
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
