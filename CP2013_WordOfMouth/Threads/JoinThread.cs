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
    public class JoinThread : ThreadTemplate
    {
        public JoinThread(int timerAmount, object o)
            : base(timerAmount, o)
        {
            acceptedResponse = "http://cdn.theatlantic.com/static/mt/assets/international/mission%20accomplished%20banner%2023423423.jpg";
            successMessage = "You have successfully joined! :)";
            failureMessage = "Oops! Something went wrong, try again. :(";
            timeoutMessage = "Your request has timed out, please try again. :(";
        }

        protected override void ThreadMethod()
        {
            try
            {
                var response = ResponsePost(new JsonSignUp(), new HttpPostSignUp(), information);
                ThreadComplete(response);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                ThreadComplete("Exception occurred.");
            }
        }

        protected override void CreateEvent(Enum.UserActions action, CompleteType type)
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
