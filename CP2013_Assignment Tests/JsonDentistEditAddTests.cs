using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CP2013_WordOfMouth.JSON;
using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Exceptions;

namespace CP2013_WordOfMouth_Tests
{
    [TestClass]
    public class JsonDentistEditAddTests
    {
        private string correctJson = "{\"dentistID\":2,\"name\":\"Dr. John J0hn\",\"email\":\"john.smith@wordofmouth.com\",\"phone\":\"0429779889\"}";
        private int id = 2;
        private string name = "Dr. John J0hn";
        private string email = "john.smith@wordofmouth.com";
        private string phone = "0429779889";

        [TestMethod]
        public void JsonDentistEditObjectToJsonTest()
        {
            TemplateJson tl = new JsonDentistEditAdd();
            var json = tl.GetJson(new Dentist(id, name, email, phone));
            Assert.AreEqual(correctJson, json);
        }

        [TestMethod]
        public void JsonDentistEditJsonToObjectTest()
        {
            TemplateJson tl = new JsonDentistEditAdd();
            var o = tl.GetObject(correctJson) as Dentist;
            Assert.AreEqual(id, o.GetID());
            Assert.AreEqual(name, o.GetName());
            Assert.AreEqual(email, o.GetEmail());
            Assert.AreEqual(phone, o.GetPhone());
        }

        [TestMethod]
        public void JsonDentistEditObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonDentistEditAdd();
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
        public void JsonDentistEditJsonToObjectInvalidTest()
        {
            bool exception = false;
            var incorrect = "{\"emails\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonDentistEditAdd();
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
