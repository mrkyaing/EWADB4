using System;
namespace AJAXTest.Models
{
    public class OrderModel
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderedAt { get; }=DateTime.Now;
        public decimal TotalCost {get;set;}

        
    }
}