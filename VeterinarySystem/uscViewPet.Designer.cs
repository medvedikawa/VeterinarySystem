namespace VeterinarySystem
{
    partial class uscViewPet
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBack = new Button();
            panelMain = new Panel();
            txtContact = new Label();
            label12 = new Label();
            txtAddress = new Label();
            label8 = new Label();
            txtOwner = new Label();
            label3 = new Label();
            label11 = new Label();
            panel1 = new Panel();
            txtMedHist = new Label();
            label7 = new Label();
            txtWeight = new Label();
            label6 = new Label();
            txtDob = new Label();
            label5 = new Label();
            txtPetAge = new Label();
            label4 = new Label();
            btnViewHistory = new Button();
            txtLastApp = new Label();
            txtUpcomingApp = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPetType = new Label();
            lblPetName = new Label();
            pbPetPicture = new PictureBox();
            btnEdit = new Button();
            btnDelete = new Button();
            labelGenderLabel = new Label();
            txtGender = new Label();
            panelMain.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPetPicture).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatStyle = FlatStyle.Popup;
            btnBack.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(25, 11);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(138, 44);
            btnBack.TabIndex = 0;
            btnBack.Text = "< Return";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(237, 219, 186);
            panelMain.Controls.Add(labelGenderLabel);
            panelMain.Controls.Add(txtGender);
            panelMain.Controls.Add(txtContact);
            panelMain.Controls.Add(label12);
            panelMain.Controls.Add(txtAddress);
            panelMain.Controls.Add(label8);
            panelMain.Controls.Add(txtOwner);
            panelMain.Controls.Add(label3);
            panelMain.Controls.Add(label11);
            panelMain.Controls.Add(panel1);
            panelMain.Controls.Add(label7);
            panelMain.Controls.Add(txtWeight);
            panelMain.Controls.Add(label6);
            panelMain.Controls.Add(txtDob);
            panelMain.Controls.Add(label5);
            panelMain.Controls.Add(txtPetAge);
            panelMain.Controls.Add(label4);
            panelMain.Controls.Add(btnViewHistory);
            panelMain.Controls.Add(txtLastApp);
            panelMain.Controls.Add(txtUpcomingApp);
            panelMain.Controls.Add(label2);
            panelMain.Controls.Add(label1);
            panelMain.Controls.Add(txtPetType);
            panelMain.Controls.Add(lblPetName);
            panelMain.Controls.Add(pbPetPicture);
            panelMain.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panelMain.Location = new Point(0, 65);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1233, 597);
            panelMain.TabIndex = 1;
            // 
            // txtContact
            // 
            txtContact.AutoSize = true;
            txtContact.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContact.Location = new Point(924, 511);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(101, 30);
            txtContact.TabIndex = 30;
            txtContact.Text = "09099999";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(921, 478);
            label12.Name = "label12";
            label12.Size = new Size(128, 30);
            label12.TabIndex = 29;
            label12.Text = "Contact No.";
            // 
            // txtAddress
            // 
            txtAddress.AutoSize = true;
            txtAddress.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.Location = new Point(675, 511);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(110, 30);
            txtAddress.TabIndex = 28;
            txtAddress.Text = "21st Street";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(672, 478);
            label8.Name = "label8";
            label8.Size = new Size(90, 30);
            label8.TabIndex = 27;
            label8.Text = "Address";
            // 
            // txtOwner
            // 
            txtOwner.AutoSize = true;
            txtOwner.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOwner.Location = new Point(457, 511);
            txtOwner.Name = "txtOwner";
            txtOwner.Size = new Size(35, 30);
            txtOwner.TabIndex = 26;
            txtOwner.Text = "00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(454, 478);
            label3.Name = "label3";
            label3.Size = new Size(76, 30);
            label3.TabIndex = 25;
            label3.Text = "Owner";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.SaddleBrown;
            label11.Location = new Point(584, 106);
            label11.Name = "label11";
            label11.Size = new Size(24, 20);
            label11.TabIndex = 24;
            label11.Text = "kg";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtMedHist);
            panel1.Location = new Point(454, 209);
            panel1.Name = "panel1";
            panel1.Size = new Size(625, 213);
            panel1.TabIndex = 15;
            // 
            // txtMedHist
            // 
            txtMedHist.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMedHist.Location = new Point(0, 0);
            txtMedHist.Name = "txtMedHist";
            txtMedHist.Size = new Size(625, 213);
            txtMedHist.TabIndex = 12;
            txtMedHist.Text = "Empty!";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(454, 164);
            label7.Name = "label7";
            label7.Size = new Size(163, 30);
            label7.TabIndex = 14;
            label7.Text = "Medical History";
            // 
            // txtWeight
            // 
            txtWeight.AutoSize = true;
            txtWeight.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWeight.Location = new Point(546, 99);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(35, 30);
            txtWeight.TabIndex = 13;
            txtWeight.Text = "00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(454, 99);
            label6.Name = "label6";
            label6.Size = new Size(86, 30);
            label6.TabIndex = 12;
            label6.Text = "Weight:";
            // 
            // txtDob
            // 
            txtDob.AutoSize = true;
            txtDob.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDob.Location = new Point(803, 32);
            txtDob.Name = "txtDob";
            txtDob.Size = new Size(95, 30);
            txtDob.TabIndex = 11;
            txtDob.Text = "00/00/00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(655, 32);
            label5.Name = "label5";
            label5.Size = new Size(142, 30);
            label5.TabIndex = 10;
            label5.Text = "Date of Birth:";
            // 
            // txtPetAge
            // 
            txtPetAge.AutoSize = true;
            txtPetAge.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPetAge.Location = new Point(516, 32);
            txtPetAge.Name = "txtPetAge";
            txtPetAge.Size = new Size(35, 30);
            txtPetAge.TabIndex = 9;
            txtPetAge.Text = "00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(454, 32);
            label4.Name = "label4";
            label4.Size = new Size(56, 30);
            label4.TabIndex = 8;
            label4.Text = "Age:";
            // 
            // btnViewHistory
            // 
            btnViewHistory.BackColor = Color.FromArgb(224, 224, 224);
            btnViewHistory.FlatStyle = FlatStyle.Flat;
            btnViewHistory.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewHistory.Location = new Point(129, 523);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new Size(127, 31);
            btnViewHistory.TabIndex = 7;
            btnViewHistory.Text = "View History";
            btnViewHistory.UseVisualStyleBackColor = false;
            btnViewHistory.Click += btnViewHistory_Click;
            // 
            // txtLastApp
            // 
            txtLastApp.AutoSize = true;
            txtLastApp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastApp.Location = new Point(129, 478);
            txtLastApp.Name = "txtLastApp";
            txtLastApp.Size = new Size(42, 21);
            txtLastApp.TabIndex = 6;
            txtLastApp.Text = "Date";
            // 
            // txtUpcomingApp
            // 
            txtUpcomingApp.AutoSize = true;
            txtUpcomingApp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUpcomingApp.Location = new Point(129, 393);
            txtUpcomingApp.Name = "txtUpcomingApp";
            txtUpcomingApp.Size = new Size(42, 21);
            txtUpcomingApp.TabIndex = 5;
            txtUpcomingApp.Text = "Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(129, 360);
            label2.Name = "label2";
            label2.Size = new Size(186, 21);
            label2.TabIndex = 4;
            label2.Text = "Upcoming Appointment:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(129, 445);
            label1.Name = "label1";
            label1.Size = new Size(143, 21);
            label1.TabIndex = 3;
            label1.Text = "Last Appointment:";
            // 
            // txtPetType
            // 
            txtPetType.Anchor = AnchorStyles.None;
            txtPetType.AutoSize = true;
            txtPetType.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPetType.Location = new Point(172, 313);
            txtPetType.Name = "txtPetType";
            txtPetType.Size = new Size(132, 25);
            txtPetType.TabIndex = 2;
            txtPetType.Text = "Animal, Breed";
            txtPetType.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPetName
            // 
            lblPetName.AutoSize = true;
            lblPetName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPetName.Location = new Point(195, 274);
            lblPetName.Name = "lblPetName";
            lblPetName.Size = new Size(87, 32);
            lblPetName.TabIndex = 1;
            lblPetName.Text = "Buddy";
            lblPetName.TextAlign = ContentAlignment.TopCenter;
            // 
            // pbPetPicture
            // 
            pbPetPicture.ErrorImage = Properties.Resources.placeholderPetImage;
            pbPetPicture.Image = Properties.Resources.placeholderPetImage;
            pbPetPicture.InitialImage = Properties.Resources.placeholderPetImage;
            pbPetPicture.Location = new Point(126, 23);
            pbPetPicture.Name = "pbPetPicture";
            pbPetPicture.Size = new Size(237, 240);
            pbPetPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPetPicture.TabIndex = 0;
            pbPetPicture.TabStop = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(64, 120, 170);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatStyle = FlatStyle.Popup;
            btnEdit.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(995, 11);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(138, 44);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit Info";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Brown;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Image = Properties.Resources.assets_2_;
            btnDelete.Location = new Point(1146, 11);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(63, 44);
            btnDelete.TabIndex = 3;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // labelGenderLabel
            // 
            labelGenderLabel.AutoSize = true;
            labelGenderLabel.BackColor = Color.Transparent;
            labelGenderLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelGenderLabel.Location = new Point(655, 99);
            labelGenderLabel.Name = "labelGenderLabel";
            labelGenderLabel.Size = new Size(89, 30);
            labelGenderLabel.TabIndex = 23;
            labelGenderLabel.Text = "Gender:";
            // 
            // txtGender
            // 
            txtGender.AutoSize = true;
            txtGender.BackColor = Color.Transparent;
            txtGender.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGender.Location = new Point(750, 99);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(63, 30);
            txtGender.TabIndex = 24;
            txtGender.Text = "blank";
            // 
            // uscViewPet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 166, 74);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnBack);
            Controls.Add(panelMain);
            Name = "uscViewPet";
            Size = new Size(1233, 662);
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPetPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnBack;
        private Panel panelMain;
        private Label lblPetName;
        private PictureBox pbPetPicture;
        private Label label1;
        private Label txtPetType;
        private Button btnViewHistory;
        private Label txtLastApp;
        private Label txtUpcomingApp;
        private Label label2;
        private Label label6;
        private Label txtDob;
        private Label label5;
        private Label txtPetAge;
        private Label label4;
        private Label txtWeight;
        private Button btnEdit;
        private Button btnDelete;
        private Label label7;
        private Panel panel1;
        private Label txtMedHist;
        private Label label11;
        private Label txtContact;
        private Label label12;
        private Label txtAddress;
        private Label label8;
        private Label txtOwner;
        private Label label3;
        private Label labelGenderLabel;
        private Label txtGender;
    }
}
