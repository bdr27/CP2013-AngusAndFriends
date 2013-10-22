using System.Collections.Generic;
using CP2013_WordOfMouth.Interface;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System;
using CP2013_WordOfMouth.DTO;

namespace CP2013_WordOfMouth.Utility
{
    public class HttpRequests : RequestResponse
    {
        private string url;
        
        public HttpRequests(string url)
        {
            this.url = url;
        }
            
        #region RequestResponse Members

        public List<OldDentist> GetAllDentists()
        {
            return JsonConvert.DeserializeObject<List<OldDentist>>(GetRequest("get/all/dentists"));
        }

        public OldDentist GetDentist(int id)
        {
            return JsonConvert.DeserializeObject<OldDentist>(GetRequest("get/dentist/" + id));
        }

        public void AddDentist(OldDentist dentist)
        {
            PostRequest(dentist, "add/dentist");
        }

        public void DeleteDentist(int id)
        {
            PostRequest("delete/dentist/" + id);
        }

        public List<OldTimeSlots> GetAllTimeSlots()
        {
            return JsonConvert.DeserializeObject<List<OldTimeSlots>>(GetRequest("/get/all/times"));
        }

        public List<OldTimeSlots> GetTimeSlotsForDentist(int id)
        {
            return JsonConvert.DeserializeObject<List<OldTimeSlots>>(GetRequest("get/all/times/for/dentist/" + id));
        }

        public void ResetDentistTimes(int id)
        {
            PostRequest("set/times/for/dentist/" + id);
        }

        public Session Login(OldLogin login)
        {
            var response = PostRequest(login, "/secure/login");
            return null;
         //   return JsonConvert.DeserializeObject<Session>(response);
        }

        #endregion

        private string PostRequest(string location)
        {
            var http = GetHttp(location);
            var response = http.Post();
            return response.Content;
        }

        private HttpResponse PostRequest(ReqJson objSend, string location)
        {
            var http = GetHttp(location);
            http.RequestBody = objSend.GetJson();
            var response = http.Post();
            return null;
           // return response.Content;
        }

        private string GetRequest(string location)
        {
            var http = GetHttp(location);
            var response = http.Get();
            return response.Content;
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
