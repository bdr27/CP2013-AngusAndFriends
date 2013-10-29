using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.Utility;
using RestSharp;

namespace CP2013_WordOfMouth.Gather
{
    public class HttpGetDentistTimeSlots : IRequestResponse
    {
        private string baseUrl = HTTP_INFO.GetUrlBase();
        private string locationBegin = HTTP_INFO.GetTimeSlotsBegining();
        private string locationEnd = HTTP_INFO.GetTimeSlotsEnd();
        private Http http;

        public HttpGetDentistTimeSlots()
        {
            http = new Http();
        }

        #region IRequestResponse Members

        public void SendRequest(string request)
        {
            http.Url = new Uri(baseUrl + locationBegin + request + locationEnd);
        }

        public string GetResponse()
        {
            return http.Get().Content;
        }

        #endregion
    }
}
