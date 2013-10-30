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
    public class LoginThread : ThreadTemplate, IGetJsonResponse
    {
        private Session sessionKey;

        public LoginThread(int timerAmount, object o)
            : base(timerAmount, o)
        {
            //acceptedResponse = "Good Response";
            successMessage = "You have successfully logged in!";
            failureMessage = "Oops! Something went wrong, try again. :(";
            timeoutMessage = "Your request has timed out, please try again. :(";
        }

        protected override void ThreadMethod()
        {
            try
            {
                var response = GetJsonResponse(new JsonLogin(), new HttpPostLogin(), information);
                var sessionJson = new JsonSession();

                sessionKey = sessionJson.GetObject(response) as Session;
                ThreadComplete(true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                sessionKey = null;
                ThreadComplete(false);
            }
        }

        public string GetJsonResponse(TemplateJson tj, IRequestResponse irr, object o)
        {
            var info = tj.GetJson(o);
            System.Diagnostics.Debug.WriteLine("Sent: " + info);
            irr.SendRequest(info);
            System.Diagnostics.Debug.WriteLine("Response: " + irr.GetResponse());
            return irr.GetResponse();
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
                args.RefreshUI = true;
                args.LoggedIn = true;
                args.SessionID = sessionKey;
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
