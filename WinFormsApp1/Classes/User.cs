using System;
using System.Data.SQLite;

namespace WinFormsApp1.Classes
{
    /// <summary>
    /// Represents a user within the tourism management system.
    /// </summary>
    public class User
    {
        #region Properties
        /// <summary>
        /// Unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Connection string to the SQLite database.
        /// </summary>
        private string _connectionString = "Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;";
        #endregion

        #region LoadUserFromDatabase
        /// <summary>
        /// Loads a user's data from the database by username.
        /// </summary>
        /// <param name="username">The username of the user to be loaded.</param>
        /// <returns>True if the user was successfully loaded; otherwise, false.</returns>
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
        #endregion
    }
}
