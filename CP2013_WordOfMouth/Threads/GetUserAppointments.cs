using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2013_WordOfMouth.JSON;
using CP2013_WordOfMouth.Gather;

namespace CP2013_WordOfMouth.Threads
{
    public class GetUserAppointments : ThreadTemplate
    {
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
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        protected override void CreateEvent(Enum.UserActions action, ThreadTemplate.CompleteType type)
        {
            throw new NotImplementedException();
        }
    }
}
