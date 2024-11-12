using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    public class PropertyTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private string _connectionString = "Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;";
        public static List<PropertyTypes> Load()
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
    }
}
