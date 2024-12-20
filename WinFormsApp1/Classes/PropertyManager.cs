using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace WinFormsApp1.Classes
{
    /// <summary>
    /// Provides methods to manage properties and property types in the tourism management system.
    /// </summary>
    public class PropertiesManager
    {
        #region Methods

        /// <summary>
        /// Loads all property types from the database.
        /// </summary>
        /// <returns>
        /// A list of <see cref="PropertyTypes"/> objects representing all property types.
        /// </returns>
        public static List<PropertyTypes> LoadTypes()
        {
            List<PropertyTypes> propertyTypes = new List<PropertyTypes>();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, Name FROM Property_Types";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
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
                    Console.WriteLine("Error loading data: " + ex.Message);
                }

                return propertyTypes;
            }
        }

        /// <summary>
        /// Loads all properties associated with a specific user from the database.
        /// </summary>
        /// <param name="UserID">The ID of the user whose properties are to be loaded.</param>
        /// <returns>
        /// A list of <see cref="Property"/> objects representing the user's properties.
        /// </returns>
        public static List<Property> LoadUserProperties(int UserID)
        {
            List<Property> properties = new List<Property>();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, Name, Address, PricePerNight, Type_ID, User_ID FROM Properties WHERE User_ID = @User_ID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@User_ID", UserID);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
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
                    Console.WriteLine("Error loading data: " + ex.Message);
                }

                return properties;
            }
        }

        #endregion
    }
}
