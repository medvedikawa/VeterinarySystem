using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VeterinarySystem.Data;

namespace VeterinarySystem
{
    public partial class searchFunction : UserControl
    {
        public searchFunction()
        {
            InitializeComponent();
            LoadPets();
            SetupAutoComplete();
        }
        private void LoadPets()
        {
            try
            {
                // Use the new lightweight method!
                var pets = PetRepository.GetAllActivePets();

                DataTable dt = new DataTable();
                dt.Columns.Add("PetID", typeof(int));
                dt.Columns.Add("PetName", typeof(string));
                dt.Columns.Add("OwnerName", typeof(string));

                foreach (var pet in pets)
                {
                    dt.Rows.Add(pet.PetID, pet.PetName, pet.OwnerName);
                }

                cmbSearch.DataSource = dt;
                cmbSearch.DisplayMember = "PetName";
                cmbSearch.ValueMember = "PetID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pets: " + ex.Message);
            }
        }

        private void SetupAutoComplete()
        {
            cmbSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // When user presses Enter
        private void cmbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OpenViewPet();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // When user clicks on a selection
        private void cmbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OpenViewPet();
        }

        private void OpenViewPet()
        {
            if (cmbSearch.SelectedValue != null)
            {
                int petID = (int)cmbSearch.SelectedValue;

                // Create ViewPet control and pass the petID
                uscViewPet viewPet = new uscViewPet(petID);

                // Get the main dashboard and switch panels
                FrmMainDashboard dashboard = this.FindForm() as FrmMainDashboard;
                if (dashboard != null)
                {
                    dashboard.ShowInPanel5(viewPet);
                }
            }
            else
            {
                MessageBox.Show("Please select a pet!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Go back to sidebar
            FrmMainDashboard dashboard = this.FindForm() as FrmMainDashboard;
            if (dashboard != null)
            {
                dashboard.ShowInPanel5(new usrSidebar());
            }
        }

        private void cmbSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OpenViewPet();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbSearch_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            OpenViewPet();
        }
    }
}