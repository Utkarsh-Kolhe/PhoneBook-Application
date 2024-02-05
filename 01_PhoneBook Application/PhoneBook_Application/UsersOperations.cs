using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhoneBook_Application
{
    public class UsersOperations
    {
        static List<User> user = new List<User>();
            

        public void userInput()
        {
            Console.Write("Enter contact number: ");
            string contact = Console.ReadLine();

            if(checkContact(contact))
            {
                Console.WriteLine("\nThis contact is already saved.!!!");
                return;
            }

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

            User usr = new User(contact, name, email, city, state, zipCode);
            user.Add(usr);
        }

        public bool checkContact(string contact)
        {
            for(int i = 0; i < user.Count; i++)
            {
                if (user[i].contact.Equals(contact))
                {
                    return true; 
                }
            }
            return false;
        }
        public void ShowUser()
        {
            Console.Write("\nEnter user contact number: ");
            string findContact = Console.ReadLine();
            bool check = false;
            for(int i = 0; i < user.Count; i++)
            {
                if (user[i].contact == findContact)
                {
                    check = true;
                    Console.WriteLine("\nName: " + user[i].name);
                    Console.WriteLine("Contact: " + user[i].contact);
                    Console.WriteLine("Email: " + user[i].email);
                    Console.WriteLine("City: " + user[i].city + "       State: " + user[i].state + "       Zipcode: " + user[i].zipCode);

                }
            }

            if(check == false)
            {
                Console.WriteLine("User not found!!!!!!!!!!!");
            }
        }

        public void EditUserDetails()
        {
            Console.Write("\nEnter user contact number: ");
            string findContact = Console.ReadLine();
            bool check = false;
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i].contact == findContact)
                {
                    check = true;
                    Console.WriteLine("\nDetails of contact: " + findContact);
                    Console.WriteLine("\nName: " + user[i].name);
                    Console.WriteLine("Contact: " + user[i].contact);
                    Console.WriteLine("Email: " + user[i].email);
                    Console.WriteLine("City: " + user[i].city + "       State: " + user[i].state + "       Zipcode: " + user[i].zipCode);

                    int chs;
                    do 
                    {
                        Console.WriteLine("\nEdit menu: ");
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Contact");
                        Console.WriteLine("3. Email");
                        Console.WriteLine("4. City");
                        Console.WriteLine("5. State");
                        Console.WriteLine("6. Zipcode");
                        Console.WriteLine("7. Back to main menu.");
                        Console.Write("Enter choice: ");
                        chs = Convert.ToInt32(Console.ReadLine());
                        switch (chs)
                        {
                            case 1: // name
                                Console.Write("Enter new name: ");
                                user[i].name = Console.ReadLine();
                                break;

                            case 2: // contact
                                Console.Write("Enter new contact: ");
                                user[i].contact = Console.ReadLine();
                                break;

                            case 3:// email
                                Console.Write("Enter new email: ");
                                user[i].email = Console.ReadLine();
                                break;

                            case 4: // city
                                Console.Write("Enter new city: ");
                                user[i].city = Console.ReadLine();
                                break;

                            case 5: // state
                                Console.Write("Enter new state: ");
                                user[i].state = Console.ReadLine();
                                break;

                            case 6: // zipcode
                                Console.Write("Enter new zipcode: ");
                                user[i].zipCode = Console.ReadLine();
                                break;
                        }
                    } while (chs != 7);
                }
            }

            if (check == false)
            {
                Console.WriteLine("User not found!!!!!!!!!!!");
            }
        }

        public void DeleteUser()
        {
            Console.Write("\nEnter user contact number: ");
            string findContact = Console.ReadLine();
            bool check = false;
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i].contact == findContact)
                {
                    check = true;
                    Console.WriteLine("\nDeleted contact");
                    Console.WriteLine("Name: " + user[i].name);
                    Console.WriteLine("Contact: " + user[i].contact);
                    Console.WriteLine("Email: " + user[i].email);
                    Console.WriteLine("City: " + user[i].city + "       State: " + user[i].state + "       Zipcode: " + user[i].zipCode);
                    user.Remove(user[i]);
                }
            }

            if (check == false)
            {
                Console.WriteLine("User not found!!!!!!!!!!!");
            }
        }

        public void StateCity()
        {
            Console.WriteLine("\n1. State");
            Console.WriteLine("2. City");
            Console.Write("Enter choice: ");
            int chs = Convert.ToInt32(Console.ReadLine());

            switch(chs)
            {
                case 1: // state
                    Console.Write("\nEnter state name: ");
                    string strState = Console.ReadLine();
                    strState = strState.ToLower();
                    for (int i = 0; i < user.Count; i++)
                    {
                        if ((user[i].state).ToLower() == strState)
                        {
                            Console.WriteLine("\nName: " + user[i].name);
                            Console.WriteLine("Contact: " + user[i].contact);
                            Console.WriteLine("Email: " + user[i].email);
                            Console.WriteLine("City: " + user[i].city + "       State: " + user[i].state + "       Zipcode: " + user[i].zipCode);
                        }
                    }
                    break;

                case 2: // city
                    Console.Write("\nEnter city name: ");
                    string strCity = Console.ReadLine();
                    strCity = strCity.ToLower();
                    for (int i = 0; i < user.Count; i++)
                    {
                        if ((user[i].city).ToLower() == strCity)
                        {
                            Console.WriteLine("\nName: " + user[i].name);
                            Console.WriteLine("Contact: " + user[i].contact);
                            Console.WriteLine("Email: " + user[i].email);
                            Console.WriteLine("City: " + user[i].city + "       State: " + user[i].state + "       Zipcode: " + user[i].zipCode);
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice!!!");
                    break;
            }
        }

        public void UserCount()
        {
            Console.WriteLine("Total number of users: " + user.Count);
        }

        public void DeleteAllUsers()
        {
            user.Clear();
        }
    }
}
