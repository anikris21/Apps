using System.Collections;
using System.Collections.ObjectModel;
using MetricsAppAPI.Model;
namespace MetricsAppAPI.Services
{
    public class CustomerService
    {
        int _id = 4;
        // mock database Id=2,
        IList<Customer> customerDb = new List<Customer>() { 
            new Customer { Id=1, FirstName = "Lee", LastName = "Mac", Email = "leemac@metricsapp.com" },
            new Customer {Id=2, FirstName = "Ram", LastName = "kumar", Email = "ram@metricsapp.com" },
            new Customer {Id=3, FirstName = "Ravi", LastName = "Pb", Email = "ravi@metricsapp.com" }
        };

        public Task<Customer> CreateAsync(Customer c1)
        {

            if (customerDb.Any(c => c.Id == c1.Id)) { 
                return Task.FromResult<Customer>(null); 
            }
            
            c1.Id = _id++; 
            customerDb.Add(c1);
            return Task.FromResult(c1);
        }

        public Task<Customer?> GetById(int Id)
        {
            if (customerDb.Any(c => c.Id == Id))
                return Task.FromResult(customerDb.First(c1 => c1.Id == Id));
            return Task.FromResult<Customer>(null);
        }

        void Test(IList<Customer> list) { }

        // ReadOnlyCollection
        public Task<ReadOnlyCollection<Customer>> GetAllAsync() {
            // Test(customerDb.AsReadOnly())
            return Task.FromResult<ReadOnlyCollection<Customer>>(customerDb.AsReadOnly()); 
        }



    }
}
