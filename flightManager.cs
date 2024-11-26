using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2129groupProject
{
    internal class FlightManager
    {
        private Flight[] flights;
        private int numFlights;
        private int max;
        private static int seed;

        private string flightFile = @"..\..\..\Files\flights.txt";

        public FlightManager(int max, int startseed)
        {
            this.max = max;
            numFlights = 0;
            flights = new Flight[max];
            seed = startseed;
            LoadFlights();
        }
        // Load flights from the file
        private void LoadFlights()
        {
            if (!File.Exists(flightFile))
            {
                Console.WriteLine("Flight file does not exist.");
                return;
            }

            try
            {
                flights = new Flight[max];
                numFlights = 0;
                string[] flightRecords = File.ReadAllLines(flightFile);
                foreach (string record in flightRecords)
                {
                    string[] data = record.Split(',');
                    Flight flight = new Flight(int.Parse(data[0]), data[1], data[2], int.Parse(data[3]))
                    {
                        passengers = int.Parse(data[4])
                    };
                    flights[numFlights++] = flight;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading flights: {ex.Message}");
            }
        }

        private int GenerateFlightId()
        {
            return numFlights > 0 ? seed+numFlights+1 : seed;
        }


        public bool AddFlight(string origin, string destination, int maxSeats)
        {
            if (numFlights >= max)
            {
                Console.WriteLine("Cannot add more flights. Maximum capacity reached.");
                return false;
            }

            int flightNum = GenerateFlightId();
            Flight newFlight = new Flight(flightNum, origin, destination, maxSeats);
            flights[numFlights++] = newFlight;
            try
            {
                string[] flightRecords = new string[numFlights];
                for (int i = 0; i < numFlights; i++)
                {
                    flightRecords[i] = $"{flights[i].flightNum},{flights[i].origin},{flights[i].destination},{flights[i].maxSeats},{flights[i].passengers}";
                }
                File.WriteAllLines(flightFile, flightRecords);
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving flights: {ex.Message}");
                return false;
            }

            
        }

        public void ViewFlights()
        {
            if(numFlights ==0)
            {
                Console.WriteLine("No flights added yet.");
                return;
            }
            
            Console.WriteLine("---- Flight List ----");
            Console.WriteLine("FlightNum\tOrigin\t\tDestination\tMaxSeats\tPassengers");
            Console.WriteLine("--------------------------------------------------------------------------");

            for (int i = 0; i < numFlights; i++)
            {
                var flight = flights[i];
                Console.WriteLine($"{flight.flightNum}\t\t{flight.origin}\t\t{flight.destination}\t\t{flight.maxSeats}\t\t{flight.passengers}");
            }
        }

        public void ViewParticularFlight(int flightNum)
        {
            int index = -1;
            for (int i = 0; i < numFlights; i++)
            {
                if (flights[i].flightNum == flightNum)
                {
                    index = i;
                    Console.WriteLine(flights[i].ToString() );
                    break;
                }

            }
            if (index == -1)
            {
                Console.Clear();
                Console.WriteLine($"No Flight with number {flightNum} found");
                
            }
        }

        public bool DeleteFlight(int flightNum)
        {
            int index = -1;
            for (int i = 0;i < numFlights;i++) { 
                if (flights[i].flightNum == flightNum)
                {
                    index= i; 
                    break;
                }
            }
            if (index == -1)
            {
                Console.Clear();
                Console.WriteLine($"No Flight with number {flightNum} found");
                return false;
            }

            flights[index] = flights[numFlights-1];
            numFlights--;
            try
            {
                string[] flightRecords = new string[numFlights];
                for (int i = 0; i < numFlights; i++)
                {
                    flightRecords[i] = $"{flights[i].flightNum},{flights[i].origin},{flights[i].destination},{flights[i].maxSeats},{flights[i].passengers}";
                }
                File.WriteAllLines(flightFile, flightRecords);
                return true;

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving flights: {ex.Message}");
                return false;
                
            }

        }

        //Find Flight by ID
        public Flight SearchFlightByNum(int flightNum)
        {
            foreach (Flight flight in flights)
            {
                if (flight!=null && flight.flightNum==flightNum)
                {
                    return flight;
                }
            }
            return null;
        }





        /*
        //Reads the Flight File and returns an array
        public string[] ReadFlightFile()
        {
            try
            {
                if (File.Exists(flightFile))
                {
                    string[] flightRecords = File.ReadAllLines(flightFile);
                    foreach (string record in flightRecords)

                    {
                        string[] data = record.Split(',');
                        Flight flight = new Flight(int.Parse(data[0]), data[1], data[2], int.Parse(data[3]))
                        {
                            passengers= int.Parse(data[4])
                        };
                        flights[numFlights++] = flight;
                    }
                    return flightRecords;
                }
                else
                {
                    Console.WriteLine("Flight file does not exist.");
                    return new string[0];                             //Return an empty array 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return new string[0];                                 //Return an empty array
            }

        }
        
        

        //Generates Flight id on the basis of last flight added
        private int GenerateFlightId()
        {
            //if flight file does not exist
            if (!File.Exists(flightFile))
            {
                return seed;
            }

            //if there are no flights yet
            string[] flights = ReadFlightFile();
            if (flights.Length == 0)
            {
                return seed;
            }

            //if there are already flights
            string lastFlight = flights[flights.Length - 1];
            int lastFlightId = Convert.ToInt32(lastFlight.Split(",")[0]);
            return lastFlightId + 1;
        }*/
        /*
        //Adding new Flights
        public bool AddFlight( string org, string dest, int maxSeat)
        {
            string[] flightRecords = ReadFlightFile();


           
            if (numFlights < max)
            {
                Flight newCust = new Flight(GenerateFlightId(), org, dest, maxSeat,);
                customers[numCustomers++] = newCust;

                using (StreamWriter writer = new StreamWriter(customerFile, true))
                {
                    writer.WriteLine($"{newCust.GetCustomerID()},{newCust.GetFirstName()},{newCust.GetLastName()},{newCust.GetPhone()},{newCust.GetNumBookings()}");
                }         //Appends file with attributes separated by comma
                return true;
            }
            else
            {
                Console.WriteLine("Not suffiecient space.");
                return false;
            }

        }*/



    }
}
