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

        public BookingManager(int max, int startseed)
        {
            this.max = max;
            numBookings=0;
            bookings = new Booking[max];
            seed = startseed;
            //LdFlights();
        }

        private string bookingFile = @"..\..\..\Files\bookings.txt";

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
                    //Booking booking = new Booking(int.Parse(data[0]), data[1], )
                    //bookings[numBookings++] = booking;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading bookings: {ex.Message}");
            }
        }

    }
}
