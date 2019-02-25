using System;
using System.Collections.Generic;

namespace Challenge_3
{
    public class ProgramUI
    {
        OutingRepository _outingRepo = new OutingRepository();
        List<Outing> _outings;
        EventType _type;
        int _response;

        public void Run()
        {
            _outings = _outingRepo.GetList();
            _outingRepo.SeedData();

            while (_response != 5)
            {
                PrintMenu();
                switch (_response)
                {
                    case 1:
                        Console.WriteLine($"List of Outings\n\nOuting Type\tNumber Of People\tDate of Outing\t\tCost per Person\t\tTotal Cost");
                        foreach (Outing thisOuting in _outings)
                            Console.WriteLine($"{thisOuting.Category}\t\t{thisOuting.NumPpl} \t\t\t{thisOuting.DateOfEvent}\t\t${thisOuting.PerPersonCost}\t\t\t${thisOuting.TotalEventCost}");
                        break;
                    case 2:
                        Console.WriteLine("Enter outing category: Golf = 1, Bowling = 2, Amusment Park = 3, Concert = 4, Other = 5");
                        int categoryInt = int.Parse(Console.ReadLine());
                        _type = _outingRepo.EventTypeSwitch(categoryInt);

                        Console.WriteLine("How manny people attended the event?");
                        var numPpl = int.Parse(Console.ReadLine());

                        Console.WriteLine("When was the event? mm/dd/yyyy");
                        var eventDate = Console.ReadLine();

                        Console.WriteLine("What was the cost per person?");
                        var perPersonCost = decimal.Parse(Console.ReadLine());
                        var totalCost = perPersonCost * numPpl;
                        Outing outing = new Outing(_type, numPpl, eventDate, perPersonCost, totalCost);

                        _outingRepo.AddToList(outing);
                        break;
                    case 3:
                        List<Outing> listByType = _outingRepo.GetNewListByType();
                        Console.WriteLine("Enter desired outing type: Golf = 1, Bowling = 2, Amusment Park = 3, Concert = 4, Other = 5");
                        var desiredType = int.Parse(Console.ReadLine());
                        var outingType = _outingRepo.EventTypeSwitch(desiredType);
                        _outingRepo.AddOutingToListByType(outingType);
                        Console.WriteLine("Total cost of desired outing = " + _outingRepo.ReturnDesiredCostByType());
                        break;
                    case 4:
                        decimal sum = 0;
                        foreach (Outing thisOuting in _outings)
                            sum += thisOuting.TotalEventCost;
                        Console.WriteLine("The outstanding total cost is: $" + sum);
                        break;
                    default:
                        Console.WriteLine("Please enter a correct value.");
                        break;
                }
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine($"What would you like to do?\n\n" +
                       $"1. See all outings\n" +
                       $"2. Add new outings to the list\n" +
                       $"3. Determine total cost by outing type\n" +
                       $"4. Determine current cost for all outstanding outings\n" +
                       $"5. Exit Menu\n");

            var cont = false;
            do
            {
                Console.Write("Please enter the menu number for your desired option: ");
                cont = int.TryParse(Console.ReadLine(), out _response);
            } while (!cont);

        }
    }
}