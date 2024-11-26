using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2129groupProject
{
    internal class BookingManager
    {
        private Booking[] bookings;
        private int numBookings;
        private int max;
        private static int seed;
        private Customer[] customers;
        private Flight[] flights;

        public BookingManager(int max, int startseed, Customer[] customers, Flight[] flights)
        {
            this.max = max;
            numBookings=0;
            bookings = new Booking[max];
            seed = startseed;
            this.customers = customers; // Reference to customers
            this.flights = flights;
            LoadBookings();
        }

        private string bookingFile = @"..\..\..\Files\bookings.txt";

        public Customer SearchCustById(int custId)
        {
            foreach (Customer customer in customers)
            {
                if (customer != null && customer.GetCustomerID() == custId)
                {
                    return customer;
                }
            }
            return null;
        }


        public Flight SearchFlightByNum(int flightNum)
        {
            foreach (Flight flight in flights)
            {
                if (flight != null && flight.flightNum == flightNum)
                {
                    return flight;
                }
            }
            return null;
        }

        // Load bookings from the file
        private void LoadBookings()
        {
            if (!File.Exists(bookingFile))
            {
                Console.WriteLine("Booking file does not exist.");
                return;
            }   

            try
            {
                numBookings = 0;
                bookings = new Booking[max];
                string[] bookingRecords = File.ReadAllLines(bookingFile);
                foreach (string record in bookingRecords)
                {
                    string[] data = record.Split(',');
                    int bookingId = int.Parse(data[0]);   // Booking ID
                    string date = data[1];               // Booking date
                    int customerId = int.Parse(data[2]); // Customer ID
                    int flightNum = int.Parse(data[3]);  // Flight Number

                    // Find the corresponding Customer and Flight
                    Customer customer = SearchCustById(customerId);
                    Flight flight = SearchFlightByNum(flightNum);

                    if (customer != null && flight != null)
                    {
                        // Create the booking object and add it to the bookings array
                        Booking booking = new Booking(bookingId, date, customer, flight);
                        bookings[numBookings++] = booking;
                    }
                    else
                    {
                        Console.WriteLine($"Error: Customer ID {customerId} or Flight Number {flightNum} not found.");
                    }
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading bookings: {ex.Message}");
            }
        }


        private int GenerateBookingId()
        {
            return numBookings > 0 ? seed + numBookings + 1 : seed;
        }

        public bool AddBooking(string date,int  customerId,int flightNum)
        {
            if (numBookings > max)
            {
                Console.WriteLine("Not suffiecient space");
                return false;
            }

            Customer customer = SearchCustById(customerId);
            Flight flight = SearchFlightByNum(flightNum);
            if (customer == null)
            {
                Console.WriteLine($"Customer with ID {customerId} does not exist.");
                return false;
            }

            if (flight == null)
            {
                Console.WriteLine($"Flight with number {flightNum} does not exist.");
                return false;
            }

            if (flight.passengers >= flight.maxSeats)
            {
                Console.WriteLine($"Flight {flightNum} is fully booked.");
                return false;
            }

            Booking booking = new Booking(GenerateBookingId(), date, customer, flight);
            bookings[numBookings++] = booking;
            flight.passengers++;
            customer.SetNumBookings(customer.GetNumBookings() + 1);

            try
            {
                // Append new booking to the file
                using (StreamWriter writer = new StreamWriter(bookingFile, true))
                {
                    writer.WriteLine($"{booking.bookingId},{booking.date},{customer.GetCustomerID()},{flight.flightNum}");
                }
                UpdateCustomerFile();
                UpdateFlightFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving booking: {ex.Message}");
                return false;
            }

            Console.WriteLine($"Booking created successfully for Customer {customerId} on Flight {flightNum}.");
            return true;


        }

        public void UpdateFlightFile()
        {
            try
            {
                string[] flightRecords = new string[flights.Length];
                for (int i = 0; i < flights.Length; i++)
                {
                    if (flights[i] != null)
                    {
                        flightRecords[i] = $"{flights[i].flightNum},{flights[i].origin},{flights[i].destination},{flights[i].maxSeats},{flights[i].passengers}";
                    }
                }
                File.WriteAllLines(@"..\..\..\Files\flights.txt", flightRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating flight file: {ex.Message}");
            }
        }

        private void UpdateCustomerFile()
        {
            try
            {
                string[] customerRecords = new string[customers.Length];
                for (int i = 0; i < customers.Length; i++)
                {
                    if (customers[i] != null)
                    {
                        customerRecords[i] = $"{customers[i].GetCustomerID()},{customers[i].GetFirstName()},{customers[i].GetLastName()},{customers[i].GetPhone()},{customers[i].GetNumBookings()}";
                    }
                }
                File.WriteAllLines(@"..\..\..\Files\customer.txt", customerRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating customer file: {ex.Message}");
            }
        }

        public void ViewBookings()
        {
            if (File.Exists(bookingFile))
            {
                string[] bookings = File.ReadAllLines(bookingFile);
                if (bookings.Length == 0)
                {
                    Console.WriteLine("No Bookings :(");
                    return;
                }

                Console.WriteLine("Bookings:");
                Console.WriteLine("Booking ID\tDate\t\tCustomer ID\tFlight Number");
                Console.WriteLine("-------------------------------------------------------");
                foreach (string booking in bookings)
                {
                    string[] parts = booking.Split(",");
                    Console.WriteLine($"{parts[0]}\t{parts[1]}\t\t{parts[2]}\t\t{parts[3]}");
                }
            }
            else
            {
                Console.WriteLine("No Bookings file found :(");
            }
        }

        public bool DeleteBooking(int bookingId)
        {
            int index = -1;
            for (int i = 0; i < numBookings; i++)
            {
                if (bookings[i].bookingId == bookingId)
                {
                    index = i;
                    break;
                }
            }

            // If booking is not found
            if (index == -1)
            {
                Console.WriteLine($"Booking with ID {bookingId} not found.");
                return false;
            }
            Customer customer = bookings[index].customer;
            Flight flight = bookings[index].flight;
            customer.SetNumBookings(customer.GetNumBookings() - 1);
            flight.passengers--;
            bookings[index] = bookings[numBookings - 1];
            numBookings--;

            try
            {
                string[] bookingRecords = new string[numBookings];
                for (int i = 0; i < numBookings; i++)
                {
                    bookingRecords[i] = $"{bookings[i].bookingId},{bookings[i].date},{bookings[i].customer.GetCustomerID()},{bookings[i].flight.flightNum}";
                }
                File.WriteAllLines(bookingFile, bookingRecords);

                UpdateFlightFile();
                UpdateCustomerFile();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine($"Error updating files: {ex.Message}");
                return false;
            }

        }
    }
}
