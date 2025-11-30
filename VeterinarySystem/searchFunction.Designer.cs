namespace VeterinarySystem
{
    partial class searchFunction
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
            panel1 = new Panel();
            btnBack = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(237, 219, 186);
            panel1.Controls.Add(btnBack);
            panel1.Location = new Point(-11, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1259, 70);
            panel1.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatStyle = FlatStyle.Popup;
            btnBack.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.FromArgb(94, 86, 81);
            btnBack.Location = new Point(31, 16);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(138, 44);
            btnBack.TabIndex = 1;
            btnBack.Text = "< Return";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Cooper Black", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(35, 31, 32);
            label1.Location = new Point(445, 179);
            label1.Name = "label1";
            label1.Size = new Size(285, 42);
            label1.TabIndex = 1;
            label1.Text = "Search for pet";
            // 
            // searchFunction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginImage;
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "searchFunction";
            Size = new Size(1233, 662);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnBack;
        private Label label1;
    }
}
