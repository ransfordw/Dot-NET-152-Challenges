using System;
using System.Collections.Generic;

namespace Challenge_7
{
    public class ProgramUI
    {
        BoothFactory _boothMaker = new ConcreteBoothFactory();
        BoothRepository _boothRepo = new BoothRepository();
        IBooth _booth;
        List<IBooth> _booths;
        List<Party> _parties;

        public void Run()
        {
            _booths = _boothRepo.GetBooths();
            _parties = _boothRepo.GetParties();
            SeedData();
            GetBoothTickets();
            Console.WriteLine("Welcome to the Komodo Party Planning Committee!");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("What would you like to do?\n\t" +
                    "1. Create a new booth \n\t" +
                    "2. Create a new party\n\t" +
                    "3. See party details\n\t" +
                    "4. See total tickets per booth\n\t" +
                    "5. See all parties\n\t" +
                    "6. Exit");
                var menuResponse = int.Parse(Console.ReadLine());
                switch (menuResponse)
                {
                    case 1:
                        Console.WriteLine("What kind of booth would you like to create?\n\t1. Burger\n\t2. Dessert");
                        var boothTypeResponse = int.Parse(Console.ReadLine());
                        _booth = _boothMaker.GetBooth(boothTypeResponse, GetBoothName(), GetMainItemCost(boothTypeResponse), _boothRepo.GetMiscCost(boothTypeResponse));
                        _boothRepo.AddBoothToList(_booth);
                        break;
                    case 2:
                        Console.WriteLine("What is the name of your party?");
                        var name = Console.ReadLine();

                        List<BurgerBooth> burgers = new List<BurgerBooth>();
                        List<DessertBooth> desserts = new List<DessertBooth>();

                        foreach (IBooth booth in _booths)
                        {
                            if (booth.GetType() == typeof(BurgerBooth))
                                burgers.Add((BurgerBooth)booth);
                            else
                                desserts.Add((DessertBooth)booth);
                        }

                        Console.WriteLine("Which Burger booth did your party have?");
                        PrintBooths(burgers);
                        var burgerChoiceInt = int.Parse(Console.ReadLine());
                        var burgerChoice = burgers[burgerChoiceInt - 1];

                        Console.WriteLine($"How many tickets did {burgerChoice.BoothName} recieve?");
                        var burgerTix = int.Parse(Console.ReadLine());

                        Console.WriteLine("Which Dessert booth did your party have?");
                        PrintBooths(desserts);

                        var dessertChoiceInt = int.Parse(Console.ReadLine());
                        var dessertChoice = desserts[dessertChoiceInt - 1];

                        Console.WriteLine($"How many tickets did {dessertChoice.BoothName} recieve?");
                        var dessertTix = int.Parse(Console.ReadLine());

                        Party party = new Party(name, burgerChoice, burgerTix, dessertChoice, dessertTix);
                        _boothRepo.AddPartyToList(party);
                        break;
                    case 3:
                        int i = 1;
                        if (_parties.Count != 0)
                        {
                            Console.WriteLine("Which party do you need details on?");
                            foreach (Party p in _parties)
                            {
                                Console.WriteLine($"{i}. {p.PartyName}");
                                i++;
                            }
                            var input = int.Parse(Console.ReadLine());
                            Console.WriteLine(_parties[input - 1]);
                        }
                        else
                            Console.WriteLine("There are no parties.");
                        break;
                    case 4:
                        Console.WriteLine("Booth Name\tTickets Taken");
                        foreach (IBooth booth in _booths)
                        {
                            if (booth is BurgerBooth)
                                Console.WriteLine($"{booth.BoothName}: {booth.TicketsTaken}");
                            else
                                Console.WriteLine($"{booth.BoothName}: {booth.TicketsTaken}");
                        }
                        Console.ReadLine();
                        break;
                    case 5:
                        foreach (Party p in _parties)
                        {
                            Console.WriteLine($"{p.PartyName}");
                        }
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
        }

        private void GetBoothTickets()
        {
            foreach (var booth in _booths)
            {
                foreach (var p in _parties)
                {
                    if (p.DessertBooth == booth)
                        booth.TicketsTaken += p.DessertTickets;
                    else if (p.BurgerBooth == booth)
                        booth.TicketsTaken += p.BurgerTickets;
                }
            }
        }

        private void SeedData()
        {
            var dessert = new DessertBooth("Mrs. Curl", 3.5m, 0.75m);
            var burger = new BurgerBooth("Bob's Burgers", 10.99m, 1.2m);
            _boothRepo.AddBoothToList(dessert);
            _boothRepo.AddBoothToList(burger);
            _boothRepo.AddPartyToList(new Party("Holiday Party", burger, 12, dessert, 34));
        }

        private decimal GetMainItemCost(int boothTypeResponse)
        {
            decimal cost = 0;
            switch (boothTypeResponse)
            {
                case 1:
                    Console.WriteLine("What is the cost of the entre?");
                    cost = decimal.Parse(Console.ReadLine());
                    return cost;
                default:
                    Console.WriteLine("What is the cost of the dessert?");
                    cost = decimal.Parse(Console.ReadLine());
                    return cost;
            }
        }

        private string GetBoothName()
        {
            Console.WriteLine("What is the name of the booth?");
            return Console.ReadLine();
        }

        private int GetTotalTickets()
        {
            Console.Write("How many tickets were recieved at this booth: ");
            var ticketsRecieved = int.Parse(Console.ReadLine());
            return ticketsRecieved;
        }

        private void PrintBooths(List<BurgerBooth> booths)
        {
            int i = 1;
            foreach (IBooth booth in booths)
            {
                Console.WriteLine($"{i}. {booth.BoothName}");
                i++;
            }
        }
        private void PrintBooths(List<DessertBooth> booths)
        {
            int i = 1;
            foreach (IBooth booth in booths)
            {
                Console.WriteLine($"{i}. {booth.BoothName}");
                i++;
            }
        }
    }
}