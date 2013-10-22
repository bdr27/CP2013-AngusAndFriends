using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CP2013_Assignment_One.JSON;
using CP2013_Assignment_One.Utility;
using CP2013_Assignment_One.Exceptions;

namespace CP2013_Assignment_Tests
{
    [TestClass]
    public class JsonSignUpTests
    {      
        private string correctJson = "{\"email\":\"name@domain.com\",\"password\":\"password"
                + "\",\"reentered_email\":\"name@domain.com\",\"reentered_password\":\"password\"," +
                "\"phone\":\"04 7373 72947\",\"first_name\":\"John\",\"last_name\":\"Smith\"}";

        private string email = "name@domain.com";
        private string password = "password";
        private string reEnteredEmail = "name@domain.com";
        private string reEnteredPassword = "password";
        private string phone = "04 7373 72947";
        private string firstName = "John";
        private string lastName = "Smith";

        [TestMethod]
        public void JsonSignUpObjectToJsonTest()
        {
            TemplateJson tl = new JsonSignUp();
            var json = tl.GetJson(new SignUp(email, password, reEnteredEmail, reEnteredPassword, phone, firstName, lastName));
            Assert.AreEqual(correctJson, json);
        }

        [TestMethod]
        public void JsonSignUpJsonToObjectTest()
        {
            TemplateJson tl = new JsonSignUp();
            var o = tl.GetObject(correctJson) as SignUp;
            Assert.AreEqual(email, o.GetEmail());
            Assert.AreEqual(password, o.GetPassword());
            Assert.AreEqual(reEnteredPassword, o.GetReEnterPassword());
            Assert.AreEqual(reEnteredEmail, o.GetReEnterEmail());
            Assert.AreEqual(phone, o.GetPhone());
            Assert.AreEqual(firstName, o.GetFirstName());
            Assert.AreEqual(lastName, o.GetLastName());
        }

        [TestMethod]
        public void JsonSignUpObjectToJsonInvalidTest()
        {
            bool exception = false;
            TemplateJson tl = new JsonSignUp();
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
        public void JsonSignUpJsonToObjectInvalidTest()
        {
            bool exception = false;
            var incorrect = "{\"emails\":\"test.user@domain.com\",\"password\":\"Password\"}";
            TemplateJson tl = new JsonSignUp();
            try
            {
                var o = tl.GetObject(incorrect) as SignUp;
            }
            catch (InvalidLoginJsonException)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }
    }
}
