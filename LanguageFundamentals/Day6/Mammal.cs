using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day6
{
    public class Mammal
    {
        public string Name { get; set; }
        public int LifeSpan { get; set; }
        public string Type { get; set; }

        public virtual void Sound()
        {
            Console.WriteLine($"Hello,{Name}");
        }

        public override string ToString()
        {
            return $"{Name},{LifeSpan},{Type}";
        }
    }
}