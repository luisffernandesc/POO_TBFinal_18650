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
            // Creates a new instance of the User class to handle authentication.
            User user = new User();

            // Loads user data based on the entered username.
            if (user.Load(textBoxUsername.Text))
            {
                // Checks if the entered password matches the user's password.
                if (textBoxPassword.Text == user.Password)
                {
                    // Opens the PropertyManagement form and hides the login form.
                    PropertyManagement window = new PropertyManagement(user.Id);
                    window.Show();
                    this.Hide();
                }
                else
                {
                    // Displays an error message if the password is incorrect.
                    MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Displays an error message if the username is incorrect or not found.
                MessageBox.Show("Wrong User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
