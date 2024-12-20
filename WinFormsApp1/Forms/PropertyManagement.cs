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
        #region Fields
        private int UserID;

        /// <summary>
        /// List of properties owned by the user.
        /// </summary>
        List<Property> UserProperties = new List<Property>();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyManagement"/> form.
        /// Loads user properties and property types, and populates the list and combo boxes.
        /// </summary>
        /// <param name="userID">The ID of the user who owns the properties.</param>
        public PropertyManagement(int userID)
        {
            InitializeComponent();
            this.UserID = userID;

            UserProperties = PropertiesManager.LoadUserProperties(UserID);

            foreach (Property p in UserProperties)
            {
                listBox1.Items.Add(p.Name);
            }

            List<PropertyTypes> UserPropertyTypes = PropertiesManager.LoadTypes();
            comboBoxTypes.DataSource = UserPropertyTypes;
            comboBoxTypes.ValueMember = "Id";
            comboBoxTypes.DisplayMember = "Name";
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Event handler for the selection change in the list box.
        /// Loads and displays the details of the selected property.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var p in UserProperties)
            {
                if (p.Name == listBox1.GetItemText(listBox1.SelectedItem))
                {
                    List<Reservation> reservationList = ReservationManager.LoadReservationProperties(p.Id);

                    textBoxNameRental.Text = p.Name;
                    textBoxAddress.Text = p.Address;
                    textBoxPrice.Text = p.PricePerNight.ToString();
                    comboBoxTypes.SelectedValue = p.Type_ID;
                    propertyID.Text = p.Id.ToString();

                    dataGridView1.DataSource = reservationList;

                    dataGridView1.Columns[0].Visible = false; // Hides the Id column
                    dataGridView1.Columns[5].Visible = false; // Hides the PropertyID column
                }
            }
        }

        /// <summary>
        /// Event handler for the save button click.
        /// Updates the selected property with the modified values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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

        /// <summary>
        /// Event handler for when a reservation is added.
        /// Reloads the reservations for the selected property.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void AddReservation_ReservationAdded(object sender, EventArgs e)
        {
            int propertyId = Int32.Parse(propertyID.Text);

            List<Reservation> reservationList = ReservationManager.LoadReservationProperties(propertyId);

            dataGridView1.DataSource = null; 
            dataGridView1.DataSource = reservationList;

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns[0].Visible = false; // Hide the Id column
                dataGridView1.Columns[5].Visible = false; // Hide the PropertyID column
            }
        }

        /// <summary>
        /// Event handler for the add reservation button click.
        /// Opens the add reservation window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void addReservationButton_Click(object sender, EventArgs e)
        {
            AddReservation window = new AddReservation(Int32.Parse(propertyID.Text), Int32.Parse(textBoxPrice.Text), textBoxNameRental.Text);
            window.ReservationAdded += AddReservation_ReservationAdded;
            window.ShowDialog();
        }
        #endregion
    }
}
