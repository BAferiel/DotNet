using AM.Core.Domain;
using AM.Core.Services;
using AM.Data;
AMContext dbContext = new AMContext();

//Staff s = new();

//Plane p = new Plane();
//Passenger s2 = new Passenger();

////Passenger pass = new Passenger();
////pass.BirdthDate = DateTime.Now.AddYears(-3);

////pass.GetAge(pass);
////Console.WriteLine(pass.Age, pass.Age);


//Plane p3 = new Plane
//{
//    ManufactoreDate = new DateTime(),
//    Capacity = 250,
//    planeType = PlaneType.Airbus
//};

//s.EmailAddress = "test";

//FlightService fl = new FlightService()
//{
//    Flights = new List<Flight>()

//};


//Flight f = new Flight
//{
//    Destination = "Tunis",
//    FLightDate = new DateTime(),
//};
//Flight f2 = new Flight
//{
//    Destination = "Paris",
//    Departure  = "paris",
//    FLightDate = new DateTime(),
//    Comment = "test",
//    plane   = ppp,
//};

//List<Flight> fls = new List<Flight>();
//fls.Add(f);
//fls.Add(f2);

//fl.Flights.Union(fls);

//IList<Flight> fl22 = fl.GetFlights("Destination", "Paris");
//foreach (Flight fs in fl22)
//{
//    Console.Write("printing");
//    Console.Write(fs.ToString());

//}
Plane p1 = new Plane()
{
    Capacity = 10,
    planeType = PlaneType.Airbus,
    ManufactoreDate = new DateTime(),

};

dbContext.Planes.Add(p1);


var flight = new Flight
{
    Destination = "New York",
    Departure = "London",
    FLightDate = DateTime.Now,
    EffectiveArrival = true,
    EstimatedDuration = 8.5f,
    plane=p1,
    Comment = ""
};

dbContext.Flights.Add(flight);



var passenger = new Passenger
{
    PassportNumber = 1238567,
    BirdthDate = new DateTime(2000, 5, 15),
    EmailAddress = "omar.addouli@example.com",
    Telnumber = 123456789,
};

passenger.FullName = new FullName
{
    FirstName = "Omar",
    LastName = "Addouli"
};

dbContext.Passengers.Add(passenger);
var reservation = new Reservation
{
    Flight = flight,
    Passenger = passenger,
    SeatNumber = "AAA3",
    Price = 566.00m,
    VIP = true
};
dbContext.Reservations.Add(reservation);
dbContext.SaveChanges();