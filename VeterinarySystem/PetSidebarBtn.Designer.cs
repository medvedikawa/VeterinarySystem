namespace VeterinarySystem
{
    partial class PetSidebarBtn
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
            btnViewRecords = new Button();
            btnAdd = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnViewRecords
            // 
            btnViewRecords.FlatStyle = FlatStyle.Flat;
            btnViewRecords.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewRecords.Image = Properties.Resources.iconView;
            btnViewRecords.ImageAlign = ContentAlignment.MiddleLeft;
            btnViewRecords.Location = new Point(62, 95);
            btnViewRecords.Name = "btnViewRecords";
            btnViewRecords.Size = new Size(223, 67);
            btnViewRecords.TabIndex = 0;
            btnViewRecords.Text = "            View Records";
            btnViewRecords.UseVisualStyleBackColor = true;
            btnViewRecords.Click += btnViewRecords_Click;
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Image = Properties.Resources.Plus_Emoji__1_;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(62, 168);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(223, 67);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "           Add New Record";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Chocolate;
            pictureBox1.ErrorImage = Properties.Resources.PlainBG;
            pictureBox1.Image = Properties.Resources.forForm;
            pictureBox1.Location = new Point(-7, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(355, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // PetSidebarBtn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 242);
            Controls.Add(pictureBox1);
            Controls.Add(btnAdd);
            Controls.Add(btnViewRecords);
            Name = "PetSidebarBtn";
            Text = "Pet Sidebar";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnViewRecords;
        private Button btnAdd;
        private PictureBox pictureBox1;
    }
}