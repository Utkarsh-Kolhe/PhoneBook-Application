using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    internal class PhoneBookOperations
    {
        Node head;

        public PhoneBookOperations()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void InsertNumber(string contact, string name, string email, string city, string state, string zipcode)
        {
            Node newNode = new Node(contact, name, email, city, state, zipcode);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node current = head;
            while(current.next != null)
            {
                current = current.next;
            }

            current.next = newNode;
        }

        public void PrintContacts()
        {
            if(head == null)
            {
                Console.WriteLine("\nContact list is empty.");
                return;
            }
            Node current = head;
            while(current.next != null)
            {
                Console.WriteLine("\nName: " + current.data.name);
                Console.WriteLine("Contact: " + current.data.contact);
                Console.WriteLine("Email: " + current.data.email);
                Console.WriteLine("City: " + current.data.city + "        State: " + current.data.state + "     ZipCode: " + current.data.zipCode);
                current = current.next;
            }
            Console.WriteLine("\nName: " + current.data.name);
            Console.WriteLine("Contact: " + current.data.contact);
            Console.WriteLine("Email: " + current.data.email);
            Console.WriteLine("City: " + current.data.city + "        State: " + current.data.state + "     ZipCode: " + current.data.zipCode);
        }

        public void ShowPerticularContact(string contact)
        {
            Node current = head;
            while(!(current.data.contact.Equals(contact)))
            {
                current = current.next;
            }
            Console.WriteLine("\nName: " + current.data.name);
            Console.WriteLine("Contact: " + current.data.contact);
            Console.WriteLine("Email: " + current.data.email);
            Console.WriteLine("City: " + current.data.city + "        State: " + current.data.state + "     ZipCode: " + current.data.zipCode);
        }

        public void EditContactDetails(string contact)
        {
            Node current = head;
            while (!(current.data.contact.Equals(contact)))
            {
                current = current.next;
            }
            Console.WriteLine("\nOld details: ");
            Console.WriteLine("Name: " + current.data.name);
            Console.WriteLine("Contact: " + current.data.contact);
            Console.WriteLine("Email: " + current.data.email);
            Console.WriteLine("City: " + current.data.city + "        State: " + current.data.state + "     ZipCode: " + current.data.zipCode);

            int chs;
            do
            {
                Console.WriteLine("\n1. Name");
                Console.WriteLine("2. Contact.");
                Console.WriteLine("3. Email.");
                Console.WriteLine("4. City.");
                Console.WriteLine("5. State.");
                Console.WriteLine("6. ZipCode.");
                Console.WriteLine("7. Go to back Menu.");

                Console.Write("\nWhat do you want to edit: ");
                chs = Convert.ToInt32(Console.ReadLine());

                switch (chs)
                {
                    case 1:// name
                        Console.Write("\nEnter new name: ");
                        current.data.name = Console.ReadLine();
                        break;

                    case 2: // contact
                        Console.Write("\nEnter new contact: ");
                        current.data.contact = Console.ReadLine();
                        break;

                    case 3: // email
                        Console.Write("\nEnter new mail: ");
                        current.data.email = Console.ReadLine();
                        break;

                    case 4: // city
                        Console.Write("\nEnter new city: ");
                        current.data.city = Console.ReadLine();
                        break;

                    case 5: // state
                        Console.Write("\nEnter new state: ");
                        current.data.state = Console.ReadLine();
                        break;

                    case 6: // zipcode
                        Console.Write("\nEnter new zipcode: ");
                        current.data.zipCode = Console.ReadLine();
                        break;

                    case 7:// back menu.
                        Console.WriteLine("\nMain Menu");
                        break;

                    default:
                        Console.WriteLine("\nIvalid choice! ! !");
                        break;
                }
            } while (chs != 7);

            Console.WriteLine("\nNew details: ");
            Console.WriteLine("Name: " + current.data.name);
            Console.WriteLine("Contact: " + current.data.contact);
            Console.WriteLine("Email: " + current.data.email);
            Console.WriteLine("City: " + current.data.city + "        State: " + current.data.state + "     ZipCode: " + current.data.zipCode);
        }

        public void RemoveContactDetails(string contact)
        {
            if(head.next == null)
            {
                Console.WriteLine("\n" + head.data.contact + " is deleted.");
                head = null;
                return;
            }
            Node current = head;
            while(!(current.next.data.contact.Equals(contact)))
            {
                current = current.next;
            }
            Console.WriteLine("\n" + current.next.data.contact + " is deleted.");
            current.next = current.next.next;

        }

        public void ShowStateOrCity()
        {
            Console.WriteLine("\n1. City.");
            Console.WriteLine("2. State.");
            
            Console.Write("\nEnter choice: ");
            int chs = Convert.ToInt32(Console.ReadLine());

            string find;

            switch(chs)
            {
                case 1: // city
                    Console.Write("Enter city name: ");
                    find = Console.ReadLine();
                    Node current = head;
                    bool check = false;
                    while(current.next != null)
                    {
                        if(current.data.city.Equals(find))
                        {
                            Console.WriteLine("\nName: " + current.data.name);
                            Console.WriteLine("Contact: " + current.data.contact);
                            Console.WriteLine("Email: " + current.data.email);
                            Console.WriteLine("City: " + current.data.city + "        State: " + current.data.state + "     ZipCode: " + current.data.zipCode);
                            check = true;
                        }
                        current = current.next;
                    }
                    if (current.data.city.Equals(find))
                    {
                        Console.WriteLine("\nName: " + current.data.name);
                        Console.WriteLine("Contact: " + current.data.contact);
                        Console.WriteLine("Email: " + current.data.email);
                        Console.WriteLine("City: " + current.data.city + "        State: " + current.data.state + "     ZipCode: " + current.data.zipCode);
                        check = true;
                    }

                    if(check == false)
                    {
                        Console.WriteLine("\nNo one is from " + find);
                    }

                    break;

                case 2: // state
                    Console.Write("Enter state name: ");
                    find = Console.ReadLine();
                    Node current1 = head;
                    bool check1 = false;
                    while (current1.next != null)
                    {
                        if (current1.data.state.Equals(find))
                        {
                            Console.WriteLine("\nName: " + current1.data.name);
                            Console.WriteLine("Contact: " + current1.data.contact);
                            Console.WriteLine("Email: " + current1.data.email);
                            Console.WriteLine("City: " + current1.data.city + "        State: " + current1.data.state + "     ZipCode: " + current1.data.zipCode);
                            check1 = true;
                        }
                        current = current1.next;
                    }
                    if (current1.data.city.Equals(find))
                    {
                        Console.WriteLine("\nName: " + current1.data.name);
                        Console.WriteLine("Contact: " + current1.data.contact);
                        Console.WriteLine("Email: " + current1.data.email);
                        Console.WriteLine("City: " + current1.data.city + "        State: " + current1.data.state + "     ZipCode: " + current1.data.zipCode);
                        check1 = true;
                    }

                    if (check1 == false)
                    {
                        Console.WriteLine("\nNo one is from " + find);
                    }
                    break;

            }
        }

        public void DetailsCount()
        {
            if (head == null)
            {
                Console.WriteLine("Contact list is empty.");
                return;
            }

            Node current = head;
            int count = 1;
            while(current.next != null)
            {
                count++;
                current = current.next;
            }
            Console.WriteLine("Count of saved contacts: " + count);
        }

        public void Clear()
        {
            head = null;
            Console.WriteLine("\nAll contacts are deleted.");
        }

        public bool CheckContact(string contact)
        {
            if(head == null)
            {
                return true;
            }

            Node current = head;
            while(current.next != null)
            {
                if(current.data.contact.Equals(contact))
                {
                    return false;
                }
                current = current.next;
            }
            if (current.data.contact.Equals(contact))
            {
                return false;
            }
            return true;
        }
    }
}
