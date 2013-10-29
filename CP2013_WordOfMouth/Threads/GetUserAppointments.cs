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
    public class GetUserAppointments : ThreadTemplate
    {
        private Appointment appointment;

        public GetUserAppointments(int timerAmount, object o)
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
                var id = Int32.Parse(information.ToString());
                var response = ResponseGet(new JsonAppointments(), new HttpGetAppointments(), id);
                var appointmentJson = new JsonAppointments();
                appointment = appointmentJson.GetObject(response) as Appointment;
                ThreadComplete(acceptedResponse);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                appointment = null;
                ThreadComplete("Bad Response");
            }
        }

        protected override void CreateEvent(Enum.UserActions action, ThreadTemplate.CompleteType type)
        {
            var args = new RequestCompleteArgs();
            args.RequestType = RequestReturnType.APPOINTMENTS;
            args.Infomation = appointment;
        }
    }
}
