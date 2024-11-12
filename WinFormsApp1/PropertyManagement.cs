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

namespace WinFormsApp1
{
    public partial class PropertyManagement : Form
    {
        List<Property> UserProperties = [];
        public PropertyManagement()
        {
            InitializeComponent();
            UserProperties = Property.LoadUserProperties(1);

            foreach (Property p in UserProperties)
            {
                listBox1.Items.Add(p.Name);
            }

            List<PropertyTypes> UserPropertyTypes = PropertyTypes.Load();
            comboBoxTypes.DataSource = UserPropertyTypes;
            comboBoxTypes.ValueMember = "Id";
            comboBoxTypes.DisplayMember = "Name";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var p in UserProperties)
            {
                if(p.Name == listBox1.GetItemText(listBox1.SelectedItem))
                {
                    textBoxNameRental.Text = p.Name;
                    textBoxAddress.Text = p.Address;
                    textBoxPrice.Text = p.PricePerNight.ToString();
                    comboBoxTypes.SelectedValue = p.Type_ID;

                }
            }
        }
    }
}
