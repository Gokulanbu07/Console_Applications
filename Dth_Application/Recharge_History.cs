using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dth_Recharge
{
    public class Recharge_History
    {
        private static int s_recharge_id = 100;
        public string User_Id{get ; }
        public string Pack_ID{get ; set ;}
        public DateTime Recharge_Date{get ; set ;}
        public double Recharge_Amount{get ; set ;}
        public DateTime Valid_time{get ; set ;}
        public int No_of_channels{get ;set ;}
        public string Recharge_Id{get ; }

        public Recharge_History(string user_Id,string pack_ID,DateTime recharge_Date,double recharge_Amount,DateTime validity,int no_of_channels)
        {
            Recharge_Id = "RP"+ ++s_recharge_id;
            User_Id = user_Id;
            Pack_ID = pack_ID;
            Recharge_Date = recharge_Date;
            Recharge_Amount = recharge_Amount;
            Valid_time = validity;
            No_of_channels = no_of_channels;
        }
    }
}