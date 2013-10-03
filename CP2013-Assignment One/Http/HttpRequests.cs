using System.Collections.Generic;
using CP2013_Assignment_One.Interface;
using Newtonsoft.Json;
using RestSharp;

namespace CP2013_Assignment_One.Http
{
    public class HttpRequests : RequestResponse
    {
        private RestClient client;
        private string url;
        
        public HttpRequests(string url)
        {
            this.url = url;
            client = new RestClient();
            client.BaseUrl = url;
        }
            
        #region RequestResponse Members

        public List<Dentist> GetAllDentists()
        {
            var request = new RestRequest();
            request.Resource = "/get/all/dentists";
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<Dentist>>(response.Content);
        }

        public Dentist GetDentist(int id)
        {
            var request = new RestRequest();
            request.Resource = "/get/dentist/" + id;
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Dentist>(response.Content);
        }

        public void AddDentist(Dentist dentist)
        {
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            request.AddBody(dentist);
            request.Resource = "/add/dentist";
            var response = client.Execute(request);
        }

        public List<TimeSlots> GetAllTimeSlots()
        {
            var request = new RestRequest();
            request.Resource = "/get/all/times";
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<TimeSlots>>(response.Content);
        }

        public List<TimeSlots> GetTimeSlotsForDentist(int id)
        {
            var request = new RestRequest();
            request.Resource = "/get/all/times/for/dentist" + id;
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<TimeSlots>>(response.Content);
        }
        #endregion
    }
}
