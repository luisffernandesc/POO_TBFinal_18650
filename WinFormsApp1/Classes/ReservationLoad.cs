using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    public class ReservationLoad
    {
        /// <summary>
        /// Loads a list of reservations from the database for a specific property.
        /// </summary>
        /// <param name="propertyID">The ID of the property whose reservations are to be loaded.</param>
        /// <returns>A list of <see cref="Reservation"/> objects representing the reservations for the specified property.</returns>
        public static List<Reservation> LoadReservationProperties(int propertyID)
        {
            // Creates a list to store the reservations loaded from the database.
            List<Reservation> reservations = new List<Reservation>();

            // Opens a connection to the SQLite database.
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, CheckIn_Date, CheckOut_Date, TotalPrice, Customer_ID, Property_ID FROM Reservations WHERE Property_ID = @Property_ID";

                    // Prepares the SQL query to retrieve reservations for a specific property based on propertyID.
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Property_ID", propertyID);

                        // Executes the query and reads the result.
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Loads customer information based on the Customer_ID.
                                Customer customer = CustomerLoad.Load(reader.GetInt32(4));

                                // Creates a new Reservation object and populates it with data from the database.
                                Reservation reservation = new Reservation
                                {
                                    Id = reader.GetInt32(0),
                                    CheckInDate = DateOnly.Parse(reader.GetString(1)),
                                    CheckOutDate = DateOnly.Parse(reader.GetString(2)),
                                    TotalPrice = reader.GetInt32(3),
                                    CustomerName = customer.Name,
                                    CustomerContact = customer.Contact,
                                    PropertyID = reader.GetInt32(5)
                                };

                                reservations.Add(reservation);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Captures and logs any exceptions that occur during the data loading process.
                    Console.WriteLine("Error loading data: " + ex.Message);
                }

                // Returns the list of loaded reservations.
                return reservations;
            }
        }
    }
}
