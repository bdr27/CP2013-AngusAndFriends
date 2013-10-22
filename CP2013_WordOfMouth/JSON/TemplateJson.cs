using CP2013_Assignment_One.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_Assignment_One.JSON
{
    public abstract class TemplateJson
    {
        /// <exception cref="InvalidObjectException">the object could not be coverted into JSON.</exception>
        public abstract string GetJson(object o);
        /// <exception cref="InvalidJsonException">The JSON passed in was not in the correct format.</exception>
        public abstract object GetObject(string json);

        /// <exception cref="InvalidObjectException">the object could not be coverted into JSON.</exception>
        protected void CheckNull(object o)
        {
            if (o == null)
            {
                throw new InvalidLoginObjectException();
            }
        }

        protected void CheckValidParams(params object[] objects)
        {
            foreach (var o in objects)
            {
                if (o == null)
                {
                    throw new InvalidLoginJsonException();
                }
            }
        }
    }
}
