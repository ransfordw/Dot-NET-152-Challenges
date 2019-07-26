using Challenge_UtilityMethods;
using System;
using System.Collections.Generic;

namespace Challenge_3
{
    public class ProgramUI
    {
        private readonly OutingRepository _outingRepo = new OutingRepository();
        private List<Outing> _outings;
        private EventType _type;
        private int _response;
        private readonly IConsole _console;

        public ProgramUI(IConsole console)
        {
            _outingRepo = new OutingRepository();
            _console = console;
        }
        public void Run()
        {
            _outings = _outingRepo.GetList();

            while (_response != 5)
            {
                PrintMenu();
                switch (_response)
                {
                    case 1:
                        _console.WriteLine($"List of Outings\n\nOuting Type\tNumber Of People\tDate of Outing\t\tCost per Person\t\tTotal Cost");
                        foreach (Outing thisOuting in _outings)
                            _console.WriteLine($"{thisOuting.Category}\t\t{thisOuting.NumPpl} \t\t\t{thisOuting.DateOfEvent}\t\t${thisOuting.PerPersonCost}\t\t\t${thisOuting.TotalEventCost}");
                        break;
                    case 2:
                        _console.WriteLine("Enter outing category: Golf = 1, Bowling = 2, Amusment Park = 3, Concert = 4, Other = 5");
                        int categoryInt = int.Parse(_console.ReadLine());
                        _type = _outingRepo.EventTypeSwitch(categoryInt);

                        _console.WriteLine("How manny people attended the event?");
                        var numPpl = int.Parse(_console.ReadLine());

                        _console.WriteLine("When was the event? mm/dd/yyyy");
                        var eventDate = _console.ReadLine();

                        _console.WriteLine("What was the cost per person?");
                        var perPersonCost = decimal.Parse(_console.ReadLine());
                        var totalCost = perPersonCost * numPpl;
                        Outing outing = new Outing(_type, numPpl, eventDate, perPersonCost, totalCost);

                        _outingRepo.AddToList(outing);
                        break;
                    case 3:
                        _console.WriteLine("Enter desired outing type: Golf = 1, Bowling = 2, Amusment Park = 3, Concert = 4, Other = 5");
                        var desiredType = int.Parse(_console.ReadLine());
                        var outingType = _outingRepo.EventTypeSwitch(desiredType);
                        _outingRepo.AddOutingToListByType(outingType);
                        _console.WriteLine("Total cost of desired outing = " + _outingRepo.ReturnDesiredCostByType());
                        break;
                    case 4:
                        decimal sum = 0;
                        foreach (Outing thisOuting in _outings)
                            sum += thisOuting.TotalEventCost;
                        _console.WriteLine("The outstanding total cost is: $" + sum);
                        break;
                    case 5:
                        break;
                    default:
                        _console.WriteLine("Please enter a correct value.");
                        break;
                }
                _console.WriteLine("Press any key to continue ...");
                _console.ReadKey();
            }
        }

        private void PrintMenu()
        {
            _console.WriteLine($"What would you like to do?\n\n" +
                       $"1. See all outings\n" +
                       $"2. Add new outings to the list\n" +
                       $"3. Determine total cost by outing type\n" +
                       $"4. Determine current cost for all outstanding outings\n" +
                       $"5. Exit Menu\n");

            bool cont;
            do
            {
                _console.Write("Please enter the menu number for your desired option: ");
                cont = int.TryParse(_console.ReadLine(), out _response);
            } while (!cont);

        }
    }
}