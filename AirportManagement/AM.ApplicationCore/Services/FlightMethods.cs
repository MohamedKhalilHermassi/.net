using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods:IFlightMethods
    {
 public List<Flight> Flights = new List<Flight>();

        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;
        public FlightMethods()
        {
            FlightDetailsDel = pl =>
            {
                var req = from f in Flights
                          where f.Plane == pl
                          select new { f.Departure, f.FlightDate };
                foreach (var f in req)
                    Console.WriteLine(f);
            };
            DurationAverageDel = dest =>
            {
                var req = from f in Flights
                          where f.Destination == dest
                          select f.EstimatedDuration;
                return req.Average();
            };
        }
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;
            var req2 = Flights.GroupBy(f => f.Destination);

            foreach ( var g in req2)
            {
                Console.WriteLine("Destination : "+ g.Key);
                foreach(var flight in g)
                {
                    Console.WriteLine("Décollage : " + flight.FlightDate);
                }
            }
                return req2;


            
        }

        public double DurationAverage(string destination)
        {
            var req = from f in Flights
                      where f.Destination == destination
                      select f.EstimatedDuration;

            var req2 = Flights.Where(f => f.Destination == destination).Average(f => f.EstimatedDuration);
            return req2;
        }

        public List<DateTime> getFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            flightDates = (from f in Flights
                          where f.Destination == destination
                          select f.FlightDate).ToList();
            var req2 = Flights.Where(f=>f.Destination == destination).Select(f=>f.FlightDate).ToList();



            return req2;
        }

        

        public void GetFlights(string FilterType, string FilterValue)
        {
            switch(FilterType)
            {
                case "Departure":
                    foreach(Flight f in Flights)
                    {
                        if (f.Departure.Equals(FilterValue))
                            Console.Write(f);
                    }
                    break;
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(FilterValue))
                            Console.Write(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate.Equals(DateTime.Parse(FilterValue)))
                            Console.Write(f);
                    }
                    break;
                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                    {
                        if(f.EstimatedDuration.Equals(int.Parse(FilterValue)))
                            Console.Write(f);
                    }
                    break;
             }
        }

        public IEnumerable<Flight> OrderDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimatedDuration descending
                      select f;

            var req2 = Flights.OrderByDescending(f => f.EstimatedDuration);
            return req;
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                       where (f.FlightDate - startDate).TotalDays<= 7 &&
                       DateTime.Compare(f.FlightDate, startDate) > 0
                       select f;
            var req2 = Flights.Where(f => (f.FlightDate - startDate).TotalDays <= 7 &&
                       DateTime.Compare(f.FlightDate, startDate) > 0).Count();
            return req2;

        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {

            var req1 = from t in flight.Passengers.OfType<Traveller>()
                       orderby t.BirthDate
                       select t;


            var req2 = flight.Passengers.OfType<Traveller>().OrderBy(f => f.BirthDate);
            return req1.Take(3);


            //pour ignorer les 3 premiers Skip(3)
            }

        public void ShowFlightDetails(Plane plane)
        {        var req = from f in Flights
                                      where f.Plane == plane
                                      select new { f.Departure, f.FlightDate };
            var req2 = Flights.Where(f => f.Plane == plane).Select(f => new {f.Departure,f.FlightDate});    
        foreach(var f in req)
                Console.WriteLine(f);
        }
        

    }
}