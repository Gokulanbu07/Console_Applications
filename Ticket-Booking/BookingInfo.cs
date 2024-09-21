using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking
{
    public enum Booking_Status{Booked,Cancelled}
    public class BookingInfo
    {
        private static int s_booking_id = 7000;
        private string _Booking_id = "BID";

        public string Booking_ID
        {
            get
            {
                return _Booking_id;
            }
        }

        public string UserID{get;set;}
        public string MovieID{get;set;}
        public string TheatreID{get;set;}
        public int SeatCount{get;set;}
        public double TotalAmount{get;set;}

        public Booking_Status BookedStatus{get;set;}

        public BookingInfo(string user_Id,string movieID,string theatreID,int seatCount,double totalAmount,Booking_Status bookingstatus)
        {
            _Booking_id += ++s_booking_id;
            UserID = user_Id;
            MovieID = movieID;
            TheatreID = theatreID;
            SeatCount = seatCount;
            TotalAmount = totalAmount;
            BookedStatus = bookingstatus;
        }

        public BookingInfo(string ans)
        {
           string[] values = ans.Split(",");
           s_booking_id = int.Parse(values[0].Remove(0,3));
           _Booking_id = values[0];
           UserID = values[1];
           MovieID = values[2];
           TheatreID = values[3];
           SeatCount = int.Parse(values[4]);
           TotalAmount = double.Parse(values[5]);
           BookedStatus = Enum.Parse<Booking_Status>(values[6]);

           
        }
    }
}