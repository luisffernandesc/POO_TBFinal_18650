using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.DirectoryServices.ActiveDirectory;
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

        public bool Save()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Properties SET Name = @name, Address = @address, PricePerNight = @pricePerNight, Type_ID = @type_ID WHERE ID = @id";


                    // Executes the SQL query to retrieve property types.
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", Id);
                        command.Parameters.AddWithValue("@name", Name);
                        command.Parameters.AddWithValue("@address", Address);
                        command.Parameters.AddWithValue("@pricePerNight", PricePerNight);
                        command.Parameters.AddWithValue("@type_ID", Type_ID);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving data: " + ex.Message);
                    return false;
                }

                return true;
            }
        }
    }      
}
