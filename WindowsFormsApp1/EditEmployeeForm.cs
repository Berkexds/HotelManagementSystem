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
   
    public partial class EditEmployeeForm : Form
    {
        private int _employeeId;
        public EditEmployeeForm(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var employee = db.Employees.Find(_employeeId);
                if (employee != null)
                {
                    txtName.Text = employee.Name;
                    txtTitle.Text = employee.Title;
                    txtSalary.Text = employee.Salary.ToString();
                    dtpDateofHiring.Value = employee.DateOfHiring ?? DateTime.Now;
                    numWorkingHours.Value = Convert.ToDecimal(employee.WorkingHours);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                var employee = db.Employees.Find(_employeeId);
                if (employee != null)
                {
                    employee.Name = txtName.Text.Trim();
                    employee.Title = txtTitle.Text.Trim();
                    employee.Salary = decimal.Parse(txtSalary.Text);
                    employee.DateOfHiring = dtpDateofHiring.Value;
                    employee.WorkingHours = numWorkingHours.Value.ToString();

                    db.SaveChanges();
                    MessageBox.Show("Employee updated successfully!");
                    this.Close();
                }
            }
        }
    }
}
