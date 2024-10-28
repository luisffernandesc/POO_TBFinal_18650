using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_alojamentos_turísticos.Classes
{
    public class Reservation
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        // Add any other properties or methods related to Reservation here
    }
}
