using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace c2129groupProject
{
    internal class Flight
    {
        public int flightNum { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public int maxSeats { get; set; }
        public int passengers { get; set; }
        public Customer[] customers { get; set; }

        


        public Flight(int flightNumber, string org, string dest, int maxSeat)
        {
            this.flightNum = flightNumber;
            this.origin = org;
            this.destination = dest;
            this.maxSeats = maxSeat;
            this.passengers = 0;
            customers= new Customer[maxSeats];

        }

        

        
        public override string ToString()
        {
            string s = "--Flight Details--";
            s += "\nFlight Number: " + flightNum + "\nOrigin: " + origin + "\nDestination: " + destination + "\nMax Seats: " + maxSeats + "\nNo. of Passengers: " + passengers;
            return s;
        }
    }
}
