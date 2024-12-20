using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Classes;

namespace WinFormsApp1.Forms
{
    /// <summary>
    /// Form to add a reservation to a property.
    /// </summary>
    public partial class AddReservation : Form
    {
        /// <summary>
        /// List of customers for selection in the reservation form.
        /// </summary>
        List<Customer> CustomerList = [];

        /// <summary>
        /// Property ID for the current property being reserved.
        /// </summary>
        private int PropertyID;

        /// <summary>
        /// Price per night for the property.
        /// </summary>
        private int PricePerNight;

        /// <summary>
        /// The ID of the selected customer.
        /// </summary>
        private int SelectedCustomerID = -1;

        /// <summary>
        /// Event triggered when a reservation is added successfully.
        /// </summary>
        public event EventHandler ReservationAdded;

        /// <summary>
        /// Initializes the AddReservation form with property ID, price per night, and property name.
        /// </summary>
        /// <param name="propertyID">The ID of the property being reserved.</param>
        /// <param name="pricePerNight">The price per night for the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public AddReservation(int propertyID, int pricePerNight, string propertyName)
        {
            InitializeComponent();
            PropertyID = propertyID;
            PricePerNight = pricePerNight;
            pricePerNightTextBox.Text = PricePerNight.ToString();
            propertyNameLabel.Text = propertyName;

            CustomerList = CustomerManager.LoadAllCustomers();

            foreach (Customer c in CustomerList)
            {
                listBox1.Items.Add(c.Name);
            }
        }

        #region Date Picker Events

        /// <summary>
        /// Event handler for when the check-in date is changed.
        /// Updates the total price based on check-in and check-out dates.
        /// </summary>
        private void checkInDatePicker_ValueChanged(object sender, EventArgs e)
        {
            int totalPrice = ReservationManager.CalculateTotalPrice(checkInDatePicker.Value, checkOutDatePicker.Value, pricePerNightTextBox.Text);
            totalPriceTextBox.Text = totalPrice.ToString();
        }

        /// <summary>
        /// Event handler for when the check-out date is changed.
        /// Updates the total price based on check-in and check-out dates.
        /// </summary>
        private void checkOutDatePicker_ValueChanged(object sender, EventArgs e)
        {
            int totalPrice = ReservationManager.CalculateTotalPrice(checkInDatePicker.Value, checkOutDatePicker.Value, pricePerNightTextBox.Text);
            totalPriceTextBox.Text = totalPrice.ToString();
        }



        #endregion

        #region Customer Management

        /// <summary>
        /// Toggles the UI for adding a new customer.
        /// </summary>
        private void RefreshCustomerUI()
        {
            clientNameTextBox.ReadOnly = !clientNameTextBox.ReadOnly;
            clientContactTextBox.ReadOnly = !clientContactTextBox.ReadOnly;
            saveNewClientButton.Enabled = !saveNewClientButton.Enabled;
            newClientButton.Text = (clientContactTextBox.ReadOnly == false) ? "Cancelar" : "Novo";
        }

        /// <summary>
        /// Event handler for clicking the new customer button.
        /// Enables or disables the customer UI for creating a new client.
        /// </summary>
        private void newClientButton_Click(object sender, EventArgs e)
        {
            RefreshCustomerUI();
        }

        /// <summary>
        /// Event handler for saving a new customer.
        /// Adds the new customer to the list if saved successfully.
        /// </summary>
        private void saveNewClientButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                Id = -1,
                Name = clientNameTextBox.Text,
                Contact = clientContactTextBox.Text
            };
            int newId = customer.Save();
            customer.Id = newId;

            if (newId != -1)
            {
                listBox1.Items.Add(customer.Name);
                CustomerList.Add(customer);
                RefreshCustomerUI();
            }
            else
            {
                MessageBox.Show("Error saving client", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for selecting a customer from the list box.
        /// Displays the selected customer's details in the text fields.
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var c in CustomerList)
            {
                if (c.Name == listBox1.GetItemText(listBox1.SelectedItem))
                {
                    clientNameTextBox.Text = c.Name;
                    clientContactTextBox.Text = c.Contact;
                    SelectedCustomerID = c.Id;
                }
            }
        }

        #endregion

        #region Reservation Management

        /// <summary>
        /// Adds the reservation to the database and closes the form.
        /// </summary>
        private void addReservationToDatabase()
        {
            Reservation reservation = new Reservation
            {
                Id = -1,
                TotalPrice = Convert.ToInt32(totalPriceTextBox.Text),
                PropertyID = PropertyID,
                CheckInDate = DateOnly.FromDateTime(checkInDatePicker.Value),
                CheckOutDate = DateOnly.FromDateTime(checkOutDatePicker.Value),
                CustomerID = SelectedCustomerID
            };
            int newID = reservation.Save();
            if (newID != -1)
            {
                reservation.Id = newID;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error saving reservation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for saving a reservation.
        /// Invokes the ReservationAdded event after saving.
        /// </summary>
        private void saveButton_Click_1(object sender, EventArgs e)
        {
            TimeSpan dateDifference = checkOutDatePicker.Value - checkInDatePicker.Value;
            int totalDays = (int)dateDifference.TotalDays;

            if (totalDays > 0)
            {
                addReservationToDatabase();
                ReservationAdded?.Invoke(this, EventArgs.Empty);
            } else
            {
                MessageBox.Show("Invalid Date Selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #endregion
    }
}
