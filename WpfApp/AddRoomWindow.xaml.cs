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
    /// Interaction logic for UpdateRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        private IRoomTypeRepository _roomTypeRepository = new RoomTypeRepository();
        public AddRoomWindow()
        {
            InitializeComponent();
            ComboBox.ItemsSource = _roomTypeRepository.GetRoomTypes();
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
    }
}
