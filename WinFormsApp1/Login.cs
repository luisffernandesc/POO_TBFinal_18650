namespace WinFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "ola" && textBoxUsername.Text == "Luis")
            {
                management window = new management();
                window.Show();
            }
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
