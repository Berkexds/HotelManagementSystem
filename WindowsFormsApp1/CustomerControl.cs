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
    public partial class CustomerControl : UserControl
    {

        private string userTitle;
        public CustomerControl(string title)
        {
            InitializeComponent();
            userTitle = title;
            LoadCustomerData();
        }
        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var customerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["CustomerID"].Value);
            string columnName = dgvCustomers.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                var form = new EditCustomerForm(customerId);
                form.ShowDialog(); // wait for user to close form
                LoadCustomerData(); // refresh grid after possible update
                // You can open a new form here
            }
            else if (columnName == "Details")
            {
                //MessageBox.Show($"View details of Customer #{customerId}");
                // Show a details form, modal, etc.
            }
            else if (columnName == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this customer?",
                                              "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    using (var db = new HotelManagementSystemEntities1())
                    {
                        var customer = db.Customers.Find(customerId);
                        if (customer != null)
                        {
                            db.Customers.Remove(customer);
                            db.SaveChanges();
                        }
                    }

                    // Refresh the table
                    LoadCustomerData();
                }
            }
        }


                    private void LoadCustomerData()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var data = db.Customers
                    .Select(c => new
                    {
                        c.CustomerID,
                        c.Name,  
                        c.EmailAddress,
                        c.Phone,
                        c.Gender
                    }).ToList();

                dgvCustomers.Columns.Clear(); // important: reset columns
                dgvCustomers.DataSource = data;

                // Add buttons only once
                if (userTitle == "Manager")
                {
                    dgvCustomers.Columns.Add(new DataGridViewButtonColumn
                    {
                        HeaderText = "",
                        Name = "Edit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    });

                

                    dgvCustomers.Columns.Add(new DataGridViewButtonColumn
                    {
                        HeaderText = "",
                        Name = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    });
                }
            }
        }
    }
}

    

