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
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text.Trim();
            string title = textBox1.Text.Trim();
            decimal salary = numericUpDown1.Value;
            DateTime dateOfHiring = dateTimePicker1.Value;
            int workingHours = (int)numericUpDown2.Value;
            int employeeId = (int)numericUpDown3.Value;

            if (employeeId <= 0)
            {
                MessageBox.Show("Employee ID pozitif bir sayı olmalıdır.", "Geçersiz ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("İsim ve unvan boş olamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new HotelManagementSystemEntities1())
            {
                bool employeeExists = db.Employees.Any(a => a.EmployeeID == employeeId);
                if (employeeExists)
                {
                    MessageBox.Show("Bu Employee ID zaten mevcut.", "Çakışan ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newEmployee = new Employee
                {
                    EmployeeID = employeeId,
                    Name = name,
                    Title = title,
                    Salary = salary,
                    DateOfHiring = dateOfHiring,
                    WorkingHours = workingHours.ToString()
                };

                try
                {
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                    MessageBox.Show("Çalışan başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
