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
    public class NewAppTimeSlotsThread : ThreadTemplate, IGetJsonResponse
    {
        private List<TimeSlot> timeslots;

        public NewAppTimeSlotsThread(int timerAmount, object o)
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
                var response = GetJsonResponse(new JsonDentistTimeSlots(), new HttpGetDentistTimeSlots(), information);
                var dentistTimes = new JsonDentistTimeSlots();

                timeslots = dentistTimes.GetObject(response) as List<TimeSlot>;
                ThreadComplete(true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);

                timeslots = null;
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
            args.RequestType = RequestReturnType.TIMESLOTS;
            args.Infomation = timeslots;

            OnRequestComplete(args);
        }
    }
}
