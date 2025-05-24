namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelEmployeeCount = new System.Windows.Forms.Label();
            this.labelCustomerCount = new System.Windows.Forms.Label();
            this.labelRoomCount = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.panelHome = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelEmployeeCount
            // 
            this.labelEmployeeCount.AutoSize = true;
            this.labelEmployeeCount.Location = new System.Drawing.Point(120, 76);
            this.labelEmployeeCount.Name = "labelEmployeeCount";
            this.labelEmployeeCount.Size = new System.Drawing.Size(90, 16);
            this.labelEmployeeCount.TabIndex = 0;
            this.labelEmployeeCount.Text = "EmployeeNo:";
            this.labelEmployeeCount.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelCustomerCount
            // 
            this.labelCustomerCount.AutoSize = true;
            this.labelCustomerCount.Location = new System.Drawing.Point(120, 130);
            this.labelCustomerCount.Name = "labelCustomerCount";
            this.labelCustomerCount.Size = new System.Drawing.Size(85, 16);
            this.labelCustomerCount.TabIndex = 1;
            this.labelCustomerCount.Text = "CustomerNo:";
            this.labelCustomerCount.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelRoomCount
            // 
            this.labelRoomCount.AutoSize = true;
            this.labelRoomCount.Location = new System.Drawing.Point(120, 184);
            this.labelRoomCount.Name = "labelRoomCount";
            this.labelRoomCount.Size = new System.Drawing.Size(65, 16);
            this.labelRoomCount.TabIndex = 2;
            this.labelRoomCount.Text = "RoomNo:";
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(387, 76);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnReservations);
            this.panel1.Controls.Add(this.btnEmployees);
            this.panel1.Controls.Add(this.btnRooms);
            this.panel1.Controls.Add(this.btnCustomers);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 589);
            this.panel1.TabIndex = 4;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(12, 28);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(94, 42);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Location = new System.Drawing.Point(12, 85);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(94, 38);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRooms.Location = new System.Drawing.Point(12, 141);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(94, 38);
            this.btnRooms.TabIndex = 3;
            this.btnRooms.Text = "Rooms";
            this.btnRooms.UseVisualStyleBackColor = false;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Location = new System.Drawing.Point(12, 202);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(94, 38);
            this.btnEmployees.TabIndex = 4;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnReservations
            // 
            this.btnReservations.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservations.Location = new System.Drawing.Point(12, 266);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Size = new System.Drawing.Size(94, 38);
            this.btnReservations.TabIndex = 5;
            this.btnReservations.Text = "Reservation";
            this.btnReservations.UseVisualStyleBackColor = false;
            this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);
            // 
            // panelHome
            // 
            this.panelHome.Controls.Add(this.labelEmployeeCount);
            this.panelHome.Controls.Add(this.labelCustomerCount);
            this.panelHome.Controls.Add(this.labelRoomCount);
            this.panelHome.Controls.Add(this.chart1);
            this.panelHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHome.Location = new System.Drawing.Point(118, 0);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(932, 589);
            this.panelHome.TabIndex = 7;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(118, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(932, 589);
            this.panelContent.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 589);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelHome.ResumeLayout(false);
            this.panelHome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelEmployeeCount;
        private System.Windows.Forms.Label labelCustomerCount;
        private System.Windows.Forms.Label labelRoomCount;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Panel panelContent;
    }
}

