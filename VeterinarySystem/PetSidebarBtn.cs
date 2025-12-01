using System;
using System.Drawing;
using System.Windows.Forms;

namespace VeterinarySystem
{
    public partial class PetSidebarBtn : Form
    {
        // Public event consumers can subscribe to.
        public event EventHandler? AddClicked;

        public PetSidebarBtn()
        {
            InitializeComponent();
        }

        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            FrmMainDashboard dashboard = Application.OpenForms["FrmMainDashboard"] as FrmMainDashboard;

            if (dashboard != null)
            {
                // Show search function in panel5
                dashboard.ShowInPanel5(new searchFunction());
            }

            // Close this sidebar form
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            var addPetForm = new frmAddNewPet();
            addPetForm.Closed += (s, args) => this.Close();
            addPetForm.Show();
        }
    }
}