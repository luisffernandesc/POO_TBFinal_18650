using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    public class PropertyTypesLoad
    {
        public static List<PropertyTypes> Load()
        {
            // Creates a list to store the property types loaded from the database.
            List<PropertyTypes> propertyTypes = new List<PropertyTypes>();

            // Opens the connection to the database.
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, Name FROM Property_Types";

                    // Executes the SQL query to retrieve property types.
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Reads the data returned by the query and adds it to the property types list.
                            while (reader.Read())
                            {
                                PropertyTypes propertyType = new PropertyTypes
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                };
                                propertyTypes.Add(propertyType);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Captures and displays any exceptions that occur during the operation.
                    Console.WriteLine("Error loading data: " + ex.Message);
                }

                // Returns the list of loaded property types.
                return propertyTypes;
            }
        }
    }
}

