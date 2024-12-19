using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Classes;
using WinFormsApp1.Forms;

namespace WinFormsApp1
{
    /// <summary>
    /// Form for managing properties within the tourism management system.
    /// </summary>
    public partial class PropertyManagement : Form
    {

        private int UserID;
        /// <summary>
        /// List of properties owned by the user.
        /// </summary>
        List<Property> UserProperties = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyManagement"/> form.
        /// Loads user properties and property types, and populates the list and combo boxes.
        /// </summary>
        public PropertyManagement(int userID)
        {
            InitializeComponent();
            this.UserID = userID;
            UserProperties = PropertiesManager.LoadUserProperties(UserID); // Loads properties for a specific user (user ID 1 in this case)

            // Populates the list box with property names.
            foreach (Property p in UserProperties)
            {
                listBox1.Items.Add(p.Name);
            }

            // Loads property types and sets them as the data source for the combo box.
            List<PropertyTypes> UserPropertyTypes = PropertiesManager.LoadTypes();
            comboBoxTypes.DataSource = UserPropertyTypes;
            comboBoxTypes.ValueMember = "Id";
            comboBoxTypes.DisplayMember = "Name";
        }

        /// <summary>
        /// Event handler for the selection change in the list box.
        /// Loads and displays the details of the selected property.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Iterates through the user's properties to find the selected property.
            foreach (var p in UserProperties)
            {
                if (p.Name == listBox1.GetItemText(listBox1.SelectedItem))
                {
                    // Loads reservations for the selected property.
                    List<Reservation> reservationList = ReservationManager.LoadReservationProperties(p.Id);

                    // Displays property details in text boxes and combo box.
                    textBoxNameRental.Text = p.Name;
                    textBoxAddress.Text = p.Address;
                    textBoxPrice.Text = p.PricePerNight.ToString();
                    comboBoxTypes.SelectedValue = p.Type_ID;
                    propertyID.Text = p.Id.ToString();

                    // Sets the reservation list as the data source for the data grid view.
                    dataGridView1.DataSource = reservationList;

                    // Hides specific columns in the data grid view for better display.
                    dataGridView1.Columns[0].Visible = false; // Hides the Id column
                    dataGridView1.Columns[5].Visible = false; // Hides the PropertyID column
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            foreach (Property p in UserProperties)
            {
                if (p.Id == Int32.Parse(propertyID.Text))
                {
                    p.Name = textBoxNameRental.Text;
                    p.Address = textBoxAddress.Text;
                    p.PricePerNight = Int32.Parse(textBoxPrice.Text);
                    p.Type_ID = Convert.ToInt32(comboBoxTypes.SelectedValue);
                    if (p.Save())
                    {
                        listBox1.Items[listBox1.SelectedIndex] = p.Name;
                    }
                }
            }

        }

        private void addReservationButton_Click(object sender, EventArgs e)
        {
            AddReservation window = new AddReservation(Int32.Parse(propertyID.Text), Int32.Parse(textBoxPrice.Text), textBoxNameRental.Text);

            window.ShowDialog();
        }
    }
}
