using WinFormsApp1.Classes;
using WinFormsApp1.Forms;

namespace WinFormsApp1
{
    /// <summary>
    /// Form for user login within the tourism management system.
    /// </summary>
    public partial class login : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="login"/> form.
        /// </summary>
        public login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the login button click.
        /// Attempts to authenticate the user based on the entered username and password.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();

            if (user.Load(textBoxUsername.Text))
            {
                if (textBoxPassword.Text == user.Password)
                {
                    PropertyManagement window = new PropertyManagement(user.Id);
                    window.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Wrong User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
