using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day5
{
    public class Dog:Animal
    {
        public Dog(string a):base(a){
        
        }
        public override void Sound()
        {
            Console.WriteLine($"{base.Name} Woak..Woak .Woak.");
        }
    }
}