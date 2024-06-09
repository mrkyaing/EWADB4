using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public interface ICreditCard
    {
        decimal GetUSDExchangeRate(decimal amount);
        decimal GetSDGExchangeRate(decimal amount);
        decimal Withdraw(decimal amount);
    }
}