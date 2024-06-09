using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Staff:IShowDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Desgination { get; set; }
       private decimal basicSalary ;
       public decimal AttendanceDay{ get; set; }
       public decimal BasicSalary
       {
        get { return basicSalary; }
        set { 
            if(value<0) throw new ArgumentException("Invalid basic salary input");
            basicSalary=value;
         }
       }
       
        public string Address { get; set; }

        public void ShowDetailInfo()
        {
           Console.WriteLine("Id:"+Id);
           Console.WriteLine("Name:"+Name);
           Console.WriteLine("Designation:"+Desgination);
           Console.WriteLine("Basic Salary:"+basicSalary);
        }

        public void PayrollDetail()
        {
           Console.WriteLine("printing out payroll");
        }
    }
}