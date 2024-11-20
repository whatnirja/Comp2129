using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirLine
{
    public class Coordinator
    {
      private BookingManager bookingManager;
      private CustomerManager customerManager;
      private FlightManager flightManager;

      public Coordinator()
      {
        bookingManager = new BookingManager(); //initializing the booking manager
        customerManager = new CustomerManager(); //initializing the customer manager
        flightManager = new FlightManager(); //initializing the flight manager
      }

      public void BookingMenu()
      {
        bool exit = false;
        while(!exit)
        {
          Console.WriteLine("ABC Airlines Ltd.");
          Console.WriteLine("Booking Menu");
          Console.WriteLine("1. View Bookings");
          Console.WriteLine("2. Make a Booking");
          Console.WriteLine("3. Delete a Booking");
          Console.WriteLine("4. Exit");
          string choice = Console.ReadLine();
          switch(choice)
          {
            case "1":
              ViewBookings();
              break;
            case "2":
              AddBooking();
              break;
            case "3":
              DeleteBooking();
              break;
            case "4":
              exit = true;
              break;
            default:
              Console.WriteLine("Invalid choice");
              break;
          }
        }
      }


      private void AddBooking()
      {
        Console.WriteLine("Enter Customer ID: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Flight ID: ");
        int flightId = Convert.ToInt32(Console.ReadLine());

        Customer customer = new CustomerManager().GetCustomerById(customerId);
        Flight flight = new FlightManager().GetFlightById(flightId);

        if(customer == null)
        {
          Console.WriteLine("Customer ID not found :(");
          return;
        }
        if(flight == null)
        {
          Console.WriteLine("Flight ID not found :(");
          return;
        }

        if(flight.AvailableSeats() <= 0)
        {
          Console.WriteLine("No available seats :(");
          return;
        }

        bookingManager.MakeBooking(customer, flight);
  
        Console.WriteLine("Booking for Customer with Customer ID " + customerId + " successful.");      
      }


      private void ViewBookings()
      {
        bookingManager.ViewBookings();
      }

      private void DeleteBooking()
      {
        Console.WriteLine("Enter Booking ID: ");
        int bookingId = Convert.ToInt32(Console.ReadLine());
        bookingManager.DeleteBooking(bookingId);
      }


    }
}