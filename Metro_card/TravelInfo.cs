using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MetroCard
{
    public class TravelInfo
    {
        private static int s_travel_id = 2001;
        private string _travelID = "TID";
        public string TravelID
        {
            get
            {
                return _travelID;
            }
        }

        public string Card_Number{get;set;}
        public string FromLocation{get;set;}
        public string ToLocation{get;set;}
        public DateTime Travel_Date{get;set;}
        public double Travel_Cost{get;set;}

        public TravelInfo(string card_number,string fromLocation,string toLocation,DateTime travel_date,double travel_cost)
        {
            _travelID += ++s_travel_id;
            Card_Number = card_number;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            Travel_Date = travel_date;
            Travel_Cost = travel_cost; 
        }
    }
}