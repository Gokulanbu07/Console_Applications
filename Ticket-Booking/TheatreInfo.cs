using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TicketBooking
{
    public class TheatreInfo
    {
        private static int s_theatre_id = 300;
        private string _TheatreId = "TID";
        public string TheatreID
        {
            get
            {
                return _TheatreId;
            }
        }

        public string MovieName{get;set;}
        public string TheatreLocation{get;set;}

        public TheatreInfo(string movieName,string theatreLocation)
        {
            _TheatreId += ++s_theatre_id;
            MovieName = movieName;
            TheatreLocation = theatreLocation;
        }

        public TheatreInfo(string ans)
        {
            string[] values = ans.Split(",");
            s_theatre_id = int.Parse(values[0].Remove(0,3));
            _TheatreId = values[0];
            MovieName = values[1];
            TheatreLocation = values[2];
        }

    }
}