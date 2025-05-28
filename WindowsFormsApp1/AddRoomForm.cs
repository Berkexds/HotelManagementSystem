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
    public partial class AddRoomForm : Form
    {
        public AddRoomForm()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int roomId = (int)numericUpDown3.Value;
            string description = textBox2.Text.Trim();
            string roomStatus = comboBox1.SelectedItem?.ToString();
            string roomType = comboBox2.SelectedItem?.ToString();
            decimal pricePerNight = numericUpDown1.Value;

            // RoomID negatif veya 0 olamaz
            if (roomId <= 0)
            {
                MessageBox.Show("Room ID pozitif bir sayı olmalıdır.", "Geçersiz ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Required alan kontrolleri
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Açıklama boş olamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(roomStatus))
            {
                MessageBox.Show("Lütfen bir oda durumu seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(roomType))
            {
                MessageBox.Show("Lütfen bir oda tipi seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pricePerNight <= 0)
            {
                MessageBox.Show("Gecelik fiyat sıfırdan büyük olmalıdır.", "Geçersiz Fiyat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new HotelManagementSystemEntities1())
            {
                // RoomID'nin zaten var olup olmadığını kontrol et
                bool idExists = db.Rooms.Any(r => r.RoomID == roomId);
                if (idExists)
                {
                    MessageBox.Show("Bu Room ID zaten mevcut. Lütfen farklı bir ID girin.", "Çakışan ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Yeni oda nesnesi oluştur
                var newRoom = new Room
                {
                    RoomID = roomId,
                    Description = description,
                    RoomStatus = roomStatus,
                    RoomType = roomType,
                    PricePerNight = pricePerNight
                };

                try
                {
                    db.Rooms.Add(newRoom);
                    db.SaveChanges();

                    MessageBox.Show("Oda başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına kayıt sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
