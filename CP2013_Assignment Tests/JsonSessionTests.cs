using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CP2013_Assignment_One.JSON;
using CP2013_Assignment_One.Exceptions;
using CP2013_Assignment_One.Utility;

namespace CP2013_Assignment_Tests
{
    [TestClass]
    public class JsonSessionTests
    {
        private string correctJson = "{\"seshID\":40,\"user_name\":\"Johnathan\",\"admin\":false}";

        [TestMethod]
        public void JsonSessionObjectToJsonTest()
        {
            TemplateJson tl = new JsonSession();
            var json = tl.GetJson(new Session(40, "Johnathan", false));
            Assert.AreEqual(correctJson, json);
        }

        [TestMethod]
        public void JsonSessionJsonToObjectTest()
        {
            TemplateJson tl = new JsonSession();
            var o = tl.GetObject(correctJson) as Session;
            Assert.AreEqual("Johnathan", o.GetUsername());
            Assert.AreEqual(false, o.GetAdmin());
            Assert.AreEqual(40, o.GetSessionID());
        }

        [TestMethod]
        public void JsonSessionObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonSession();
            try
            {
                var json = tl.GetJson("I am the wrong object");
            }
            catch (InvalidLoginObjectException)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }

        [TestMethod]
        public void JsonSessionJsonToObjectInvalidTest()
        {
            bool exception = false;
            var incorrect = "{\"emails\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonSession();
            try
            {
                var o = tl.GetObject(incorrect) as Session;
            }
            catch (InvalidLoginJsonException)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }
    }
}
