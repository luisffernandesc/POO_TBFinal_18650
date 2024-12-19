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

namespace WinFormsApp1.Forms
{
    public partial class AddReservation : Form
    {
        List<Customer> CustomerList = [];
        
        private int PropertyID;

        private int PricePerNight;

        private int SelectedCustomerID = -1;
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

        private void checkInDatePicker_ValueChanged(object sender, EventArgs e)
        {

            int totalPrice = ReservationManager.CalculateTotalPrice(checkInDatePicker.Value, checkOutDatePicker.Value, pricePerNightTextBox.Text);

            totalPriceTextBox.Text = totalPrice.ToString();

        }

        private void checkOutDatePicker_ValueChanged(object sender, EventArgs e)
        {
            int totalPrice = ReservationManager.CalculateTotalPrice(checkInDatePicker.Value, checkOutDatePicker.Value, pricePerNightTextBox.Text);

            totalPriceTextBox.Text = totalPrice.ToString();
        }

        private void pricePerNightTextBox_TextChanged(object sender, EventArgs e)
        {
            int totalPrice = ReservationManager.CalculateTotalPrice(checkInDatePicker.Value, checkOutDatePicker.Value, pricePerNightTextBox.Text);

            totalPriceTextBox.Text = totalPrice.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.Id = -1;
            reservation.TotalPrice= Convert.ToInt32(totalPriceTextBox.Text);
            reservation.PropertyID = PropertyID;
            reservation.CheckInDate = DateOnly.FromDateTime(checkInDatePicker.Value);
            reservation.CheckOutDate = DateOnly.FromDateTime(checkOutDatePicker.Value);
            reservation.CustomerID = SelectedCustomerID;
            int newID = reservation.Save();
            if (newID != -1) 
            {
                reservation.Id= newID;
                this.Close();

            } else
            {
                MessageBox.Show("Error saving reservation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RefreshCustomerUI()
        {
            clientNameTextBox.ReadOnly = !clientNameTextBox.ReadOnly;
            clientContactTextBox.ReadOnly = !clientContactTextBox.ReadOnly;
            saveNewClientButton.Enabled = !saveNewClientButton.Enabled;
            newClientButton.Text = (clientContactTextBox.ReadOnly == false) ? "Cancelar" : "Novo";
        }
        private void newClientButton_Click(object sender, EventArgs e)
        {
            RefreshCustomerUI();
        }

        private void saveNewClientButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Id = -1;
            customer.Name = clientNameTextBox.Text;
            customer.Contact = clientContactTextBox.Text;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (var c in CustomerList)
            {
                if(c.Name == listBox1.GetItemText(listBox1.SelectedItem))
                {
                    clientNameTextBox.Text = c.Name;
                    clientContactTextBox.Text = c.Contact;
                    SelectedCustomerID = c.Id;
                }
            }
        }
    }
}
