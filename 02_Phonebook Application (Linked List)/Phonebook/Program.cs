using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBookOperations phn = new PhoneBookOperations();
            int chs;
            do
            {
                Console.WriteLine("\n1. Add contact details.");
                Console.WriteLine("2. Show perticular contact.");
                Console.WriteLine("3. Show all contacts.");
                Console.WriteLine("4. Edit contact details.");
                Console.WriteLine("5. Delete a contact.");
                Console.WriteLine("6. Show all contact for a state or city");
                Console.WriteLine("7. Get count of contacts.");
                Console.WriteLine("8. Clear all the contact.");
                Console.WriteLine("9. Exit");

                Console.Write("\nEnter choice: ");
                chs = Convert.ToInt32(Console.ReadLine());

                switch (chs)
                {
                    case 1: // add
                        Console.Write("\nEnter contact: ");
                        string contact = Console.ReadLine();
                        if(phn.CheckContact(contact))
                        {
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter email: ");
                            string email = Console.ReadLine();

                            Console.Write("Enter city: ");
                            string city = Console.ReadLine();

                            Console.Write("Enter state: ");
                            string state = Console.ReadLine();

                            Console.Write("Enter zipcode: ");
                            string zipCode = Console.ReadLine();
                            phn.InsertNumber(contact, name, email, city, state, zipCode);
                        }
                        else
                        {
                            Console.WriteLine("\nThis contact is already saved.");
                        }
                        break;

                    case 2:
                        Console.Write("\nEnter contact: ");
                        string searchContact = Console.ReadLine();
                        if(!(phn.CheckContact(searchContact)))
                        {
                            phn.ShowPerticularContact(searchContact);
                        }
                        else
                        {
                            Console.WriteLine("\nContact doesn't exist.");
                        }
                        break;

                    case 3: // display all contacts
                        phn.PrintContacts();
                        break;

                    case 4: // editing contact.
                        Console.Write("\nEnter contact: ");
                        string editContact = Console.ReadLine();
                        if (!(phn.CheckContact(editContact)))
                        {
                            phn.EditContactDetails(editContact);
                        }
                        else
                        {
                            Console.WriteLine("\nContact doesn't exist.");
                        }
                        break;

                    case 5: // delete a contact
                        Console.Write("\nEnter contact: ");
                        string deleteContact = Console.ReadLine();
                        if (!(phn.CheckContact(deleteContact)))
                        {
                            phn.RemoveContactDetails(deleteContact);
                        }
                        else
                        {
                            Console.WriteLine("\nContact doesn't exist.");
                        }
                        break;

                    case 6: // Show all contact for a state or city.
                        if (!phn.IsEmpty())
                        {
                            phn.ShowStateOrCity();
                        }
                        else
                        {
                            Console.WriteLine("\nContact list is Empty.");
                        }
                        break;

                    case 7: // count of contacts
                        phn.DetailsCount();
                        break;

                    case 8: // delete all contacts.
                        phn.Clear();
                        break;

                    case 9: // exit
                        Console.WriteLine("\nProgram Exiting. . .\n");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice!!!");
                        break;
                }
            } while (chs != 9);
        }
    }
}
