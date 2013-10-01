using Newtonsoft.Json;

namespace CP2013_Assignment_One.Http
{
    public class Dentist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
