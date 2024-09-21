using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedStore
{
        public enum Order_Status{Purchased,Cancelled}
    public class Order_Details
    {
       private static int s_order_id = 3000;
       public string User_Id{get ; set;}
       public string Medicine_ID{get; set;}
       public int Medicine_count{get ; set;}
       public double Total_Price{get ; set;}
       public DateTime Order_Date{get; set;}
       public Order_Status Order_Status{get; set;}
       public string Order_ID{get;set;}

       public Order_Details(string user_id,string medicine_id,int medicine_count,double total_price,DateTime order_date,Order_Status order_status)
       {
            Order_ID = "OID"+ ++s_order_id;
            User_Id = user_id;
            Medicine_ID =  medicine_id;
            Medicine_count = medicine_count;
            Total_Price = total_price;
            Order_Date = order_date;
            Order_Status = order_status;
        
       }

    }
}