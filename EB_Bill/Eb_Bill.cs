using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace Ass3
{
     
    public class Eb_Bill
    {
        private static int Bill_ID = 100;
        private static int s_meter_Id = 1000;
        public string UserName{get ; set ;}
        public long PhoneNumber{get ; set ;}
        public string Mail_Id{get ; set ;}

        public string Meter_ID{get ; set;}


        public Eb_Bill(string userName,long phoneNumber, string mail_Id)
        {
            Meter_ID = "EB"+ ++s_meter_Id;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Mail_Id = mail_Id;
        }
    
    }

    
}