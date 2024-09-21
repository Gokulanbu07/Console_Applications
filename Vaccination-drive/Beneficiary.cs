using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public enum Gender{Male,Female,others}
    public class Benificiary
    {
        public static int s_registration_number = 1000;
        public string Name{get; set;}
        public int Age{get;set;}
        public Gender Gender{get ; set;}
        public long Mobile_Number{get;set ;}
        public string City{get ; set;}
        public string Registration_number{get ; set;}

        public Benificiary(string name,int age,Gender gender,long mobile_number,string city)
        {
            Registration_number = "BID"+ ++s_registration_number;
            Name = name;
            Age = age;
            Gender = gender;
            Mobile_Number = mobile_number;
            City = city;  
        }

    }
}