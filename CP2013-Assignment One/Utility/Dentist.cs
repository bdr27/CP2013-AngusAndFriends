using CP2013_Assignment_One.Interface;
using Newtonsoft.Json;

namespace CP2013_Assignment_One.Utility
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
