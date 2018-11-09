using System;
using System.Collections.Generic;

namespace Challenge_3
{
    public class ProgramUI
    {
        public void Run()
        {
            OutingRepository outingRepo = new OutingRepository();
            List<Outing> outings = outingRepo.GetList();
            Outing bowling = new Outing(EventType.Bowling, 15, "6/23/2018", 23.00m, 345.0m);
            Outing concert = new Outing(EventType.Concert, 6, "8/26/2018", 26.0m, 156.0m);
            Outing golfOne = new Outing(EventType.Golf, 4, "7/31/2018", 15.0m, 60.0m);
            Outing golfTwo = new Outing(EventType.Golf, 4, "6/30/2018", 25.0m, 100.0m);
            EventType _type;

            outingRepo.AddToList(bowling);
            outingRepo.AddToList(concert);
            outingRepo.AddToList(golfOne);
            outingRepo.AddToList(golfTwo);

            string response = "0";
            while (response != "5")
            {
                Console.Clear();
                Console.WriteLine($"What would you like to do?\n\n1. See all outings\n2. Add new outings to the list\n3. Determine total cost by outing type\n4. Determine current cost for all outstanding outings\n5. Exit Menu\n");
                response = Console.ReadLine();
                Console.Clear();

                switch (response)
                {
                    case "1":
                        Console.WriteLine($"List of Outings\n\nOuting Type\tNumber Of People\tDate of Outing\t\tCost per Person\t\tTotal Cost");
                        foreach (Outing thisOuting in outings)
                            Console.WriteLine($"{thisOuting.Category}\t\t{thisOuting.NumPpl} \t\t\t{thisOuting.DateOfEvent}\t\t${thisOuting.PerPersonCost}\t\t\t${thisOuting.TotalEventCost}");
                        Console.WriteLine($"\nPress 'enter' to return to menu.");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Enter outing category: Golf = 1, Bowling = 2, Amusment Park = 3, Concert = 4, Other = 5");
                        int categoryInt = int.Parse(Console.ReadLine());
                        _type = outingRepo.EventTypeSwitch(categoryInt);

                        Console.WriteLine("How manny people attended the event?");
                        var numPpl = int.Parse(Console.ReadLine());

                        Console.WriteLine("When was the event? mm/dd/yyyy");
                        var eventDate = Console.ReadLine();

                        Console.WriteLine("What was the cost per person?");
                        var perPersonCost = decimal.Parse(Console.ReadLine());
                        var totalCost = perPersonCost * numPpl;
                        Outing outing = new Outing(_type, numPpl, eventDate, perPersonCost, totalCost);

                        outingRepo.AddToList(outing);

                        Console.WriteLine($"\nPress 'enter' to return to menu.");
                        Console.ReadLine();
                        break;
                    case "3":
                        List<Outing> listByType = outingRepo.GetNewListByType();
                        Console.WriteLine("Enter desired outing type: Golf = 1, Bowling = 2, Amusment Park = 3, Concert = 4, Other = 5");
                        var desiredType = int.Parse(Console.ReadLine());
                        var outingType = outingRepo.EventTypeSwitch(desiredType);
                        outingRepo.AddOutingToListByType(outingType);
                        Console.WriteLine("Total cost of desired outing = " + outingRepo.ReturnDesiredCostByType());

                        Console.WriteLine($"\nPress 'enter' to return to menu.");
                        Console.ReadLine();
                        break;
                    case "4":
                        decimal sum = 0;
                        foreach (Outing thisOuting in outings)
                            sum += thisOuting.TotalEventCost;
                        Console.WriteLine("The outstanding total cost is: $" + sum);
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}