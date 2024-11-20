using System.Threading.Tasks;

namespace _2129_prj
{
    internal class Customer
    {
        public int CustomerID { get; private set; }
        public string CustomerFname { get; private set; }
        public string CustomerLname { get; private set; }
        public string PhoneNumber { get; private set; }
        public int NumberOfBookings { get; set; }

        // Constructor
        public Customer(string firstname, string lastname, string phonenumber)
        {
            CustomerFname = firstname;
            CustomerLname = lastname;
            PhoneNumber = phonenumber;
            CustomerID = GenerateCustomerID(); // Auto-generate unique ID
            NumberOfBookings = 0; // Default value
        }

        // Generate unique ID
        private static int GenerateCustomerID()
        {
            return new Random().Next(1000, 9999);
        }

        public bool IsValidCustomer()
        {
            return !string.IsNullOrEmpty(CustomerFname) &&
                   !string.IsNullOrEmpty(CustomerLname) &&
                   !string.IsNullOrEmpty(PhoneNumber);
        }

        public override string ToString()
        {
            return $"ID: {CustomerID}, Name: {CustomerFname} {CustomerLname}, Phone: {PhoneNumber}, Bookings: {NumberOfBookings}";
        }
    }
}
