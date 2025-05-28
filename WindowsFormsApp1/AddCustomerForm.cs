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
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();

            button1.Click += new EventHandler(button1_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int customerId = (int)numericUpDown3.Value;
            string name = textBox2.Text.Trim();
            string phone = maskedTextBox1.Text.Trim();
            string email = textBox1.Text.Trim();
            string gender = comboBox1.SelectedItem?.ToString();
            DateTime dateOfBirth = dateTimePicker1.Value;

            if (customerId <= 0)
            {
                MessageBox.Show("Customer ID pozitif bir sayı olmalıdır.", "Geçersiz ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("İsim boş bırakılamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(phone) || phone.Contains("_"))
            {
                MessageBox.Show("Telefon numarasını eksiksiz girin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Geçerli bir email adresi girin.", "Hatalı Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                MessageBox.Show("Lütfen bir cinsiyet seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateOfBirth > DateTime.Today)
            {
                MessageBox.Show("Doğum tarihi bugünden sonra olamaz.", "Geçersiz Tarih", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new HotelManagementSystemEntities1())
            {
                bool idExists = db.Customers.Any(c => c.CustomerID == customerId);
                if (idExists)
                {
                    MessageBox.Show("Bu Customer ID zaten mevcut. Lütfen farklı bir ID girin.", "Çakışan ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newCustomer = new Customer
                {
                    CustomerID = customerId,
                    Name = name,
                    Phone = phone,
                    EmailAddress = email,
                    Gender = gender,
                    DateOfBirth = dateOfBirth
                };

                try
                {
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                    MessageBox.Show("Müşteri başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


    }
}
