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
    public class GetAppointmentTypesThread : ThreadTemplate
    {
        private List<CP2013_WordOfMouth.DTO.AppointmentType> appTypes;

        public GetAppointmentTypesThread(int timerAmount, object o)
            : base(timerAmount, o)
        {
            acceptedResponse = "Good Response";
            successMessage = "";
            failureMessage = "";
            timeoutMessage = "";
        }

        protected override void ThreadMethod()
        {
            try
            {
                var response = ResponseGet(new JsonAllAppointmentTypes(), new HttpGetAllAppointmentTypes(), 1);
                var dentists = new JsonAllAppointmentTypes();
                appTypes = dentists.GetObject(response) as List<CP2013_WordOfMouth.DTO.AppointmentType>;
                ThreadComplete(acceptedResponse);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                appTypes = null;
                ThreadComplete("Bad Response");
            }
        }

        protected override string ResponseGet(TemplateJson tj, IRequestResponse irr, int id)
        {
            return irr.GetResponse();
        }

        protected override void CreateEvent(Enum.UserActions action, ThreadTemplate.CompleteType type)
        {
            var args = new RequestCompleteArgs();
            args.RequestType = RequestReturnType.APPOINTMENT_TYPES;
            args.Infomation = appTypes;

            OnRequestComplete(args);
        }
    }
}
