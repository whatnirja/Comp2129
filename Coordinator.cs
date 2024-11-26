using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2129groupProject
{
    internal class Coordinator
    {
        private CustomerManager customerMan;
        private FlightManager flightMan;
        private BookingManager bookMan;

        public Coordinator()
        {
            customerMan = new CustomerManager(1000, 1);
            flightMan=new FlightManager(1000, 400);
            bookMan = new BookingManager(1000, 700,customerMan,flightMan);
        }

        //1. Customer
        public void CustomerMenu()
        {
            bool exit = false;
            while (!exit)
            {
                //Customer menu
                Console.WriteLine("\n---ABC Airlines Ltd.---");
                Console.WriteLine("Customer Menu");
                Console.WriteLine();
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. View Customers");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice(1-4): ");

                try
                {
                    string? choice = Console.ReadLine();                       
                    if (string.IsNullOrWhiteSpace(choice) || !int.TryParse(choice, out int parsedChoice)) 
                    {
                        //Loops till valid integer found
                        Console.Clear();
                        Console.WriteLine("Invalid choice, please enter integer (1-4).");
                        continue;
                    }

                    switch (parsedChoice)
                    {
                        case 1:
                            Console.Clear();
                            AddCustomer();
                            break;
                        case 2:
                            Console.Clear();
                            ViewCustomers();
                            break;
                        case 3:
                            Console.Clear();
                            DeleteCustomer();
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid choice, please enter integer (1-4).");
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

            }
        }

        //Adds Customer
        public void AddCustomer()
        {
            bool repeat;
            repeat = true;
            while (repeat) { //Repeats until valid input found
                Console.Clear();
                Console.WriteLine("Add new Customer");
                Console.WriteLine("Enter First Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter Phone Number: ");
                string phone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(phone))
                {
                    if (customerMan.AddCustomer(firstName, lastName, phone))
                    {
                        Console.WriteLine("New customer added successfuly.");
                        
                    }
                    
                    repeat = false;
                }
                else { Console.WriteLine("Invalid input. All fields must be non-empty."); }
            }
            
            
        }

        //Viwing all customer data
        public void ViewCustomers()
        {
            customerMan.ViewAllCustomer();
        }


        //Deleting Customer using ID input
        public void DeleteCustomer()
        {
            
            bool repeat=true;

            while(repeat)
            {
                ViewCustomers();
                Console.WriteLine("\nEnter Customer ID to be deleted(or press e to exit): ");
                string input=Console.ReadLine();
                if (input.ToLower() == "e")
                {
                    Console.Clear();
                    break;
                }
                if (int.TryParse(input, out int customerId))
                {
                    if (customerMan.DeleteCustomer(customerId))
                    {
                        
                        repeat = false;
                    }
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Id. Please try again. ");
                }
            }



       
            
        }



        //2. Flights
        public void FlightMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n---ABC Airlines Ltd.---");
                Console.WriteLine("Flight Menu");
                Console.WriteLine();
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
                            Console.Clear();
                            AddFlight();
                            break;
                        case 2:
                            Console.Clear();
                            ViewAllFlights();
                            break;
                        case 3:
                            Console.Clear();
                            ViewAParticularFlight();
                            break;
                        case 4:
                            Console.Clear();
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

        public void AddFlight()
        {
            bool repeat;
            repeat = true;
            while (repeat)
            { //Repeats until valid input found
                Console.Clear();
                Console.WriteLine("--Add new Flight--");
                Console.WriteLine("Enter Origin: ");
                string origin = Console.ReadLine();
                Console.WriteLine("Enter Destination: ");
                string destination = Console.ReadLine();
                Console.WriteLine("Enter maximum seats: ");
                string maxSeats = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(origin) && !string.IsNullOrWhiteSpace(destination) && !string.IsNullOrWhiteSpace(maxSeats))
                {
                    if (flightMan.AddFlight(origin, destination, int.Parse(maxSeats)))
                    {
                        Console.Clear() ;
                        Console.WriteLine($"Flight added successfully.");

                    }

                    repeat = false;
                }
                else { Console.WriteLine("Invalid input. All fields must be non-empty."); }
            }
        }
        public void ViewAllFlights()
        {
            flightMan.ViewFlights();
        }

        public void ViewAParticularFlight()
        {
            bool repeat = true;

            while (repeat)
            {
                
                Console.WriteLine("\nEnter Flight number to be viewed(or press e to exit): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "e")
                {
                    Console.Clear();
                    break;
                }
                if (int.TryParse(input, out int flightNum))
                {
                    flightMan.ViewParticularFlight(flightNum);
                    repeat = false;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Id. Please try again. ");
                }
            }
        }

        public void DeleteFlight()
        {
            bool repeat = true;
            
            while (repeat)
            {
                ViewAllFlights();
                Console.WriteLine("\nEnter Flight number to be deleted(or press e to exit): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "e")
                {
                    Console.Clear();
                    break;
                }
                if (int.TryParse(input, out int flightNum))
                {
                    if (flightMan.DeleteFlight(flightNum))
                    {
                        Console.Clear() ;
                        Console.WriteLine($"Flight with number {flightNum} deleted.");
                        repeat = false;
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Id. Please try again. ");
                }
            }
        }

        //3. Booking
        public void BookingMenu()
        {
            bool exit = false;
            while (!exit)
            {
                //Booking menu
                Console.WriteLine("\n---ABC Airlines Ltd.---");
                Console.WriteLine("Booking Menu");
                Console.WriteLine();
                Console.WriteLine("1. View Bookings");
                Console.WriteLine("2. Make a Booking");
                Console.WriteLine("3. Delete a Booking");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice(1-4): ");

                try
                {
                    string? choice = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(choice) || !int.TryParse(choice, out int parsedChoice))
                    {
                        //Loops till valid integer found
                        Console.Clear();
                        Console.WriteLine("Invalid choice, please enter integer (1-4).");
                        continue;
                    }

                    switch (parsedChoice)
                    {
                        case 1:
                            Console.Clear();
                            //AddBooking();
                            break;
                        case 2:
                            Console.Clear();
                            //ViewBookings();
                            break;
                        case 3:
                            Console.Clear();
                            //DeleteBooking();
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid choice, please enter integer (1-4).");
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

            }
        }

        //1. add New Booking
        public void AddBooking()
        {
            bool repeat;
            repeat = true;
            while (repeat)
            { //Repeats until valid input found
                Console.Clear();
                Console.WriteLine("--Add new Booking--");
                Console.WriteLine("Enter Date: ");
                string date = Console.ReadLine();
                Console.WriteLine("Enter Customer ID: ");
                string custId = Console.ReadLine();
                Console.WriteLine("Enter Flight ID: ");
                string flightId = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(date) && !string.IsNullOrWhiteSpace(custId) && !string.IsNullOrWhiteSpace(flightId))
                {
                    if (bookMan.AddBooking(date, int.Parse(custId), int.Parse(flightId)))
                    {
                        Console.Clear();
                        Console.WriteLine($"Flight added successfully.");

                    }

                    repeat = false;
                }
                else { Console.WriteLine("Invalid input. All fields must be non-empty."); }
            }
        }


    }
}
