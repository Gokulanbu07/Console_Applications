using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace TicketBooking
{
    public class Operations
    {
        // Lists
        public static List<PersonalInfo> PersonalDetails = new List<PersonalInfo>();
        public static List<UserInfo> UserDetails = new List<UserInfo>();
        public static List<BookingInfo> BookingDetails = new List<BookingInfo>();
        public static List<TheatreInfo> TheatreDetails = new List<TheatreInfo>();
        public static List<MovieInfo> MovieDetails = new List<MovieInfo>();
        public static List<ScreeningInfo> ScreeningDetails = new List<ScreeningInfo>();

        //User for Registration

        static UserInfo login_User;
        // static BookingInfo booking;

        public static void MainMenu()
        {
            FileHandling.Create();
            FileHandling.ReadFromCsv();
            //DefaultData();

             /*StreamReader sm1 = new StreamReader("TicketBooking/UserInfo.csv");
               if(sm1.ReadLine() == null)
               {
                   DefaultData();
               }

               StreamReader sm2 = new StreamReader("TicketBooking/PersonalInfo.csv");
               if(sm2.ReadLine() == null)
               {
                   DefaultData();
               }

               StreamReader sm3 = new StreamReader("TicketBooking/BookingInfo.csv");
               if(sm3.ReadLine() == null)
               {
                   DefaultData();
               }

               StreamReader sm4 = new StreamReader("TicketBooking/TheatreInfo.csv");
               if(sm4.ReadLine() == null)
               {
                   DefaultData();
               }

               StreamReader sm5 = new StreamReader("TicketBooking/MovieInfo.csv");
               if(sm5.ReadLine() == null)
               {
                   DefaultData();
               }

               StreamReader sm6 = new StreamReader("TicketBooking/ScreeningInfo.csv");
               if(sm6.ReadLine() == null)
               {
                   DefaultData();
               }*/


            Console.WriteLine();
            Console.WriteLine(" * * * * * HEY BUDDY * * * * * ");
            Console.WriteLine();
            string choice = "No";
            do
            {
                Console.WriteLine("Option 1 => Registration");
                Console.WriteLine();
                Console.WriteLine("Option 2 => Login");
                Console.WriteLine();
                Console.WriteLine("OPtion 3 => Exit");
                Console.WriteLine();
                Console.Write("Enter the Options you need to Proceed : ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        {
                            Console.WriteLine("Welcome To Registration");
                            Console.WriteLine();
                            Registration();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Welcome To Login");
                            Console.WriteLine();
                            User_Login();
                            break;
                        }
                    case "3":
                        {
                            choice = "Yes";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("You Have Entered the Wrong Option!!! Please select the correct one Above");
                            Console.WriteLine();
                            break;
                        }
                }

            } while (choice == "No");

            FileHandling.WriteToCsv();
        }

        public static void Registration()
        {
            Console.WriteLine("* * * * * Welcome To The Registration * * * * *");
            Console.WriteLine();
            Console.Write("Do You want to Continue (Yes / No) : ");
            string option = Console.ReadLine();
            Console.WriteLine();

            if (!option.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(" Thank You !! Please Enter Yes or No and Here is Your Main Menu ! !");
                Console.WriteLine();
                return;

            }
            Console.WriteLine("* * * * *  Hey Buddy * * * * * ");
            Console.WriteLine();

            string name = "";
            bool check = false;

            while (!check)
            {
                Console.Write("Please Enter the Name : ");
                name = Console.ReadLine().Trim();

                foreach (var c in name)
                {
                    if (!char.IsPunctuation(c) || char.IsDigit(c) || name.Contains(" "))
                    {
                        check = true;
                        break;
                    }
                }
                if (!check)
                {
                    Console.WriteLine("Please enter the valid Name");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Welcome Buddy " + name);
            Console.WriteLine();

            // Age verification

            int age = 0;
            bool check1 = false;

            while (!check1)
            {
                Console.Write("Enter the age : ");
                string age_input = Console.ReadLine();

                if (int.TryParse(age_input, out age) && age > 0 && age < 120)
                {
                    check1 = true;
                    break;
                }
            }
            if (!check1)
            {
                Console.WriteLine("Enter the Correct age !!");
                Console.WriteLine();
            }

            //Gender

            string gender_input = "";
            Gender_Type gender;

            while (true)
            {
                Console.Write("Enter the Gender : ");
                gender_input = Console.ReadLine();

                if (Enum.TryParse(gender_input, true, out gender))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("enter the valid Gender");
                    Console.WriteLine();
                }
            }

            // Phone number

            long phone_number = 0;
            bool check3 = false;

            while (!check3)
            {
                Console.Write("Enter the Phone number : ");
                string phoneNumber = Console.ReadLine().Trim();

                if (long.TryParse(phoneNumber, out phone_number) && phoneNumber.Length == 10)
                {
                    check3 = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter the valid Phone number !! ");
                    Console.WriteLine();
                }
            }

            Console.Write("Enter the wallet balance : ");
            double wallet_balance = double.Parse(Console.ReadLine());
            Console.WriteLine();

            UserInfo uI = new UserInfo(name, age, phone_number, gender, wallet_balance);
            UserDetails.Add(uI);

            Console.WriteLine("User Registration is Successfully Completed ! !");
            Console.WriteLine("Your User Id is : " + uI.User_Id);
            Console.WriteLine();
        }


        public static void User_Login()
        {
            Console.WriteLine("* * * * * Welcome To Login * * * * * ");
            Console.WriteLine();
            Console.Write("Enter the Login Id : ");
            string iD = Console.ReadLine().ToUpper();
            bool check = false;
            foreach (var ans in UserDetails)
            {
                if (ans.User_Id == iD)
                {
                    check = true;
                    login_User = ans;
                    bool flag = false;
                    do
                    {
                        Console.WriteLine(" SUB - MENU ");
                        Console.WriteLine();
                        Console.WriteLine("Option 1 => Ticket Booking");
                        Console.WriteLine("Option 2 => Ticket Cancellation");
                        Console.WriteLine("Option 3 => Booking History");
                        Console.WriteLine("Option 4 => Wallet Recharge");
                        Console.WriteLine("Option 5 => Show Wallet Balance");
                        Console.WriteLine("Option 6 => Exit");
                        Console.WriteLine();

                        Console.Write("Enter the Option You need To Proceed : ");
                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1":
                                {
                                    TicketBooking();
                                    break;
                                }
                            case "2":
                                {
                                    TicketCancellation();
                                    break;
                                }
                            case "3":
                                {
                                    Booking_History();
                                    break;
                                }
                            case "4":
                                {
                                    WalletRecharge();
                                    break;
                                }
                            case "5":
                                {
                                    ShowWalletBalance();
                                    break;
                                }
                            case "6":
                                {
                                    Console.WriteLine("Thankyou ! ! ");
                                    flag = true;
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Please Enter the Correct Option");
                                    Console.WriteLine();
                                    break;
                                }
                        }

                    } while (!flag);
                }
            }
            if (!check)
            {
                Console.WriteLine("Please enter the valid User ID ! ! ");
            }
        }

        public static void TicketBooking()
        {
            Console.WriteLine("Theatre Details");
            Console.WriteLine();

            foreach (var ans in TheatreDetails)
            {
                Console.WriteLine("Theatre ID : " + ans.TheatreID);
                Console.WriteLine("Movie Name : " + ans.MovieName);
                Console.WriteLine("Theatre Location : " + ans.TheatreLocation);
                Console.WriteLine("---------------------");
            }
            Console.WriteLine();
            Console.Write("Please select the Theatre using the Theatre ID : ");
            string theatreId = Console.ReadLine().ToUpper();

            TheatreInfo result = TheatreDetails.Find(c => c.TheatreID == theatreId);
            if (result == null)
            {
                Console.WriteLine("Enter Valid Theatre ID");
                return;
            }
            else
            {
                Console.WriteLine("Movies Running Today ");
                Console.WriteLine();
                foreach (var ans in MovieDetails)
                {
                    Console.WriteLine("Movie ID : " + ans.Movie_ID + "  " + "Movie Name : " + ans.MovieName + "  " + "Language : " + ans.Language);
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("Screening Details");
                Console.WriteLine();
                foreach (var ans in ScreeningDetails)
                {
                    Console.WriteLine("Movie ID : " + ans.Movie_ID + "  " + "Theatre ID : " + ans.TheatreID + "  " + "Ticket Price : " + ans.TicketPrice + "  " + "Seat Availability : " + ans.NoOfSeats);
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.Write("Please Select the movie using Movie ID using the Screening list : ");
                string movieID = Console.ReadLine().ToUpper();
                MovieInfo mI = MovieDetails.Find(m => m.Movie_ID == movieID);
                if (mI == null)
                {
                    Console.WriteLine("Please enter the Correct Movie ID");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    ScreeningInfo sI = ScreeningDetails.Find(s => s.Movie_ID == movieID && s.TheatreID == theatreId);
                    if (sI == null)
                    {
                        Console.WriteLine("This Movie is not in the Theatre");
                        return;
                    }
                    else
                    {
                        Console.Write("Enter the number of Tickets your need : ");
                        int noOfseats = int.Parse(Console.ReadLine());
                        if (noOfseats <= sI.NoOfSeats)
                        {
                            double TotalAmount = noOfseats * sI.TicketPrice * 1.18;

                            if (login_User.WalletBalance >= TotalAmount)
                            {
                                login_User.DeductBalance(TotalAmount);
                                sI.NoOfSeats -= noOfseats;
                                BookingInfo bI = new BookingInfo(login_User.User_Id, sI.Movie_ID, sI.TheatreID, noOfseats, TotalAmount, Booking_Status.Booked);
                                BookingDetails.Add(bI);

                                Console.WriteLine();
                                Console.WriteLine("Ticket Booked Successfully . Enjoy Your Time With Us");
                                Console.WriteLine();

                            }
                            else
                            {
                                Console.WriteLine("Insufficient Wallet Balance Please Recharge. Please Recharge your Wallet");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Required Tickets are not Available");
                            Console.WriteLine("Currently Available Ticket counts Are : " + sI.NoOfSeats);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        public static void TicketCancellation()
        {
            bool check = false;
            foreach (var ans in BookingDetails)
            {
                if (ans.UserID == login_User.User_Id && ans.BookedStatus == Booking_Status.Booked)
                {
                    check = true;
                    Console.WriteLine("User ID        : " + ans.UserID);
                    Console.WriteLine("Booking ID     : " + ans.Booking_ID);
                    Console.WriteLine("Theatre ID     : " + ans.TheatreID);
                    Console.WriteLine("Total Amount   : " + ans.TotalAmount);
                    Console.WriteLine("Booking Status : " + ans.BookedStatus);
                    Console.WriteLine("---------------------------");
                }
            }
            if (!check)
            {
                Console.WriteLine("No History Found...Please Book the Ticket");
            }

            Console.WriteLine();
            bool check1 = false;
            foreach (var ans in BookingDetails)
            {
                if (login_User.User_Id == ans.UserID)
                {
                    check1 = true;
                    Console.WriteLine("Welcome To Ticket Cancellation");
                    Console.WriteLine();
                    Console.Write("Enter the booking Id you need to Cancel : ");
                    string cancelId = Console.ReadLine().ToUpper();
                    if (ans.Booking_ID == cancelId)
                    {
                        if (ans.BookedStatus == Booking_Status.Booked)
                        {
                            foreach (var seat in ScreeningDetails)
                            {
                                if (seat.Movie_ID == ans.MovieID && seat.TheatreID == ans.TheatreID)
                                {
                                    seat.NoOfSeats += ans.SeatCount;

                                    double amount = ans.TotalAmount - 20;
                                    login_User.WalletBalance += amount;

                                    ans.BookedStatus = Booking_Status.Cancelled;
                                    Console.WriteLine("Successfully Cancelled");
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid status");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Enter the Booking Id which You have Booked before ! !");
                        return;
                    }
                }
            }
            if (!check1)
            {
                Console.WriteLine("Hyy there !! You have not Booked the Show");
                return;
            }
        }

        public static void Booking_History()
        {
            bool check = false;
            foreach (var ans in BookingDetails)
            {
                if (ans.UserID == login_User.User_Id)
                {
                    check = true;
                    Console.WriteLine("User ID : " + ans.UserID);
                    Console.WriteLine("Booking ID : " + ans.Booking_ID);
                    Console.WriteLine("Theatre ID : " + ans.TheatreID);
                    Console.WriteLine("Total Amount : " + ans.TotalAmount);
                    Console.WriteLine("Booking Status : " + ans.BookedStatus);
                    Console.WriteLine("---------------------------");
                }
            }
            if (!check)
            {
                Console.WriteLine("No History Found...PLease Book the Ticket");
            }
        }

        public static void WalletRecharge()
        {   bool amountCheck;
        double amount ;
            do{
            
            Console.Write("Enter the Amount to be Recharge : ");
            amountCheck = double.TryParse(Console.ReadLine(),null, out amount);
            }while(!amountCheck);

            login_User.WalletBalance += amount;
            Console.WriteLine("Your Recharge Amount is : " + amount + "  " + "Wallet Balance : " + login_User.WalletBalance);
            Console.WriteLine();
        }

        public static void ShowWalletBalance()
        {
            Console.WriteLine(" * * * Wallet Balance * * * ");
            Console.WriteLine();
            Console.WriteLine("Current Balance : " + login_User.WalletBalance);
            Console.WriteLine();
        }


        public static void DefaultData()
        {
            // User Details
            UserInfo user1 = new UserInfo("Gokul", 21, 7904643846, Gender_Type.Male, 500);
            UserInfo user2 = new UserInfo("Siva", 20, 1234567890, Gender_Type.Male, 100);
            UserDetails.Add(user1);
            UserDetails.Add(user2);

            // Theatre Details

            TheatreInfo theatre1 = new TheatreInfo("Inox", "Velacherry");
            TheatreInfo theatre2 = new TheatreInfo("Ega", "Anna Nagar");
            TheatreInfo theatre3 = new TheatreInfo("Kasi", "Vadapalani");
            TheatreDetails.Add(theatre1);
            TheatreDetails.Add(theatre2);
            TheatreDetails.Add(theatre3);

            //Movie Details

            MovieInfo movie1 = new MovieInfo("VTV", "Tamil");
            MovieInfo movie2 = new MovieInfo("Kalki", "Tamil");
            MovieInfo movie3 = new MovieInfo("Premam", "Malayalam");
            MovieInfo movie4 = new MovieInfo("Game Of Thrones", "English");
            MovieInfo movie5 = new MovieInfo("Vikram", "Hindi");
            MovieInfo movie6 = new MovieInfo("GOAT", "Tamil");
            MovieDetails.Add(movie1);
            MovieDetails.Add(movie2);
            MovieDetails.Add(movie3);
            MovieDetails.Add(movie4);
            MovieDetails.Add(movie5);
            MovieDetails.Add(movie6);

            // Screening Details

            ScreeningInfo screen1 = new ScreeningInfo("MID501", "TID301", 200, 5);
            ScreeningInfo screen2 = new ScreeningInfo("MID502", "TID301", 300, 2);
            ScreeningInfo screen3 = new ScreeningInfo("MID506", "TID301", 50, 1);
            ScreeningInfo screen4 = new ScreeningInfo("MID501", "TID302", 400, 11);
            ScreeningInfo screen5 = new ScreeningInfo("MID505", "TID302", 300, 20);
            ScreeningInfo screen6 = new ScreeningInfo("MID504", "TID302", 500, 2);
            ScreeningInfo screen7 = new ScreeningInfo("MID505", "TID303", 200, 11);
            ScreeningInfo screen8 = new ScreeningInfo("MID502", "TID303", 200, 20);
            ScreeningInfo screen9 = new ScreeningInfo("MID504", "TID303", 350, 2);
            ScreeningDetails.Add(screen1);
            ScreeningDetails.Add(screen2);
            ScreeningDetails.Add(screen3);
            ScreeningDetails.Add(screen4);
            ScreeningDetails.Add(screen5);
            ScreeningDetails.Add(screen6);
            ScreeningDetails.Add(screen7);
            ScreeningDetails.Add(screen8);
            ScreeningDetails.Add(screen9);

            // Booking Details

            BookingInfo booking1 = new BookingInfo("UID1001", "MID501", "TID301", 1, 236, Booking_Status.Booked);
            BookingInfo booking2 = new BookingInfo("UID1001", "MID504", "TID302", 1, 472, Booking_Status.Booked);
            BookingInfo booking3 = new BookingInfo("UID1002", "MID505", "TID302", 1, 354, Booking_Status.Booked);
            BookingDetails.Add(booking1);
            BookingDetails.Add(booking2);
            BookingDetails.Add(booking3);


        }


    }
}