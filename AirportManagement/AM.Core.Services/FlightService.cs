using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class FlightService : IFlightService
    {
        public IList<Flight> Flights { get; set; } = new List<Flight>();

        public IList<DateTime> GetFlightDates(string destination)
        {

            List<DateTime> dates = new List<DateTime>();
            List<Flight> f = Flights.Where(e => e.Destination == destination).ToList();
            foreach (Flight fl in f)
            {
                dates.Add(fl.FLightDate);

            }
            return dates;
        }

        public void ShowFlightDetails(Plane plane)
        {
            IList<Flight> f = Flights.Where(e => e.plane.PlaneId == plane.PlaneId).ToList();

            if (f == null)
            {
                Console.WriteLine("no flights available");

            }
            else
            {
                foreach(Flight fl in f)
                {
                    Console.WriteLine($"Flight details: {fl.FLightDate} {fl.Destination}");

                }
            }
        }

        public int GetWeeklyFlightNumber(DateTime date)
        {
            DateTime end = date.AddDays(6);
            IList<Flight> fl = Flights.Where(e => e.FLightDate >= date && e.FLightDate <= end).ToList();
            return fl.Count;

        }

        public float GetDurationAverage(string destination)
        {
            return Flights.Where(e => e.Destination == destination).Average(e => e.EstimatedDuration);

        }

        public IList<Flight> SortFlights()
        {

            return Flights.OrderByDescending(e => e.EstimatedDuration).ToList();

        }

        public IList<Passenger> GetThreeOlderTravellers(Flight f)
        {

            List<Passenger> p = f.passengers.ToList();

            return p.OrderByDescending(e => e.Age).Take(3).ToList();


        }

        public void ShowGroupedFlights()
        {
            IList<Flight> li = (IList<Flight>)Flights.GroupBy(e => e.Destination).ToList();
            foreach(Flight f in li)
            {
                Console.WriteLine(li);
            }
        }

        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> filteredFlights = new List<Flight>();

            PropertyInfo[] propertyInfos = typeof(Flight).GetProperties(BindingFlags.Public);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.Name.Equals(filterType))
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        filteredFlights = Flights.Where(flight =>
                            propertyInfo.GetValue(flight)?.ToString() == filterValue)
                            .ToList();
                    }
                    else if (propertyInfo.PropertyType == typeof(int))
                    {
                        filteredFlights = Flights.Where(flight =>
                            propertyInfo.GetValue(flight).ToString() == filterValue)
                            .ToList();

                    }
                }
            }

            return filteredFlights;
        }

    }
}
