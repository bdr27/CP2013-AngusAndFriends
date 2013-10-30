﻿using CP2013_WordOfMouth.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpPostAddDentist : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string location = HTTP_INFO.GetAddDentist();
        private Http http;
        private HttpResponse response;

        public HttpPostAddDentist()
        {
            http = new Http();
            http.Url = new Uri(baseUrl + location);
            http.RequestContentType = "application/json";
        }

        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.RequestBody = request;
            response = http.Post();
        }

        public string GetResponse()
        {
            return response.Content;
        }

        #endregion


        public HttpResponse GetHttpResponse()
        {
            return response;
        }
    }
}
