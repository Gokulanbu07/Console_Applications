using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedStore
{
    public class User_Details
    {
       private static int s_user_Id = 1000;
       public string UserName{get ; set ;} 
       public int Age{get; set;}
       public string City{get; set;}
       public long Phone_Number{get;set;}
       public double Balance{get ; set ;}
       public string User_Id{get; set;}


       public User_Details(string username, int age, string city,long phone_number,double balance)
    {
        User_Id = "UID"+ ++s_user_Id;
        UserName = username;
        Age = age;
        City  = city;
        Phone_Number = phone_number;
        Balance =  balance;

    }
    }

    
}