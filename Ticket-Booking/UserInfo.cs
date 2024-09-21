using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking
{
    public class UserInfo : PersonalInfo,IWallet
    {
        private static int s_userId = 1000;

        private string _userID = "UID";
        
        public string User_Id
        {
            get{
                return _userID;
            }
        }

        public double WalletBalance{get;set;}

        public UserInfo(string name,int age,long phoneNumber,Gender_Type gender,double wallet_balance) : base(name,age,phoneNumber,gender)
        {
            _userID += ++s_userId;
            WalletBalance = wallet_balance;
        }

        public UserInfo(string ans)
        {
           string[] values = ans.Split(",");
           s_userId = int.Parse(values[0].Remove(0,3));
           _userID = values[0];
           Name = values[1];
           Age = int.Parse(values[2]);
           PhoneNumber = long.Parse(values[3]);
           Gender = Enum.Parse<Gender_Type>(values[4]);
           WalletBalance = double.Parse(values[5]);

        }

        public void RechargeWallet(double amount)
        {
            WalletBalance += amount;
        }
        public void DeductBalance(double amount)
        {
            WalletBalance -= amount;
            return;
        }

        
    }
}