using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day4
{
    public class Student
    {
        private string Name;
        private int Age;
        private string Email;
        private string Address;
        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetAge(int age)
        {
            //data validation /protection in here 
            if (age < 0)
            {
                throw new ArgumentException("Invalid Age");
            }
            this.Age = age;
        }
        public void SetEmail(string email)
        {
            if (!email.Contains("@"))
            {
                throw new ArgumentException("Invalid email address");
            }
            this.Email = email;
        }
        public void SetAddress(string address)
        {
            this.Address = address;
        }
        public override string ToString()
        {
            return $"Name:{Name},Age:{Age},Address{Address}";
        }
    }
}