using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VeterinarySystem.Data;
using VeterinarySystem.Models;

namespace VeterinarySystem
{
    public partial class confirmEntry : Form
    {
        private readonly PetRecord _pet;

        public confirmEntry(PetRecord pet)
        {
            InitializeComponent();
            _pet = pet ?? throw new ArgumentNullException(nameof(pet));

            // Wire events (Designer didn't wire btnYes/btnNo)
            btnYes.Click += BtnYes_Click;
            btnNo.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            PopulateFields();
        }

        private void PopulateFields()
        {
            lblPetName.Text = _pet.PetName ?? string.Empty;
            lblPetType.Text = string.IsNullOrWhiteSpace(_pet.PetSpecies) ? _pet.PetBreed ?? string.Empty : $"{_pet.PetSpecies}, {_pet.PetBreed}";
            txtAge.Text = _pet.PetAge?.ToString() ?? string.Empty;
            txtBday.Text = _pet.DateOfBirth?.ToShortDateString() ?? string.Empty;
            txtWeight.Text = _pet.PetWeight?.ToString() ?? string.Empty;
            txtMedHist.Text = _pet.MedicalHistory ?? string.Empty;
            txtNameOwner.Text = _pet.OwnerName ?? string.Empty;
            txtAddress.Text = _pet.Address ?? string.Empty;
            txtContactNo.Text = _pet.ContactNo ?? string.Empty;

            if (_pet.PetImage != null && _pet.PetImage.Length > 0)
            {
                try
                {
                    using var ms = new MemoryStream(_pet.PetImage);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                catch
                {
                    // ignore image errors, leave placeholder
                }
            }
        }

        private void BtnYes_Click(object? sender, EventArgs e)
        {
            try
            {
                PetRepository.Save(_pet);
                MessageBox.Show("Pet saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save pet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}