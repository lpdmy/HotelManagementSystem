using BusinessObjects;
using Repositories;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UpdateRoomWindow.xaml
    /// </summary>
    public partial class UpdateRoomWindow : Window
    {
        private int roomID;
        private IRoomTypeRepository _roomTypeRepository = new RoomTypeRepository();
        private IRoomInformationRepository _roomInformationRepository = new RoomInfomationRepository();
        public UpdateRoomWindow(int roomId)
        {
            InitializeComponent();
            this.roomID = roomId;

            var r = _roomInformationRepository.GetRoomInformationById(roomID);
            this.DataContext = r;
            ComboBox.ItemsSource = _roomTypeRepository.GetRoomTypes();
            ComboStatus.ItemsSource = Enum.GetNames(typeof(RoomStatus));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change here
            if (ComboBox.SelectedItem != null)
            {
                RoomType selectedRoomType = (RoomType)ComboBox.SelectedItem;
                MessageBox.Show($"Selected Room Type: {selectedRoomType.RoomTypeName}");
            }
        }

        private void ComboBox_SelectionChangedStatus(object sender, SelectionChangedEventArgs e)
        {
            if (ComboStatus.SelectedItem != null)
            {
                // Lấy chuỗi đại diện cho enum từ ComboBox
                string selectedStatusString = ComboStatus.SelectedItem.ToString();

                // Chuyển đổi chuỗi thành enum RoomStatus
                if (Enum.TryParse(selectedStatusString, out RoomStatus selectedStatus))
                {
                    MessageBox.Show($"Selected Room Status Enum: {selectedStatus}");
                    // Bạn có thể sử dụng giá trị enum selectedStatus ở đây
                }

            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            RoomType selectedRoomType = (RoomType)ComboBox.SelectedItem;

            if (ComboStatus.SelectedItem != null)
            {
                string selectedStatusString = ComboStatus.SelectedItem.ToString();

                if (Enum.TryParse(selectedStatusString, out RoomStatus selectedStatus))
                {
                    RoomInformation room = new RoomInformation()
                    {
                        RoomStatus = selectedStatus,
                        RoomType = selectedRoomType,
                        RoomTypeID = selectedRoomType.RoomTypeID,
                        RoomID = roomID,
                        RoomDescription = txtRoomDesc.Text,
                        RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text),
                        RoomNumber = txtRoomNumber.Text,
                        RoomPricePerDate = decimal.Parse(txtRoomPrice.Text),
                    };
                    _roomInformationRepository.UpdateRoomInformation(
                         room
                         );


                    MessageBox.Show("Room information updated successfully!");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Invalid room status selected.");
                }
            }
            else
            {
                MessageBox.Show("Please select a room status.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
