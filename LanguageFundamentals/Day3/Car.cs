using System;
namespace Day3
{   
    public class Car
    {
        //declare the variable state of car class
        //field ,state,instance variable 
        public int Speed;
        public string LicenceNo;
        public string Type;
        //it can be called construtor overloading 
        //compile time  polymprphsim
        //no argument constructor
        public Car(){

        }
        //construtor with 2 arguments
        public Car(string type,string licenceNo){
            this.LicenceNo=licenceNo;
            this.Type=type;
        }
      //construtor with 3 arguments
         public Car(string type,string licenceNo,int speed){//7
            this.LicenceNo=licenceNo;
            this.Type=type;
            this.Speed=speed;
        }
        //behavior of Car class 
        public void Drive(){
            Console.WriteLine("Start the Engine");
        }
         //runtime polymorphism 
        public override string ToString()
        {
            return $"Car info : \n Type:{Type},LicenceNo:{LicenceNo},Speed:{Speed}";
        }
        //method overloading 
        public void PlayHorn()=>Console.WriteLine("T");
        //method overloading 
        public void PlayHorn(int count){
            for(int i=1;i<=count;i++){
               Console.WriteLine("T"); 
            }
        }
    }
}