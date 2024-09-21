using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MetroCard
{
    public class Operations
    {

        public static List<UserInfo> UserList = new List<UserInfo>();
        public static List<TravelInfo> TravelList = new List<TravelInfo>();
        public static List<TicketFairInfo> TicketsFairList = new List<TicketFairInfo>();
        static UserInfo login_user;
        public static void MainMenu()
        {
            DefaultData();
            bool check = false;
            Console.WriteLine();
            Console.WriteLine(" * * * * * * * * * * Welcome To Metro Rail Limited * * * * * * * * * * ");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Option 1 => UserRegistration");
                Console.WriteLine("Option 2 => LoginUser");
                Console.WriteLine("Option 3 => Exit");
                Console.WriteLine();
                Console.Write("Please Enter the Option You need To Proceed : ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        {
                            Console.WriteLine("Welcome To User Registration");
                            Console.WriteLine();
                            UserRegistration();
                            break;
                        }
                    case "2":
                        {
                            Login();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Thank You !! Jai Hind");
                            check = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please Enter the Valid Option");
                            break;
                        }
                }
            } while (!check);
        }

        public static void UserRegistration()
        {
            Console.WriteLine();
            Console.Write("Do You Need To Register (Yes or No) : ");
            string answer = Console.ReadLine();
            Console.WriteLine();

            if (!answer.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine();
                Console.WriteLine("Thank you");
                return;
            }

            Console.WriteLine(" Metro Rail Limited Welcomes You ! !");
            Console.WriteLine();

            string userName = "";
            bool flag1 = false;
            while (!flag1)
            {
                Console.Write("Enter the User Name Please : ");
                userName = Console.ReadLine().Trim();

                foreach (var c in userName)
                {
                    if (!char.IsPunctuation(c) || char.IsDigit(c) || userName.Contains("  "))
                    {
                        flag1 = true;
                        break;
                    }
                }
                if (!flag1)
                {
                    Console.WriteLine("Please Enter the name in Valid Format");
                    Console.WriteLine();
                }
            }

            long Phone_number = 0;
            bool check1 = false;

            while (!check1)
            {
                Console.Write("Enter the Phone number : ");
                string phoneNumber = Console.ReadLine().Trim();

                if (long.TryParse(phoneNumber, out Phone_number) && phoneNumber.Length == 10)
                {
                    check1 = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter the Valid Phone Number");
                    Console.WriteLine();
                }
            }

            Console.Write("Enter the Balance to be Added : ");
            double balance = double.Parse(Console.ReadLine());
            Console.WriteLine();

            UserInfo uI = new UserInfo(userName, Phone_number, balance);
            UserList.Add(uI);

            Console.WriteLine("Registration Successful and Your CardNumber is : " + uI.CardID);
            Console.WriteLine();



        }

        public static void Login()
        {
            bool flag = false;

            Console.WriteLine("Welcome To the Login Page");
            Console.WriteLine();
            Console.Write("Please Enter your Card Number : ");
            string cardNumber = Console.ReadLine().ToUpper();
            bool check = false;
            foreach (var ans in UserList)
            {
                if (ans.CardID == cardNumber)
                {
                    do
                    {
                        check = true;
                        login_user = ans;
                        Console.WriteLine();
                        Console.WriteLine("SUB - MENU");
                        Console.WriteLine();
                        Console.WriteLine("Option 1 => Balance Check");
                        Console.WriteLine("Option 2 => Recharge");
                        Console.WriteLine("Option 3 => View Travel History");
                        Console.WriteLine("Option 4 => Travel");
                        Console.WriteLine("Option 5 => Exit");
                        Console.WriteLine();
                        Console.WriteLine("Please Enter the Option You need to Proceed : ");
                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1":
                                {
                                    BalanceCheck();
                                    break;
                                }
                            case "2":
                                {
                                    WalletRecharge();
                                    break;
                                }
                            case "3":
                                {
                                    ViewTravelHistory();
                                    break;
                                }
                            case "4":
                                {
                                    Travel();
                                    break;
                                }
                            case "5":
                                {
                                    Console.WriteLine("Thank You");
                                    flag = true;
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Please enter the valid Option");
                                    break;
                                }
                        }
                    } while (!flag);
                }

            }
            if (!check)
            {
                Console.WriteLine("Please Provide the Correct Card number");
                return;
            }

        }

        public static void BalanceCheck()
        {
            Console.WriteLine();
            Console.WriteLine("Your Balance Is : " + login_user.Balance);
            Console.WriteLine();
        }

        public static void WalletRecharge()
        {
            Console.WriteLine("Enter the amount to recharge : ");
            double amount = double.Parse(Console.ReadLine());
            login_user.WalletRecharge(amount);
            Console.WriteLine();
            Console.WriteLine("Recharge amount : " + amount + " " + "Balance : " + login_user.Balance);
            Console.WriteLine();
        }
        public static void ViewTravelHistory()
        {
            Console.WriteLine(" * * * Travel History * * * ");
            Console.WriteLine();
            bool check = false;
            foreach (var ans in TravelList)
            {
                if (login_user.CardID == ans.Card_Number)
                {
                    check = true;
                    Console.WriteLine("Travel ID : " + ans.TravelID);
                    Console.WriteLine("Card Number : " + ans.Card_Number);
                    Console.WriteLine("From Location : " + ans.FromLocation);
                    Console.WriteLine("To Location : " + ans.ToLocation);
                    Console.WriteLine("Travel Cost : " + ans.Travel_Cost);
                    Console.WriteLine("Travel Date : " + ans.Travel_Date);
                    Console.WriteLine("------------------------------");
                }

            }
            if (!check)
            {
                Console.WriteLine("No History Found");
                return;
            }
        }

        public static void Travel()
        {
            Console.WriteLine(" Welcome To Travel ");
            Console.WriteLine();
            TravelLists();
            Console.WriteLine();
            Console.Write("Enter the Ticket ID you wish : ");
            string Id = Console.ReadLine();
            bool check = false;
            foreach (var ans in TicketsFairList)
            {
                if (ans.Ticket_ID == Id)
                {
                    check = true;
                    if (login_user.Balance >= ans.TicketPrice)
                    {
                        login_user.DeductBalance(ans.TicketPrice);

                        TravelInfo tI = new TravelInfo(login_user.CardID, ans.FromLocation, ans.ToLocation, DateTime.Now, ans.TicketPrice);
                        TravelList.Add(tI);

                        Console.WriteLine("Successfully Booked");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Balance Please Recharge ! !");
                        return;
                    }
                }

            }
            if (!check)
            {
                Console.WriteLine("Invalid User ID ");
            }
        }

        public static void DefaultData()
        {
            // USer Detail Class

            UserInfo user1 = new UserInfo("Ravi", 9848812345, 100);
            UserInfo user2 = new UserInfo("Baskaran", 9848854321, 50);
            UserList.Add(user1);
            UserList.Add(user2);

            // Travel History

            TravelInfo travel1 = new TravelInfo("CMRL1001", "Airport", "Egmore", new DateTime(2023, 10, 10), 55);
            TravelInfo travel2 = new TravelInfo("CMRL1001", "Egmore", "Koyambedu", new DateTime(2023, 10, 10), 32);
            TravelInfo travel3 = new TravelInfo("CMRL1002", "Alandur", "Koyambedu", new DateTime(2023, 11, 10), 40);
            TravelInfo travel4 = new TravelInfo("CMRL1002", "Egmore", "Thirumangalam", new DateTime(2023, 11, 10), 25);
            TravelList.Add(travel1);
            TravelList.Add(travel2);
            TravelList.Add(travel3);
            TravelList.Add(travel4);

            //Ticket Fair

            TicketFairInfo ticket1 = new TicketFairInfo("Airport", "Egmore", 55);

            TicketFairInfo ticket2 = new TicketFairInfo("Airport", "Koyambedu", 25);

            TicketFairInfo ticket3 = new TicketFairInfo("Alandur", "Egmore", 40);

            TicketFairInfo ticket4 = new TicketFairInfo("Egmore", "Koyambedu", 32);

            TicketFairInfo ticket5 = new TicketFairInfo("Egmore", "Koyambedu", 45);

            TicketFairInfo ticket6 = new TicketFairInfo("Vadaplani", "Egmore", 30);

            TicketFairInfo ticket7 = new TicketFairInfo("Vadapalani", "Koyambedu", 20);

            TicketFairInfo ticket8 = new TicketFairInfo("Egmore", "Thirumangalam", 55);

            TicketsFairList.Add(ticket1);
            TicketsFairList.Add(ticket2);
            TicketsFairList.Add(ticket3);
            TicketsFairList.Add(ticket4);
            TicketsFairList.Add(ticket5);
            TicketsFairList.Add(ticket6);
            TicketsFairList.Add(ticket7);
            TicketsFairList.Add(ticket8);






        }

        public static void TravelLists()
        {
            foreach (var ans in TicketsFairList)
            {
                Console.WriteLine("Travel Id : " + ans.Ticket_ID + " " + " From Location : " + ans.FromLocation + " " + "To Location : " + ans.ToLocation + " " + "Ticket Price : " + ans.TicketPrice);
            }
        }
    }

}