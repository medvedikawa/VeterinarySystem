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
using System.Globalization;

namespace VeterinarySystem
{
    public partial class frmAddNewPet : Form
    {
        // Maximum allowed weight in kilograms.
        // Set slightly above the heaviest recorded domestic dog to enforce a practical upper bound.
        // (Using 160 kg as a safe ceiling for pet weight entries.)
        private const decimal MAX_WEIGHT_KG = 160m;

        public frmAddNewPet()
        {
            InitializeComponent();
        }
        //String age;
        int age;

        // runtime-created checkbox to allow manual age entry (made optional so no Designer changes)
        private CheckBox chkManualAge;

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

            // Set DateTimePicker maximum date to today (can't select future dates)
            dtBday.MaxDate = DateTime.Today;

            // Set default value to today
            dtBday.Value = DateTime.Today;

            // Optional: Set format for better display
            dtBday.Format = DateTimePickerFormat.Long;

            // --- IMPORTANT: wire the ValueChanged handler (designer didn't) ---
            dtBday.ValueChanged += dtpDOB_ValueChanged;

            // Create the "Add age manually" checkbox at runtime (keeps Designer clean)
            chkManualAge = new CheckBox
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point),
                Name = "chkManualAge",
                Text = "Add age manually",
                UseVisualStyleBackColor = true
            };

            // Place it directly under the Age textbox so it stays aligned with the Designer layout
            chkManualAge.Location = new Point(txtAge.Left, txtAge.Bottom + 6);
            chkManualAge.CheckedChanged += chkManualAge_CheckedChanged;

            // Add it to the same panel so layout stays consistent
            panel1.Controls.Add(chkManualAge);
            panel1.Controls.SetChildIndex(chkManualAge, panel1.Controls.GetChildIndex(txtAge) + 1);

            // Default: DOB mode (age auto-calculated)
            txtAge.ReadOnly = true;
            dtBday.Enabled = true;
            chkManualAge.Checked = false;

            // Wire input handlers for validation
            txtOwnerName.KeyPress += txtOwnerName_KeyPress;
            txtOwnerContactNo.KeyPress += txtOwnerContactNo_KeyPress;
            txtOwnerContactNo.Leave += txtOwnerContactNo_Leave;
            txtWeight.KeyPress += txtWeight_KeyPress;
            txtWeight.Leave += txtWeight_Leave;

            // Populate the age textbox once immediately
            dtpDOB_ValueChanged(dtBday, EventArgs.Empty);

            // Enforce DropDownList for combos and populate gender options if needed
            cmbSpecies.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBreeds.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;

            // Optionally populate gender choices if Designer left it empty
            if (cmbGender.Items.Count == 0)
            {
                cmbGender.Items.AddRange(new[] { "Male", "Female", "Unknown" });
                cmbGender.SelectedIndex = -1;
            }

            // Keep species/breed selection default behavior (you already populate breeds on species change)
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
    "Bernese Mountain Dog", "Akita", "Shiba Inu", "Dalmatian",
    "Australian Cattle Dog", "Cane Corso", "Weimaraner", "Vizsla",
    "Belgian Malinois", "Bichon Frise", "Maltese", "Saint Bernard",
    "Rhodesian Ridgeback", "West Highland White Terrier", "Bloodhound",
    "Bull Terrier", "Samoyed", "Papillon", "Portuguese Water Dog",
    "Cairn Terrier", "Irish Setter", "Soft Coated Wheaten Terrier",
    "Alaskan Malamute", "Airedale Terrier", "Whippet", "Staffordshire Bull Terrier",
    "English Springer Spaniel", "Old English Sheepdog", "Cardigan Welsh Corgi",
    "Chow Chow", "Greater Swiss Mountain Dog", "Afghan Hound",
    "Pekingese", "Basenji", "Italian Greyhound", "Chinese Shar-Pei",
    "Flat-Coated Retriever", "Chesapeake Bay Retriever", "Jack Russell Terrier",
    "Collie", "Shih Poo", "Goldendoodle", "Labradoodle", "Cockapoo",
    "Cavapoo", "Schnoodle", "Bernedoodle", "Australian Labradoodle",
    "Lhasa Apso", "American Eskimo Dog", "Bouvier des Flandres",
    "Finnish Spitz", "Kuvasz", "Keeshond", "Saluki", "Greyhound",
    "Irish Wolfhound", "Scottish Terrier", "Norwich Terrier", "Norfolk Terrier"
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
    "Chartreux", "Korat", "Ocicat", "Singapura", "Havana Brown",
    "Ragamuffin", "Selkirk Rex", "LaPerm", "Egyptian Mau",
    "American Curl", "Bombay", "Munchkin", "Savannah",
    "Peterbald", "Toyger", "Snowshoe", "American Wirehair",
    "European Shorthair", "Pixie-Bob", "British Longhair",
    "Chausie", "California Spangled", "Cymric", "German Rex",
    "Javanese", "Nebelung", "Ragdoll Mink", "York Chocolate",
    "Colorpoint Shorthair", "Khao Manee", "Kurilian Bobtail",
    "Sokoke", "Thai", "Australian Mist", "Chantilly-Tiffany",
    "Dragon Li", "Donskoy", "Foldex", "Highlander",
    "Kinkalow", "Lykoi", "Minuet", "Ojos Azules",
    "Raas", "Sam Sawet", "Serengeti", "Suphalak"
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

        private void txtOwnerContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        // Enforce only digits and maximum length (11). Wired to txtOwnerContactNo.KeyPress
        private void txtOwnerContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (backspace, delete, arrow navigation)
            if (char.IsControl(e.KeyChar))
                return;

            // Only allow digits
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            var tb = sender as TextBox;
            if (tb == null)
                return;

            // If selection will replace some text, compute resulting length
            int newLength = tb.Text.Length - tb.SelectionLength + 1; // +1 for this key
            if (newLength > 11)
            {
                e.Handled = true;
            }
        }

        // When leaving the contact field ensure exactly 11 digits
        private void txtOwnerContactNo_Leave(object sender, EventArgs e)
        {
            var digits = (txtOwnerContactNo.Text ?? "").Trim();
            if (digits.Length == 0)
                return; // allow empty if optional

            if (digits.Length != 11 || !digits.All(char.IsDigit))
            {
                MessageBox.Show("Contact number must be exactly 11 digits.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOwnerContactNo.Focus();
                txtOwnerContactNo.SelectAll();
            }
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            // If user chose manual age entry, do not auto-calculate
            if (chkManualAge != null && chkManualAge.Checked)
                return;

            DateTime dob = dtBday.Value;
            DateTime today = DateTime.Today;

            // Calculate age
            age = today.Year - dob.Year;

            // Adjust if birthday hasn't occurred this year yet
            if (dob.Date > today.AddYears(-age))
            {
                age--;
            }

            // Display age in textbox
            txtAge.Text = age.ToString();

            // Optional: Show age in years and months for young pets
            if (age < 2)
            {
                int months = (today.Year - dob.Year) * 12 + today.Month - dob.Month;
                if (today.Day < dob.Day)
                    months--;

                txtAge.Text = $"{age} year(s), {months % 12} month(s)";
            }
        }

        // Now allow digits when manual mode is enabled; don't show messagebox
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow digits and backspace only
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        // Owner name: allow letters, spaces and basic control characters (backspace)
        private void txtOwnerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            // Allow letters and spaces only
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Replace txtWeight_KeyPress with culture-aware decimal handling
        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            var tb = sender as TextBox;
            if (tb == null)
            {
                e.Handled = true;
                return;
            }

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Allow one decimal separator using current culture
            var decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            char decChar = decSep.Length > 0 ? decSep[0] : '.';

            if (e.KeyChar == decChar)
            {
                if (tb.Text.Contains(decChar))
                    e.Handled = true;
                else if (tb.SelectionLength == tb.Text.Length && tb.SelectionLength > 0) // replacing all text with decimal char
                    e.Handled = true;
                return;
            }

            e.Handled = true;
        }

        private void txtWeight_Leave(object sender, EventArgs e)
        {
            var text = (txtWeight.Text ?? "").Trim();
            if (text.Length == 0)
                return;

            if (!decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal weight))
            {
                MessageBox.Show("Please enter a valid numeric weight.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWeight.Focus();
                txtWeight.SelectAll();
                return;
            }

            if (weight > MAX_WEIGHT_KG)
            {
                MessageBox.Show($"Weight cannot exceed {MAX_WEIGHT_KG} kg.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWeight.Text = MAX_WEIGHT_KG.ToString(CultureInfo.InvariantCulture);
                txtWeight.Focus();
                txtWeight.SelectAll();
            }
        }

        private void chkManualAge_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManualAge == null)
                return;

            bool manual = chkManualAge.Checked;

            // When manual, enable txtAge for input and disable the date picker
            txtAge.ReadOnly = !manual;
            dtBday.Enabled = !manual;

            if (!manual)
            {
                // Switch back to DOB mode and recalc
                dtpDOB_ValueChanged(dtBday, EventArgs.Empty);
            }
            else
            {
                // Clear age field to let user type
                txtAge.Text = "";
                age = 0;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Determine age (use manual if checked)
            if (chkManualAge != null && chkManualAge.Checked)
            {
                if (!int.TryParse(txtAge.Text, out age))
                {
                    MessageBox.Show("Please enter a valid numeric age.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Parse weight (optional)
            decimal? weight = null;
            var weightText = (txtWeight.Text ?? "").Trim();
            if (weightText.Length > 0 && decimal.TryParse(weightText, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out decimal w))
            {
                weight = w;
            }

            // Convert image to bytes (optional)
            byte[]? imageBytes = null;
            if (pictureBox1.Image != null)
            {
                using var ms = new System.IO.MemoryStream();
                // Save as PNG to preserve transparency where applicable
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageBytes = ms.ToArray();
            }

            var pet = new VeterinarySystem.Models.PetRecord
            {
                PetName = txtPetName.Text.Trim(),
                PetSpecies = cmbSpecies.SelectedItem as string ?? cmbSpecies.Text,
                PetBreed = cmbBreeds.SelectedItem as string ?? cmbBreeds.Text,
                PetGender = cmbGender.SelectedItem as string ?? cmbGender.Text,
                DateOfBirth = dtBday.Enabled ? dtBday.Value.Date : (DateTime?)null,
                PetAge = age,
                PetWeight = weight,
                MedicalHistory = txtMedicalHistory.Text,
                PetImage = imageBytes,
                OwnerName = txtOwnerName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                ContactNo = txtOwnerContactNo.Text.Trim(),
                IsActive = true
            };

            using var confirm = new confirmEntry(pet);
            var result = confirm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                // optionally clear the form or close
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}