using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismManagementSystem.Classes
{
    public class Reservation
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

    }
}
