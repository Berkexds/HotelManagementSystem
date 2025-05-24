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
    public partial class EditCustomerForm : Form
    {
        private int _customerId;
        public EditCustomerForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            LoadCustomerData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadCustomerData()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var customer = db.Customers.Find(_customerId);
                if (customer != null)
                {
                    txtName.Text = customer.Name;
                    txtEmail.Text = customer.EmailAddress;
                    txtPhone.Text = customer.Phone;
                    cmbGender.SelectedItem = customer.Gender;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var customer = db.Customers.Find(_customerId);
                if (customer != null)
                {
                    customer.Name = txtName.Text.Trim();
                    customer.EmailAddress = txtEmail.Text.Trim();
                    customer.Phone = txtPhone.Text.Trim();
                    customer.Gender = cmbGender.SelectedItem?.ToString();

                    db.SaveChanges();
                    MessageBox.Show("Customer updated successfully.");
                    this.Close();
                }
            }
        }
    }
}
