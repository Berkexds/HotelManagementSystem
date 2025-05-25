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
    public partial class Form1 : Form
    {
        private string userTitle;
        public Form1(string title)
        {
            InitializeComponent();
            userTitle = title;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var db = new HotelManagementSystemEntities1())
            {
                // Total employee count
                int employeeCount = db.Employees.Count();
                labelEmployeeCount.Text = $"Employees: {employeeCount}";

                // Total customer count
                int customerCount = db.Customers.Count();
                labelCustomerCount.Text = $"Customers: {customerCount}";

                // Available rooms
                int availableRooms = db.Rooms.Count(r => r.RoomStatus == "Available"); // or whatever your availability flag is
                labelRoomCount.Text = $"Available Rooms: {availableRooms}";

                // Gender distribution chart
                int maleCount = db.Customers.Count(c => c.Gender == "Male");
                int femaleCount = db.Customers.Count(c => c.Gender == "Female");

                chart1.Series.Clear();
                chart1.Titles.Clear(); // In case it's loaded multiple times
                chart1.Titles.Add("Gender Distribution");
                

                var series = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "Gender",
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie


                };
               

                series.IsValueShownAsLabel = true;

                series.Points.AddXY($"Male: {maleCount}", maleCount);
                series.Points.AddXY($"Female: {femaleCount}", femaleCount);
                chart1.Series.Add(series);
                CustomizeBasedOnRole();

            }
        }
        private void ShowPanel(Panel panelToShow)
        {
            // Always hide the dashboard
            panelHome.Visible = false;

            // If a panel is passed (like Home), show it
            if (panelToShow != null)
            {
                panelToShow.Visible = true;
                panelToShow.BringToFront();
            }
        }

        private void CustomizeBasedOnRole()
        {
            if (userTitle != "Manager")
            {
                // ❌ Hide Employees tab entirely
                btnEmployees.Visible = true;
                btnEmployees.Enabled = true;



            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();      // Remove any loaded control
            ShowPanel(panelHome);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ShowPanel(null);                    // Hide panelHome
            panelContent.Controls.Clear();
            var customerControl = new CustomerControl(userTitle);
            customerControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(customerControl);
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            ShowPanel(null);
            panelContent.Controls.Clear();
            var roomControl = new RoomControl(userTitle);
            roomControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(roomControl);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            if (userTitle != "Manager")
            {
                MessageBox.Show("You do not have permission to access the Employees section.",
                                "Access Denied",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // ✅ block access
            }
            ShowPanel(null);
            panelContent.Controls.Clear();
            var employeeControl = new EmployeeControl();
            employeeControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(employeeControl);
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            ShowPanel(null);
            panelContent.Controls.Clear();
            var reservationControl = new ReservationControl(userTitle);
            reservationControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(reservationControl);
        }
    }
}