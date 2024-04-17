using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FLightDate { get; set; }
        public int FlighttId { get; set; }
        public bool EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        public int PlaneId { get; set; }
        public virtual Plane plane { get; set; }
        public string Comment { get; set; }

        public virtual IList<Passenger>? passengers { get; set; }

        public virtual IList<Reservation>? Reservations { get; set; }
    }
}
