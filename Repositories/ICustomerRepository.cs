using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        void SaveCustomer(Customer customer);
        void DeleteCustomer (Customer customer);
        void UpdateCustomer (Customer customer);
        Customer GetCustomerById (int id);
        Customer GetCustomerByEmail(string email);

    }
}
