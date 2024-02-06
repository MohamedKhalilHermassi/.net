// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore;
using AM.ApplicationCore.Domain;

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