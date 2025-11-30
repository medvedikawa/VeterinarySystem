using System;
using System.Windows.Forms;
using VeterinarySystem.Data;  // ADD THIS LINE!

namespace VeterinarySystem
{
    public partial class usrSidebar : UserControl
    {
        public usrSidebar()
        {
            InitializeComponent();
            LoadRecentPets(); // ADD THIS LINE!
        }

        // ADD THIS ENTIRE METHOD:
        private void LoadRecentPets()
        {
            try
            {
                petGridWillAppear.Controls.Clear();

                var recentPets = PetRepository.GetRecentPets(4); // Gets top 4 recent pets

                Console.WriteLine($"Loading {recentPets.Count} recent pets");

                foreach (var pet in recentPets)
                {
                    var petControl = new petGrid();
                    petControl.SetPetData(pet); // THIS is the method name!
                    petGridWillAppear.Controls.Add(petControl);
                    Console.WriteLine($"Added pet: {pet.PetName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading pets: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnPetFrm_Click(object sender, EventArgs e)
        {
            var petSidebar = new PetSidebarBtn();
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