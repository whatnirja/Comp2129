internal class Customer
{
    private int customerId;
    private string firstName;
    private string lastName;
    private string phone;
    private int numBookings;

    public Customer(int custId, string firstName, string lastName, string phone)
    {
        this.customerId = custId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        numBookings = 0;
    }

    public int getCustomerID() { return customerId; }
    public string getFirstName() { return firstName; }
    public string getLastName() { return lastName; }
    public string getPhone() { return phone; }
    public int getNumBookings() { return numBookings; }

    public void setCustomerID(int custID) { this.customerId = custID; }
    public void setFirstName(string firstName) { this.firstName = firstName; }
    public void setLastName(string lastName) { this.lastName = lastName; }
    public void setPhone(string phone) { this.phone = phone; }
    public override string ToString()
    {
        string s = customerId + "\t" + firstName + "\t" + lastName + "\t" + phone;
        return s;
    }

}
