using System;
using System.Collections.Generic;

namespace Challenge_4v2
{
    internal class ProgramUI
    {
        readonly BadgeRepository _badgeRepo = new BadgeRepository();
        List<Door> _allDoors;
        List<Door> _tempDoors;
        Dictionary<int, List<Door>> _badges;
        internal void Run()
        {
            _badges = _badgeRepo.GetAllBadges();
            _allDoors = _badgeRepo.GetAllDoors();

            var isRunning = true;

            while (isRunning)
            {
                PrintMainMenu();
                ParseUserResponse(Console.ReadLine());
            }
        }

        private void ParseUserResponse(string userResponse)
        {
            int.TryParse(userResponse, out int menuResult);
            switch (menuResult)
            {
                case 1:
                    AddNewBadge();
                    break;
                case 2:
                    //PrintEditBadgeMenu();
                    break;
                case 3:
                    // PrintBadges();
                    break;

                default:
                    break;
            }
        }

        private void AddNewBadge()
        {
            _tempDoors = new List<Door>();
            bool addMoreDoors;
            do
            {
                Console.WriteLine($"Would you like to:\n" +
                    $"1. Add an existing Door?\n" +
                    $"2. Add a new door?\n");
                int.TryParse(Console.ReadLine(), out int menuResult);
                switch (menuResult)
                {
                    case 1:
                        PrintAllDoors();
                        Console.Write("Enter the number of the door you wish to add to the new badge:");
                        var desiredDoorIndex = int.Parse(Console.ReadLine()) - 1;
                        _tempDoors.Add(_tempDoors[desiredDoorIndex]);
                        break;
                    case 2:
                        _tempDoors.Add(CreateNewDoor());
                        break;
                }
                Console.WriteLine("Would you like to add more doors to the badge? y/n");
                addMoreDoors = GetBooleanResponse();
            } while (addMoreDoors);
            var newBadge = new Badge(_badges.Count + 1, _tempDoors);
            _badgeRepo.AddBadgeToDictionary(newBadge);
        }

        private bool GetBooleanResponse()
        {
            var response = Console.ReadLine().ToLower();
            return response.Contains("y");
        }

        private Door CreateNewDoor()
        {
            Door newDoor;
            Console.WriteLine($"Enter the name of the new door:");
            var doorName = Console.ReadLine();

            if (!_allDoors.Exists(door => door.DoorName == doorName))
            {
                newDoor = new Door(_allDoors.Count + 1, doorName);
                _allDoors.Add(newDoor);
                return newDoor;
            }
            else
                return _allDoors.Find(door => door.DoorName == doorName);
        }

        private void PrintAllDoors()
        {
            var i = 1;
            foreach (var door in _allDoors)
            {
                Console.WriteLine($"{i}. {door}");
                i++;
            }
        }

        private void PrintMainMenu()
        {
            Console.WriteLine($"What would you like to do?" +
                $"\n\n1. Add a badge" +
                $"\n2. Edit a badge" +
                $"\n3. List all badges" +
                $"\n4. Add a Door" +
                $"\n5. Edit a Door" +
                $"\n6. Remove a Door" +
                $"\n7. Exit program");
        }
    }
}