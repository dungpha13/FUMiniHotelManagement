using DataAccessObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dungphase172122WPF
{
    /// <summary>
    /// Interaction logic for AddEditRoomDialog.xaml
    /// </summary>
    public partial class AddEditRoomDialog : Window
    {
        public RoomDTO Room { get; private set; }

        public AddEditRoomDialog(RoomDTO room = null)
        {
            InitializeComponent();
            if (room != null)
            {
                Room = room;
                txtRoomNumber.Text = room.RoomNumber;
                txtDescription.Text = room.RoomDetailDescription;
                txtMaxCapacity.Text = room.RoomMaxCapacity.ToString();
                txtStatus.Text = room.RoomStatus.ToString();
                txtPrice.Text = room.RoomPricePerDay.ToString();
                txtType.Text = room.RoomType;
            }
            else
            {
                Room = new RoomDTO();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRoomNumber.Text) &&
                !string.IsNullOrEmpty(txtDescription.Text) &&
                !string.IsNullOrEmpty(txtMaxCapacity.Text) &&
                !string.IsNullOrEmpty(txtStatus.Text) &&
                !string.IsNullOrEmpty(txtPrice.Text) &&
                !string.IsNullOrEmpty(txtType.Text))
            {
                // All text fields are not null or empty, proceed with assigning values
                Room.RoomNumber = txtRoomNumber.Text;
                Room.RoomDetailDescription = txtDescription.Text;
                Room.RoomMaxCapacity = int.Parse(txtMaxCapacity.Text);
                Room.RoomStatus = txtStatus.Text;
                Room.RoomPricePerDay = decimal.Parse(txtPrice.Text);
                Room.RoomType = txtType.Text;

                DialogResult = true;
                Close();
            }
            else
            {
                // Show a message indicating that all fields are required
                //MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
