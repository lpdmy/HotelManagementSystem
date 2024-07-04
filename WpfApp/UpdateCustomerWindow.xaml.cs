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
    /// Interaction logic for UpdateCustomerWindow.xaml
    /// </summary>
    public partial class UpdateCustomerWindow : Window
    {
        private ICustomerRepository _customerRepository = new CustomerRepository();
        private int customerID;
        public UpdateCustomerWindow(int customerId)
        {
            InitializeComponent();
            ComboStatus.ItemsSource = Enum.GetNames(typeof(CustomerStatus));
            this.customerID = customerId;
            var c = _customerRepository.GetCustomerById(customerId);
            this.DataContext = c;
            
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
           

            if (ComboStatus.SelectedItem != null)
            {
                string selectedStatusString = ComboStatus.SelectedItem.ToString();

                if (Enum.TryParse(selectedStatusString, out CustomerStatus selectedStatus))
                {
                    var cus = new Customer()
                    {
                        CustomerStatus = selectedStatus,
                        CustomerBirthday = DateTime.Parse(txtDate.Text),
                        CustomerFullName = txtFullName.Text,
                        CustomerID = customerID,
                        EmailAddress = txtEmail.Text,
                        Password = txtPassword.Text,
                        Telephone = txtTelephone.Text,
                    };
                    _customerRepository.UpdateCustomer(
                         cus
                         );


                    MessageBox.Show("Customer information updated successfully!");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Invalid Customer status selected.");
                }
            }
            else
            {
                MessageBox.Show("Please select a customer status.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChangedStatus(object sender, SelectionChangedEventArgs e)
        {
            if (ComboStatus.SelectedItem != null)
            {
                string selectedStatusString = ComboStatus.SelectedItem.ToString();
                if (Enum.TryParse(selectedStatusString, out CustomerStatus selectedStatus))
                {
                    MessageBox.Show($"Selected Customer Status Enum: {selectedStatus}");
                }

            }
        }
    }
}
