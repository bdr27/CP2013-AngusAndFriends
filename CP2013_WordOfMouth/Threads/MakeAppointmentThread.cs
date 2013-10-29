using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Threads
{
    public class MakeAppointmentThread : ThreadTemplate
    {
        public MakeAppointmentThread(int timerAmount, object o)
            : base(timerAmount, o)
        {
        }

        protected override void ThreadMethod()
        {
            try
            {
                ThreadComplete(acceptedResponse);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                ThreadComplete("Bad Response");
            }
        }

        protected override void CreateEvent(Enum.UserActions action, ThreadTemplate.CompleteType type)
        {
            throw new NotImplementedException();
        }
    }
}
