using System;

namespace Airport
{
    public class Flight : IFlight
    {
        public int FlightNumber { get; private set; }
        public string Arrival { get; private set; }
        public string Departure { get; private set; }


        public Flight()
        {
        }
        public Flight(int flightNumber, string arrival, string departure)
        {
            this.FlightNumber = flightNumber;
            this.Arrival = arrival;
            this.Departure = departure;
        }

        public static Flight FindFlightByNumber(int flightNumber, List<Flight> flights)
        {
            foreach (Flight flight in flights)
            {
                if (flight.FlightNumber == flightNumber)
                {
                    return flight;
                }
            }
            return new Flight(0, "NO SUCH FLIGHT", "NO SUCH FLIGHT");
        }

        public static List<Flight> FindFlightsByArrival(string arrival, List<Flight> flights)
        {
            var FoundFlights = new List<Flight>();
            foreach (Flight flight in flights)
            {
                if (flight.Arrival.ToUpper().Equals(arrival.ToUpper()))
                {
                    FoundFlights.Add(flight);
                }
            }
            if (FoundFlights is null)
            {
                FoundFlights.Add(new Flight(0, "NO SUCH FLIGHT", "NO SUCH FLIGHT"));
            }
            return FoundFlights;
        }

        public static List<Flight> FindFlightsByDeparture(string departure, List<Flight> flights)
        {
            var FoundFlights = new List<Flight>();
            foreach (Flight flight in flights)
            {
                if (flight.Departure.ToUpper().Equals(departure.ToUpper()))
                {
                    FoundFlights.Add(flight);
                }
            }
            if (FoundFlights is null)
            {
                FoundFlights.Add(new Flight(0, "NO SUCH FLIGHT", "NO SUCH FLIGHT"));
            }
            return FoundFlights;
        }

        public void AddFlight(List<Flight> flights)
        {
            flights.Add(this);
        }

        public void RemoveFlight(List<Flight> flights)
        {
            flights.Remove(this);
        }




    }





}



