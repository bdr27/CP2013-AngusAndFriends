using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CP2013_WordOfMouth.JSON;
using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Exceptions;

namespace CP2013_WordOfMouth_Tests
{
    [TestClass]
    public class JsonTimeSlotTests
    {
        private string correctJson = "{\"id\":165,\"dentist\":{\"id\":3,\"name\":\"Dr.Carl\",\"email\":\"\",\"phone\":\"\"},\"hour\":15,\"minute\":30,\"day\":5}";
        private int id = 165;
        private Dentist dentist = new Dentist(3, "Dr.Carl", "", "");
        private int hour = 15;
        private int min = 30;
        private int day = 5;

        [TestMethod]
        public void JsonAppointmentObjectToJsonTest()
        {
            TemplateJson tl = new JsonEveryTimeSlot();
            var json = tl.GetJson(new TimeSlot(id, dentist, hour, min, day));
            Assert.AreEqual(correctJson, json);
        }

        [TestMethod]
        public void JsonAppointmentJsonToObjectTest()
        {
            TemplateJson tl = new JsonEveryTimeSlot();
            var o = tl.GetObject(correctJson) as TimeSlot;
            Assert.AreEqual(id, o.GetID());
            var od = o.GetDentist();
            Assert.AreEqual(dentist.GetEmail(), od.GetEmail());
            Assert.AreEqual(dentist.GetID(), od.GetID());
            //Will fail if email and phone not included
            Assert.AreEqual(dentist.GetName(), od.GetName());
            Assert.AreEqual(dentist.GetPhone(), od.GetPhone());
            Assert.AreEqual(hour, o.GetHour());
            Assert.AreEqual(min, o.GetMin());
            Assert.AreEqual(day, o.GetDay());
        }

        [TestMethod]
        public void JsonAppointmentObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonEveryTimeSlot();
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
            TemplateJson tl = new JsonEveryTimeSlot();
            try
            {
                var o = tl.GetObject(incorrect) as TimeSlot;
            }
            catch (InvalidLoginJsonException)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }
    }
}
