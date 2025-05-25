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
            LoadReservationData();
           
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
                }
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
    }
}



