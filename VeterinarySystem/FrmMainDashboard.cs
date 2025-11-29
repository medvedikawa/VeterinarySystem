using System;
using System.Drawing;
using System.Windows.Forms;

namespace VeterinarySystem
{
    public partial class FrmMainDashboard : Form
    {
        public FrmMainDashboard()
        {
            InitializeComponent();

            // Show the sidebar in panel5 as the first thing users see after login
            ShowInPanel5(new usrSidebar());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        /// Replace contents of panel5 with the supplied UserControl and dock it to fill.
        /// </summary>
        public void ShowInPanel5(UserControl ctrl)
        {
            if (ctrl == null)
                throw new ArgumentNullException(nameof(ctrl));

            panel5.SuspendLayout();
            panel5.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            panel5.Controls.Add(ctrl);
            panel5.ResumeLayout();
        }
    }
}