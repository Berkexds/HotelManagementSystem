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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class ReservationControl : UserControl
    {
        private string userTitle;
        public ReservationControl(string title)
        {
            InitializeComponent();
            userTitle = title;
            dgvReservation.CellContentClick += dgvReservation_CellContentClick;
            dgvReservation.ColumnHeaderMouseClick += dgvReservation_ColumnHeaderMouseClick; ;
            textBox1.TextChanged += textBox1_TextChanged;
            LoadReservationData();

        }

        private void dgvReservation_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String columnName = dgvReservation.Columns[e.ColumnIndex].Name;


            using (var db = new HotelManagementSystemEntities1())
            {
                switch (columnName)
                {
                    case "ReservationStatus":
                        dgvReservation.DataSource = db.Reservations
                        .OrderBy(r => r.ReservationStatus)
                        .Select(r => new
                        {
                            r.ReservationID,
                            Customer = r.Customer.Name,
                            Room = r.Room.RoomID,
                            r.Date,
                            r.ReservationStatus,
                            r.NumberOfPeople
                        }).ToList();
                        break;
                    case "NumberOfPeople":
                        dgvReservation.DataSource = db.Reservations
                        .OrderBy(x => x.NumberOfPeople)
                        .Select(r => new
                        {
                            r.ReservationID,
                            Customer = r.Customer.Name,
                            Room = r.Room.RoomID,
                            r.Date,
                            r.ReservationStatus,
                            r.NumberOfPeople
                        }).ToList();
                        break;
                    case "Date":
                        dgvReservation.DataSource = db.Reservations
                        .OrderBy(x => x.Date)
                        .Select(r => new
                        {
                            r.ReservationID,
                            Customer = r.Customer.Name,
                            Room = r.Room.RoomID,
                            r.Date,
                            r.ReservationStatus,
                            r.NumberOfPeople
                        }).ToList();
                        break;
                    case "Room":
                        dgvReservation.DataSource = db.Reservations
                        .OrderBy(x => x.RoomID)
                        .Select(r => new
                        {
                            r.ReservationID,
                            Customer = r.Customer.Name,
                            Room = r.Room.RoomID,
                            r.Date,
                            r.ReservationStatus,
                            r.NumberOfPeople
                        }).ToList();
                        break;
                    case "Customer":
                        dgvReservation.DataSource = db.Reservations
                        .OrderBy(x => x.CustomerID)
                        .Select(r => new
                        {
                            r.ReservationID,
                            Customer = r.Customer.Name,
                            Room = r.Room.RoomID,
                            r.Date,
                            r.ReservationStatus,
                            r.NumberOfPeople
                        }).ToList();
                        break;
                    default:
                        dgvReservation.DataSource = db.Reservations
                        .OrderBy(x => x.ReservationID)
                        .Select(r => new
                        {
                            r.ReservationID,
                            Customer = r.Customer.Name,
                            Room = r.Room.RoomID,
                            r.Date,
                            r.ReservationStatus,
                            r.NumberOfPeople
                        }).ToList();
                        break;

                }

            }
        }

        private void LoadReservationData()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var data = db.Reservations.Select(r => new
                {
                    r.ReservationID,
                    Customer = r.Customer.Name,
                    Room = r.Room.RoomID,
                    r.Date,
                    r.ReservationStatus,
                    r.NumberOfPeople
                }).ToList();
                dgvReservation.Columns.Clear();
                dgvReservation.DataSource = data;


                if (userTitle == "Manager")
                {
                    dgvReservation.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    });

                    dgvReservation.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Details",
                        Text = "Details",
                        UseColumnTextForButtonValue = true
                    });

                    dgvReservation.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    });

                    tableLayoutPanel1.Controls.Add(dgvReservation, 0, 1);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = textBox1.Text.ToLower();

            using (var db = new HotelManagementSystemEntities1())
            {
                var result = db.Reservations.Where(r =>
                r.Customer.Name.ToLower().Contains(query) ||
                r.ReservationStatus.ToLower().Contains(query) ||
                r.NumberOfPeople.ToString().Contains(query) ||
                r.Room.RoomID.ToString().ToLower().Contains(query) ||
                r.Date.ToString().Contains(query))
                .Select(r => new
                {
                    r.ReservationID,
                    Customer = r.Customer.Name,
                    Room = r.Room.RoomID,
                    r.Date,
                    r.ReservationStatus,
                    r.NumberOfPeople
                }).ToList();

                dgvReservation.DataSource = result;
            }
        }

        private bool detailsFormOpen = false;
        private void dgvReservation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvReservation.Columns[e.ColumnIndex].Name;
                int reservationId = Convert.ToInt32(dgvReservation.Rows[e.RowIndex].Cells["ReservationID"].Value);

                if (columnName == "Details")
                {
                    if (detailsFormOpen) return; // ❌ Skip if already open
                    detailsFormOpen = true;

                    var form = new ReservationDetailsForm(reservationId);
                    form.FormClosed += (s, args) => detailsFormOpen = false; // ✅ Reset flag on close
                    form.Show();
                }
                else if (columnName == "Edit")
                {
                    new EditReservationForm(reservationId).ShowDialog();
                    LoadReservationData();
                }
                else if (columnName == "Delete")
                {
                    using (var db = new HotelManagementSystemEntities1())
                    {
                        var res = db.Reservations.Find(reservationId);
                        res.Room.RoomStatus = "Available";
                        if (res != null)
                        {
                            db.Reservations.Remove(res);
                            db.SaveChanges();
                            LoadReservationData();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddReservationForm aRF = new AddReservationForm();
            aRF.ShowDialog();
        }
    }
}



