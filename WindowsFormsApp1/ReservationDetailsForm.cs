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
    public partial class ReservationDetailsForm : Form
    {
        private int ReservationID;
        public ReservationDetailsForm(int id)
        {
            InitializeComponent();
            ReservationID = id;
            LoadReservationDetails();
        }
        private void LoadReservationDetails()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var reservation = db.Reservations.Find(ReservationID);
                if (reservation != null)
                {
                    lblResIDValue.Text = reservation.ReservationID.ToString();
                    lblStatusValue.Text = reservation.ReservationStatus;
                    lblPeopleValue.Text = reservation.NumberOfPeople?.ToString();
                    lblDateValue.Text = reservation.Date?.ToString("yyyy-MM-dd");
                    lblRoomValue.Text = reservation.RoomID?.ToString();
                    lblCustomerValue.Text = reservation.CustomerID?.ToString();
                }
            }
        }
        private void lblCustomerValue_Click(object sender, EventArgs e)
        {

        }
    }
}
