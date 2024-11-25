using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2129groupProject
{
    internal class Customer
    {
        
        private int customerID;
        private string firstName;
        private string lastName;
        private string phone;
        private int numBookings;

        //Constructor
        public Customer(int custID, string firstName, string lastName, string phone)
        {
            this.customerID = custID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            numBookings = 0;                                                       //initial number of bookings
        }

        //Getters
        public int GetCustomerID() { return customerID; }
        public string GetFirstName() { return firstName; }
        public string GetLastName() { return lastName; }
        public string GetPhone() { return phone; }
        public int GetNumBookings() { return numBookings; }

        //Setters
        public void SetCustomerID(int custID) { this.customerID = custID; }
        public void SetFirstName(string firstName) { this.firstName = firstName; }
        public void SetLastName(string lastName) { this.lastName = lastName; }
        public void SetPhone(string phone) { this.phone = phone; }
        public void SetNumBookings(int numBook) {  this.numBookings = numBook; }


        public override string ToString()
        {
            string s = "--Customer Details--"; 
            s += "\nID: "+customerID + "\nFirst Name: " + firstName + "\nLast Name: " + lastName + "\nPhone: " + phone +"\nNo. of Bookings: " +numBookings;
            return s;
        }

    }
}
