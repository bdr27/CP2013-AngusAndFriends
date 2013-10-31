using CP2013_WordOfMouth.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Engine
{
    class GetMultipleRequestComposite : IRequest
    {
        private List<IRequest> requests;

        public GetMultipleRequestComposite()
        {
            requests = new List<IRequest>();
        }

        public void SendRequest()
        {
            foreach (var request in requests)
            {
                request.SendRequest();
            }
        }

        public object GetResponse()
        {
            List<object> responses = new List<object>();
            foreach (var request in requests)
            {
                responses.Add(request.GetResponse());
            }
            return responses;
        }

        public void SetRequest(object o)
        {
            //
        }
    }
}
