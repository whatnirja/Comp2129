using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirLine
{
    public class Booking
    {
        public int bookingId;
        public string date; 
        public Customer customer; // Single customer for the booking
        public Flight flight;

        private const string BookingFile = "bookings.txt";

        // Constructor for single customer booking
        public Booking(int bookingId, string date, Customer customer, Flight flight)
        {
            this.bookingId = bookingId;
            this.date = DateTime.Now.ToString(@"MM/dd/yyyy hh:mm:ss tt");
            this.customer = customer;
            this.flight = flight;
        }

        public Booking(string date, Customer customer, Flight flight)
        {
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
        public void SaveBooking()
        {
            using StreamWriter file = new StreamWriter(BookingFile, true);
            file.WriteLine($"{GetBookingId()}, {GetDate()}, {customer.GetCustomerId()}, {customer.GetFirstName()} {customer.GetLastName()} {customer.GetEmail()}, {GetFlight().getFlightNum()},{GetFlight().getFlightNum()}");
            
        }

        // ToString method for displaying booking info
        public override string ToString()
        {
            return $"{GetBookingId()}, {GetDate()}, {customer.GetFirstName()} {customer.GetLastName()}, {GetFlight().getFlightNum()},{GetFlight().getFlightNum()}";
        }
    }
}
