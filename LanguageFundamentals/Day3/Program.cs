
namespace Day3;
using StudentInfo;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Student.SayHello();//SayHello() method is static method
        Student s=new Student();
        s.SayHi();
        foreach(Student s1 in s.getAllStudent()){
            Console.WriteLine(s1);
        }

        Car myCar=new Car();//create a car object or instance of car class 
        myCar.Type="BMW";
        myCar.LicenceNo="YGN-123";
        myCar.Speed=35;
        myCar.Drive();
       
        Console.WriteLine(myCar);
        int k=10;
        Console.Write(k);
        Random rdn=new Random();//crea
        Console.WriteLine(rdn.Next(1));//1
        Car yourCar=new Car("TOYATA","MDY-303");
        //yourCar.Type="TOYOTA";
       // yourCar.LicenceNo="MDY-303";
        yourCar.Drive();
        Console.WriteLine(yourCar);
        Car c=new Car("SUSI","YGN-410",303);
        c.Drive();
        Console.WriteLine(c);
        c.PlayHorn();//T
        c.PlayHorn(3);//TTT

        Console.WriteLine(Utility.Day);//SUNDAY
        Utility.Now();
    }
}
