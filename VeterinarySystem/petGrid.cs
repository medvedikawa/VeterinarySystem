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
        private Label lblPetName;
        private Label lblPetInfo;
        private PictureBox pictureBoxPet;
        private PetRecord petData;

        public petGrid()
        {
            InitializeComponent();
        }

        // ⭐ NEW: Initialize the petGrid with pet data
        public void SetPetData(PetRecord pet)
        {
            petData = pet;
            BuildUI();
            PopulateData();
        }

        private void BuildUI()
        {
            this.Size = new Size(140, 180);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Padding = new Padding(8);

            // Picture Box
            pictureBoxPet = new PictureBox
            {
                Size = new Size(124, 100),
                Location = new Point(8, 8),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(240, 240, 240),
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(pictureBoxPet);

            // Pet Name Label
            lblPetName = new Label
            {
                Location = new Point(8, 112),
                Size = new Size(124, 24),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoEllipsis = true
            };
            this.Controls.Add(lblPetName);

            // Pet Info Label (Age)
            lblPetInfo = new Label
            {
                Location = new Point(8, 140),
                Size = new Size(124, 32),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.TopCenter,
                AutoEllipsis = true
            };
            this.Controls.Add(lblPetInfo);
        }

        private void PopulateData()
        {
            if (petData == null)
                return;

            // Set pet name
            lblPetName.Text = petData.PetName ?? "Unknown";

            // Set pet image
            if (petData.PetImage != null && petData.PetImage.Length > 0)
            {
                try
                {
                    using var ms = new MemoryStream(petData.PetImage);
                    pictureBoxPet.Image = Image.FromStream(ms);
                }
                catch
                {
                    pictureBoxPet.BackColor = Color.FromArgb(200, 200, 200);
                }
            }
            else
            {
                pictureBoxPet.BackColor = Color.FromArgb(200, 200, 200);
            }

            // Set pet info (age and breed)
            string infoText = string.Empty;
            if (petData.PetAge.HasValue)
                infoText += $"Age: {petData.PetAge} yrs\n";
            if (!string.IsNullOrEmpty(petData.PetBreed))
                infoText += petData.PetBreed;

            lblPetInfo.Text = infoText.Trim();
        }
    }
}
