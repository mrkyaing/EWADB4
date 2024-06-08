// See https://aka.ms/new-console-template for more information
using Day4;

Console.WriteLine("Encapsulation Practice");
try
{
    Teacher teacher = new Teacher();
    teacher.Name = "U Ba";
    teacher.Address = "YGN";
    teacher.Age = 30;
    teacher.TrainingFees = 30000;
    Console.WriteLine(teacher);
    Student student = new Student();
    student.SetName("MG MG");
    student.SetAddress("YGN");
    student.SetAge(20);
    student.SetEmail("mgmg@gmail.com");
    Console.WriteLine(student);
    Student student1 = new Student();
    student1.SetName("Su Su");
    student1.SetAddress("YGN");
    student1.SetAge(30);
    student1.SetEmail("susu@gmail.com");
    Console.WriteLine(student1);
    Teacher dawHla=new Teacher();
    dawHla.Name="Daw Hla";
    dawHla.Address="YGN";
    dawHla.Age=-30;
    dawHla.Email="hla@gmail.com";
    Console.WriteLine(dawHla);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

