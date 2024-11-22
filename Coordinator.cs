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
        customerManager = new CustomerManager(1000, 0); //initializing the customer manager
        flightManager = new FlightManager(); //initializing the flight manager
      }


      //booking menuuu
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
          Console.Write("Enter your choice: ");

          try
          {
            string? choice = Console.ReadLine(); //declared as nullable 
            if (string.IsNullOrWhiteSpace(choice) || !int.TryParse(choice, out int parsedChoice))
            {
              Console.WriteLine("Invalid choice, please enter a number.");
              continue;
            }

            switch (parsedChoice)
            {
              case 1:
                ViewBookings();
                break;
              case 2:
                AddBooking();
                break;
              case 3:
                DeleteBooking();
                break;
              case 4:
                exit = true;
                break;
              default:
                Console.WriteLine("Invalid choice, please try again.");
                break;
            
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine($"An error occurred: {ex.Message}");
          }

        }
      }

      //flight menu
      public void FlightMenu()
      {
        bool exit = false;
        while(!exit)
        {
          Console.WriteLine("ABC Airlines Ltd.");
          Console.WriteLine("Flight Menu");
          Console.WriteLine("1. Add Flight");
          Console.WriteLine("2. View Flights");
          Console.WriteLine("3. View a Particular Flight ");
          Console.WriteLine("4. Delete Flight");
          Console.WriteLine("5. Exit");
          Console.Write("Enter your choice: ");

          try
          {
            string? choice = Console.ReadLine(); //declared as nullable 
            if (string.IsNullOrWhiteSpace(choice) || !int.TryParse(choice, out int parsedChoice))
            {
              Console.WriteLine("Invalid choice, please enter a number.");
              continue;
            }

            switch (parsedChoice)
            {
              case 1:
                AddFlight();
                break;
              case 2:
                ViewFlights();
                break;
              case 3:
                ViewAParticularFlight();
                break;
              case 4:
                DeleteFlight();
                break;
              case 5:
                exit = true;
                break;
              default:
                Console.WriteLine("Invalid choice, please try again.");
                break;
            
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine($"An error occurred: {ex.Message}");
          }

        }
      }

      //flight menu
      public void CustomerMenu()
      {
        bool exit = false;
        while(!exit)
        {
          Console.WriteLine("ABC Airlines Ltd.");
          Console.WriteLine("Customer Menu");
          Console.WriteLine("1. Add Customer");
          Console.WriteLine("2. View Customers");
          Console.WriteLine("3. Delete Customer");
          Console.WriteLine("4. Exit");
          Console.Write("Enter your choice: ");

          try
          {
            string? choice = Console.ReadLine(); //declared as nullable 
            if (string.IsNullOrWhiteSpace(choice) || !int.TryParse(choice, out int parsedChoice))
            {
              Console.WriteLine("Invalid choice, please enter a number.");
              continue;
            }

            switch (parsedChoice)
            {
              case 1:
                AddCustomer();
                break;
              case 2:
                ViewCustomers();
                break;
              case 3:
                DeleteCustomer();
                break;
              case 4:
                exit = true;
                break;
              default:
                Console.WriteLine("Invalid choice, please try again.");
                break;
            
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine($"An error occurred: {ex.Message}");
          }

        }
      }

      //methods for the flight menu 
      private void AddFlight()
      {
        flightManager.AddFlight();
      }

      private void ViewFlights()
      {
        flightManager.ViewFlights();
      }

      private void ViewAParticularFlight()
      {
        Console.WriteLine("Enter Flight ID: ");
        int flightId = Convert.ToInt32(Console.ReadLine());
        flightManager.ViewParticularFlight(flightId);
      }

      private void DeleteFlight()
      {
        flightManager.DeleteFlight();
      }
    

      //methods for the booking menu
      private void AddBooking()
      {
        Console.WriteLine("Enter Customer ID: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Flight ID: ");
        int flightId = Convert.ToInt32(Console.ReadLine());

        Customer customer = new CustomerManager(1000, 0).searchCustByID(customerId);
        Flight flight = flightManager.getFlight(flightId);


          
      if (customer == null)
      {
        Console.WriteLine("Customer ID not found :(");
        return;
      }
      if(flight == null)
      {
        Console.WriteLine("Flight ID not found :(");
        return;
      }

      if(flight.getPassengers() <= flight.getMaxSeats())
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

    //methods for the customer menu
    private void AddCustomer()
    {
      Console.WriteLine("Enter First Name: ");
      string firstName = Console.ReadLine();
      Console.WriteLine("Enter Last Name: ");
      string lastName = Console.ReadLine();
      Console.WriteLine("Enter Phone Number: ");
      string phone = Console.ReadLine();
      customerManager.addCustomer(firstName, lastName, phone);
    }

    private void ViewCustomers()
    {
      customerManager.viewAllCustomers();
    }

    private void DeleteCustomer()
    {
      Console.WriteLine("Enter Customer ID: ");
      int customerId = Convert.ToInt32(Console.ReadLine());
      customerManager.deleteCustomer(customerId);
    }

  }
}
