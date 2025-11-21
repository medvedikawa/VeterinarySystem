namespace VeterinarySystem
{
    partial class FrmMainDashboard
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            txtWelcome = new Label();
            pictrLogo = new PictureBox();
            panel2 = new Panel();
            btnOwnersFrm = new Button();
            panel3 = new Panel();
            btnPetFrm = new Button();
            panel4 = new Panel();
            btnAppointmentFrm = new Button();
            panel5 = new Panel();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictrLogo).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackgroundImage = Properties.Resources.loginImage;
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(panel4);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(284, 660);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.loginImage;
            panel1.Controls.Add(txtWelcome);
            panel1.Controls.Add(pictrLogo);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(277, 140);
            panel1.TabIndex = 0;
            // 
            // txtWelcome
            // 
            txtWelcome.AutoSize = true;
            txtWelcome.BackColor = Color.Transparent;
            txtWelcome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtWelcome.Location = new Point(111, 100);
            txtWelcome.Name = "txtWelcome";
            txtWelcome.Size = new Size(53, 21);
            txtWelcome.TabIndex = 7;
            txtWelcome.Text = "label1";
            // 
            // pictrLogo
            // 
            pictrLogo.BackColor = Color.Transparent;
            pictrLogo.Image = Properties.Resources.logo__1_;
            pictrLogo.Location = new Point(29, -23);
            pictrLogo.Name = "pictrLogo";
            pictrLogo.Size = new Size(219, 163);
            pictrLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictrLogo.TabIndex = 6;
            pictrLogo.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnOwnersFrm);
            panel2.Location = new Point(3, 149);
            panel2.Name = "panel2";
            panel2.Size = new Size(277, 59);
            panel2.TabIndex = 1;
            // 
            // btnOwnersFrm
            // 
            btnOwnersFrm.BackColor = Color.FromArgb(237, 219, 186);
            btnOwnersFrm.Cursor = Cursors.Hand;
            btnOwnersFrm.FlatStyle = FlatStyle.Flat;
            btnOwnersFrm.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOwnersFrm.Image = Properties.Resources.image_removebg_preview1;
            btnOwnersFrm.Location = new Point(-157, -22);
            btnOwnersFrm.Name = "btnOwnersFrm";
            btnOwnersFrm.Size = new Size(438, 100);
            btnOwnersFrm.TabIndex = 2;
            btnOwnersFrm.Text = "                            OWNERS";
            btnOwnersFrm.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnPetFrm);
            panel3.Location = new Point(3, 214);
            panel3.Name = "panel3";
            panel3.Size = new Size(277, 59);
            panel3.TabIndex = 2;
            // 
            // btnPetFrm
            // 
            btnPetFrm.BackColor = Color.FromArgb(237, 219, 186);
            btnPetFrm.Cursor = Cursors.Hand;
            btnPetFrm.FlatStyle = FlatStyle.Flat;
            btnPetFrm.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPetFrm.ForeColor = Color.FromArgb(94, 86, 81);
            btnPetFrm.Image = Properties.Resources.logo_1_;
            btnPetFrm.Location = new Point(-157, -22);
            btnPetFrm.Name = "btnPetFrm";
            btnPetFrm.Size = new Size(438, 100);
            btnPetFrm.TabIndex = 2;
            btnPetFrm.Text = "                      PETS";
            btnPetFrm.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(237, 219, 186);
            panel4.Controls.Add(btnAppointmentFrm);
            panel4.Location = new Point(3, 279);
            panel4.Name = "panel4";
            panel4.Size = new Size(277, 59);
            panel4.TabIndex = 3;
            // 
            // btnAppointmentFrm
            // 
            btnAppointmentFrm.BackColor = Color.FromArgb(237, 219, 186);
            btnAppointmentFrm.Cursor = Cursors.Hand;
            btnAppointmentFrm.FlatStyle = FlatStyle.Flat;
            btnAppointmentFrm.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAppointmentFrm.ForeColor = Color.FromArgb(35, 31, 32);
            btnAppointmentFrm.Image = Properties.Resources.calendarlogo;
            btnAppointmentFrm.Location = new Point(-197, -20);
            btnAppointmentFrm.Name = "btnAppointmentFrm";
            btnAppointmentFrm.Size = new Size(517, 100);
            btnAppointmentFrm.TabIndex = 2;
            btnAppointmentFrm.Text = "                                          APPOINTMENTS";
            btnAppointmentFrm.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.Location = new Point(284, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(955, 660);
            panel5.TabIndex = 1;
            // 
            // FrmMainDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 660);
            Controls.Add(panel5);
            Controls.Add(flowLayoutPanel1);
            Name = "FrmMainDashboard";
            Text = "VetTrack";
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictrLogo).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Button btnOwnersFrm;
        private Panel panel3;
        private Button btnPetFrm;
        private Panel panel4;
        private Button btnAppointmentFrm;
        private Panel panel5;
        private Label txtWelcome;
        private PictureBox pictrLogo;
    }
}