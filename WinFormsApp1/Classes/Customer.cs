using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    /// <summary>
    /// Represents a customer within the tourism management system.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Unique identifier for the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contact information for the customer.
        /// </summary>
        public string Contact { get; set; }
 
    }
}
