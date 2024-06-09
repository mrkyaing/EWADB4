using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public interface IPayrollService
    {
       
        decimal CalculatePayroll(Staff staff,int workingDays,decimal benefit,decimal deduction);
        decimal CalculateTax(Staff staff,decimal grossPay);
    }
}