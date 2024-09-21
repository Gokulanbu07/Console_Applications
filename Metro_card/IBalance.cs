using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public interface IBalance
    {
        public double Balance{get;set;}
        public void WalletRecharge(double amount);
        public void DeductBalance(double amount);
    }
}