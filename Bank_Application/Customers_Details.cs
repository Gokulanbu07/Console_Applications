using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_Application
{
    public enum Gender{Male,Female,Others}
    public class Customers_Details
    {
        public static int s_customer_id = 1000;
        public string Customer_name{get ; set ;}
        public Gender Gender{get ; set ;}
        public double Balance{get ; set ;}
        public long Phone_number{get ; set ;}
        public string Email{get; set ;}
        public string DateOfBirth{get ; set ;}
        public string Customer_Id{get ; set ;}


        public Customers_Details(string customer_name, Gender gender, double balance, long phone_number,string email,string dateofbirth)
        {
            Customer_Id = "HDFC"+ ++s_customer_id;
            Customer_name = customer_name;
            Gender = gender;
            Balance = balance;
            Phone_number = phone_number;
            Email= email;
            DateOfBirth = dateofbirth;
        }

         public Customers_Details(string ans)
        {
            string[] values = ans.Split(",");
            Customer_Id = values[0];
            s_customer_id = int.Parse(values[0].Remove(0,4));
            Customer_name = values[1];
            Gender = Enum.Parse<Gender>(values[2]);
            Balance = double.Parse(values[3]);
            Phone_number = long.Parse(values[4]);
            Email= values[5];
            DateOfBirth = values[6];
        }

    }
}