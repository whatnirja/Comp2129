using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2129groupProject
{
    internal class CustomerManager
    {
        private Customer[] customers;             
        private int numCustomers;
        private int max;
        private static int seed;

        private string customerFile = @"..\..\..\Files\customer.txt";


        public CustomerManager(int max, int startseed)
        {
            this.max = max;
            numCustomers = 0;
            customers = new Customer[max];
            seed = startseed;
            LoadCustomer();
        }

        private void LoadCustomer()
        {
            if (!File.Exists(customerFile))
            {
                Console.WriteLine("Customer file does not exist.");
                return;
            }

            try
            {
                numCustomers = 0;
                customers = new Customer[max];
                string[] customerRecords = File.ReadAllLines(customerFile);
                foreach (string record in customerRecords)
                {
                    string[] data = record.Split(',');
                    Customer customer = new Customer(int.Parse(data[0]), data[1], data[2], data[3]);
                    customer.SetNumBookings(int.Parse(data[4]));
                    customers[numCustomers++] = customer;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading flights: {ex.Message}");
            }
        }
        //Reads the Customer File and returns an array
        public string[] ReadCustomerFile()
        {
            try
            {
                if (File.Exists(customerFile))
                {
                    string[] customers = File.ReadAllLines(customerFile);  
                    numCustomers = customers.Length;
                    return customers;
                }
                else
                {
                    Console.WriteLine("Customer file does not exist.");
                    return new string[0];                             //Return an empty array 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return new string[0];                                 //Return an empty array
            }
            
        }



        //Generates customer id on the basis of last customer added
        private int GenerateCustomerId()
        {
            //if customer file does not exist
            if (!File.Exists(customerFile))
            {
                return seed;
            }

            //if there are no customers yet
            string[] customers = ReadCustomerFile();
            if (customers.Length == 0)
            {
                return seed;
            }

            //if there are already customers
            string lastCustomer = customers[customers.Length - 1];
            int lastCustomerId = Convert.ToInt32(lastCustomer.Split(",")[0]);
            return lastCustomerId + 1;       
        }

        //Adding new Customers
        public bool AddCustomer(string firstName, string lastName, string phone)
        {
            string[] customerRecords = ReadCustomerFile();
            
            if (customerRecords.Length>0)
            {
                foreach (string record in customerRecords)    //Loops through each customer entry
                {
                    string[] data = record.Split(',');        
                    if (data[1] == firstName && data[2] == lastName && data[3] == phone)   //checks for exact same credentials
                    {
                        Console.WriteLine("Customer with the same name and phone number already exists.");
                        return false;                          // Doesn't add if duplicate found
                    }
                }
            }
            if (numCustomers < max) 
            {
                Customer newCust = new Customer(GenerateCustomerId(), firstName, lastName, phone);
                customers[numCustomers++] = newCust;
                
                using (StreamWriter writer = new StreamWriter(customerFile, true))
                {
                    writer.WriteLine($"{newCust.GetCustomerID()},{newCust.GetFirstName()},{newCust.GetLastName()},{newCust.GetPhone()},{newCust.GetNumBookings()}");
                }         //Appends file with attributes separated by comma
                return true;
            }
            else
            {
                Console.WriteLine("Not suffiecient space.");
                return false;
            }
            
        }
        
        
        //Views all Customer data
        public bool ViewAllCustomer()
        {
            

        Console.WriteLine("----Customer List----");
        Console.WriteLine("ID\tFirst Name\tLast name\tPhone\t\tNo. of Bookings");
        Console.WriteLine("----------------------------------------------------------------------");

        string[] customerRecords = ReadCustomerFile();

        if (customerRecords.Length > 0)
        {
            foreach (string record in customerRecords)
            {
            string[] data = record.Split(',');
            Console.WriteLine($"{data[0]}\t{data[1]}\t\t{data[2]}\t\t{data[3]}\t\t{data[4]}");
            }
        }
        else
        {
            Console.WriteLine("No customers found."); //if customerRecord.Length is 0
        }
            return true;
        }


        //Deletes customer by taking Id input
        public bool DeleteCustomer(int custId)
        {
            string[] customerRecords = ReadCustomerFile(); // Read all customer records from file
            if (customerRecords == null || customerRecords.Length == 0)
            {
                Console.WriteLine("No customers found to delete.");
                return false;
            }

            bool found = false;
            string[] updatedRecords = new string[customerRecords.Length - 1]; //Array for updated records
            int counter = 0;

            foreach (string record in customerRecords)
            {
                string[] data = record.Split(',');
                if (data[0] == custId.ToString())                             //Check if the ID matches
                {
                    if (int.Parse(data[4]) == 0)                              //Checks for any active bookings
                    {
                        found = true;                                        
                        continue;                                             //Doesn't add this customer entry to updated records 
                    }
                    else
                    {
                        Console.WriteLine($"Customer with ID {custId} has active Bookings.");
                        return false;                                         //exits if person has bookings
                    }
                    
                }

                if (counter < customerRecords.Length - 1)
                {
                    updatedRecords[counter++] = record;                       //Adds the record to the updated array
                }
            }

            if (!found)
            {
                Console.Clear();
                Console.WriteLine($"Customer with ID {custId} not found.");
                return false;
            }

            //Write the updated records back to the file
            try
            {
                File.WriteAllLines(customerFile, updatedRecords);
                Console.WriteLine($"Customer with ID {custId} has been deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
                return false;
            }

            return true;
        }

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

    }
}
