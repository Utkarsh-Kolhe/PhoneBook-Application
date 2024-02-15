using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            UsersOperations usr = new UsersOperations();
            do
            {
                Console.WriteLine("\n1. Add contact details.");
                Console.WriteLine("2. Show details of contact.");
                Console.WriteLine("3. Edit contact details.");
                Console.WriteLine("4. Delete a contact.");
                Console.WriteLine("5. View all contact for a state or city");
                Console.WriteLine("6. Get count of contacts.");
                Console.WriteLine("7. Clear all the contact.");
                Console.WriteLine("8. Show all the contact.");
                Console.WriteLine("9. Exit");
                Console.Write("\nEnter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: // add contact
                        usr.userInput();
                        break;

                    case 2: // show details
                        usr.ShowUser();
                        break;

                    case 3: // edit contact
                        usr.EditUserDetails();
                        break;

                    case 4: // delete contact
                        usr.DeleteUser();
                        break;

                    case 5: // state, city
                        usr.StateCity();
                        break;

                    case 6: // count
                        usr.UserCount();
                        break;

                    case 7: // clear
                        usr.DeleteAllUsers();
                        break;

                    case 8: // Show all contacts
                        usr.ShowAllContacts();
                        break;

                    case 9: // Exit
                        usr.SaveToTxt();
                        Console.WriteLine("\nExiting program. . .\n");
                        break;

                    default:
                        Console.WriteLine("\nInvalid Choice! ! !");
                        break;
                }
            } while (choice != 9);
        }
    }
}
