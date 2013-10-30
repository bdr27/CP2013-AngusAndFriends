using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.Gather;
using CP2013_WordOfMouth.JSON;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Threads
{
    public class EditDentistTimeSlotThread : ThreadTemplate, IPostHTTPRequest
    {
        public EditDentistTimeSlotThread(int timerAmount, object o)
            : base(timerAmount, o)
        {
            successMessage = "You have successfully updated this dentist's timetable!";
            failureMessage = "Oops! Something went wrong, try again. :(";
            timeoutMessage = "Your request has timed out, please try again. :(";
        }

        protected override void ThreadMethod()
        {
            try
            {
                timer.Enabled = false;
                var info = information as List<string>;
                var response = PostHttpRequest(new HttpPostEditDentistTimeslots(info.ElementAt(0)), info.ElementAt(1));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    ThreadComplete(true);
                }
                else
                {
                    ThreadComplete(false);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                
                ThreadComplete(false);
            }
        }

        public HttpResponse PostHttpRequest(IRequestResponse h, object o)
        {
            h.SendRequest(o.ToString());
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
