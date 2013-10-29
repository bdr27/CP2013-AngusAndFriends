using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.Gather;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Threads
{
    public class RemoveAppointmentThread : ThreadTemplate
    {
        public RemoveAppointmentThread(int timerAmount, object o)
            : base(timerAmount, o)
        {
            acceptedResponse = "Good Response";
            successMessage = "You have cancelled your appointment.";
            failureMessage = "Oops! Something went wrong, try again. :(";
            timeoutMessage = "Your request has timed out, please try again. :(";
        }

        protected override void ThreadMethod()
        {
            timer.Enabled = false;
            try
            {
                var response = PostRequest(new HttpPostDeleteAppointment(), information);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    ThreadComplete(acceptedResponse);
                }
                else
                {
                    ThreadComplete("Bad Response");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                ThreadComplete("Bad Response");
            }
        }

        private HttpResponse PostRequest(HttpPostDeleteAppointment h, object information)
        {
            h.SendRequest(information.ToString());
            return h.GetHttpResponse();
        }

        protected override void CreateEvent(UserActions action, CompleteType type)
        {
            var args = new RequestCompleteArgs();
            args.Action = action;
            args.DisplayResponse = false;
            args.RefreshUI = false;
            args.LoggedIn = false;

            if (type == CompleteType.THREAD && action == UserActions.SUCCESS)
            {
                args.Response = successMessage;
                args.DisplayResponse = true;
                args.RefreshUI = true;
            }
            else if (type == CompleteType.THREAD && action == UserActions.FAILURE)
            {
                args.Response = failureMessage;
                args.DisplayResponse = true;
            }
            else
            {
                args.Response = timeoutMessage;
                args.DisplayResponse = true;
            }

            OnRequestComplete(args);
        }
    }
}
