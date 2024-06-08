using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day5
{
    public class Cat:Animal
    {
        public override void Sound()
        {
           Console.WriteLine($"{base.Name} is making as Meow..Meow.Meow.");
        }
    }
}