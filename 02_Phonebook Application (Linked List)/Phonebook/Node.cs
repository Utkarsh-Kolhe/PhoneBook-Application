using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    internal class Node
    {
        public User data;
        public Node next;

        public Node(string contact, string name, string email, string city, string state, string zipcode)
        {
            data = new User(contact, name, email, city, state, zipcode);
            next = null;
        }
    }
}
