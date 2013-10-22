using CP2013_WordOfMouth.Interface;
using Newtonsoft.Json;

namespace CP2013_WordOfMouth.Utility
{
    public class Dentist : ReqJson
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
