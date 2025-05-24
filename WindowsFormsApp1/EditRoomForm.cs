using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EditRoomForm : Form
    {
        private int _roomId;
        //temp
        public EditRoomForm(int roomId)
        {
            InitializeComponent();
            _roomId = roomId;
            nudPricePerNight.Maximum = 10000;

            LoadRoomData();
        }
        private void LoadRoomData()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var room = db.Rooms.Find(_roomId);
                if (room != null)
                {
                    cbRoomStatus.Text = room.RoomStatus;
                    tbDescription.Text = room.Description;
                    nudPricePerNight.Value = room.PricePerNight ?? 0;
                    cbRoomType.Text = room.RoomType;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            using (var db = new HotelManagementSystemEntities1())
            {
                var room = db.Rooms.Find(_roomId);
                if (room != null)
                {
                    room.RoomStatus = cbRoomStatus.Text.Trim();
                    room.Description = tbDescription.Text.Trim();
                    room.PricePerNight = nudPricePerNight.Value;
                    room.RoomType = cbRoomType.Text.Trim();

                    db.SaveChanges();
                    MessageBox.Show("Room updated successfully!");
                    this.Close();
                }
            }
        }
    }
}
