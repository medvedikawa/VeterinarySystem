namespace VeterinarySystem
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainDash = new FrmMainDashboard();
            mainDash.Closed += (s, args) => this.Close();
            mainDash.Show();
        }
    }
}