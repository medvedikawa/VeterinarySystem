using System;
using System.Drawing;
using System.Windows.Forms;
using CalendarTest;

namespace VeterinarySystem
{
    public class uscAppointments : UserControl
    {
        private CalendarControl _calendar;
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

            _topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 48,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            _lblTitle = new Label
            {
                Text = "Appointments",
                AutoSize = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(12, 12)
            };

            _btnBack = new Button
            {
                Text = "Back",
                AutoSize = true,
                Location = new Point(this.Width - 90, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            _btnBack.Click += BtnBack_Click;

            _topPanel.Controls.Add(_lblTitle);
            _topPanel.Controls.Add(_btnBack);

            _calendar = new CalendarControl
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