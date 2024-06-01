
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
    }
}
