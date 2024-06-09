using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class PayrollService : IPayrollService,IShowDetail
    {
        //aggregration with Staff for payroll process 
        public decimal CalculatePayroll(Staff staff, int workingDays, decimal benefit, decimal deduction)
        {
            //(BasicPay/WorkingDays)*AttendanceDay+Benefit-Deduction-Tax
            return (staff.BasicSalary/workingDays)*staff.AttendanceDay+benefit-deduction;
        }

        public decimal CalculateTax(Staff staff, decimal grossPay)
        {
           //return (staff.BasicSalary+grossPay)*0.01m;
           return 0;
        }

        public void PayrollDetail()
        {
            throw new NotImplementedException();
        }

        public void ShowDetailInfo()
        {
            throw new NotImplementedException();
        }
    }
}