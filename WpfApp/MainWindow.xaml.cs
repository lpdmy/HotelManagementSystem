using Repositories;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string emailConfig = App.Configuration["AdminAccount:Email"];
        private string passwordConfig = App.Configuration["AdminAccount:Password"];
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUserName.Text;
            string password = txtPass.Password;

            // Fetch the customer by email
            var customer = _customerRepository.GetCustomerByEmail(email);

            if (customer != null && customer.Password == password)
            {
                MessageBox.Show("Login successful!");
                // Proceed to the next part of the application
            }
            else if (customer == null && emailConfig.Equals(txtUserName.Text))
            {
                //MessageBox.Show("Login admin successful!");
                this.Hide();
                Admin adminWindow = new Admin();
                adminWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }
    }
}

