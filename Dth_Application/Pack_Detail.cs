using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Dth_Recharge
{
    public class Pack_Detail
    {
        public string Pack_iD{get ; set ;}
        public string Pack_name{get ; set ;}    
        public double Price{get ; set ;}                                          
        public int Validity{get ; set ;}
        public int No_of_channels{get ; set ;}

        public Pack_Detail(string pack_id,string pack_name,double price,int validity,int no_of_channels)
        {
            Pack_iD = pack_id;
            Pack_name = pack_name;
            Price = price;
            Validity = validity;
            No_of_channels = no_of_channels;
        }


    }
}