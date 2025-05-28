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
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp1
{
    public partial class AddReservationForm : Form
    {
        public AddReservationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int reservationId = (int)numericUpDown3.Value;
            string reservationStatus = comboBox1.SelectedItem?.ToString();
            int numberOfPeople = (int)numericUpDown1.Value;
            DateTime date = dateTimePicker1.Value;
            int roomId = (int)numericUpDown2.Value;
            int customerId = (int)numericUpDown4.Value;

            if (reservationId <= 0)
            {
                MessageBox.Show("Reservation ID pozitif bir sayı olmalıdır.", "Geçersiz ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(reservationStatus))
            {
                MessageBox.Show("Rezervasyon durumu boş olamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numberOfPeople <= 0)
            {
                MessageBox.Show("Kişi sayısı sıfırdan büyük olmalıdır.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new HotelManagementSystemEntities1())
            {
                bool reservationExists = db.Reservations.Any(r => r.ReservationID == reservationId);
                if (reservationExists)
                {
                    MessageBox.Show("Bu Reservation ID zaten mevcut.", "Çakışan ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool roomExists = db.Rooms.Any(r => r.RoomID == roomId);
                if (!roomExists)
                {
                    MessageBox.Show("Girilen Room ID geçersiz. Böyle bir oda yok.", "Geçersiz Oda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool customerExists = db.Customers.Any(c => c.CustomerID == customerId);
                if (!customerExists)
                {
                    MessageBox.Show("Girilen Customer ID geçersiz. Böyle bir müşteri yok.", "Geçersiz Müşteri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newReservation = new Reservation
                {
                    ReservationID = reservationId,
                    ReservationStatus = reservationStatus,
                    NumberOfPeople = numberOfPeople,
                    Date = date,
                    RoomID = roomId,
                    CustomerID = customerId
                };

                try
                {
                    db.Reservations.Add(newReservation);
                    db.SaveChanges();
                    MessageBox.Show("Rezervasyon başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
