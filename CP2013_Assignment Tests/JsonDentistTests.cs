using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CP2013_WordOfMouth.JSON;
using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Exceptions;

namespace CP2013_WordOfMouth_Tests
{
    [TestClass]
    public class JsonDentistTests
    {
        private string correctJson = "{\"dentistID\":123,\"name\":\"DENTIST NAME\",\"email\":\"example@domain.com\",\"phone\":\"044445556666\"}";
        private int id = 123;
        private string name = "DENTIST NAME";
        private string email = "example@domain.com";
        private string phone = "044445556666";

        [TestMethod]
        public void JsonDentistObjectToJsonTest()
        {
            TemplateJson tl = new JsonDentist();
            var json = tl.GetJson(new Dentist(id, name, email, phone));
            Assert.AreEqual(correctJson, json);
        }

        [TestMethod]
        public void JsonDentistJsonToObjectTest()
        {
            TemplateJson tl = new JsonDentist();
            var o = tl.GetObject(correctJson) as Dentist;
            Assert.AreEqual(id, o.GetID());
            Assert.AreEqual(name, o.GetName());
            Assert.AreEqual(email, o.GetEmail());
            Assert.AreEqual(phone, o.GetPhone());
        }

        [TestMethod]
        public void JsonDentistObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonDentist();
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
        public void JsonDentistJsonToObjectInvalidTest()
        {
            bool exception = false;
            var incorrect = "{\"emails\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonDentist();
            try
            {
                var o = tl.GetObject(incorrect) as Dentist;
            }
            catch (InvalidLoginJsonException)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }
    }
}
