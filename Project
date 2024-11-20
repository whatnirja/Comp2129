using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2129_prj
{
    internal class CustomerManager
    {
        private List<Customer> customers;

        public CustomerManager()
        {
            customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            if (!customer.IsValidCustomer())
            {
                Console.WriteLine("Invalid customer details. Customer not added.");
                return;
            }

            customers.Add(customer);
            Console.WriteLine("Customer added successfully.");
        }
        public void ViewCustomers()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
                return;
            }

            Console.WriteLine("\nList of Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        public bool DeleteCustomer(int customerID)
        {
            var customer = customers.Find(c => c.CustomerID == customerID);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return false;
            }

            if (customer.NumberOfBookings > 0)
            {
                Console.WriteLine("Cannot delete customer. They have active bookings.");
                return false;
            }

            customers.Remove(customer);
            Console.WriteLine("Customer deleted successfully.");
            return true;
        }
    }
}
