using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day6
{
    public class Human:Mammal
    {
        public string BlodType { get; set; }
        public string IdCard { get; set; }
        public string Occupitition { get; set; }
        public override void Sound()
        {
           Console.WriteLine($"Hello,Nice to see you , I am {base.Name}");
        }

        public void DoWork(){
             Console.WriteLine($"I am {base.Name} {Occupitition}");
        }

        public override string ToString()
        {
            return $"{base.ToString()},{BlodType},{IdCard},{Occupitition}";
        }
    }
}