using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirLine;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Booking booking = new Booking(1, "01/01/2023", new Customer(1, "John", "Doe", "o2vVJ@example.com"), new Flight(1, "1234", "New York", "2023-01-01T10:00:00", "London", "2023-01-01T12:00:00", "Airline"));
            Coordinator coordinator = new Coordinator();
            coordinator.BookingMenu();

        }
    }
}