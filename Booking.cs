using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2129groupProject
{
    internal class Booking
    {
        public int bookingId;
        public string date;
        public Customer customer; // Single customer for the booking
        public Flight flight;

        private string bookingFile = @"..\..\..\Files\bookings.txt";
        public Booking(int bookingId, string date, Customer customer, Flight flight)
        {
            this.bookingId = bookingId;
            this.date = DateTime.Now.ToString(@"MM/dd/yyyy hh:mm:ss tt");
            this.customer = customer;
            this.flight = flight;
        }

        // Getters
        public int GetBookingId() => bookingId;
        public string GetDate() => date;
        public Customer GetCustomer() => customer;
        public Flight GetFlight() => flight;

        // Setters
        public void SetBookingId(int bookingId) => this.bookingId = bookingId;
        public void SetDate(string date) => this.date = date;
        public void SetCustomer(Customer customer) => this.customer = customer;
        public void SetFlight(Flight flight) => this.flight = flight;

        // Save booking to file
        /*
        public void SaveBooking()
        {
            using StreamWriter file = new StreamWriter(bookingFile, true);
            file.WriteLine($"{GetBookingId()}, {GetDate()}, {Customer.GetCustomerID()}, {customer.GetFirstName()} {customer.GetLastName()} , {flight.light().getFlightNum()}");

        }*/

        // ToString method for displaying booking info
        public override string ToString()
        {
            return $"{GetBookingId()}, {GetDate()}, {customer.GetFirstName()} {customer.GetLastName()}, {GetFlight().flightNum},{GetFlight().flightNum}";
        }

    }
}
