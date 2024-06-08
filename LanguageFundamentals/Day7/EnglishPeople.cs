using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day7
{
    public class EnglishPeople : SayHello
    {
        //follow the enforce detail implemention process here because contract between English and SayHello
        public override void AboutMe()
        {
             Console.WriteLine("I am English.");
        }

        public override void SayGreetingMessage()
        {
           Console.WriteLine("Hello,Nice to see you");
        }

        public override void WorkDo()
        {
           Console.WriteLine("doing work at "+base.Address);
        }
         
    }
}