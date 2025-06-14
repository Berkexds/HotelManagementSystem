﻿using DataAccess;
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
            textBox1.TextChanged += textBox1_TextChanged;
            dgvCustomers.ColumnHeaderMouseClick += dgvCustomers_ColumnHeaderMouseClick;
        }

        private void dgvCustomers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String columnName = dgvCustomers.Columns[e.ColumnIndex].Name;


            using (var db = new HotelManagementSystemEntities1())
            {
                switch (columnName)
                {
                    case "Name":
                        dgvCustomers.DataSource = db.Customers
                        .OrderBy(x => x.Name)
                        .Select(x => new
                        {
                        x.CustomerID,
                        x.Name,
                        x.EmailAddress,
                        x.Phone,
                        x.Gender,
                        x.DateOfBirth
                        }).ToList();
                        break;
                    case "EmailAddress":
                        dgvCustomers.DataSource = db.Customers
                        .OrderBy(x => x.EmailAddress)
                        .Select(x => new
                        {
                            x.CustomerID,
                            x.Name,
                            x.EmailAddress,
                            x.Phone,
                            x.Gender,
                            x.DateOfBirth
                        }).ToList();
                        break;
                    case "Phone":
                        dgvCustomers.DataSource = db.Customers
                        .OrderBy(x => x.Phone)
                        .Select(x => new
                        {
                            x.CustomerID,
                            x.Name,
                            x.EmailAddress,
                            x.Phone,
                            x.Gender,
                            x.DateOfBirth
                        }).ToList();
                        break; 
                    case "Gender":
                        dgvCustomers.DataSource = db.Customers
                        .OrderBy(x => x.Gender)
                        .Select(x => new
                        {
                            x.CustomerID,
                            x.Name,
                            x.EmailAddress,
                            x.Phone,
                            x.Gender,
                            x.DateOfBirth
                        }).ToList();
                        break;
                    default:
                        dgvCustomers.DataSource = db.Customers
                        .OrderBy(x => x.CustomerID)
                        .Select(x => new
                        {
                            x.CustomerID,
                            x.Name,
                            x.EmailAddress,
                            x.Phone,
                            x.Gender,
                            x.DateOfBirth
                        }).ToList();
                        break;
                }
            }

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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = textBox1.Text.ToLower();

            using (var db = new HotelManagementSystemEntities1())
            {
                var result = db.Customers.Where(cus =>
                cus.Name.ToLower().Contains(query) ||
                cus.EmailAddress.ToLower().Contains(query) ||
                cus.Phone.ToString().Contains(query) ||
                cus.Gender.ToLower().Contains(query) ||
                cus.DateOfBirth.ToString().Contains(query))
                .Select(x => new
                {
                            x.CustomerID,
                            x.Name,
                            x.EmailAddress,
                            x.Phone,
                            x.Gender,
                            x.DateOfBirth
                        }).ToList();

                dgvCustomers.DataSource = result;
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

                    tableLayoutPanel1.Controls.Add(dgvCustomers, 0, 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ShowDialog();
        }
    }
}



