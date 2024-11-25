using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    public class CustomerLoad
    {
        public static Customer Load(int customerID)
        {
            // Creates a new instance of Customer to hold the loaded data.
            Customer customer = new Customer();

            // Opens a connection to the SQLite database.
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, Name, Contact FROM Customers WHERE ID = @Customer_ID";

                    // Prepares the SQL query to retrieve the customer data based on customerID.
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Customer_ID", customerID);

                        // Executes the query and reads the result.
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
                    // Captures and logs any exceptions that occur during the data loading process.
                    Console.WriteLine("Error loading data: " + ex.Message);
                }

                // Returns the populated Customer object.
                return customer;
            }
        }
    }
}
