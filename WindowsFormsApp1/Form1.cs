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
            loadPieChart();
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

        private void loadPieChart()
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

                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.ChartAreas.Clear();
                chart1.Legends.Clear();

                chart1.Titles.Add("Reservation Status Distribution");
                chart1.ChartAreas.Add(new ChartArea("MainArea"));

                Legend legend = new Legend("Legend1");
                legend.Font = new Font("Segoe UI", 9);
                chart1.Legends.Add(legend);

                var series = new Series("Reservation Status")
                {
                    ChartType = SeriesChartType.Pie,
                    ChartArea = "MainArea",
                    IsValueShownAsLabel = true,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Legend = "Legend1" // bu satır varsa yukarıyla uyuşmalı
                };

                series["PieLabelStyle"] = "Outside";
                series.Label = "#VALX: #PERCENT{P1}";

                foreach (var group in db.Reservations
                    .GroupBy(r => r.ReservationStatus)
                    .Select(g => new { Status = g.Key, Count = g.Count() })
                    .ToList())
                {
                    series.Points.AddXY(group.Status, group.Count);
                }

                chart1.BackColor = Color.Transparent;
                chart1.Series.Add(series);
                chart1.Width = 400;
                chart1.Height = 300;

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

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            panelHome.BackColor = Color.CornflowerBlue;// Remove any loaded control
            ShowPanel(panelHome);
            loadPieChart();
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