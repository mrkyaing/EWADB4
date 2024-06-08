using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day5
{
    public class Animal
    {
     public string Name { get; set; }
     public string Type { get; set; }
     public double LifeSpan { get; set; }
    
    public Animal(string a){
        
    }
     public  void Eat(){
        Console.WriteLine($"{Name} is eating..");
     }
     public  void Sleep(){
        Console.WriteLine($"{Name} is sleeping..");
     }
      public virtual void Sound(){
        Console.WriteLine($"{Name} is making sound..");
     }
        public override string ToString()
        {
            return $"Name{Name},Type{Type}";
        }
    }
}