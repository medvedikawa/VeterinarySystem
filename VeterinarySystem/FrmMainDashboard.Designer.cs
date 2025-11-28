namespace VeterinarySystem
{
    partial class FrmMainDashboard
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
            panel5 = new Panel();
            usrSidebar1 = new usrSidebar();
            panel1 = new Panel();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.Controls.Add(panel1);
            panel5.Controls.Add(usrSidebar1);
            panel5.Location = new Point(-1, -2);
            panel5.Name = "panel5";
            panel5.Size = new Size(1235, 662);
            panel5.TabIndex = 1;
            // 
            // usrSidebar1
            // 
            usrSidebar1.Location = new Point(0, 0);
            usrSidebar1.Name = "usrSidebar1";
            usrSidebar1.Size = new Size(1233, 662);
            usrSidebar1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(290, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(933, 656);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // FrmMainDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 660);
            Controls.Add(panel5);
            Name = "FrmMainDashboard";
            Text = "VetTrack";
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel5;
        private usrSidebar usrSidebar1;
        private Panel panel1;
    }
}