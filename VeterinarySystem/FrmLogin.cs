using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VeterinarySystem
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            // Ensure flat button has no border and uses our hover/pressed colors
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 79, 112);   // hover (darker)
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(34, 64, 92);    // pressed (even darker)
            // Keep text white
            btnLogin.ForeColor = Color.White;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainDash = new FrmMainDashboard();
            mainDash.Closed += (s, args) => this.Close();
            mainDash.Show();
        }
    }
}