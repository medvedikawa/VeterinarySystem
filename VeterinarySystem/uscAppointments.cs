using System;
using System.Drawing;
using System.Windows.Forms;

namespace VeterinarySystem
{
    public class uscAppointments : UserControl
    {
        private Calendar.CalendarControl _calendar;
        private Button _btnBack;
        private Panel _topPanel;
        private Label _lblTitle;

        public uscAppointments()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            // Orange theme background
            this.BackColor = Color.FromArgb(255, 245, 230);

            _topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(230, 126, 34) // Warm orange
            };

            _lblTitle = new Label
            {
                Text = "📅 Appointments",
                AutoSize = false,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(20, 12),
                Size = new Size(300, 36),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };

            _btnBack = new Button
            {
                Text = "← Back",
                AutoSize = false,
                Location = new Point(this.Width - 110, 13),
                Size = new Size(95, 34),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(210, 105, 30), // Darker orange
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            _btnBack.FlatAppearance.BorderSize = 0;
            _btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 85, 20);
            _btnBack.Click += BtnBack_Click;

            _topPanel.Controls.Add(_lblTitle);
            _topPanel.Controls.Add(_btnBack);

            _calendar = new Calendar.CalendarControl
            {
                Dock = DockStyle.Fill
            };

            this.Controls.Add(_calendar);
            this.Controls.Add(_topPanel);
        }

        private void BtnBack_Click(object? sender, EventArgs e)
        {
            var main = this.FindForm() as FrmMainDashboard;
            if (main != null)
            {
                // Show the sidebar as the main screen
                main.ShowInPanel5(new usrSidebar());
            }
        }
    }
}