using System.Collections.Generic;
using CP2013_Assignment_One.Interface;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System;

namespace CP2013_Assignment_One.Utility
{
    public class HttpRequests : RequestResponse
    {
        private string url;
        
        public HttpRequests(string url)
        {
            this.url = url;
        }
            
        #region RequestResponse Members

        public List<Dentist> GetAllDentists()
        {
            return JsonConvert.DeserializeObject<List<Dentist>>(GetRequest("get/all/dentists"));
        }

        public Dentist GetDentist(int id)
        {
            return JsonConvert.DeserializeObject<Dentist>(GetRequest("get/dentist/" + id));
        }

        public void AddDentist(Dentist dentist)
        {
            PostRequestJson(dentist, "add/dentist");
        }

        public void DeleteDentist(int id)
        {
            PostRequest("delete/dentist/" + id);
        }

        public List<TimeSlots> GetAllTimeSlots()
        {
            return JsonConvert.DeserializeObject<List<TimeSlots>>(GetRequest("/get/all/times"));
        }

        public List<TimeSlots> GetTimeSlotsForDentist(int id)
        {
            return JsonConvert.DeserializeObject<List<TimeSlots>>(GetRequest("get/all/times/for/dentist/" + id));
        }

        public void ResetDentistTimes(int id)
        {
            PostRequest("set/times/for/dentist/" + id);
        }

        #endregion

        private string PostRequest(string location)
        {
            var http = GetHttp(location);
            var response = http.Post();
            return response.Content;
        }

        private string GetRequest(string location)
        {
            var http = GetHttp(location);
            var response = http.Get();
            return response.Content;
        }

        private void PostRequestJson(ReqJson objSend, string location)
        {
            var http = GetHttp(location);
            http.RequestBody = objSend.GetJson();
            var response = http.Post();
        }

        private Http GetHttp(string location)
        {
            var http = new Http();
            http.Url = new Uri(url + location);
            http.RequestContentType = "application/json";
            return http;
        }

        private Http SetJson(Http http)
        {
            http.RequestContentType = "application/json";
            return http;
        }
    }
}
