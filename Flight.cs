using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine
{
    public class Flight
    {
        protected int flightNum;
        protected string origin;
        protected string destination;
        protected int maxSeats;
        protected int passengers;
        Customer[] customers = new Customer[0];

        public Flight(int flightNumber, string org, string dest, int maxSeat)
        {
            this.flightNum = flightNumber;
            this.origin = org;
            this.destination = dest;
            this.maxSeats = maxSeat;
            this.passengers = 0;
        }

        public int getPassengers() { return passengers; }
        public int getFlightNum() { return flightNum; }

        public int getMaxSeats() { return maxSeats; } // N

        //CHANGE WHILE MAKING BOOKINGS
        public void addPassenger(int customerId, string firstName, string lastName, string email) {
            Array.Resize(ref customers, customers.Length + 1);
            customers[customers.Length - 1] = new Customer(customerId, firstName, lastName,  email);
            passengers++; 
        }
        //CHANGE WHILE MAKING BOOKINGS
        public void removePassenger(int customerID)
        {
            int indexToRemove = -1;
            for (int i = 0; i < customers.Length; i++)
            {
                if (customers[i].GetCustomerId() == customerID) 
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove == -1)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            Customer[] newCustomers = new Customer[customers.Length - 1];

            for (int i = 0, j = 0; i < customers.Length; i++)
            {
                if (i != indexToRemove)
                {
                    newCustomers[j++] = customers[i];
                }
            }

            customers = newCustomers;
            passengers--;
        }

        public string getDetails()
        {
            string s = $"Flight Number: {flightNum}\n";
            s += $"Origin: {origin}\n";
            s += $"Destination: {destination}\n";
            s += "Passengers on this flight:\n";

            if (customers != null && customers.Any())
            {
                foreach (var customer in customers)
                {
                    s += $"- {customer.GetFirstName() +" " + customer.GetLastName()} (ID: {customer.GetCustomerId()})\n";
                }
            }
            else
            {
                s += "No passengers on this flight.\n";
            }

            return s;
        }

        public string getSummary()
        {
            string s = $"Flight Number: {flightNum}\n";
            s += $"Origin: {origin}\n";
            s += $"Destination: {destination}\n";
            return s;
        }

    }
}
