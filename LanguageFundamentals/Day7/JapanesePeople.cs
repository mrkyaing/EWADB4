using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day7
{
    public class JapanesePeople : SayHello
    {
        public override void AboutMe()
        {
             Console.WriteLine("I am Japanese.");
        }

        public override void SayGreetingMessage()
        {
           Console.WriteLine("Kohni ,shi wah");
        }

        public override void WorkDo()
        {
            Console.WriteLine("doing work");
        }
        
    }
}