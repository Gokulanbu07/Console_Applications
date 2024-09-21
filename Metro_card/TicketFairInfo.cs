using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class TicketFairInfo
    {
        private static int s_ticketid =3001;
        private string _Ticket_Id = "MR";
        public string Ticket_ID
        {
            get
            {
                return _Ticket_Id;
            }
        } 

        public string FromLocation{get;set;}
        public string ToLocation{get;set;}

        public double TicketPrice{get;set;}

        public TicketFairInfo(string fromLocation,string toLocation,double ticketPrice)
        {
            _Ticket_Id+= ++s_ticketid;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            TicketPrice = ticketPrice;
        }

    }
}