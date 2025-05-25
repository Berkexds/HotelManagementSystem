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
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl()
        {
            InitializeComponent();
            LoadEmployeeData();

            this.dgvEmployee.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployee_ColumnHeaderMouseClick);
        }

        private void dgvEmployee_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String columnName = dgvEmployee.Columns[e.ColumnIndex].Name;


            using (var db = new HotelManagementSystemEntities1())
            {
                switch (columnName)
                {
                    case "Name":
                        dgvEmployee.DataSource = db.Employees
                        .OrderBy(x => x.Name)
                        .Select(x => new
                        {
                            x.EmployeeID,
                            x.Name,
                            x.Title,
                            x.Salary,
                            x.DateOfHiring,
                            x.WorkingHours
                        }).ToList();
                        break;
                    case "Title":
                        dgvEmployee.DataSource = db.Employees
                        .OrderBy(x => x.Title)
                        .Select(x => new
                        {
                            x.EmployeeID,
                            x.Name,
                            x.Title,
                            x.Salary,
                            x.DateOfHiring,
                            x.WorkingHours
                        }).ToList();
                        break;
                    case "Salary":
                        dgvEmployee.DataSource = db.Employees
                        .OrderBy(x => x.Salary)
                        .Select(x => new
                        {
                            x.EmployeeID,
                            x.Name,
                            x.Title,
                            x.Salary,
                            x.DateOfHiring,
                            x.WorkingHours
                        }).ToList();
                        break;
                    case "DateOfHiring":
                        dgvEmployee.DataSource = db.Employees
                        .OrderBy(x => x.DateOfHiring)
                        .Select(x => new
                        {
                            x.EmployeeID,
                            x.Name,
                            x.Title,
                            x.Salary,
                            x.DateOfHiring,
                            x.WorkingHours
                        }).ToList();
                        break;
                    case "WorkingHours":
                        dgvEmployee.DataSource = db.Employees
                        .OrderBy(x => x.WorkingHours)
                        .Select(x => new
                        {
                            x.EmployeeID,
                            x.Name,
                            x.Title,
                            x.Salary,
                            x.DateOfHiring,
                            x.WorkingHours
                        }).ToList();
                        break;
                    default:
                        dgvEmployee.DataSource = db.Employees
                        .OrderBy(x => x.EmployeeID)
                        .Select(x => new
                        {
                            x.EmployeeID,
                            x.Name,
                            x.Title,
                            x.Salary,
                            x.DateOfHiring,
                            x.WorkingHours
                        }).ToList();
                        break;

                }
            }
        }

        private void LoadEmployeeData()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var data = db.Employees
                    .Select(e => new
                    {
                        e.EmployeeID,
                        e.Name,
                        e.Title,
                        e.Salary,
                        e.DateOfHiring,
                        e.WorkingHours
                    })
                    .ToList();

                dgvEmployee.DataSource = data;
            }

            // Add buttons only once
            if (!dgvEmployee.Columns.Contains("Edit"))
            {
                dgvEmployee.Columns.Add(new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                });

                dgvEmployee.Columns.Add(new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                });
            }
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int employeeId = Convert.ToInt32(dgvEmployee.Rows[e.RowIndex].Cells["EmployeeID"].Value);
            string columnName = dgvEmployee.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                var editForm = new EditEmployeeForm(employeeId);
                editForm.ShowDialog();
                LoadEmployeeData(); // Refresh the grid after edit

            }
            else if (columnName == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this employee?",
                                              "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    using (var db = new HotelManagementSystemEntities1())
                    {
                        var emp = db.Employees.Find(employeeId);
                        if (emp != null)
                        {
                            db.Employees.Remove(emp);
                            db.SaveChanges();
                        }
                    }

                    // Refresh
                    LoadEmployeeData();
                }
            }
        }
    }
}