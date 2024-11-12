using WinFormsApp1.Classes;

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
            User user = new User();

            if (user.Load(textBoxUsername.Text))
            {
                if (textBoxPassword.Text == user.Password) 
                {
                    PropertyManagement window = new PropertyManagement();
                    window.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Wrong User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }
    }
}
