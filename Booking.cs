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
      public Customer[] customers; //booking can be made for multiple customers
      public Flight flight;

      private const string BookingFile = "bookings.txt";

      //for single customer
      public Booking(int bookingId, string date, Customer customer, Flight flight)
      {
        this.bookingId = bookingId; // supposed to be supplied by the system 
        this.date = DateTime.Now.ToString(@"MM/dd/yyyy hh:mm:ss tt");
        this.customers = new Customer[]{customer};
        this.flight = flight;
        
      }


      //for multiple customers
      public Booking(int bookingId, string date, Customer[] customers, Flight flight)
      {
        this.bookingId = bookingId;
        this.date = date;
        this.customers = customers;
        this.flight = flight;
      }


      //getters
      public int GetBookingId()
      {
        return bookingId;
      }
      public string GetDate()
      {
        return date;
      }
      public Customer GetCustomer()
      {
        if(customers != null && customers.Length > 0){
          return customers[0];
        }
        return null;
      }
      public Flight GetFlight()
      {
        return flight;
      }

      //setters
      public void SetBookingId(int bookingId)
      {
        this.bookingId = bookingId;
      }
      public void SetDate(string date)
      {
        this.date = date;
      }
      public void SetCustomer(Customer customer)
      {
        customers = new Customer[]{customer}; //single customer 
      }
      public void SetCustomers(Customer[] customers)
      {
        this.customers = customers;
      }
      public void SetFlight(Flight flight)
      {
        this.flight = flight;
      }


      public void SaveBooking()
      {
        using StreamWriter file = new StreamWriter(BookingFile, true);
        if(customers.Length == 1){
          Customer customer = customers[0];
          file.WriteLine($"{GetBookingId()}, {GetDate()}, {customer.GetCustomerId()}, {customer.GetFirstName()} {customer.GetLastName()} {customer.GetEmail()}, {GetFlight().GetFlightID()},{GetFlight().GetFlightNumber()}"); // for single customer
        } 
        else
        {
          foreach(Customer customer in customers)
          {
            file.WriteLine($"{GetBookingId()}, {GetDate()}, {customer.GetCustomerId()}, {customer.GetFirstName()} {customer.GetLastName()} {customer.GetEmail()}, {GetFlight().GetFlightID()},{GetFlight().GetFlightNumber()}"); // for multiple customers
          } 
        }
      }

      public static void ViewBookings()
      {
        if(File.Exists(BookingFile))
        {
          string[] bookings = File.ReadAllLines(BookingFile);
          if(bookings.Length == 0)
          {
            Console.WriteLine("No Bookings :(");
            return;
          }

          Console.WriteLine("Bookings:");
          foreach(string booking in bookings)
          {
            string[] parts = booking.Split(",");
            Console.WriteLine($"Booking ID: {parts[0]}, Date: {parts[1]}, Customer ID: {parts[2]}, Customer Name: {parts[3]}, Flight ID: {parts[4]}, Flight Number: {parts[5]}");
          }
          
        }
        else
        {
          Console.WriteLine("No Bookings file found :(");
        }

      }
      


      public override string ToString()
      {
        if(customers.Length == 1){
          Customer customer = customers[0];
          return $"{GetBookingId()}, {GetDate()}, {customer.GetCustomerId()}, {customer.GetFirstName()} {customer.GetLastName()} {customer.GetEmail()}, {GetFlight().GetFlightID()},{GetFlight().GetFlightNumber()}"; // for single customer
        } 
        else  
        {
          string customerNames = string.Join(", ", customers.Select(c => $"{c.GetFirstName()} {c.GetLastName()}")); // for multiple customers
          return $"{GetBookingId()}, {GetDate()}, {customerNames}, {GetFlight().GetFlightID()},{GetFlight().GetFlightNumber()}";
        }
      }

      

    }
}

      

      