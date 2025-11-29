using System;
using System.Drawing;
using System.Windows.Forms;

namespace VeterinarySystem
{
    public class uscAddPet : UserControl
    {
        private Button btnBack;
        private Label lblTitle;

        public uscAddPet()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;

            lblTitle = new Label
            {
                Text = "Add Pet (user control)",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point),
                AutoSize = true,
                Location = new Point(16, 16)
            };

            btnBack = new Button
            {
                Text = "Back",
                Location = new Point(16, 56),
                AutoSize = true
            };
            btnBack.Click += BtnBack_Click;

            // Add more inputs/controls here or convert your frmAddNewPet into a UserControl and use it here.
            this.Controls.Add(lblTitle);
            this.Controls.Add(btnBack);
        }

        private void BtnBack_Click(object? sender, EventArgs e)
        {
            // Return to a default view (for example the calendar control). Adjust as needed.
            var main = this.FindForm() as FrmMainDashboard;
            if (main != null)
            {
                // Replace with whatever default you want — here we add a fresh CalendarControl instance.
                main.ShowInPanel5(new CalendarTest.CalendarControl());
            }
        }
    }
}