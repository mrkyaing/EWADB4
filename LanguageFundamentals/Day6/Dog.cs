using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day6
{
    public class Dog:Mammal
    {
        public override void Sound()
        {
           Console.WriteLine("Woak.Woak.Woak");
        }
    }
}