using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void DeleteCustomer(Customer customer)
        {
            CustomerDAO.Instance.DeleteCustomer(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return CustomerDAO.Instance.GetCustomerById(id);
        }

        public List<Customer> GetCustomers()
        {
            return CustomerDAO.Instance.GetCustomers();
        }

        public void SaveCustomer(Customer customer)
        {
            CustomerDAO.Instance.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            CustomerDAO.Instance.UpdateCustomer(customer);
        }

        public Customer GetCustomerByEmail (string email)
        {
            return CustomerDAO.Instance.GetCustomerByEmail(email);
        }

        public int GetNewId()
        {
            return CustomerDAO.Instance.GetNewId();
        }

        public Customer GetCurrentCustomer()
        {
            return CustomerDAO.Instance.GetCurrentCustomer();
        }

        public void UpdateCurrentCustomer(Customer customer)
        {
            CustomerDAO.Instance.UpdateCustomer(customer);
        }
    }
}
