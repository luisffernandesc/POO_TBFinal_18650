using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace WinFormsApp1.Classes
{
    #region Reservation Management
    /// <summary>
    /// Provides methods for managing reservations in the system.
    /// </summary>
    public class ReservationManager : Reservation
    {
        #region Methods

        /// <summary>
        /// Loads a list of reservations from the database for a specific property.
        /// </summary>
        /// <param name="propertyID">The ID of the property whose reservations are to be loaded.</param>
        /// <returns>A list of <see cref="Reservation"/> objects representing the reservations for the specified property.</returns>
        public static List<Reservation> LoadReservationProperties(int propertyID)
        {
            List<Reservation> reservations = new List<Reservation>();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\Users\\Pro\\source\\repos\\POO_Trabalho_Final_18650\\WinFormsApp1\\database.db;Version=3;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, CheckIn_Date, CheckOut_Date, TotalPrice, Customer_ID, Property_ID FROM Reservations WHERE Property_ID = @Property_ID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Property_ID", propertyID);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = CustomerManager.Load(reader.GetInt32(4));

                                Reservation reservation = new Reservation
                                {
                                    Id = reader.GetInt32(0),
                                    CheckInDate = DateOnly.Parse(reader.GetString(1)),
                                    CheckOutDate = DateOnly.Parse(reader.GetString(2)),
                                    TotalPrice = reader.GetInt32(3),
                                    CustomerID = reader.GetInt32(4),
                                    PropertyID = reader.GetInt32(5)
                                };

                                reservations.Add(reservation);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading data: " + ex.Message);
                }

                return reservations;
            }
        }

        /// <summary>
        /// Calculates the total price of a reservation based on the number of nights and the price per night.
        /// </summary>
        /// <param name="checkIn">The check-in date.</param>
        /// <param name="checkOut">The check-out date.</param>
        /// <param name="sPricePerNight">The price per night as a string.</param>
        /// <returns>
        /// The total price of the reservation if valid input is provided; otherwise, -1.
        /// </returns>
        public static int CalculateTotalPrice(DateTime checkIn, DateTime checkOut, string sPricePerNight)
        {
            int pricePerNight = 0;

            try
            {
                pricePerNight = Convert.ToInt32(sPricePerNight);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Price Error: " + ex.Message);
            }

            if (checkOut > checkIn && pricePerNight > 0)
            {
                int totalDays = (checkOut - checkIn).Days;
                int totalPrice = totalDays * pricePerNight;

                return totalPrice;
            }

            return -1;
        }

        #endregion
    }
    #endregion
}
