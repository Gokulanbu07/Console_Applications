using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedStore
{
    public class Medicine_Details
    {
        private static int s_medicine_id = 2000;
        public string Medicine_Name{get ; set ;}
        public int Available_Count{get ; set ;}
        public double Price{get; set;}
        public DateTime DateOfExpiry{get; set;}
        public string Medicine_ID{get ; set;}

        public Medicine_Details(string medicine_name, int available_count,double price, DateTime dateofexpiry)
        {
            Medicine_ID = "MD"+ ++s_medicine_id;
            Medicine_Name = medicine_name;
            Available_Count = available_count;
            Price = price;
            DateOfExpiry = dateofexpiry;
        }

    }
}