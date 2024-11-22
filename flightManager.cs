using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AirLine
{
    internal class FlightManager
    {
        private static int numFlights;
        private static int maxFlights;
        private static Flight[] Flights = new Flight[maxFlights];

        public FlightManager(int max)
        {
            maxFlights = max;
            numFlights = 0;
            Flights = new Flight[max];
        }

        public FlightManager() { } //N

        public static int getValidInt()
        {
            int validInput;
            while (!int.TryParse(Console.ReadLine(), out validInput))
            {
                Console.WriteLine("Please enter a valid integer");
            }
            return validInput;
        }
        public void AddFlight()
        {
            if (numFlights < maxFlights)
            {
            
                Console.WriteLine("Enter Flight Number:");
                int flightNumber = getValidInt();
                Console.WriteLine("Enter Origin:");
                string origin = Console.ReadLine();
                Console.WriteLine("Enter Destination:");
                string destination = Console.ReadLine();
                Console.WriteLine("Enter Max Seats:");
                int maxSeats = getValidInt();


                foreach (var flight in Flights)
                {
                    if (flight != null && flight.getFlightNum() == flightNumber)
                    {
                        Console.WriteLine("Flight number already exists. Please choose a different flight number.");
                        return;
                    }
                }
                

                Flights[numFlights] = new Flight(flightNumber, origin, destination, maxSeats);
                numFlights++;
                Console.WriteLine("Flight added successfully.");
                
            }
            else
            {
                Console.WriteLine("Maximum flight limit reached.");
            }
        }

        public void ViewFlights()
        {
            Console.WriteLine("\nList of All Flights:");
            foreach (var flight in Flights)
            {
                if (flight != null)
                {
                    Console.WriteLine(flight.getSummary());
                }
            }
            Console.ReadKey();

        }

        public void ViewParticularFlight(int flightId)
        {
            Console.WriteLine("Enter Flight Number:");
            int partFlightNumber = getValidInt(); 

            bool flightFound = false;
            foreach (var flight in Flights)
            {
                if (flight != null && flight.getFlightNum() == partFlightNumber)
                {
                    Console.WriteLine("\nFlight Details:");
                    Console.WriteLine(flight.getDetails());
                    flightFound = true; 
                    break;
                }
            }

            if (!flightFound) 
            {
                Console.WriteLine("Flight not found. Please check the flight number.");
            }
        }

        public Flight getFlight(int flightId)
        {
            bool flightFound = false;
            Flight flight1 = null;
            foreach (var flight in Flights)
            {
                if (flight != null && flight.getFlightNum() == flightId)
                {
                    flight1 = flight;
                    flightFound = true;
                    break;
                }
            }

            if (!flightFound)
            {
                Console.WriteLine("Flight not found. Please check the flight number.");
            }
            return flight1;
        }
        public void DeleteFlight()
        {
            Console.WriteLine("Enter the flight number to delete:");
            int flightNum = getValidInt();

            // Find the flight to delete
            Flight delFlight = null;
            for (int i = 0; i < numFlights; i++)
            {
                if (Flights[i] != null && Flights[i].getFlightNum() == flightNum)
                {
                    delFlight = Flights[i];
                    Flights[i] = null; // Mark the slot as empty
                    break;
                }
            }

            if (delFlight == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            if (delFlight.getPassengers() > 0)
            {
                Console.WriteLine("Cannot delete the flight because there are customers booked on it.");
                return;
            }

            // Compact the array by shifting flights after the removed one
            for (int i = 0; i < numFlights - 1; i++)
            {
                if (Flights[i] == null)
                {
                    Flights[i] = Flights[i + 1];
                    Flights[i + 1] = null;
                }
            }

            numFlights--; // Decrement the flight count
            Console.WriteLine("Flight deleted successfully.");
        }

    }
}
