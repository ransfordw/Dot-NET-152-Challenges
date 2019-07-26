using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge_5
{
    public class CustomerRepository
    {
        private readonly List<Customer> _customers;
        private string _emailResponse;
        private CustomerStatus _status;

        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }
        public List<Customer> GetCustomerList()
        {
            return _customers;
        }

        public void AddCustomerToList(Customer customer)
        {
            if (customer != null)
                _customers.Add(customer);
            else
                throw new Exception("Customer did not exist");
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
            if(!_customers.Exists(c => c.Name ==name))
              throw new Exception("Cannot find the desired customer. No need to remove");

            _customers.Remove(_customers.Single(c => c.Name == name));
        }

        public bool YesNoResponse(string input)
        {
            if (input.ToLower().Contains("y"))
                return true;
            else
                return false;
        }

        public CustomerStatus GetCustomerStatus(string input)
        {
            var inputToLower = input.ToLower();
            if (inputToLower.Contains("cu"))
                _status = CustomerStatus.Current;
            else if (inputToLower.Contains("pa"))
                _status = CustomerStatus.Past;
            else
                _status = CustomerStatus.Potential;
            return _status;
        }
    }
}
