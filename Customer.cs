using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirLine
{
    public class Customer
    {
        private int customerId;
        private string firstName;
        private string lastName;
        private string email;
        private string customerFile = "customers.txt";
        public Customer(int customerId, string firstName, string lastName , string email)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        public Customer(){}
        public int GetCustomerId()
        {
            return this.customerId;
        }

        public string GetFirstName()
        {
            return this.firstName;
        } 

        public string GetLastName()
        {
            return this.lastName;
        }
        public string GetEmail()
        {
            return this.email;
        }

        public string ViewCustomers()
        {
            if(File.Exists(customerFile))
            {
                string[] customers = File.ReadAllLines(customerFile);
                if(customers.Length == 0)
                {
                    return "No customers :(";
                }
                return string.Join("\n", customers);
            }
            else
            {
                return "No customers file found :(";
            }
        }

        public void IncrementBookings()
        {
            File.AppendAllText(customerFile, this.ToString() + "\n");
        }

        public override string ToString()
        {
            return $"{GetCustomerId()}, {GetFirstName()} {GetLastName()}, {GetEmail()}";
        }

       
    }
}
