using BusinessObjects;
using DataAccessObjects.DTO;
using DataAccessObjects.DTO.Request;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interface;
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

namespace Dungphase172122WPF
{
    /// <summary>
    /// Interaction logic for AddEditBookingDialog.xaml
    /// </summary>
    public partial class AddEditBookingDialog : Window
    {
        private readonly IRoomService _service;
        public BookingDTO Booking { get; private set; }
        public Customer Customer { get; set; }
        private RoomDTO room { get; set; }

        public AddEditBookingDialog()
        {
            InitializeComponent();
            _service = ((App)Application.Current).ServiceProvider.GetRequiredService<IRoomService>() ?? throw new ArgumentNullException(nameof(RoomService));

            Booking = new BookingDTO();
            Loaded += LoadRoom;
        }

        private void LoadRoom(object sender, RoutedEventArgs e)
        {
            var data = _service.GetRooms(r => r.RoomStatus != 1);
            dgAvailableRooms.ItemsSource = data;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void dgAvailableRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAvailableRooms.SelectedItems.Count > 0)
            {
                room = (RoomDTO)dgAvailableRooms.SelectedItem;
                txtRoomId.Text = room.RoomId.ToString();
                txtRoomNumber.Text = room.RoomNumber;
                txtNumPerson.Text = room.RoomMaxCapacity.ToString();
                txtPrice.Text = room.RoomPricePerDay.ToString();
            }
        }

        private void dpDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.HasValue)
            {
                DateTime startDate = dpStartDate.SelectedDate.Value;
                DateTime endDate = dpEndDate.SelectedDate.Value;

                int daysDifference = (endDate - startDate).Days;
                var TotalPrice = (daysDifference * room.RoomPricePerDay);
                txtTotalPrice.Text = TotalPrice.ToString();

                if (startDate < DateTime.Today || endDate < DateTime.Today)
                {
                    txtTotalPrice.Text = "0";
                }
            }
        }
    }
}
