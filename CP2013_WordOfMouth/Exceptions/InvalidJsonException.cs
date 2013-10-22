using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Exceptions
{
    public class InvalidLoginJsonException : Exception
    {
        private int errorCode = 2;

        public int GetErrorCode()
        {
            return errorCode;
        }

        public string GetErrorMessage()
        {
            return "json passed in was not a valid login json request";
        }
    }
}
