using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class BankAccount : ICreditCard
    {
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public decimal OpeningBalance { get; set; }//300000
        //composition with Staff 
        public Staff Staff { get; set; }

        public decimal GetSDGExchangeRate(decimal amount)
        {
            return  amount/2100;
        }

        public decimal GetUSDExchangeRate(decimal amount)
        {
            return amount/3000 ;
        }

        public decimal Withdraw(decimal amount)
        {
            if (amount > OpeningBalance)//500000 , 100000
                throw new ArgumentException("amount is not enough");
            this.OpeningBalance -= amount;
            return this.OpeningBalance;
        }
    }
}