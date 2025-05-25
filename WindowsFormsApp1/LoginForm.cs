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
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputName = txtName.Text.Trim();
            string inputPassword = txtPassword.Text.Trim();

          

            using (var db = new HotelManagementSystemEntities1()) // make sure this matches your context
            {



                var employee = db.Employees
        .AsEnumerable()
        .FirstOrDefault(emp =>
            emp.Name.Trim().Equals(inputName, StringComparison.InvariantCultureIgnoreCase) &&
            emp.Password.Trim() == inputPassword);

                if (employee != null)
                {
                    if (employee.Title == "Manager")
                    {
                        MessageBox.Show("Manager login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 managerForm = new Form1(employee.Title);
                        managerForm.Show();
                        this.Hide();
                    }
                    else
                    {
                       MessageBox.Show("Employee login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 employeeForm = new Form1(employee.Title);
                        employeeForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
