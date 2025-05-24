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
    public partial class EditReservationForm : Form
    {
        private int reservationId;
        public EditReservationForm(int id)
        {
            InitializeComponent();
            reservationId = id;
            LoadReservation();
        }
        private void LoadReservation()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var reservation = db.Reservations.Find(reservationId);
                if (reservation == null) return;

                cbStatus.Text = reservation.ReservationStatus;
                nudPeople.Value = reservation.NumberOfPeople ?? 1;
                dtDate.Value = reservation.Date ?? DateTime.Today;

                // .ToString() because combo box items are strings
                cbRoom.SelectedItem = reservation.RoomID.ToString();
                cbCustomer.SelectedItem = reservation.CustomerID.ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var reservation = db.Reservations.Find(reservationId);
                if (reservation != null)
                {
                    reservation.ReservationStatus = cbStatus.Text;
                    reservation.NumberOfPeople = (int)nudPeople.Value;
                    reservation.Date = dtDate.Value;
                    reservation.RoomID = Convert.ToInt32(cbRoom.SelectedItem);
                    reservation.CustomerID = Convert.ToInt32(cbCustomer.SelectedItem);

                    db.SaveChanges();
                    MessageBox.Show("Reservation updated successfully!");
                    this.Close();
                }
            }
        }
    }
}
    

