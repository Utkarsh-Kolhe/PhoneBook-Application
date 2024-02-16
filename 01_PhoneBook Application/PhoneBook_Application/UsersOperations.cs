using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace PhoneBook_Application
{
    public class UsersOperations
    {
        static List<User> user = new List<User>();

        public string emailPattern = @"^\w+@\w+\.[a-zA-Z]{2,}$";
        public string phonePattern = @"^(\+91[\s\-]?)?[789]\d{9}$";
        public string zipCodePattern = @"^\d{6}$";
        public bool check = true;

        private string filePath = @"D:\Git\Phone Book\ContactDetails.csv";

        public UsersOperations()
        {
            User usr = new User("Contact", "Name", "Email", "City", "State", "Zip Code");
            user.Add(usr);
            if (File.Exists(filePath))
            {
                string[] users = File.ReadAllLines(filePath);
                if (users.Length > 1)
                {
                    foreach (string line in users)
                    {
                        string[] details = line.Split(',');

                        if (details.Length == 6)
                        {
                            if (details[0].CompareTo("Contact") == 0)
                            {
                                continue;
                            }
                            string contact = details[0].Trim();
                            string name = details[1].Trim();
                            string email = details[2].Trim();
                            string city = details[3].Trim();
                            string state = details[4].Trim();
                            string zipCode = details[5].Trim();
                            User us = new User(contact, name, email, city, state, zipCode);
                            user.Add(us);
                        }
                    }
                }
            }
            else
            {
                FileStream fileStream = File.Create(filePath);
                fileStream.Close();
            }
        }

        public void userInput()
        {
            string contact;
            string email;
            string zipCode;
            do
            {
                Console.Write("Enter contact number: ");
                contact = Console.ReadLine();
                check = Regex.IsMatch(contact, phonePattern);
                if (!check)
                {
                    Console.WriteLine("You entered invalid phone number!!.\nPlease enter valid phone number.");
                }
            } while (!check);

            if (checkContact(contact))
            {
                Console.WriteLine("\nThis contact is already saved.!!!");
                return;
            }

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            do
            {
                Console.Write("Enter email: ");
                email = Console.ReadLine();

                check = Regex.IsMatch(email, emailPattern);
                if (!check)
                {
                    Console.WriteLine("You entered invalid email address!!.\nPlease enter valid email address.");
                }
            } while (!check);

            Console.Write("Enter city: ");
            string city = Console.ReadLine();

            Console.Write("Enter state: ");
            string state = Console.ReadLine();

            do
            {
                Console.Write("Enter zipcode: ");
                zipCode = Console.ReadLine();
                check = Regex.IsMatch(zipCode, zipCodePattern);
                if (!check)
                {
                    Console.WriteLine("You entered invalid Zip Code!!.\nPlease enter valid Zip Code.");
                }
            } while (!check);

            User usr = new User(contact, name, email, city, state, zipCode);
            user.Add(usr);
        }

        public void ShowAllContacts()
        {
            if (user.Count > 1)
            {
                Console.WriteLine("\n*******************************************************************************************************");
                for (int i = 0; i < user.Count; i++)
                {
                    if (user[i].name.CompareTo("Name") == 0)
                    {
                        continue;
                    }
                    Console.WriteLine("\nName: " + user[i].name);
                    Console.WriteLine("Contact: " + user[i].contact);
                    Console.WriteLine("Email: " + user[i].email);
                    Console.WriteLine("City: " + user[i].city + "       State: " + user[i].state + "       Zipcode: " + user[i].zipCode);
                    Console.WriteLine("\n*******************************************************************************************************");
                }

            }
            else
            {
                Console.WriteLine("\n Contact List is Empty.");
            }
        }

        public bool checkContact(string contact)
        {
            for (int i = 0; i < user.Count; i++)
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
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i].contact == findContact)
                {
                    check = true;
                    Console.WriteLine("\n*******************************************************************************************************");
                    Console.WriteLine("\nName: " + user[i].name);
                    Console.WriteLine("Contact: " + user[i].contact);
                    Console.WriteLine("Email: " + user[i].email);
                    Console.WriteLine("City: " + user[i].city + "       State: " + user[i].state + "       Zipcode: " + user[i].zipCode);
                    Console.WriteLine("\n*******************************************************************************************************");
                }
            }

            if (check == false)
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
                                do
                                {
                                    Console.Write("Enter new contact: ");
                                    user[i].contact = Console.ReadLine();
                                    check = Regex.IsMatch(user[i].contact, phonePattern);
                                    if (!check)
                                    {
                                        Console.WriteLine("You entered invalid phone number!!.\nPlease enter valid phone number.");
                                    }
                                } while (!check);
                                break;

                            case 3:// email
                                do
                                {
                                    Console.Write("Enter new email: ");
                                    user[i].email = Console.ReadLine();
                                    check = Regex.IsMatch(user[i].email, emailPattern);
                                    if (!check)
                                    {
                                        Console.WriteLine("You entered invalid email address!!.\nPlease enter valid email address.");
                                    }
                                } while (!check);
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
                                do
                                {
                                    Console.Write("Enter new zipcode: ");
                                    user[i].zipCode = Console.ReadLine();
                                    check = Regex.IsMatch(user[i].zipCode, zipCodePattern);
                                    if (!check)
                                    {
                                        Console.WriteLine("You entered invalid Zip Code!!.\nPlease enter valid Zip Code.");
                                    }
                                } while (!check);
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

            switch (chs)
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
            Console.WriteLine("Total number of users: " + (user.Count - 1));
        }

        public void DeleteAllUsers()
        {
            user.Clear();
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public void SaveToTxt()
        {
            if (user.Count > 0)
            {
                string[] userArr = new string[user.Count];
                int index = 0;
                foreach (User ur in user)
                {
                    userArr[index] = ur.contact + ", " + ur.name + ", " + ur.email + ", " + ur.city + ", " + ur.state + ", " + ur.zipCode;
                    index++;
                }
                File.WriteAllLines(filePath, userArr);
            }
        }
    }
}
