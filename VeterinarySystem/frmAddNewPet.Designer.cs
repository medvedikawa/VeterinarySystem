namespace VeterinarySystem
{
    partial class frmAddNewPet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            txtPetName = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            lblYorM = new Label();
            txtUnit = new Label();
            label10 = new Label();
            dtBday = new DateTimePicker();
            txtAddress = new TextBox();
            label9 = new Label();
            txtOwnerContactNo = new TextBox();
            label8 = new Label();
            txtOwnerName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            txtAge = new TextBox();
            label5 = new Label();
            txtMedicalHistory = new RichTextBox();
            label4 = new Label();
            txtWeight = new TextBox();
            cmbBreeds = new ComboBox();
            label3 = new Label();
            cmbSpecies = new ComboBox();
            label2 = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            openFileDialog1 = new OpenFileDialog();
            btnUpload = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(26, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(152, 153);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtPetName
            // 
            txtPetName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPetName.Location = new Point(157, 38);
            txtPetName.Name = "txtPetName";
            txtPetName.Size = new Size(213, 29);
            txtPetName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 42);
            label1.Name = "label1";
            label1.Size = new Size(84, 21);
            label1.TabIndex = 2;
            label1.Text = "Pet Name:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(237, 219, 186);
            panel1.Controls.Add(lblYorM);
            panel1.Controls.Add(txtUnit);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(dtBday);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtOwnerContactNo);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtOwnerName);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtAge);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtMedicalHistory);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtWeight);
            panel1.Controls.Add(cmbBreeds);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbSpecies);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtPetName);
            panel1.Location = new Point(204, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(796, 522);
            panel1.TabIndex = 3;
            // 
            // lblYorM
            // 
            lblYorM.AutoSize = true;
            lblYorM.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblYorM.ForeColor = Color.SaddleBrown;
            lblYorM.Location = new Point(616, 97);
            lblYorM.Name = "lblYorM";
            lblYorM.Size = new Size(0, 20);
            lblYorM.TabIndex = 24;
            // 
            // txtUnit
            // 
            txtUnit.AutoSize = true;
            txtUnit.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtUnit.ForeColor = Color.SaddleBrown;
            txtUnit.Location = new Point(615, 152);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(24, 20);
            txtUnit.TabIndex = 23;
            txtUnit.Text = "kg";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(470, 97);
            label10.Name = "label10";
            label10.Size = new Size(44, 21);
            label10.TabIndex = 22;
            label10.Text = "Age:";
            // 
            // dtBday
            // 
            dtBday.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtBday.Location = new Point(528, 40);
            dtBday.Name = "dtBday";
            dtBday.Size = new Size(222, 25);
            dtBday.TabIndex = 21;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.Location = new Point(523, 473);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(213, 29);
            txtAddress.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(523, 449);
            label9.Name = "label9";
            label9.Size = new Size(74, 21);
            label9.TabIndex = 19;
            label9.Text = "Address:";
            // 
            // txtOwnerContactNo
            // 
            txtOwnerContactNo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOwnerContactNo.Location = new Point(285, 473);
            txtOwnerContactNo.Name = "txtOwnerContactNo";
            txtOwnerContactNo.Size = new Size(213, 29);
            txtOwnerContactNo.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(285, 449);
            label8.Name = "label8";
            label8.Size = new Size(153, 21);
            label8.TabIndex = 17;
            label8.Text = "Owner Contact No.:";
            // 
            // txtOwnerName
            // 
            txtOwnerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOwnerName.Location = new Point(48, 473);
            txtOwnerName.Name = "txtOwnerName";
            txtOwnerName.Size = new Size(213, 29);
            txtOwnerName.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(48, 449);
            label7.Name = "label7";
            label7.Size = new Size(63, 21);
            label7.TabIndex = 15;
            label7.Text = "Owner:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(407, 42);
            label6.Name = "label6";
            label6.Size = new Size(107, 21);
            label6.TabIndex = 14;
            label6.Text = "Date of Birth:";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAge.Location = new Point(528, 93);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(82, 29);
            txtAge.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(46, 205);
            label5.Name = "label5";
            label5.Size = new Size(130, 21);
            label5.TabIndex = 11;
            label5.Text = "Medical History:";
            // 
            // txtMedicalHistory
            // 
            txtMedicalHistory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMedicalHistory.Location = new Point(46, 233);
            txtMedicalHistory.Name = "txtMedicalHistory";
            txtMedicalHistory.Size = new Size(693, 202);
            txtMedicalHistory.TabIndex = 10;
            txtMedicalHistory.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(447, 151);
            label4.Name = "label4";
            label4.Size = new Size(67, 21);
            label4.TabIndex = 9;
            label4.Text = "Weight:";
            // 
            // txtWeight
            // 
            txtWeight.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWeight.Location = new Point(527, 147);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(83, 29);
            txtWeight.TabIndex = 8;
            // 
            // cmbBreeds
            // 
            cmbBreeds.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBreeds.FormattingEnabled = true;
            cmbBreeds.Location = new Point(157, 146);
            cmbBreeds.Name = "cmbBreeds";
            cmbBreeds.Size = new Size(213, 29);
            cmbBreeds.TabIndex = 7;
            cmbBreeds.SelectedIndexChanged += cmbBreeds_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(53, 150);
            label3.Name = "label3";
            label3.Size = new Size(85, 21);
            label3.TabIndex = 6;
            label3.Text = "Pet Breed:";
            // 
            // cmbSpecies
            // 
            cmbSpecies.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSpecies.FormattingEnabled = true;
            cmbSpecies.Location = new Point(157, 91);
            cmbSpecies.Name = "cmbSpecies";
            cmbSpecies.Size = new Size(213, 29);
            cmbSpecies.TabIndex = 5;
            cmbSpecies.SelectedIndexChanged += cmbSpecies_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(41, 95);
            label2.Name = "label2";
            label2.Size = new Size(97, 21);
            label2.TabIndex = 4;
            label2.Text = "Pet Species:";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(64, 120, 170);
            btnConfirm.FlatStyle = FlatStyle.Popup;
            btnConfirm.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = SystemColors.ButtonHighlight;
            btnConfirm.Location = new Point(51, 413);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(96, 37);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Brown;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(51, 478);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 37);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnUpload
            // 
            btnUpload.BackColor = SystemColors.ControlLight;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpload.Location = new Point(46, 196);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(113, 28);
            btnUpload.TabIndex = 6;
            btnUpload.Text = "Upload Image";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // frmAddNewPet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginImage;
            ClientSize = new Size(1028, 573);
            Controls.Add(btnUpload);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Name = "frmAddNewPet";
            Text = "Add New Record";
            Load += frmAddNewPet_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtPetName;
        private Label label1;
        private Panel panel1;
        private Button btnConfirm;
        private Button btnCancel;
        private Label label2;
        private OpenFileDialog openFileDialog1;
        private ComboBox cmbSpecies;
        private ComboBox cmbBreeds;
        private Label label3;
        private Label label4;
        private TextBox txtWeight;
        private Label label7;
        private Label label5;
        private RichTextBox txtMedicalHistory;
        private TextBox txtOwnerName;
        private TextBox txtAddress;
        private Label label9;
        private TextBox txtOwnerContactNo;
        private Label label8;
        private DateTimePicker dtBday;
        private Label label6;
        private TextBox txtAge;
        private Label lblYorM;
        private Label txtUnit;
        private Label label10;
        private Button btnUpload;
    }
}