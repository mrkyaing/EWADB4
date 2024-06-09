using PayrollSystem;

Console.WriteLine("Welcome to Payroll system");
Staff s1=new Staff(){
    Id="s001",
    Name="Su SU",
    BasicSalary=500000,
    AttendanceDay=30,
    Address="YGN",
    Desgination="HR"
};
Staff s2=new Staff(){
    Id="s002",
    Name="Aung Aung",
    BasicSalary=500000,
    AttendanceDay=20,
    Address="YGN",
    Desgination="Accounting"
};
BankAccount b1=new BankAccount(){
    AccountNo="AA001",
    BankName="CB Bank",
    Staff=s1
};
BankAccount b2=new BankAccount(){
    AccountNo="BB001",
    BankName="KBZ",
    Staff=s2
};
IPayrollService payrollService=new PayrollService();
decimal grosspay=payrollService.CalculatePayroll(s1,30,20000,5000);
Console.WriteLine("gross pay of "+s1.Name+grosspay);
decimal tax=payrollService.CalculateTax(s1,grosspay);
Console.WriteLine("Tax amout of "+s1.Name+tax);
b1.OpeningBalance=grosspay-tax;
Console.WriteLine("Check balance of Amount after payroll :"+s1.Name+b1.OpeningBalance);
b1.Withdraw(100000);
Console.WriteLine("Check balance of Amount after withdraw:"+s1.Name+b1.OpeningBalance);
b1.Withdraw(500000);
Console.WriteLine("Check balance of Amount after withdraw:"+s1.Name+b1.OpeningBalance);
Console.WriteLine("Exchange rage Amount in USD"+b1.GetUSDExchangeRate(1));