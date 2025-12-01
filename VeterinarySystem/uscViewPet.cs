using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VeterinarySystem.Data;
using VeterinarySystem.Models;

namespace VeterinarySystem
{
    public partial class uscViewPet : UserControl
    {
        private int currentPetID;
        private PetRecord currentPet;

        public uscViewPet()
        {
            InitializeComponent();
        }

        public uscViewPet(int petID) : this()
        {
            currentPetID = petID;
            LoadPetDetails();
        }

        private void LoadPetDetails()
        {
            try
            {
                currentPet = PetRepository.GetById(currentPetID);

                if (currentPet != null)
                {
                    // Use the SAME pattern your groupmate used!
                    lblPetName.Text = currentPet.PetName ?? string.Empty;
                    txtPetType.Text = string.IsNullOrWhiteSpace(currentPet.PetSpecies)
                        ? currentPet.PetBreed ?? string.Empty
                        : $"{currentPet.PetSpecies}, {currentPet.PetBreed}";
                    txtPetAge.Text = currentPet.PetAge?.ToString() ?? string.Empty;
                    txtDob.Text = currentPet.DateOfBirth?.ToShortDateString() ?? string.Empty;
                    txtWeight.Text = currentPet.PetWeight?.ToString() ?? string.Empty;
                    txtMedHist.Text = currentPet.MedicalHistory ?? string.Empty;
                    txtOwner.Text = currentPet.OwnerName ?? string.Empty;
                    txtAddress.Text = currentPet.Address ?? string.Empty;
                    txtContact.Text = currentPet.ContactNo ?? string.Empty;
                    txtGender.Text = currentPet.PetGender ?? string.Empty;

                    // Load image if you have a PictureBox
                    if (currentPet.PetImage != null && currentPet.PetImage.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(currentPet.PetImage))
                        {
                            pbPetPicture.Image = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Pet not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pet: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMainDashboard dashboard = this.FindForm() as FrmMainDashboard;
            if (dashboard != null)
            {
                dashboard.ShowInPanel5(new searchFunction());
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            // TODO: Show appointment history
            MessageBox.Show($"Appointment history for {currentPet.PetName}");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // TODO: Edit pet
            MessageBox.Show("Edit coming soon!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // TODO: Soft delete (set isActive = 0)
            MessageBox.Show("Delete coming soon!");
        }
    }
}