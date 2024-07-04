using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class CustomerWindow : Window, INotifyPropertyChanged
    {
        private ICustomerRepository _customerRepository = new CustomerRepository();
        private IBookingReservationRepository _bookingReservationRepository = new BookingReservationRepository();
        private IBookingDetailRepository _bookingDetailRepository = new BookingDetailRepository();
        private IRoomInformationRepository _roomInformationRepository = new RoomInfomationRepository();
        
        private List<RoomInformation> _roomLists;
        public List<RoomInformation> RoomLists
        {
            get { return _roomLists; }
            set
            {
                _roomLists = value;
                OnPropertyChanged(nameof(RoomLists));
            }
        }

        private RoomInformation _selectedRoom;
        public RoomInformation SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                if (_selectedRoom != value)
                {
                    _selectedRoom = value;
                    OnPropertyChanged(nameof(SelectedRoom));

                    if (_selectedRoom != null)
                    {
                        RoomPricePerDate = _selectedRoom.RoomPricePerDate;
                    }
                }
            }
        }


        private decimal _roomPricePerDate;
        public decimal RoomPricePerDate
        {
            get { return _roomPricePerDate; }
            set
            {
                if (_roomPricePerDate != value)
                {
                    _roomPricePerDate = value;
                    OnPropertyChanged(nameof(RoomPricePerDate));
                    CalculateActualPrice(); // Recalculate ActualPrice when RoomPricePerDate changes

                    if (SelectedRoom != null)
                    {
                        SelectedRoom.RoomPricePerDate = _roomPricePerDate;
                        OnPropertyChanged(nameof(SelectedRoom)); // Notify SelectedRoom change
                    }
                }
            }
        }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        private DateTime _startTime = DateTime.Now;
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
                CalculateActualPrice(); // Recalculate ActualPrice when StartTime changes
            }
        }

        private DateTime _endTime = DateTime.Now;
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
                CalculateActualPrice(); // Recalculate ActualPrice when EndTime changes
            }
        }
        private decimal _actualPrice = 0;
        public decimal ActualPrice
        {
            get => _actualPrice;
            set
            {
                _actualPrice = value;
                OnPropertyChanged(nameof(ActualPrice));
                CalculateTotalPrice();
            }
        }

        private decimal _totalPrice = 0;
        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
        private void CalculateActualPrice()
        {
            int days = (EndTime.Date - StartTime.Date).Days + 1;
            ActualPrice = RoomPricePerDate * days;
        }

        private void CalculateTotalPrice()
        {
            decimal taxRate = 0.08m; 
            TotalPrice = ActualPrice * (1 + taxRate);
        }

        public CustomerWindow()
        {
            InitializeComponent();
            DataContext = this;

            BindCustomer();
            RoomLists = _roomInformationRepository.GetRoomInformations();

            cbRoom.ItemsSource = RoomLists;
            cbRoom.DisplayMemberPath = "RoomNumber";
            BindBookingDetails();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BindCustomer()
        {
            Customer = _customerRepository.GetCurrentCustomer();
        }

        private void BindBookingDetails()
        {
            dtBookingDetails.ItemsSource = _bookingDetailRepository.GetBookingDetails(Customer.CustomerID);
            dtBookingDetails.Items.Refresh();

        }


        private void cbRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedRoom = cbRoom.SelectedItem as RoomInformation;
        }

        private void  ButtonBook_Click(object sender, RoutedEventArgs e)
        {
            BookingReservation bookingReservation = new BookingReservation()
            {
                BookingDate = DateTime.Now,
                TotalPrice = Decimal.Parse(txtTotalPrice.Text),
                BookingReservationID = 0,
                BookingStatus = BookingStatus.Pending,
                CustomerID = Customer.CustomerID,
                Customer = Customer,
            };
            var newBookingReservation = _bookingReservationRepository.AddReservation(bookingReservation);
            var list = _bookingReservationRepository.GetAllReservations();
            BookingDetail bookingDetail = new BookingDetail()
            {
                ActualPrice = Decimal.Parse(txtActualPrice.Text),
                BookingReservation = newBookingReservation,
                BookingReservationID = newBookingReservation.BookingReservationID,
                EndDate = DateTime.Parse(txtEndDate.Text),
                RoomID = SelectedRoom.RoomID,
                RoomInformation = SelectedRoom,
                StartDate = DateTime.Parse(txtStartDate.Text),
            };
            _bookingDetailRepository.AddBookingDetail(bookingDetail);
            var list1 = _bookingDetailRepository.GetAllBookingDetails();

            MessageBox.Show("Book room successfully, waiting for admin to confirm your booking");
            BindBookingDetails();
        }

      

        private void ButtonLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            UpdateProfile updateWindow = new UpdateProfile();
            updateWindow.Owner = Window.GetWindow(this);
            updateWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            updateWindow.Closed += (s, args) =>
            {
                BindCustomer();

            };

            updateWindow.ShowDialog();
        }
    }
}

