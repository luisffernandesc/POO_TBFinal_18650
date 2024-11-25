using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    /// <summary>
    /// Represents a reservation within the tourism management system.
    /// </summary>
    public class Reservation
    {
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
        /// Name of the customer who made the reservation.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Contact information of the customer.
        /// </summary>
        public string CustomerContact { get; set; }

        /// <summary>
        /// Identifier of the property associated with this reservation.
        /// </summary>
        public int PropertyID { get; set; }
      
    }
}
