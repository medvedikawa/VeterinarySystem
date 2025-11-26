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
    public partial class PetSidebarBtn : Form
    {
        public PetSidebarBtn()
        {
            InitializeComponent();
        }

        private void btnViewRecords_Click(object sender, EventArgs e)
        {

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