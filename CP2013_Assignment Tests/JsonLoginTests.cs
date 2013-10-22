using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CP2013_WordOfMouth.JSON;
using CP2013_WordOfMouth.Utility;
using CP2013_WordOfMouth.Exceptions;
using CP2013_WordOfMouth.DTO;

namespace CP2013_WordOfMouth_Tests
{
    [TestClass]
    public class JsonLoginTests
    {
        private string correctJson = "{\"email\":\"test.user@domain.com\",\"password\":\"Password\"}";
        [TestMethod]
        public void JsonLoginObjectToJsonTest()
        {
            TemplateJson tl = new JsonLogin();
            var json = tl.GetJson(new Login("test.user@domain.com", "Password"));
            Assert.AreEqual(correctJson,json);
        }

        [TestMethod]
        public void JsonLoginJsonToObjectTest()
        {
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
