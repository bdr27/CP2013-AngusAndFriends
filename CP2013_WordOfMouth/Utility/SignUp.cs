using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_Assignment_One.Utility
{
    public class SignUp
    {
        private string email;
        private string password;
        private string reEnterEmail;        
        private string reEnterPassword;
        private string phone;
        private string firstName;
        private string lastName;

        public SignUp(string email, string password, string reEnterEmail, string reEnterPassword, string phone, string firstName, string lastName)
        {
            this.email = email;
            this.reEnterEmail = reEnterEmail;
            this.password = password;
            this.reEnterPassword = reEnterPassword;
            this.phone = phone;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string GetEmail()
        {
            return email;
        }

        public string GetReEnterEmail()
        {
            return reEnterEmail;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetReEnterPassword()
        {
            return reEnterPassword;
        }

        public string GetPhone()
        {
            return phone;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }
    }
}
