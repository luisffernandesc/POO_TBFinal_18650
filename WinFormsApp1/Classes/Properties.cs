using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1.Classes
{
    /// <summary>
    /// Represents a property within the tourism management system.
    /// </summary>
    public class Property
    {
        #region Attributes
        /// <summary>
        /// Unique identifier for the property.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address of the property.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Price per night for renting the property.
        /// </summary>
        public int PricePerNight { get; set; }

        /// <summary>
        /// Identifier for the type of the property.
        /// </summary>
        public int Type_ID { get; set; }

        /// <summary>
        /// Identifier for the user who owns the property.
        /// </summary>
        public int User_ID { get; set; }
        #endregion
    }      
}
