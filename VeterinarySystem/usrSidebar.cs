using System;
using System.Windows.Forms;

namespace VeterinarySystem
{
    public partial class usrSidebar : UserControl
    {
        public usrSidebar()
        {
            InitializeComponent();
        }

        private void btnPetFrm_Click(object sender, EventArgs e)
        {
            var petSidebar = new PetSidebarBtn();

            // Subscribe to the public AddClicked event (not the internal button).
            petSidebar.AddClicked += (s, args) =>
            {
                var main = this.FindForm() as FrmMainDashboard;
                if (main != null)
                {
                    main.ShowInPanel5(new uscAddPet());
                }
            };

            petSidebar.Show();
        }

        private void btnAppointmentFrm_Click(object sender, EventArgs e)
        {
            var main = this.FindForm() as FrmMainDashboard;
            if (main != null)
            {
                main.ShowInPanel5(new uscAppointments());
            }
        }
    }
}