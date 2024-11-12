using System;
using System.Data.SQLite;

namespace WinFormsApp1.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private string _connectionString = "Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;";

        // Load a users's data by username
        public bool Load(string username)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, username, password FROM users WHERE username = @username";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Id = reader.GetInt32(0);
                                Username = reader.GetString(1);
                                Password = reader.GetString(2);
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading data: " + ex.Message);
                }
            }
            return false;
        }

        // Save or update users's data
        public bool Save()
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = Id == 0
                        ? "INSERT INTO users (username, password) VALUES (@username, @password); SELECT last_insert_rowid();"
                        : "UPDATE users SET username = @username, password = @password WHERE id = @id";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", Username);
                        command.Parameters.AddWithValue("@password", Password);

                        if (Id == 0)
                        {
                            Id = Convert.ToInt32(command.ExecuteScalar()); // Get the new Id for an inserted row
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@id", Id);
                            command.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving data: " + ex.Message);
                }
            }
            return false;
        }
    }
}