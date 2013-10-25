using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.Utility
{
    public class RequestType
    {
        private static string instance = null;
        public RequestType()
        {
        }

        public static string GetInstance()
        {
            if (instance == null)
            {
                instance = "application/json";
            }
            return instance;
        }
    }
}
