using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class PersonalInfo
    {
        public string UserName{get;set;}
        public long Phone_Number{get;set;}

        public PersonalInfo(string userName,long phone_number)
        {
            UserName = userName;
            Phone_Number = phone_number;
        }
    }
}