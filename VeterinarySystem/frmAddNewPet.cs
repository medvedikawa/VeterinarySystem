using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinarySystem
{
    public partial class frmAddNewPet : Form
    {
        public frmAddNewPet()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Get the selected file path
                    string selectedFilePath = openFileDialog1.FileName;

                    // Load the image into the PictureBox
                    pictureBox1.Image = Image.FromFile(selectedFilePath);

                    // Optional: Display the file path in the form title
                    this.Text = $"Picture Upload - {System.IO.Path.GetFileName(selectedFilePath)}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmAddNewPet_Load(object sender, EventArgs e)
        {
            // Setup Species ComboBox
            cmbSpecies.Items.Clear();
            cmbSpecies.Items.Add("Dog");
            cmbSpecies.Items.Add("Cat");

            // Optional: Set default (leave unselected)
            cmbSpecies.SelectedIndex = -1; // Nothing selected

            // Setup Breed ComboBox with autocomplete
            cmbBreeds.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbBreeds.AutoCompleteSource = AutoCompleteSource.ListItems;
            // Clear previous breeds
            cmbBreeds.Items.Clear();
            cmbBreeds.Text = "";
            cmbBreeds.SelectedIndex = -1;
        }

        private void LoadDogBreeds()
        {
            cmbBreeds.Items.Clear();
            cmbBreeds.Text = "";
            cmbBreeds.SelectedIndex = -1;

            string[] dogBreeds = {
        "Non-Pedigree Dog", "Labrador Retriever", "German Shepherd", "Golden Retriever",
        "French Bulldog", "Bulldog", "Poodle", "Beagle",
        "Rottweiler", "German Shorthaired Pointer", "Dachshund",
        "Pembroke Welsh Corgi", "Australian Shepherd", "Yorkshire Terrier",
        "Boxer", "Great Dane", "Siberian Husky", "Doberman Pinscher",
        "Cavalier King Charles Spaniel", "Miniature Schnauzer",
        "Shih Tzu", "Boston Terrier", "Pomeranian", "Havanese",
        "Shetland Sheepdog", "Brittany", "Pug", "Cocker Spaniel",
        "Miniature American Shepherd", "Mastiff", "Chihuahua",
        "Border Collie", "Basset Hound", "Newfoundland",
        "Bernese Mountain Dog", "Akita", "Shiba Inu", "Dalmatian"
    };

            cmbBreeds.Items.AddRange(dogBreeds);
        }

        private void LoadCatBreeds()
        {
            cmbBreeds.Items.Clear();
            cmbBreeds.Text = "";
            cmbBreeds.SelectedIndex = -1;

            string[] catBreeds = {
        "Non-Pedigree Cat", "Domestic Shorthair", "Domestic Longhair", "Persian",
        "Maine Coon", "Ragdoll", "British Shorthair", "Siamese",
        "American Shorthair", "Scottish Fold", "Sphynx", "Bengal",
        "Abyssinian", "Birman", "Oriental Shorthair", "Devon Rex",
        "American Bobtail", "Himalayan", "Burmese", "Russian Blue",
        "Norwegian Forest", "Cornish Rex", "Exotic Shorthair",
        "Turkish Angora", "Manx", "Balinese", "Tonkinese",
        "Siberian", "Somali", "Japanese Bobtail", "Turkish Van",
        "Chartreux", "Korat", "Ocicat", "Singapura", "Havana Brown"
    };

            cmbBreeds.Items.AddRange(catBreeds);
        }

        // Designer is wired to this method (see FrmMainDashboard.Designer.cs).
        private void species_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cmbSpecies.SelectedItem as string;
            if (string.IsNullOrEmpty(selected))
            {
                // No species selected: clear breeds
                cmbBreeds.Items.Clear();
                cmbBreeds.Text = "";
                cmbBreeds.SelectedIndex = -1;
                return;
            }

            // Ensure autocomplete remains enabled
            cmbBreeds.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbBreeds.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (selected == "Dog")
            {
                LoadDogBreeds();
            }
            else if (selected == "Cat")
            {
                LoadCatBreeds();
            }
            else
            {
                // Unknown selection: clear breeds
                cmbBreeds.Items.Clear();
                cmbBreeds.Text = "";
                cmbBreeds.SelectedIndex = -1;
            }
        }

        // Forwarder in case the event is wired to the other name.

        private void cmbBreeds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            species_SelectedIndexChanged(sender, e);
        }
    }
}