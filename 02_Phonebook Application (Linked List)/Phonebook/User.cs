using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    internal class User
    {
        public string contact;
        public string name;
        public string email;
        public string city;
        public string state;
        public string zipCode;

        public User(string contact, string name, string email, string city, string state, string zipcode)
        {
            this.contact = contact;
            this.name = name;
            this.email = email;
            this.city = city;
            this.state = state;
            this.zipCode = zipcode;
        }
    }
}
