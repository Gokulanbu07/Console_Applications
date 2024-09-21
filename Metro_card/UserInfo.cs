using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class UserInfo : PersonalInfo,IBalance
    {
        private static int s_cardNumber = 1000;
        private string _cardID = "CMRL";

        public string CardID
        {
            get
            {
                return _cardID;
            }
        }

        public double Balance{get;set;}
        public UserInfo(string userName,long phone_number,double balance) : base(userName,phone_number)
        {
            _cardID+= ++s_cardNumber;
            Balance = balance;
        }
         public void WalletRecharge(double amount)
        {
            Balance+=amount;
        }

        public void DeductBalance(double amount) 
        {
            Balance -= amount;
        }
        
    }
}