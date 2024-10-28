using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_alojamentos_turísticos.Classes
{
        public class Customer
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public List<Reservation> Reservations { get; set; } = new List<Reservation>();

            // Add any other properties or methods related to Customer here
        }
}

