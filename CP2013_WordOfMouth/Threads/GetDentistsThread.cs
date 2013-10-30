using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.Gather;
using CP2013_WordOfMouth.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Threads
{
    public class GetDentistsThread : ThreadTemplate, IGetJsonResponse
    {
        private List<Dentist> dentistsList;

        public GetDentistsThread(int timerAmount, object o)
            : base(timerAmount, o)
        {
            //acceptedResponse = "Good Response";
            //successMessage = "";
            //failureMessage = "";
            //timeoutMessage = "";
        }

        protected override void ThreadMethod()
        {
            try
            {
                var response = GetJsonResponse(new JsonAllDentists(), new HttpGetAllDentist(), information);
                var dentists = new JsonAllDentists();

                dentistsList = dentists.GetObject(response) as List<Dentist>;
                ThreadComplete(true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);

                dentistsList = null;
                ThreadComplete(false);
            }
        }

        public string GetJsonResponse(TemplateJson tj, IRequestResponse irr, object o)
        {
            irr.SendRequest("");
            return irr.GetResponse();
        }

        protected override void CreateEvent(UserActions action, CompleteType type)
        {
            var args = new RequestCompleteArgs();
            args.RequestType = RequestReturnType.DENTISTS;
            args.Infomation = dentistsList;

            OnRequestComplete(args);
        }
    }
}
