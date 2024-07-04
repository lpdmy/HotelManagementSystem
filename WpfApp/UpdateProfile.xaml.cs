using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UpdateProfile.xaml
    /// </summary>
    public partial class UpdateProfile : Window
    {
        private ICustomerRepository _customerRepository = new CustomerRepository();
        public Customer Customer { get; set; } = new Customer();
        public UpdateProfile()
        {
            InitializeComponent();
            Customer = _customerRepository.GetCurrentCustomer();
            this.DataContext = Customer;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {



            var cus = new Customer()
            {
                CustomerStatus = Customer.CustomerStatus,
                CustomerBirthday = DateTime.Parse(txtDate.Text),
                CustomerFullName = txtFullName.Text,
                CustomerID = Customer.CustomerID,
                EmailAddress = txtEmail.Text,
                Password = txtPassword.Text,
                Telephone = txtTelephone.Text,
            };
            _customerRepository.UpdateCustomer(
                 cus
                 );
            _customerRepository.UpdateCurrentCustomer(cus);

            this.Close();
            MessageBox.Show("Customer information updated successfully!");

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
