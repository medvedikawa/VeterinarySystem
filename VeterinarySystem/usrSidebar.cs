using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var PetSidebar = new PetSidebarBtn();
            PetSidebar.Show();
        }

        private void btnAppointmentFrm_Click(object sender, EventArgs e)
        {

        }
    }
}