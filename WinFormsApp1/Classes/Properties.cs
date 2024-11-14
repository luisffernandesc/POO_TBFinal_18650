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

        /// <summary>
        /// Connection string to the SQLite database.
        /// </summary>
        private string _connectionString = "Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;";

        /// <summary>
        /// Loads a list of properties from the database for a specific user.
        /// </summary>
        /// <param name="UserID">The ID of the user whose properties are to be loaded.</param>
        /// <returns>A list of <see cref="Property"/> objects representing the user's properties.</returns>
        public static List<Property> LoadUserProperties(int UserID)
        {
            // Creates a list to store the properties loaded from the database.
            List<Property> properties = new List<Property>();

            // Opens a connection to the SQLite database.
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, Name, Address, PricePerNight, Type_ID, User_ID FROM Properties WHERE User_ID = @User_ID";

                    // Prepares the SQL query to retrieve the properties based on UserID.
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@User_ID", UserID);

                        // Executes the query and reads the result.
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Reads each property record and adds it to the list.
                            while (reader.Read())
                            {
                                Property property = new Property
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Address = reader.GetString(2),
                                    PricePerNight = reader.GetInt32(3),
                                    Type_ID = reader.GetInt32(4),
                                    User_ID = reader.GetInt32(5)
                                };
                                properties.Add(property);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Captures and logs any exceptions that occur during the data loading process.
                    Console.WriteLine("Error loading data: " + ex.Message);
                }

                // Returns the list of loaded properties.
                return properties;
            }
        }
    }
}
