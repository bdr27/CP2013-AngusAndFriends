using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.JSON;
using CP2013_WordOfMouth.Gather;
using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Enum;

namespace CP2013_WordOfMouth.Threads
{
    public class GetUserAppointments : ThreadTemplate, IGetJsonResponse
    {
        private List<Appointment> appointment;

        public GetUserAppointments(int timerAmount, object o)
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
                var response = GetJsonResponse(new JsonAppointments(), new HttpGetAppointments(), information);
                var appointmentJson = new JsonAppointments();

                appointment = appointmentJson.GetObject(response) as List<Appointment>;
                ThreadComplete(true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);

                appointment = null;
                ThreadComplete(false);
            }
        }

        public string GetJsonResponse(TemplateJson tj, IRequestResponse irr, object o)
        {
            System.Diagnostics.Debug.WriteLine("Sent: " + o.ToString());
            irr.SendRequest(o.ToString());
            System.Diagnostics.Debug.WriteLine("Response: " + irr.GetResponse());
            return irr.GetResponse();
        }

        protected override void CreateEvent(UserActions action, CompleteType type)
        {
            var args = new RequestCompleteArgs();
            args.RequestType = RequestReturnType.APPOINTMENTS;
            args.Infomation = appointment;

            OnRequestComplete(args);
        }
    }
}
