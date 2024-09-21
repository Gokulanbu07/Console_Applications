using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking
{
    public class MovieInfo
    {
        private static int s_movie_id = 500;
        private string _Movie_id = "MID";
        public string Movie_ID
        {
            get
            {
                return _Movie_id;
            }
        }

        public string MovieName{get;set;}
        public string Language{get;set;}

        public MovieInfo(string movieName,string language)
        {
            _Movie_id += ++s_movie_id;
            MovieName = movieName;
            Language = language;
        }

        public MovieInfo(string ans)
        {
            string[] values = ans.Split(",");
            s_movie_id = int.Parse(values[0].Remove(0,3));
            _Movie_id = values[0];
            MovieName = values[1];
            Language = values[2];
        }
    }
}