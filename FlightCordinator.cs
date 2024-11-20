using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    internal class FlightCordinator
    {
        private flightManager FlightM;

        public FlightCordinator(flightManager FlightM)
        {
            this.FlightM = FlightM;
        }
        static void showFlightMenu()
        {
            Console.Clear();
            Console.WriteLine("XYZ Airlines Limited");
            Console.WriteLine("Flight Menu");
            Console.WriteLine("1. Add Flight");
            Console.WriteLine("2. View Flights");
            Console.WriteLine("3. View a particular Flight");
            Console.WriteLine("4. Delete a Flight");
            Console.WriteLine("5. Back to Main Menu");
        }

        static int getValidFlightInput()
        {
            int choice;
            showFlightMenu();
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                showFlightMenu();
                Console.WriteLine("Please enter a valid choice");
            }
            return choice;
        }
        public static void returnToFlightMenu()
        {
            int input;
            Console.WriteLine("Enter 0 to return to Flight Menu");
            while (!int.TryParse(Console.ReadLine(), out input) || input == 0)
            {
                Console.Clear();
                showFlightMenu();
            }
            
        }
        public void runFlightProgram()
        {
            while (true)
            {
                int choice = getValidFlightInput(); 

                switch (choice)
                {
                    case 1:
                        FlightM.AddFlight();
                        returnToFlightMenu();
                        break;
                    case 2:
                        FlightM.ViewFlights();
                        returnToFlightMenu();
                        break;
                    case 3:
                        FlightM.ViewParticularFlight();
                        returnToFlightMenu();
                        break;
                    case 4:
                        FlightM.DeleteFlight();
                        returnToFlightMenu();
                        break;
                    case 5:
                        Console.WriteLine("Returning to Main Menu...");
                        return; // Exit the method to go back to the main menu
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

    }
}