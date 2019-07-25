using System;
using System.Collections.Generic;

namespace Challenge_2
{
    public class ProgramUI
    {
        readonly ClaimRepository _claimsRepo = new ClaimRepository();
        Queue<Claim> _claimsQueue;
        int _response;

        public void Run()
        {
            _claimsQueue = _claimsRepo.GetClaims();

            Console.WriteLine("Main Menu");
            while (_response != 4)
            {

                PrintMenu();
                switch (_response) 
                {
                    case 1:
                        _claimsRepo.GetClaims();

                        Console.WriteLine($"Claim ID# \t Type of claim \t Amount \t Date of Incident \t Date of Claim \t Is Valid \t Description");
                        foreach (Claim c in _claimsQueue)
                            Console.WriteLine($"{c.ClaimID} \t\t {typeof(TypeOfClaim).GetEnumName(c.Category)}\t\t ${c.ClaimAmount} \t {c.IncidentDate} \t\t {c.ClaimDate} \t {c.IsValid} \t\t {c.Description}");

                        Console.WriteLine($"\nPress 'Enter' to return to menu.");

                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine($"{_claimsQueue.Peek()}\n" +
                            $"Do you want to address this now? y/n");
                        string handleClaim = Console.ReadLine().ToLower();

                        if (handleClaim == "y")
                            _claimsRepo.RemoveQueueItem();

                        break;
                    case 3:
                        CreateANewClaim();

                        break;
                    default:
                        break;
                }
            }
        }

        private void CreateANewClaim()
        {
            Console.WriteLine("Enter claim type: 1 = Car, 2 = Home, 3 = Theft, 4 = Other");
            var claimTypeInt = int.Parse(Console.ReadLine());

            var claimType = _claimsRepo.ClaimTypeSwitch(claimTypeInt);

            Console.WriteLine("Describe the claim: ");
            var description = Console.ReadLine();

            Console.WriteLine("How much will the claim cost?");
            var amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("When did the incident happen? mm/dd/yyyy");
            var incidentDate = GetDateAsString();

            string claimDate;
            Console.WriteLine("Was the claim filed today? y/n");
            if (Console.ReadLine().ToLower().Contains("y"))
            {
                claimDate = $"{DateTime.Now.Month}/{DateTime.Now.Day}/{DateTime.Now.Year}";
            }
            else
            {
                Console.WriteLine("When was the claim filed?");
                claimDate = GetDateAsString();
            }

            Claim claim = new Claim(claimType, description, amount, claimDate, incidentDate);

            _claimsRepo.AddClaimToQueue(claim);
        }

        private void PrintMenu()
        {
            Console.WriteLine($"1. See All Claims \n" +
                $"2. See Next Claim \n" +
                $"3. Enter New Claim \n" +
                $"4. Exit Menu");
            int.TryParse(Console.ReadLine(), out _response);
        }

        public string GetDateAsString()
        {
            Console.Write("Month #: ");
            bool isMonth = false;
            int month=0;
            while (!isMonth)
            {
                isMonth = int.TryParse(Console.ReadLine(), out month);
                if (!isMonth)
                    Console.WriteLine("Please enter the month in the correct format:");
            }
            isMonth = false;

            int day=0;
            while (!isMonth)
            {
                Console.Write("Date: ");

                isMonth = int.TryParse(Console.ReadLine(), out day);
                if (!isMonth)
                    Console.WriteLine("Please enter the day in the correct format:");
                else if (month == 2 && day > 29)
                {
                    Console.WriteLine("Please enter a correct date for february: ");
                    isMonth = false;
                }
                else if (_claimsRepo.MonthHas31Days(month) && day >= 31)
                {
                    Console.WriteLine("Please enter a date less than 31.");
                    isMonth = false;
                }
                else if (!_claimsRepo.MonthHas31Days(month) && day >= 30)
                {
                    Console.WriteLine("Please enter a date less than 30.");
                    isMonth = false;
                }
            }

            Console.Write("Year: ");
            var year = Console.ReadLine();
            while (year.Length != 4)
            {
                Console.WriteLine("Please enter the year in the correct format:");
                year = Console.ReadLine();
                Console.Clear();
            }
            return $"{month}/{day}/{year}";
        }

        
    }
}