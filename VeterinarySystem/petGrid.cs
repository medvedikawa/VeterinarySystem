using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinarySystem.Models;

namespace VeterinarySystem
{
    public partial class petGrid : UserControl
    {
        private PetRecord petData;

        public petGrid()
        {
            InitializeComponent();
        }

        // ⭐ NEW: Initialize the petGrid with pet data
        public void SetPetData(PetRecord pet)
        {
            petData = pet;
            PopulateData();
        }

        private void PopulateData()
        {
            if (petData == null)
                return;

            // Set pet name and age
            string nameAgeText = petData.PetName ?? "Unknown";
            if (petData.PetAge.HasValue)
                nameAgeText += $", {petData.PetAge}";
            lblNameAge.Text = nameAgeText;

            // Set species and breed
            string speciesBreedText = string.Empty;
            if (!string.IsNullOrEmpty(petData.PetSpecies))
                speciesBreedText += petData.PetSpecies;
            if (!string.IsNullOrEmpty(petData.PetBreed))
            {
                if (speciesBreedText.Length > 0)
                    speciesBreedText += ", ";
                speciesBreedText += petData.PetBreed;
            }
            lblSpeciesBreed.Text = speciesBreedText.Length > 0 ? speciesBreedText : "No data";

            // Set pet image
            if (petData.PetImage != null && petData.PetImage.Length > 0)
            {
                try
                {
                    using var ms = new MemoryStream(petData.PetImage);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                catch
                {
                    // Keep placeholder on error
                }
            }
            // If no image, the designer already set placeholderPetImage as default
        }
    }
}
