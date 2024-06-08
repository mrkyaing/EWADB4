using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day4
{
    public class Teacher
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Age");
                }
                age = value;
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private decimal trainingFees;
        public decimal TrainingFees
        {
            get { return trainingFees; }
            set { 
                if(value<0) {
                    throw new ArgumentException("Invalid Training Fees");
                }
                trainingFees = value; }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Name:{Name},Age:{Age},Address{Address},TrainingFees{TrainingFees}";
        }
    }
}