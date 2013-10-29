using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Enum;
using CP2013_WordOfMouth.Gather;
using CP2013_WordOfMouth.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace CP2013_WordOfMouth.Threads
{
    public abstract class ThreadTemplate
    {
        protected System.Timers.Timer timer;
        protected Thread requestThread;
        protected string acceptedResponse;
        protected string successMessage, failureMessage, timeoutMessage;
        protected object information;

        public ThreadTemplate(int timerAmount, object o)
        {
            timer = new System.Timers.Timer(timerAmount);
            timer.Elapsed += TimerTickMethod;

            requestThread = new Thread(ThreadMethod);

            information = o;
        }

        public virtual void Start()
        {
            timer.Enabled = true;
            requestThread.IsBackground = true;
            requestThread.Start();
        }

        protected abstract void ThreadMethod();

        protected void TimerTickMethod(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Enabled = false;
            requestThread.Abort();
            CreateEvent(UserActions.FAILURE, CompleteType.TIMER);
        }

        protected virtual void ThreadComplete(string response)
        {
            timer.Enabled = false;
            if (response == acceptedResponse)
            {
                CreateEvent(UserActions.SUCCESS, CompleteType.THREAD);
            }
            else
            {
                CreateEvent(UserActions.FAILURE, CompleteType.THREAD);
            }
        }

        protected virtual string Response(TemplateJson tj, IRequestResponse irr, object o)
        {
            var json = tj.GetJson(o);
            Console.WriteLine("Json in: " + json);
            irr.SendRequest(json);
            Console.WriteLine("Resposne: " + irr.GetResponse());
            return irr.GetResponse();
        }

        protected abstract void CreateEvent(UserActions action, CompleteType type);

        protected enum CompleteType
        {
            THREAD,
            TIMER
        }

        protected virtual void OnRequestComplete(RequestCompleteArgs e)
        {
            RequestEventHandler handler = eventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event RequestEventHandler eventHandler;
    }

    public class RequestCompleteArgs : EventArgs
    {
        public UserActions Action { get; set; }
        public String Response { get; set; }
        public bool DisplayResponse { get; set; }
        public bool RefreshUI { get; set; }
        public Session SessionID { get; set; }
        public bool LoggedIn { get; set; }
    }

    public delegate void RequestEventHandler(object sender, RequestCompleteArgs e);
}
