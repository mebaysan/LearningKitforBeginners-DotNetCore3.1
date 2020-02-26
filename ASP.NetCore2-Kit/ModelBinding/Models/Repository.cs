using System.Collections.Generic;
using System.Linq;

namespace ModelBinding.Models
{
    public interface IRepository
    {
        List<Customer> Customers { get; }
        Customer Get(int customerId);
    }
    public class Repository : IRepository
    {
        private List<Customer> _customers;
        public Repository()
        {
            _customers = new List<Customer>(){
                new Customer(){CustomerId=1,FirstName="Ali",LastName="Xyz"},
                new Customer(){CustomerId=2,FirstName="Enes",LastName="Xyz"},
                new Customer(){CustomerId=3,FirstName="Yusuf",LastName="Xyz"},
                new Customer(){CustomerId=4,FirstName="Yavuz",LastName="Xyz"},
                new Customer(){CustomerId=5,FirstName="Ahmet",LastName="Xyz"}
            };
        }

        public List<Customer> Customers => _customers;

        public Customer Get(int customerId) =>
            _customers.FirstOrDefault(i => i.CustomerId == customerId);

    }
}