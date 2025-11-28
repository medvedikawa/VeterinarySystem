namespace VeterinarySystem
{
    partial class petGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPetType = new Label();
            lblPetName = new Label();
            pictureBox1 = new PictureBox();
            txtLastApp = new Label();
            txtUpcomingApp = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblPetType
            // 
            lblPetType.Anchor = AnchorStyles.None;
            lblPetType.AutoSize = true;
            lblPetType.BackColor = Color.Transparent;
            lblPetType.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPetType.Location = new Point(32, 200);
            lblPetType.Name = "lblPetType";
            lblPetType.Size = new Size(112, 21);
            lblPetType.TabIndex = 7;
            lblPetType.Text = "Animal, Breed";
            lblPetType.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPetName
            // 
            lblPetName.AutoSize = true;
            lblPetName.BackColor = Color.Transparent;
            lblPetName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPetName.Location = new Point(43, 170);
            lblPetName.Name = "lblPetName";
            lblPetName.Size = new Size(90, 25);
            lblPetName.TabIndex = 6;
            lblPetName.Text = "Buddy, 2";
            lblPetName.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.ErrorImage = Properties.Resources.placeholderPetImage;
            pictureBox1.Image = Properties.Resources.placeholderPetImage;
            pictureBox1.Location = new Point(14, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(149, 151);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtLastApp
            // 
            txtLastApp.AutoSize = true;
            txtLastApp.Font = new Font("Segoe UI", 10F);
            txtLastApp.Location = new Point(7, 317);
            txtLastApp.Name = "txtLastApp";
            txtLastApp.Size = new Size(38, 19);
            txtLastApp.TabIndex = 11;
            txtLastApp.Text = "Date";
            // 
            // txtUpcomingApp
            // 
            txtUpcomingApp.AutoSize = true;
            txtUpcomingApp.Font = new Font("Segoe UI", 10F);
            txtUpcomingApp.Location = new Point(7, 258);
            txtUpcomingApp.Name = "txtUpcomingApp";
            txtUpcomingApp.Size = new Size(38, 19);
            txtUpcomingApp.TabIndex = 10;
            txtUpcomingApp.Text = "Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(7, 231);
            label2.Name = "label2";
            label2.Size = new Size(162, 19);
            label2.TabIndex = 9;
            label2.Text = "Upcoming Appointment:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(7, 290);
            label1.Name = "label1";
            label1.Size = new Size(124, 19);
            label1.TabIndex = 8;
            label1.Text = "Last Appointment:";
            // 
            // petGrid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtLastApp);
            Controls.Add(txtUpcomingApp);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPetType);
            Controls.Add(lblPetName);
            Controls.Add(pictureBox1);
            Name = "petGrid";
            Size = new Size(177, 355);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPetType;
        private Label lblPetName;
        private PictureBox pictureBox1;
        private Label txtLastApp;
        private Label txtUpcomingApp;
        private Label label2;
        private Label label1;
    }
}
