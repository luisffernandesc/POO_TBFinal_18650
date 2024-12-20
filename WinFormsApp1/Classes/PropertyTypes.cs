using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    #region Attributes
    /// <summary>
    /// Represents a property type within the tourism management system.
    /// </summary>
    public class PropertyTypes
    {
        /// <summary>
        /// Unique identifier for the property type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the property type.
        /// </summary>
        public string Name { get; set; }

    }
    #endregion
}
