using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day7
{
    public abstract class SayHello
    {
        public string Name { get; set; }
        public string Address { get; set; }
       
         //abstraction process here because say What 
         public abstract void SayGreetingMessage();
         public abstract void AboutMe();
         public abstract void WorkDo();

        public void DisplayInfo(){
            Console.WriteLine ($"{Name} live in at {Address}");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}