﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    #region Customer Class
    /// <summary>
    /// Represents a customer within the tourism management system.
    /// </summary>
    public class Customer
    {
        #region Properties
        /// <summary>
        /// Unique identifier for the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contact of the customer.
        /// </summary>
        public string Contact { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// Saves the customer to the database. If the customer ID is -1, a new record is created.
        /// Otherwise, the existing record is updated.
        /// </summary>
        /// <returns>The ID of the saved customer, or -1 if an error occurs.</returns>
        public int Save()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();

                    string query = (Id == -1)
                        ? "INSERT INTO Customers (Name, Contact) VALUES (@name, @contact)"
                        : "UPDATE Customers SET Name = @name, Contact = @contact WHERE ID = @id";

                    int id;

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", Name);
                        command.Parameters.AddWithValue("@contact", Contact);

                        if (Id != -1)
                        {
                            command.Parameters.AddWithValue("@id", Id);
                            command.ExecuteNonQuery();
                            id = Id;
                        }
                        else
                        {
                            id = Convert.ToInt32(command.ExecuteScalar());
                        }

                        return id;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving client: " + ex.Message);
                    return -1;
                }
            }
        }
        #endregion
    }
}
#endregion