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
            LoadRoomCombo();
            LoadCustomerCombo();
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

        private void LoadRoomCombo()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var roomList = db.Rooms
                    .Select(r => new
                    {
                        RoomID = r.RoomID,
                        DisplayText = "Room " + r.RoomID
                    })
                    .ToList();

                cbRoom.DataSource = roomList;
                cbRoom.DisplayMember = "DisplayText";  // kullanıcıya gösterilen
                cbRoom.ValueMember = "RoomID";         // arka planda tutulan ID
            }
        }

        private void LoadCustomerCombo()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var customerList = db.Customers
                    .Select(c => new
                    {
                        CustomerID = c.CustomerID,
                        DisplayText = c.Name // veya $"{c.Name} (ID: {c.CustomerID})"
                    })
                    .ToList();

                cbCustomer.DataSource = customerList;
                cbCustomer.DisplayMember = "DisplayText";
                cbCustomer.ValueMember = "CustomerID";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var reservation = db.Reservations.Find(reservationId);
                if (reservation == null)
                {
                    MessageBox.Show("Rezervasyon bulunamadı.");
                    return;
                }

                // Seçilen RoomID ve CustomerID'yi al
                if (cbRoom.SelectedItem == null || cbCustomer.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen geçerli bir oda ve müşteri seçin.");
                    return;
                }

                int selectedRoomId;
                int selectedCustomerId;
                try
                {
                    selectedRoomId = (int)cbRoom.SelectedValue;
                    selectedCustomerId = (int)cbCustomer.SelectedValue;
                }
                catch
                {
                    MessageBox.Show("Oda veya müşteri ID'si geçerli bir sayı değil.");
                    return;
                }

                // Room ve Customer gerçekten var mı kontrol et
                var room = db.Rooms.FirstOrDefault(r => r.RoomID == selectedRoomId);
                if (room == null)
                {
                    MessageBox.Show("Seçilen oda veritabanında bulunamadı.");
                    return;
                }
                else if (!room.RoomStatus.Equals("Available"))
                {
                    MessageBox.Show("Oda kullanıma müsait değil");
                    return;
                } 

                var customer = db.Customers.FirstOrDefault(c => c.CustomerID == selectedCustomerId);
                if (customer == null)
                {
                    MessageBox.Show("Seçilen müşteri veritabanında bulunamadı.");
                    return;
                }

                

                // Güncellemeleri yap
                reservation.ReservationStatus = cbStatus.Text;
                reservation.NumberOfPeople = (int)nudPeople.Value;
                reservation.Date = dtDate.Value;
                reservation.RoomID = selectedRoomId;
                reservation.CustomerID = selectedCustomerId;


                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Rezervasyon başarıyla güncellendi.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt sırasında hata:\n" + ex.Message);
                }
            }
        }

    }
}



