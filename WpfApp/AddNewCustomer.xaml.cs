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
    /// Interaction logic for AddNewCustomer.xaml
    /// </summary>
    public partial class AddNewCustomer : Window
    {
        private ICustomerRepository _customerRepository = new CustomerRepository();
        public AddNewCustomer()
        {
            InitializeComponent();
            ComboStatus.ItemsSource = Enum.GetNames(typeof(CustomerStatus));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
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
                        CustomerID = _customerRepository.GetNewId(),
                        EmailAddress = txtEmail.Text,
                        Password = txtPassword.Text,
                        Telephone = txtTelephone.Text,
                    };
                    _customerRepository.SaveCustomer(
                        cus
                        );
                    MessageBox.Show("Customer information added successfully!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid customer status selected.");
            };
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
                    //MessageBox.Show($"Selected Customer Status Enum: {selectedStatus}");
                }

            }
        }
    }
}
