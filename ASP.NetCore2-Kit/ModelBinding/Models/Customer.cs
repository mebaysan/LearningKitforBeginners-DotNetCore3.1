using System;

namespace ModelBinding.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public Role Role { get; set; }
    }
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    public enum Role
    {
        Admin,
        User,
        Member
    }
}