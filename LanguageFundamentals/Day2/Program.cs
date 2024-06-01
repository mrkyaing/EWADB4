namespace Day2;
using System;
class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 121, 22, 33 };
        foreach (int i in numbers)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine($"Even:{i}");//string interpolation style 
            }
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }


        int j = 0;
        while (j < numbers.Length)
        {
            Console.WriteLine(numbers[j]);
            j++;
        }
        long result = (1 + 3) / 7 * (3 - 1);
        Console.Write("Result" + result);

        if (result == 0)
        {
            goto Okay;
        }
    Okay:
        {
            Console.WriteLine("Hi");
        }
        try
        {
            Person p = new Person();
            p.Age = -10;
            p.SayHello();
        }
        catch (Exception e)
        {
            Console.WriteLine("error" + e.Message);
        }
    }
}
public class Person
{
    public int Age;

    public void setAge(int age)
    {
        if (age<0)
        {
            throw new Exception("Invalid age");
        }
        else{
        this.Age = age;
        }  
    }

    public void SayHello()
    {
        Console.WriteLine($"I am {Age} years old.");
    }
}
