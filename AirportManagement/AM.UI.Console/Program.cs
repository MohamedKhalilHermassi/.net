// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");

Plane p = new Plane();
p.Capacity = 100;
Console.WriteLine(p.Capacity);
p.ManufactureDate = DateTime.Now;
Console.WriteLine(p.ManufactureDate);
p.PlaneType = PlaneType.Boeing;
Console.WriteLine(p.PlaneType);

Flight f = new Flight
{
    Departure = "Tunis",
    Destination = "Paris",
    FlightDate = new DateTime(2024, 4, 16)
};

Console.WriteLine(f);

Passenger passenger = new Passenger
{
    EmailAddress = "khalil",
    FirstName="khalil",
    LastName="khalil"
};
Console.WriteLine(passenger.CheckProfile("khalil", "khalil"));
Staff s = new Staff();
s.PassengerType();

FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;
foreach (DateTime d in fm.getFlightDates("Paris"))
    {
    Console.WriteLine(d);

}

fm.GetFlights("Destination", "Madrid");
Console.WriteLine("**********Plane************");
fm.ShowFlightDetails(TestData.Airbusplane);
fm.FlightDetailsDel(TestData.Airbusplane);
Console.WriteLine("************Programmed Flights************");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2021,12,31)));

Console.WriteLine("************Average Duration************");
Console.WriteLine(fm.DurationAverage("Paris"));
Console.WriteLine(fm.DurationAverageDel("Paris"));
Console.WriteLine("************Order Flights Duration************");

foreach (Flight fl in fm.OrderDurationFlights())
    Console.WriteLine(fl.EstimatedDuration);

Console.WriteLine("***********TOP 3 AGED****************");
foreach(Traveller t in fm.SeniorTravellers(TestData.flight1))
    Console.WriteLine(t.BirthDate);
Console.WriteLine("****************");
Console.WriteLine(fm.DestinationGroupedFlights());

Console.WriteLine("*****************Passenger Extension****************");
passenger.UpperFullname();
Console.WriteLine(passenger.FirstName +  " " + passenger.LastName);
