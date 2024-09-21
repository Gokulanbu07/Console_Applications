using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking
{
    public enum Gender_Type{Male,Female,Others}
    public class PersonalInfo
    {
        public string Name{get;set;}
        public int Age{get;set;}
        public long PhoneNumber{get;set;}
        public Gender_Type Gender{get;set;}

        public PersonalInfo()
        {}
        public PersonalInfo(string name,int age,long phoneNumber,Gender_Type gender)
        {
            Name = name;
            Age = age;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }
    }
}