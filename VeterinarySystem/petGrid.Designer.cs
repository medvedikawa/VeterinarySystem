namespace VeterinarySystem
{
    partial class petGrid
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
            pictureBox1 = new PictureBox();
            lblNameAge = new Label();
            lblSpeciesBreed = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = Properties.Resources.placeholderPetImage;
            pictureBox1.Image = Properties.Resources.placeholderPetImage;
            pictureBox1.Location = new Point(34, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(121, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblNameAge
            // 
            lblNameAge.AutoSize = true;
            lblNameAge.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameAge.Location = new Point(57, 142);
            lblNameAge.Name = "lblNameAge";
            lblNameAge.Size = new Size(75, 21);
            lblNameAge.TabIndex = 1;
            lblNameAge.Text = "Buddy, 2";
            // 
            // lblSpeciesBreed
            // 
            lblSpeciesBreed.AutoSize = true;
            lblSpeciesBreed.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSpeciesBreed.Location = new Point(38, 169);
            lblSpeciesBreed.Name = "lblSpeciesBreed";
            lblSpeciesBreed.Size = new Size(112, 21);
            lblSpeciesBreed.TabIndex = 2;
            lblSpeciesBreed.Text = "Animal, Breed";
            // 
            // petGrid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSpeciesBreed);
            Controls.Add(lblNameAge);
            Controls.Add(pictureBox1);
            Name = "petGrid";
            Size = new Size(190, 208);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblNameAge;
        private Label lblSpeciesBreed;
    }
}
