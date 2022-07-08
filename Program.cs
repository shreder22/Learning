using System;

namespace Airport
{
    class Program
    {
        static List<Flight> Flights = new List<Flight>();
        static void DisplayFlights()
        {
            {
                foreach (Flight flight in Flights)
                {
                    Console.WriteLine($"Flight number : {flight.FlightNumber}: \n Departure from : {flight.Departure} \n Arrival to :{flight.Arrival}");
                }
            }
        }
        static int choice = 0;
        public static Flight FillFlightDetails()
        {
            Console.WriteLine("Please enter the Flight number:");
            int flightNumber = 0; ;
            try
            {
                flightNumber = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Flight  arrival:");
            var arrival = Console.ReadLine();
            Console.WriteLine("Flight departure:");
            var departure = Console.ReadLine();
            Flight flight;
            if (flightNumber == 0)
            {
                flight = new Flight(0, "CANT BE ADDED", "CANT BE ADDED"); return flight;
            }
            else
            {
                flight = new Flight(flightNumber, arrival, departure); return flight;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Press any button to continue: Press Escape to exit");
            var k = Console.ReadKey();
            while (k.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Please select your action:\n 1.Add new Flight \n 2.Remove Flight \n 3.Search Flight by Flight number \n 4.Search Flight by Arrival \n 5.Search Flight by Departure \n 6.Display all flights");
                try
                {
                    choice = int.Parse(Console.ReadLine());

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                switch (choice)
                {
                    case 0: Console.WriteLine("Wrong format typed.\n Try again"); break;
                    case 1:
                        Flight flight = new Flight();
                        flight = FillFlightDetails();
                        if (flight is not null) { Flights.Add(flight); break; }
                        else { Console.WriteLine("Flight cant be added"); break; }
                    case 2:
                        Flight flight1 = FillFlightDetails();
                        if (flight1 is not null) {Flights.Remove(flight1); break; }
                        else { Console.WriteLine("Flight cant be removed"); break; }
                    case 3:
                        Console.WriteLine("Enter flight number:");
                        int flightNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine($" Flight arrival :{Flight.FindFlightByNumber(flightNumber, Flights).Arrival} Flight Departure: {Flight.FindFlightByNumber(flightNumber, Flights).Departure}"); break;
                    case 4:
                        Console.WriteLine("Enter flight arrival");
                        string arrival = Console.ReadLine();
                        List<Flight> FoundFlights = new List<Flight>();
                        FoundFlights = Flight.FindFlightsByArrival(arrival, Flights);
                        foreach (Flight flight3 in FoundFlights)
                        {
                            Console.WriteLine($"Flight number:{flight3.FlightNumber} Flight departure: {flight3.Departure}");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter flight departure:");
                        string departure = Console.ReadLine();
                        FoundFlights = Flight.FindFlightsByArrival(departure, Flights);
                        foreach (Flight flight3 in FoundFlights)
                        {
                            Console.WriteLine($"Flight number:{flight3.FlightNumber} Flight departure: {flight3.Departure}");
                        }
                        break;

                    case 6:
                        DisplayFlights(); break;
                        Console.WriteLine("Press any button to continue: Press Escape to exit");
                        k = Console.ReadKey();
                }
            }
        }
    }
}
