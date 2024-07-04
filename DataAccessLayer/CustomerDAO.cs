using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO : SingletonBase<CustomerDAO>
    {
        Customer CurrentCustomer = new Customer();
        List<Customer> list = new List<Customer>()
            {
                new Customer
                {
                    CustomerID = 1,
                    CustomerFullName = "John Doe",
                    Telephone = "1234567890",
                    EmailAddress = "john.doe@example.com",
                    CustomerBirthday = new DateTime(1990, 1, 1),
                    CustomerStatus = CustomerStatus.Active,
                    Password = "password123"
                },
                new Customer
                {
                    CustomerID = 2,
                    CustomerFullName = "Jane Smith",
                    Telephone = "0987654321",
                    EmailAddress = "jane.smith@example.com",
                    CustomerBirthday = new DateTime(1985, 5, 15),
                    CustomerStatus = CustomerStatus.Active,
                    Password = "password456"
                },
                new Customer
                {
                    CustomerID = 3,
                    CustomerFullName = "Michael Johnson",
                    Telephone = "1231231234",
                    EmailAddress = "michael.johnson@example.com",
                    CustomerBirthday = new DateTime(1978, 8, 20),
                    CustomerStatus = CustomerStatus.Active,
                    Password = "password789"
                },
                new Customer
                {
                    CustomerID = 4,
                    CustomerFullName = "Emily Davis",
                    Telephone = "4564564567",
                    EmailAddress = "emily.davis@example.com",
                    CustomerBirthday = new DateTime(1995, 3, 10),
                    CustomerStatus = CustomerStatus.Active,
                    Password = "password101"
                },
                new Customer
                {
                    CustomerID = 5,
                    CustomerFullName = "William Brown",
                    Telephone = "7897897890",
                    EmailAddress = "william.brown@example.com",
                    CustomerBirthday = new DateTime(1982, 12, 25),
                    CustomerStatus = CustomerStatus.Active,
                    Password = "password102"
                },
                new Customer
                {
                    CustomerID = 6,
                    CustomerFullName = "Olivia Wilson",
                    Telephone = "1472583690",
                    EmailAddress = "olivia.wilson@example.com",
                    CustomerBirthday = new DateTime(1991, 6, 30),
                    CustomerStatus = CustomerStatus.Active,
                    Password = "password103"
                },
                new Customer
                {
                    CustomerID = 7,
                    CustomerFullName = "James Taylor",
                    Telephone = "3216549870",
                    EmailAddress = "james.taylor@example.com",
                    CustomerBirthday = new DateTime(1988, 11, 11),
                    CustomerStatus = CustomerStatus.Active,
                    Password = "password104"
                },
                new Customer
                {
                    CustomerID = 8,
                    CustomerFullName = "Isabella Anderson",
                    Telephone = "3692581470",
                    EmailAddress = "isabella.anderson@example.com",
                    CustomerBirthday = new DateTime(1993, 2, 20),
                    CustomerStatus = CustomerStatus.Active,
                    Password = "password105"
                },
                new Customer
                {
                    CustomerID = 9,
                    CustomerFullName = "Liam Thomas",
                    Telephone = "8529637410",
                    EmailAddress = "liam.thomas@example.com",
                    CustomerBirthday = new DateTime(1987, 4, 14),
                    CustomerStatus = CustomerStatus.Active,
                    Password = "password106"
                },
                new Customer
                {
                    CustomerID = 10,
                    CustomerFullName = "Sophia Martinez",
                    Telephone = "9637412580",
                    EmailAddress = "sophia.martinez@example.com",
                    CustomerBirthday = new DateTime(1992, 9, 19),
                    CustomerStatus = CustomerStatus.Active,
                    Password = "password107"
                }
            };

        public Customer GetCurrentCustomer()
        {
            return CurrentCustomer;
        }
        public List<Customer> GetCustomers()
        {
            
            return list;
        }

        public void AddCustomer (Customer customer)
        {
            list.Add(customer);
        }

        public void UpdateCurrentCustomer(Customer customer)
        {
            CurrentCustomer = customer;
        }
        public void UpdateCustomer (Customer customer)
        {
            foreach (var current in list.ToList()) {
                if (current.CustomerID == customer.CustomerID)
                {
                    current.CustomerFullName = customer.CustomerFullName;
                    current.Telephone = customer.Telephone;
                    current.EmailAddress = customer.EmailAddress;
                    current.CustomerBirthday = customer.CustomerBirthday;
                    current.CustomerStatus = customer.CustomerStatus;
                    current.Password = customer.Password;
                }
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            foreach (var current in list.ToList())
            {
                if (current.CustomerID == customer.CustomerID)
                {
                    list.Remove(current);
                }
            }
        }

        public Customer GetCustomerById (int id)
        {
            foreach (var current in list)
            {
                if (current.CustomerID == id)
                {
                    return current;
                }
               
            }
            return null;
        }

        public Customer GetCustomerByEmail (string email)
        {
            foreach (var current in list)
            {
                if (current.EmailAddress.Equals(email))
                {
                    CurrentCustomer = current;
                    return current;
                }
            }
            return null;
        }

        public int GetNewId ()
        {
            return list.Max(x => x.CustomerID) + 1;
        }
        
    }
}
