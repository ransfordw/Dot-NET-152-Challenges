using System.Collections.Generic;
using System.Linq;

namespace Challenge_5
{
    public class CustomerRepository
    {
        private List<Customer> _customers = new List<Customer>();
        private string _emailResponse;
        private CustomerStatus _status;

        public List<Customer> GetCustomerList()
        {
            return _customers;
        }

        public void AddCustomerToList(Customer customer)
        {
            _customers.Add(customer);
        }

        public string GetEmailResponse(CustomerStatus status)
        {
            switch (status)
            {
                case CustomerStatus.Current:
                    _emailResponse = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case CustomerStatus.Past:
                    _emailResponse = "It's been a long time since we've heard from you, we want you back";
                    break;
                case CustomerStatus.Potential:
                    _emailResponse = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
                default:
                    break;
            }
            return _emailResponse;
        }

        public void RemoveCustomerFromList(string name)
        {
            var remove = _customers.Single(c => c.Name == name);
            _customers.Remove(remove);
        }

        public bool YesNoResponse(string input)
        {
            if (input.Contains("y"))
                return true;
            else
                return false;
        }

        public CustomerStatus GetCustomerStatus(string input)
        {
            input.ToLower();
            if (input.Contains("cu"))
                _status = CustomerStatus.Current;
            else if (input.Contains("pa"))
                _status = CustomerStatus.Past;
            else
                _status = CustomerStatus.Potential;
            return _status;
        }
    }
}
