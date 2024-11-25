using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
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

        /// <summary>
        /// Connection string to the SQLite database.
        /// </summary>
        private string _connectionString = "Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;";

        /// <summary>
        /// Loads a list of property types from the database.
        /// </summary>
        /// <returns>A list of <see cref="PropertyTypes"/> objects representing the property types.</returns>
    }
}
