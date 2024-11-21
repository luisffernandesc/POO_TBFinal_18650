using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    public class PropertyLoad
    {
        /// <summary>
        /// Loads properties from the DataBase using the UserID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
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

