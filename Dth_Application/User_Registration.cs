using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dth_Recharge
{
    public class User_Registration
    {
        private static int s_user_Id = 1000;
        public string UserName{get ; set;}
        public long Number{get ;  set;}
        public string Mail_Id{get ;  set ;}
        public double Wallet_Balance{get ; set ;}
        public string User_Id{get ; }

        public User_Registration(string userName, long number,string mail_Id,double wallet_balance)
        {
            User_Id = "UID"+ ++s_user_Id;
            UserName = userName;
            Number = number;
            Mail_Id = mail_Id;
            Wallet_Balance = wallet_balance;
        }
    }

}