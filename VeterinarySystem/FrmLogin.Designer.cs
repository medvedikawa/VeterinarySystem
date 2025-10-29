namespace VeterinarySystem
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            pictrLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictrLogo).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(64, 120, 170);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(64, 120, 170);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 120, 170);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 120, 170);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(120, 304);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(93, 36);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(113, 185);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(178, 25);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(113, 229);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(178, 25);
            txtPassword.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(33, 189);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(72, 17);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(33, 233);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(69, 17);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // pictrLogo
            // 
            pictrLogo.BackColor = Color.Transparent;
            pictrLogo.Image = Properties.Resources.logo__1_;
            pictrLogo.Location = new Point(77, 31);
            pictrLogo.Name = "pictrLogo";
            pictrLogo.Size = new Size(179, 132);
            pictrLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictrLogo.TabIndex = 5;
            pictrLogo.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 170, 80);
            BackgroundImage = Properties.Resources.loginImage;
            ClientSize = new Size(330, 413);
            Controls.Add(pictrLogo);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnLogin);
            Name = "FrmLogin";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictrLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblUsername;
        private Label lblPassword;
        private PictureBox pictrLogo;
    }
}
