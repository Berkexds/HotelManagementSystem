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
    public partial class RoomControl : UserControl
    {
        public RoomControl()
        {
            InitializeComponent();
            LoadRoomData();
        }

        private void LoadRoomData()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var data = db.Rooms
                    .Select(r => new
                    {
                        r.RoomID,
                        r.RoomStatus,
                        r.Description,
                        r.PricePerNight,
                        r.RoomType
                    })
                    .ToList();

                dgvRoom.DataSource = data;
                if (!dgvRoom.Columns.Contains("Edit"))
                {
                    dgvRoom.Columns.Add(new DataGridViewButtonColumn
                    {
                        HeaderText = "",
                        Name = "Edit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    });

                    dgvRoom.Columns.Add(new DataGridViewButtonColumn
                    {
                        HeaderText = "",
                        Name = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    });
                }

                dgvRoom.ReadOnly = true;
                dgvRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int roomId = Convert.ToInt32(dgvRoom.Rows[e.RowIndex].Cells["RoomID"].Value);
            string columnName = dgvRoom.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                var form = new EditRoomForm(roomId);
                form.ShowDialog();
                LoadRoomData(); // Refresh the table after editing
            }
            else if (columnName == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this room?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (var db = new HotelManagementSystemEntities1())
                    {
                        var room = db.Rooms.Find(roomId);
                        if (room != null)
                        {
                            db.Rooms.Remove(room);
                            db.SaveChanges();
                            LoadRoomData(); // refresh
                        }
                    }
                }
            }
        }
    }
}
