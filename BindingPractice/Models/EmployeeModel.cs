namespace BindingPractice.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //Has-A Relationship
        public AddressModel HomeAddress { get; set; }
    }
}