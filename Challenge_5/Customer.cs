namespace Challenge_5
{
    public enum CustomerStatus { Current = 1, Past, Potential }

    public class Customer
    {
        public Customer() { }

        public Customer(string name, CustomerStatus status, string email)
        {
            Name = name;
            Status = status;
            EmailResponse = email;
        }

        public string Name { get; set; }
        public CustomerStatus Status { get; set; }
        public string EmailResponse { get; set; }
    }
}
