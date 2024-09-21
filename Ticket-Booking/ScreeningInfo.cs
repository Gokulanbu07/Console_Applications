using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking
{
    public class ScreeningInfo
    {
        public string Movie_ID{get;set;}
        public string TheatreID{get;set;}
        public int NoOfSeats{get;set;}
        public double TicketPrice{get;set;}

        public ScreeningInfo(string movieID,string theatreID,int noOfSeats,double ticketPrice)
        {
            Movie_ID = movieID;
            TheatreID = theatreID;
            NoOfSeats = noOfSeats;
            TicketPrice = ticketPrice;
        }

        public ScreeningInfo(string ans)
        {
            string[] values = ans.Split(",");
            Movie_ID = values[0];
            TheatreID = values[1];
            NoOfSeats = int.Parse(values[2]);
            TicketPrice = int.Parse(values[3]);
        }

        
    }
}