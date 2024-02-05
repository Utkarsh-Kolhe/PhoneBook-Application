using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application
{
    public class User
    {
        public string contact;
        public string name;
        public string email;
        public string city;
        public string state;
        public string zipCode;

        public User(string contact, string name, string email, string city, string state, string zipCode)
        {
            this.contact = contact;
            this.name = name;
            this.email = email;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
        }
    }
}
