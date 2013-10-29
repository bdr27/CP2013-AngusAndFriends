using System;
using System.Collections.Generic;
using CP2013_WordOfMouth.DTO;
using CP2013_WordOfMouth.Exceptions;
using CP2013_WordOfMouth.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CP2013_WordOfMouth_Tests
{
    [TestClass]
    public class JsonDentistTimeSlotTests
    {
        string json = "[{\"id\":1,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":2,\"hour\":8,\"minute\":0},{\"id\":2,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":2,\"hour\":8,\"minute\":30},{\"id\":3,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":2,\"hour\":9,\"minute\":0},{\"id\":4,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":2,\"hour\":9,\"minute\":30},{\"id\":6,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":2,\"hour\":10,\"minute\":30},{\"id\":7,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":2,\"hour\":11,\"minute\":0},{\"id\":8,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":2,\"hour\":11,\"minute\":30},{\"id\":9,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":2,\"hour\":12,\"minute\":0},{\"id\":10,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":2,\"hour\":12,\"minute\":30},{\"id\":11,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":3,\"hour\":8,\"minute\":30},{\"id\":12,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":3,\"hour\":9,\"minute\":0},{\"id\":13,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":3,\"hour\":9,\"minute\":30},{\"id\":14,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":3,\"hour\":10,\"minute\":0},{\"id\":15,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":3,\"hour\":10,\"minute\":30},{\"id\":16,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":3,\"hour\":11,\"minute\":0},{\"id\":17,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":3,\"hour\":11,\"minute\":30},{\"id\":18,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":3,\"hour\":12,\"minute\":0},{\"id\":19,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":3,\"hour\":12,\"minute\":30},{\"id\":20,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":3,\"hour\":13,\"minute\":0},{\"id\":33,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":1,\"hour\":9,\"minute\":0},{\"id\":34,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":1,\"hour\":9,\"minute\":30},{\"id\":35,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":1,\"hour\":10,\"minute\":0},{\"id\":36,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":1,\"hour\":10,\"minute\":30},{\"id\":37,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":1,\"hour\":11,\"minute\":0},{\"id\":38,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":1,\"hour\":11,\"minute\":30},{\"id\":39,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":1,\"hour\":12,\"minute\":0},{\"id\":40,\"dentist\":{\"id\":1,\"name\":\"Dr. Smile\",\"phone\":\"04 2977 9888\",\"email\":\"smile@wordofmouth.com\"},\"day\":1,\"hour\":12,\"minute\":30}]";
        
        [TestMethod]
        public void JsonAppointmentObjectToJsonTest()
        {
            TemplateJson tl = new JsonDentistTimeSlots();
            //var json = tl.GetJson(new TimeSlot(id, dentist, hour, min, day));
            //Assert.AreEqual(correctJson, json);
        }

        [TestMethod]
        public void JsonAppointmentJsonToObjectTest()
        {
            TemplateJson tl = new JsonDentistTimeSlots();
            var o = tl.GetObject(json) as List<TimeSlot>;
            var one = o[0];
            Assert.AreEqual(2, one.GetDay());
            Assert.AreEqual(8, one.GetHour());
            Assert.AreEqual(1, one.GetID());
            Assert.AreEqual(0, one.GetMin());
            Assert.AreEqual("smile@wordofmouth.com", one.GetDentist().GetEmail());
            Assert.AreEqual(1, one.GetDentist().GetID());
            Assert.AreEqual("Dr. Smile", one.GetDentist().GetName());
            Assert.AreEqual("04 2977 9888", one.GetDentist().GetPhone());
        }

        [TestMethod]
        public void JsonAppointmentObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonDentistTimeSlots();
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
            TemplateJson tl = new JsonDentistTimeSlots();
            try
            {
                var o = tl.GetObject(incorrect) as List<TimeSlot>;
            }
            catch (Exception)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }
       
       }
}
