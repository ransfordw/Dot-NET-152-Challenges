using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge_5
{
    public class ProgramUI
    {
        public void Run()
        {
            CustomerRepository customerRepo = new CustomerRepository();
            Customer customer = new Customer();
            List<Customer> customers = customerRepo.GetCustomerList();
            bool response = true;
            CustomerStatus status;

            while (response)
            {
                Console.WriteLine("Welcome to Komodo Customer management!\n\nWhat would you like to do?\n\t" +
                    "1. See all customers\n\t" +
                    "2. Add customer\n\t" +
                    "3. Remove customer\n\t" +
                    "4. Update customer status\n\t" +
                    "5. Exit");
                var menuInput = int.Parse(Console.ReadLine());
                switch (menuInput)
                {
                    case 1:
                        List<Customer> sortedList = customers.OrderBy(c => c.Name).ToList();
                        Console.WriteLine("Name\t\tStatus\t\tEmail");
                        if (customers.Count < 1 || customers.Capacity == 0)
                            Console.WriteLine("It appears there aren't any customers.");
                        else
                            foreach (Customer c in sortedList)
                            {
                                Console.WriteLine($"{c.Name}\t\t{c.Status}\t\t{c.EmailResponse}");
                            }
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter customer name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter customer status (Current, Past, Potential): ");
                        string statusInput = Console.ReadLine().ToLower();
                        status = customerRepo.GetCustomerStatus(statusInput);
                        customer = new Customer()
                        {
                            Name = name,
                            Status = status,
                            EmailResponse = customerRepo.GetEmailResponse(status),
                        };
                        customerRepo.AddCustomerToList(customer);
                        break;
                    case 3:
                        Console.WriteLine("Enter the name of the customer you would like to remove: \n\n" +
                            "Name\t\tStatus");
                        if (customers.Count < 1 || customers.Capacity == 0)
                            Console.WriteLine("It appears there aren't any customers.");
                        else
                        {
                            foreach (Customer c in customers)
                                Console.WriteLine($"{c.Name}\t\t{c.Status}");

                            var remove = Console.ReadLine();
                            customerRepo.RemoveCustomerFromList(remove);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter the name of the customer you would like to update:");
                        PrintCustomerDetails(customers);
                        var updateName = Console.ReadLine();
                        foreach (Customer c in customers)
                        {
                            if (c.Name == updateName)
                            {
                                Console.WriteLine($"Current Name: {c.Name}. Would you like to update?");
                                if (customerRepo.YesNoResponse(Console.ReadLine()))
                                {
                                    Console.Write("Enter new name: ");
                                    c.Name = Console.ReadLine();
                                }
                                Console.WriteLine($"Current Status: {c.Status}. Would you like to update?");
                                if (customerRepo.YesNoResponse(Console.ReadLine()))
                                {
                                    Console.Write("Enter new status: ");
                                    string updateStatus = Console.ReadLine().ToLower();
                                    c.Status = customerRepo.GetCustomerStatus(updateStatus);
                                }
                            }
                        }
                        break;
                    default:
                        response = false;
                        break;
                }
            }
        }
        public void PrintCustomerDetails(List<Customer> customers)
        {
            Console.WriteLine("Name\t\tStatus");
            foreach (Customer c in customers)
            {
                Console.WriteLine($"{c.Name}\t\t{c.Status}");
            }
        }
    }
}