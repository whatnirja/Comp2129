using AirLine;

internal class CustomerManager
{
    private Customer[] customers;
    private int numCustomers;
    private int max;
    private static int seed;


    public CustomerManager(int max, int startseed)
    {
        this.max = max;
        numCustomers = 0;
        customers = new Customer[max];
        seed = startseed;
    }

    public bool addCustomer(string firstName, string lastName, string phone)
    {
        if (numCustomers < max)
        {
            customers[numCustomers++] = new Customer(seed, firstName, lastName, phone);
            seed++;
            numCustomers++;
            return true;
        }
        return false;
    }

    public Customer searchCustByID(int id)
    {
        for (int i = 0; i < numCustomers; i++)
        {
            if (customers[i].GetCustomerId() == id)
            {
                return customers[i];
            }
        }
        return null;
    }
    public bool deleteCustomer(int id)
    {
        for (int i = 0; i < numCustomers; i++)
        {
            if (customers[i].GetCustomerId() == id)
            {
                customers[i] = customers[numCustomers - 1];
                numCustomers--;
                return true;
            }
        }
        return false;
    }
    public string viewAllCustomers()
    {
        string s = "List of Customers";
        for (int i = 0; i < numCustomers; i++)
        {
            s = s + "\n" + customers[i];
        }
        return s;
    }
}
