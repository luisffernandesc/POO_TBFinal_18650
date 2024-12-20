using System;
using System.Data.SQLite;

namespace WinFormsApp1.Classes
{
    #region Attributes
    /// <summary>
    /// Represents a reservation within the tourism management system.
    /// </summary>
    public class Reservation
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the reservation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Check-in date for the reservation.
        /// </summary>
        public DateOnly CheckInDate { get; set; }

        /// <summary>
        /// Check-out date for the reservation.
        /// </summary>
        public DateOnly CheckOutDate { get; set; }

        /// <summary>
        /// Total price of the reservation.
        /// </summary>
        public int TotalPrice { get; set; }

        /// <summary>
        /// ID of the customer who made the reservation.
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Identifier of the property associated with this reservation.
        /// </summary>
        public int PropertyID { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Saves the reservation to the database.
        /// </summary>
        /// <returns>
        /// The ID of the newly created reservation if successful; otherwise, -1.
        /// </returns>
        public int Save()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Reservations (CheckIn_Date, CheckOut_Date, TotalPrice, Customer_ID, Property_ID) VALUES (@checkIn_Date, @checkOut_Date, @totalPrice, @customer_ID, @property_ID)";
                    int id = -1;

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@checkIn_Date", CheckInDate);
                        command.Parameters.AddWithValue("@checkOut_Date", CheckOutDate);
                        command.Parameters.AddWithValue("@totalPrice", TotalPrice);
                        command.Parameters.AddWithValue("@customer_ID", CustomerID);
                        command.Parameters.AddWithValue("@property_ID", PropertyID);

                        id = Convert.ToInt32(command.ExecuteScalar());
                        return id;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving data: " + ex.Message);
                    return -1;
                }
            }
        }

        #endregion
    }
    #endregion
}
