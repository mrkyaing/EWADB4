namespace LanguageFundamentals;
using System;
class Program
{
    static void Main(string[] args)
    {
       int i=10;// primitive data type 
       Console.WriteLine(i);//10 
       Employee e=new Employee();//reference data type 
       e.Age=20;
       e.Name="Mg Mg";
       e.SayHello();
       if(e.Age>18){
        Console.WriteLine("You are mature");
       }
       else {
        Console.WriteLine("You are not mature.");
       }
       switch(i){
        case 10:Console.WriteLine("This is 10");break;
        case 1:Console.WriteLine("This is 1");break;
        default:Console.WriteLine("Nothings");break;
       }
    }
}
public class Employee{
    public int Age;
    public string Name;
    public void SayHello(){
        Console.WriteLine("Hello,My name is "+Name+". I am "+Age+" years old.");
    }
}
