using System;
using System.Collections.Generic;
using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Exceptions;
using CP2013_WordOfMouth.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CP2013_WordOfMouth_Tests
{
    [TestClass]
    public class JsonAllDentistsTests
    {
        private string correctJson = "[{\"id\":123,\"name\":\"DENTIST NAME\",\"email\":\"example@domain.com\",\"phone\":\"044445556666\"},{\"id\":120,\"name\":\"John Smith\",\"email\":\"john@me.com\",\"phone\":\"585959595\"}]";
        
        private int id1 = 123;
        private string name1 = "DENTIST NAME";
        private string email1 = "example@domain.com";
        private string phone1 = "044445556666";

        private int id2 = 120;
        private string name2 = "John Smith";
        private string email2 = "john@me.com";
        private string phone2 = "585959595";

        [TestMethod]
        public void JsonAllDentistsObjectToJsonTest()
        {
            TemplateJson tl = new JsonAllDentists();
            var dentists = new List<Dentist>();
            dentists.Add(new Dentist(id1, name1, email1, phone1));
            dentists.Add(new Dentist(id2, name2, email2, phone2));
            var json = tl.GetJson(dentists);
            Assert.AreEqual(correctJson, json);
        }

        [TestMethod]
        public void JsonAllDentistsJsonToObjectTest()
        {
            TemplateJson tl = new JsonAllDentists();
            var o = tl.GetObject(correctJson) as List<Dentist>;
            var d1 = o[0];
            var d2 = o[1];
            Assert.AreEqual(id1, d1.GetID());
            Assert.AreEqual(name1, d1.GetName());
            Assert.AreEqual(email1, d1.GetEmail());
            Assert.AreEqual(phone1, d1.GetPhone());

            Assert.AreEqual(id2, d2.GetID());
            Assert.AreEqual(name2, d2.GetName());
            Assert.AreEqual(email2, d2.GetEmail());
            Assert.AreEqual(phone2, d2.GetPhone());
        }

        [TestMethod]
        public void JsonAllDentistsObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonAllDentists();
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
        public void JsonAllDentistsJsonToObjectInvalidTest()
        {
            bool exception = false;
            var incorrect = "{\"emails\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonAllDentists();
            try
            {
                var o = tl.GetObject(incorrect) as List<Dentist>;
            }
            catch (Exception)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }
    }
}
