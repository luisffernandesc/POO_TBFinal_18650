using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1.Classes
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PricePerNight { get; set; }
        public int Type_ID { get; set; }
        public int User_ID { get; set; }

        private string _connectionString = "Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;";
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
    }

}
