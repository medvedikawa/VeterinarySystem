namespace VeterinarySystem
{
    partial class usrSidebar
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnlTop = new Panel();
            txtWelcome = new Label();
            pictrLogo = new PictureBox();
            panel3 = new Panel();
            btnPetFrm = new Button();
            panel4 = new Panel();
            btnAppointmentFrm = new Button();
            panel1 = new Panel();
            flowLayoutPanel1.SuspendLayout();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictrLogo).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackgroundImage = Properties.Resources.loginImage;
            flowLayoutPanel1.Controls.Add(pnlTop);
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(panel4);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(284, 662);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // pnlTop
            // 
            pnlTop.BackgroundImage = Properties.Resources.loginImage;
            pnlTop.Controls.Add(txtWelcome);
            pnlTop.Controls.Add(pictrLogo);
            pnlTop.Location = new Point(3, 3);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(277, 181);
            pnlTop.TabIndex = 0;
            // 
            // txtWelcome
            // 
            txtWelcome.Anchor = AnchorStyles.None;
            txtWelcome.AutoSize = true;
            txtWelcome.BackColor = Color.Transparent;
            txtWelcome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtWelcome.Location = new Point(97, 125);
            txtWelcome.Name = "txtWelcome";
            txtWelcome.Size = new Size(81, 21);
            txtWelcome.TabIndex = 7;
            txtWelcome.Text = "Welcome!";
            txtWelcome.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictrLogo
            // 
            pictrLogo.BackColor = Color.Transparent;
            pictrLogo.Image = Properties.Resources.logo__1_;
            pictrLogo.Location = new Point(29, -4);
            pictrLogo.Name = "pictrLogo";
            pictrLogo.Size = new Size(219, 163);
            pictrLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictrLogo.TabIndex = 6;
            pictrLogo.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnPetFrm);
            panel3.Location = new Point(3, 190);
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
            btnPetFrm.Click += btnPetFrm_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(237, 219, 186);
            panel4.Controls.Add(btnAppointmentFrm);
            panel4.Location = new Point(3, 255);
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
            btnAppointmentFrm.Click += btnAppointmentFrm_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(286, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(947, 662);
            panel1.TabIndex = 2;
            // 
            // usrSidebar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Name = "usrSidebar";
            Size = new Size(1233, 662);
            flowLayoutPanel1.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictrLogo).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pnlTop;
        private Label txtWelcome;
        private PictureBox pictrLogo;
        private Panel panel3;
        private Button btnPetFrm;
        private Panel panel4;
        private Button btnAppointmentFrm;
        private Panel panel1;
    }
}
