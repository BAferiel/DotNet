using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }
        [ForeignKey("Passenger")]
        public long PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool VIP { get; set; }
    }
}
