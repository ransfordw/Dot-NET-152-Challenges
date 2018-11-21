using System;
using System.Collections.Generic;

namespace Challenge_2
{
    public class ProgramUI
    {
        public void Run()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<Claim> claimsQueue = claimRepo.GetClaims();

            Claim claimOne = new Claim(1, TypeOfClaim.Car, "Accident on 65", 500.0m, "7/29/2018", "5/22/2018", false);
            Claim claimTwo = new Claim(2, TypeOfClaim.Car, "Flat tire", 125.0m, "7/25/2018", "6/30/2018", true);
            claimRepo.AddClaimToQueue(claimOne);
            claimRepo.AddClaimToQueue(claimTwo);

            Console.WriteLine("Main Menu");
            string response = "0";
            while (response != "4")
            {
                Console.Clear();
                Console.WriteLine($"1. See All Claims \n2. See Next Claim \n3. Enter New Claim \n4. Exit Menu");
                response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.Clear();
                        claimRepo.GetClaims();

                        Console.WriteLine($"Claim ID# \t Type of claim \t Amount \t Date of Incident \t Date of Claim \t Is Valid \t Description");
                        foreach (Claim c in claimsQueue)
                            Console.WriteLine($"{c.ClaimID} \t\t {typeof(TypeOfClaim).GetEnumName(c.Category)}\t\t ${c.ClaimAmount} \t {c.IncidentDate} \t\t {c.ClaimDate} \t {c.IsValid} \t\t {c.Description}");

                        Console.WriteLine($"\nPress 'Enter' to return to menu.");

                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine($"{claimsQueue.Peek()}\n");
                        Console.WriteLine("Do you want to address this now? y/n");
                        string handleClaim = Console.ReadLine();

                        if (handleClaim == "y")
                            claimRepo.RemoveQueueItem();

                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Enter new claim number: ");
                        var id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter claim type: 1 = Car, 2 = Home, 3 = Theft, 4 = Other");
                        var claimTypeInt = int.Parse(Console.ReadLine());

                        var claimType = claimRepo.ClaimTypeSwitch(claimTypeInt);

                        Console.WriteLine("Describe the claim: ");
                        var description = Console.ReadLine();

                        Console.WriteLine("How much will the claim cost?");
                        var amount = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("When did the incident happen? mm/dd/yyyy");
                        var incidentDate = Console.ReadLine();

                        Console.WriteLine("When was the claim filed? mm/dd/yyyy");
                        var claimDate = Console.ReadLine();

                        Claim claim = new Claim()
                        {
                            ClaimID = id,
                            Category = claimType,
                            Description = description,
                            ClaimAmount = amount,
                            ClaimDate = claimDate,
                            IncidentDate = incidentDate,
                            IsValid = claimRepo.ValidateClaim(claimDate, incidentDate)
                        };
                        claimRepo.AddClaimToQueue(claim);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}