using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("TicketBooking"))
            {
                Console.WriteLine("Created Directory");
                Directory.CreateDirectory("TicketBooking");
            }
            else
            {
                Console.WriteLine("Directory Already Exits");
            }

            // User Detail Class

            if(!File.Exists("TicketBooking/UserInfo.csv"))
            {
                Console.WriteLine("Creating UserInfo Csv...");
                File.Create("TicketBooking/UserInfo.csv").Close();
            }
            else
            {
                Console.WriteLine("UserInfo csv Already Exits");
            }

            //Booking Info class

             if(!File.Exists("TicketBooking/BookingInfo.csv"))
            {
                Console.WriteLine("Creating BookingInfo Csv...");
                File.Create("TicketBooking/BookingInfo.csv").Close();
            }
            else
            {
                Console.WriteLine("BookingInfo csv Already Exits");
            }

            //Theatre Details class
             if(!File.Exists("TicketBooking/TheatreInfo.csv"))
            {
                Console.WriteLine("Creating TheatreInfo Csv...");
                File.Create("TicketBooking/TheatreInfo.csv").Close();
            }
            else
            {
                Console.WriteLine("Theatre Info csv Already Exits");
            }

            //Movie Info class

             if(!File.Exists("TicketBooking/MovieInfo.csv"))
            {
                Console.WriteLine("Creating MovieInfo Csv...");
                File.Create("TicketBooking/MovieInfo.csv").Close();
            }
            else
            {
                Console.WriteLine("MovieInfo csv Already Exits");
            }

            //Screening  Info  class

             if(!File.Exists("TicketBooking/ScreeningInfo.csv"))
            {
                Console.WriteLine("Creating ScreeningInfo Csv...");
                File.Create("TicketBooking/ScreeningInfo.csv").Close();
            }
            else
            {
                Console.WriteLine("ScreeningInfo csv Already Exits");
            }
        }

        public static void WriteToCsv()
        {
            // user Details
            string[] userDetails = new string[Operations.UserDetails.Count] ;
            for(int i = 0;i<Operations.UserDetails.Count;i++)
            {
                userDetails[i] = Operations.UserDetails[i].User_Id+","+Operations.UserDetails[i].Name+","+Operations.UserDetails[i].Age+","+Operations.UserDetails[i].PhoneNumber+","+Operations.UserDetails[i].Gender+","+Operations.UserDetails[i].WalletBalance;
            }
            File.WriteAllLines("TicketBooking/UserInfo.csv",userDetails);

             //  Booking Details
            string[] bookingDetails = new string[Operations.BookingDetails.Count] ;
            for(int i = 0;i<Operations.BookingDetails.Count;i++)
            {
                bookingDetails[i] = Operations.BookingDetails[i].Booking_ID+","+Operations.BookingDetails[i].UserID+","+Operations.BookingDetails[i].MovieID+","+Operations.BookingDetails[i].TheatreID+","+Operations.BookingDetails[i].SeatCount+","+Operations.BookingDetails[i].TotalAmount+","+Operations.BookingDetails[i].BookedStatus;
            }
            File.WriteAllLines("TicketBooking/BookingInfo.csv",bookingDetails);

             //  Theatre Details
            string[] theatreDetails = new string[Operations.TheatreDetails.Count] ;
            for(int i = 0;i<Operations.TheatreDetails.Count;i++)
            {
                theatreDetails[i] = Operations.TheatreDetails[i].TheatreID+","+Operations.TheatreDetails[i].MovieName+","+Operations.TheatreDetails[i].TheatreLocation;
            }
            File.WriteAllLines("TicketBooking/TheatreInfo.csv",theatreDetails);

             //  Theatre Details
            string[] movieDetails = new string[Operations.MovieDetails.Count] ;
            for(int i = 0;i<Operations.MovieDetails.Count;i++)
            {
                movieDetails[i] = Operations.MovieDetails[i].Movie_ID+","+Operations.MovieDetails[i].MovieName+","+Operations.MovieDetails[i].Language;
            }
            File.WriteAllLines("TicketBooking/MovieInfo.csv",movieDetails);

              //  Screening Details
            string[] screenDetails = new string[Operations.ScreeningDetails.Count] ;
            for(int i = 0;i<Operations.ScreeningDetails.Count;i++)
            {
                screenDetails[i] = Operations.ScreeningDetails[i].Movie_ID+","+Operations.ScreeningDetails[i].TheatreID+","+Operations.ScreeningDetails[i].NoOfSeats+","+Operations.ScreeningDetails[i].TicketPrice;
            }
            File.WriteAllLines("TicketBooking/ScreeningInfo.csv",screenDetails);
        }

        public static void ReadFromCsv()
        {
            string[] userDetail = File.ReadAllLines("TicketBooking/UserInfo.csv");
            foreach(var ans in userDetail)
            {
                UserInfo uI = new UserInfo(ans);
                Operations.UserDetails.Add(uI);
            }

            string[] bookingDetails = File.ReadAllLines("TicketBooking/BookingInfo.csv");
            foreach(var ans in bookingDetails)
            {
                BookingInfo bI = new BookingInfo(ans);
                Operations.BookingDetails.Add(bI);
            }

            string[] theatreDetails = File.ReadAllLines("TicketBooking/TheatreInfo.csv");
            foreach(var ans in theatreDetails)
            {
                TheatreInfo tD = new TheatreInfo(ans);
                Operations.TheatreDetails.Add(tD);
            }

            string[] movieDetails = File.ReadAllLines("TicketBooking/MovieInfo.csv");
            foreach(var ans in movieDetails)
            {
                MovieInfo mI = new MovieInfo(ans);
                Operations.MovieDetails.Add(mI);
            }

            string[] screeningDetails = File.ReadAllLines("TicketBooking/ScreeningInfo.csv");
            foreach(var ans in screeningDetails)
            {
                ScreeningInfo sI = new ScreeningInfo(ans);
                Operations.ScreeningDetails.Add(sI);
            }

        }
    }
}