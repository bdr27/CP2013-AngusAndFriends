using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CP2013_Assignment_One.JSON;
using CP2013_Assignment_One.Utility;
using CP2013_Assignment_One.Exceptions;

namespace CP2013_Assignment_Tests
{
    [TestClass]
    public class JsonLoginTests
    {
        [TestMethod]
        public void JsonLoginObjectToJsonTest()
        {
            var correctJson = "{\"email\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonLogin();
            var json = tl.GetJson(new Login("test.user@domain.com", "Password"));
            Assert.AreEqual(correctJson,json);
        }

        [TestMethod]
        public void JsonLoginJsonToObjectTest()
        {
            var correctJson = "{\"email\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonLogin();
            var o = tl.GetObject(correctJson) as Login;
            Assert.AreEqual("test.user@domain.com", o.GetUsername());
            Assert.AreEqual("Password" ,o.GetPassword());
        }

        [TestMethod]
        public void JsonLoginObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonLogin();
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
        public void JsonLoginJsonToObjectInvalidTest()
        {
            bool exception = false;
            var incorrect = "{\"emails\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonLogin();
            try
            {
                var o = tl.GetObject(incorrect) as Login;
            }
            catch (InvalidLoginJsonException)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }
    }
}
