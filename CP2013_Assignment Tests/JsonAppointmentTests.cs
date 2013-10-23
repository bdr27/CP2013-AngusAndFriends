using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CP2013_WordOfMouth.JSON;
using CP2013_WordOfMouth.Exceptions;
using CP2013_WordOfMouth.DTO;

namespace CP2013_WordOfMouth_Tests
{
    [TestClass]
    public class JsonAppointmentTests
    {
        private string correctJson = "{\"id\":123,\"description\":\"Check Up or whatever\",\"cost\":49.99}";
        private int id = 123;
        private string desc = "Check Up or whatever";
        private double cost = 49.99;

        [TestMethod]
        public void JsonAppointmentObjectToJsonTest()
        {
            TemplateJson tl = new JsonAppointmentType();
            var json = tl.GetJson(new AppointmentType(id, desc, cost));
            Assert.AreEqual(correctJson, json);
        }

        [TestMethod]
        public void JsonAppointmentJsonToObjectTest()
        {
            TemplateJson tl = new JsonAppointmentType();
            var o = tl.GetObject(correctJson) as AppointmentType;
            Assert.AreEqual(id, o.GetID());
            Assert.AreEqual(desc, o.GetDescription());
            Assert.AreEqual(cost, o.GetCost());
        }

        [TestMethod]
        public void JsonAppointmentObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonAppointmentType();
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
        public void JsonAppointmentJsonToObjectInvalidTest()
        {
            bool exception = false;
            var incorrect = "{\"emails\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonAppointmentType();
            try
            {
                var o = tl.GetObject(incorrect) as AppointmentType;
            }
            catch (InvalidLoginJsonException)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }
    }
}
