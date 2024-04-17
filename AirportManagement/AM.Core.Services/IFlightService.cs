using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public interface IFlightService
    {
        public IList<DateTime> GetFlightDates(string destination);
        public IList<Flight> GetFlights(string filterType, string filterValue);

    }
}
