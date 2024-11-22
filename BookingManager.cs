using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace AirLine
{
    public class BookingManager
    {
      private const string BookingFile = "bookings.txt";
      private int GenerateBookingId()
      {
        //if booking file does not exist
        if(!File.Exists(BookingFile))
        {
          return 1;
        }

        //if there are no bookings yet
        string [] bookings = File.ReadAllLines(BookingFile);
        if(bookings.Length == 0)
        {
          return 1;
        }

        //if there are already bookings
        string lastBooking = bookings[bookings.Length - 1];
        int lastBookingId = Convert.ToInt32(lastBooking.Split(",")[0]);
        return lastBookingId + 1;
      }

      public void MakeBooking(Customer customer, Flight flight)
      {   
        
        int bookingId = GenerateBookingId();
        string date = DateTime.Now.ToString(@"MM/dd/yyyy hh:mm:ss tt");

        Booking booking = new Booking(bookingId, date, customer, flight);
        booking.SaveBooking();

        flight.addPassenger(customer.GetCustomerId(), customer.GetFirstName(), customer.GetLastName(), customer.GetEmail());
        customer.IncrementBookings();

        Console.WriteLine("Booking successful!");

        
      }

      public void ViewBookings()
      {
        if (File.Exists(BookingFile))
          {
              string[] bookings = File.ReadAllLines(BookingFile);
              if (bookings.Length == 0)
              {
                  Console.WriteLine("No Bookings :(");
                  return;
              }

              Console.WriteLine("Bookings:");
              foreach (string booking in bookings)
              {
                  string[] parts = booking.Split(",");
                  Console.WriteLine($"Booking ID: {parts[0]}, Date: {parts[1]}, Customer ID: {parts[2]}, Flight ID: {parts[3]}");
              }
          }
          else
          {
              Console.WriteLine("No Bookings file found :(");
          }
      }

      public void DeleteBooking(int bookingId)
      {
        if(!File.Exists(BookingFile))
        {
          Console.WriteLine("No bookings file found :(");
          return;
        }

        string[] bookings = File.ReadAllLines(BookingFile);
        if(bookings.Length == 0)
        {
          Console.WriteLine("No bookings :(");
          return;
        }

        bool bookingFound = false;
        string[] remainingBookings = new string[bookings.Length - 1];
        int index = 0;

        foreach(string booking in bookings)
        {
          string[] parts = booking.Split(",");
          int currentBookingId = Convert.ToInt32(parts[0]);
          if(currentBookingId == bookingId)
          {
            bookingFound = true;
            continue;
          }
          remainingBookings[index++] = booking;
        }

        if(bookingFound)
        {
          File.WriteAllLines(BookingFile, remainingBookings);
          Console.WriteLine($"Booking with Booking ID {bookingId} deleted successfully.");
        }
        else
        {
          Console.WriteLine($"Booking with Booking ID {bookingId} not found.");
        }
      }


    }
}
