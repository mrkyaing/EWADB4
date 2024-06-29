using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BindingPractice.Models
{
    public class AddressModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Township { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
    }
}