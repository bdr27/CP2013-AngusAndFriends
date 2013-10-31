using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Engine
{
    public class RequestEngine : IActiveObjectEngine
    {
        private List<IRequest> requests;
        private bool active;

        public RequestEngine()
        {
            requests = new List<IRequest>();
            active = false;
        }

        public void Run()
        {
            try
            {
                foreach (var request in requests)
                {
                    if (active)
                    {
                        request.SendRequest();
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
            active = false;
        }

        public bool Cancel()
        {
            if (active)
            {
                active = false;
                return true;
            }
            return false;
        }

        public bool AddRequest(IRequest request)
        {
            if (!active)
            {
                requests.Add(request);
            }
            return false;
        }
    }
}
