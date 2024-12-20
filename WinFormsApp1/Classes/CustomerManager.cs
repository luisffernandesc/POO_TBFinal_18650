using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    /// <summary>
    /// Provides functionality for managing customer data within the tourism management system.
    /// </summary>
    public class CustomerManager : Customer
    {
        #region Methods

        /// <summary>
        /// Loads a customer from the database based on the provided customer ID.
        /// </summary>
        /// <param name="customerID">The unique identifier of the customer to load.</param>
        /// <returns>A <see cref="Customer"/> object populated with data from the database.</returns>
        public static Customer Load(int customerID)
        {
            Customer customer = new Customer();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, Name, Contact FROM Customers WHERE ID = @Customer_ID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Customer_ID", customerID);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populates the Customer object with data from the database.
                                customer.Id = reader.GetInt32(0);
                                customer.Name = reader.GetString(1);
                                customer.Contact = reader.GetString(2);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading data: " + ex.Message);
                }

                return customer;
            }
        }

        /// <summary>
        /// Loads all customers from the database.
        /// </summary>
        /// <returns>A list of <see cref="Customer"/> objects populated with data from the database.</returns>
        public static List<Customer> LoadAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, Name, Contact FROM Customers";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Contact = reader.GetString(2)
                                };
                                customers.Add(customer);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading customers: " + ex.Message);
                }

                return customers;
            }
        }

        #endregion
    }
}