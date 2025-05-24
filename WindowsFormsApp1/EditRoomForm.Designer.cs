namespace WindowsFormsApp1
{
    partial class EditRoomForm
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
            this.cbRoomStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.nudPricePerNight = new System.Windows.Forms.NumericUpDown();
            this.cbRoomType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerNight)).BeginInit();
            this.SuspendLayout();
            // 
            // cbRoomStatus
            // 
            this.cbRoomStatus.FormattingEnabled = true;
            this.cbRoomStatus.Items.AddRange(new object[] {
            "Available",
            "Occupied",
            "Maintenance"});
            this.cbRoomStatus.Location = new System.Drawing.Point(256, 105);
            this.cbRoomStatus.Name = "cbRoomStatus";
            this.cbRoomStatus.Size = new System.Drawing.Size(121, 24);
            this.cbRoomStatus.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(292, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(256, 149);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(100, 22);
            this.tbDescription.TabIndex = 2;
            // 
            // nudPricePerNight
            // 
            this.nudPricePerNight.Location = new System.Drawing.Point(257, 187);
            this.nudPricePerNight.Name = "nudPricePerNight";
            this.nudPricePerNight.Size = new System.Drawing.Size(120, 22);
            this.nudPricePerNight.TabIndex = 3;
            // 
            // cbRoomType
            // 
            this.cbRoomType.FormattingEnabled = true;
            this.cbRoomType.Items.AddRange(new object[] {
            "Standard",
            "Suite",
            "Deluxe"});
            this.cbRoomType.Location = new System.Drawing.Point(256, 227);
            this.cbRoomType.Name = "cbRoomType";
            this.cbRoomType.Size = new System.Drawing.Size(121, 24);
            this.cbRoomType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "RoomStatus:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "PricePerNight:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "RoomType:";
            // 
            // EditRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRoomType);
            this.Controls.Add(this.nudPricePerNight);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbRoomStatus);
            this.Name = "EditRoomForm";
            this.Text = "Description";
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerNight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRoomStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.NumericUpDown nudPricePerNight;
        private System.Windows.Forms.ComboBox cbRoomType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}