using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    class KomodoUI
    {
        private DeveloperRepo _devRepo = new DeveloperRepo();
        private DevTeamRepo _teamRepo = new DevTeamRepo();

        public void Run()
        {
            SeedList();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Insurance\n\n" +
                    "Select a menu option:\n" +
                    "1. Adding Devs to Team\n" +
                    "2. Remove Devs from Team\n" +
                    "3. Developers\n" +
                    "4. Developer Teams\n" +
                    "5. PluralSight Request\n" +
                    "6. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddDeveloperToTeam();
                        break;
                    case "2":
                        RemoveDeveloperFromTeam();
                        break;
                    case "3":
                        Menu();
                        break;
                    case "4":
                        TeamMenu();
                        break;
                    case "5":
                        PluralSightRequest();
                        break;
                    case "6":
                        Console.WriteLine("\nThanks for using KomodoUI.\n" +
                            "\n" +
                            "Good Bye\n");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }


                Console.Clear();
            }
        }

        private void Menu()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. View All Developers\n" +
                    "2. View Developers by ID\n" +
                    "3. Add New Developer\n" +
                    "4. Update Existing Developers\n" +
                    "5. Delete Existing Developers\n" +
                    "6. Return to Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllDevs();
                        break;
                    case "2":
                        DisplayDevById();
                        break;
                    case "3":
                        AddNewDeveloper();
                        break;
                    case "4":
                        UpdateExistingDevList();
                        break;
                    case "5":
                        DeleteExistingDev();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the name of Developer");
            newDeveloper.DevName = Console.ReadLine();

            Console.WriteLine("Enter the ID of the Developer");
            string idAsString = Console.ReadLine();
            newDeveloper.DevId = int.Parse(idAsString);

            Console.WriteLine("Does the Developer have PluralSight? (y/n)");
            string hasPluralSight = Console.ReadLine().ToLower();

            if (hasPluralSight == "y")
            {
                newDeveloper.HasPluralSight = true;
            }
            else
            {
                newDeveloper.HasPluralSight = false;
            }

            _devRepo.AddDevToList(newDeveloper);  //Does not return anything - void

        }
        private void DisplayAllDevs()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _devRepo.GetDevList();
            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Developer: {developer.DevName.PadRight(15)} ID: {developer.DevId}");
            }
        }
        private void DisplayDevById()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the Developer: (ex. 1, 2, ...");
            int idAsString = int.Parse(Console.ReadLine());

            Developer developer = _devRepo.GetDevById(idAsString);

            if (developer != null)
            {
                Console.Clear();
                Console.WriteLine($"ID: {developer.DevId}\n" +
                    $"Name: {developer.DevName}");

                if (developer.HasPluralSight == true)
                {
                    Console.WriteLine("PluralSight Access: Yes");
                }
                else
                {
                    Console.WriteLine("PluralSight Access: No");
                }
            }
            else
            {
                Console.WriteLine("No Developer by that ID.");
            }
        }

        private void UpdateExistingDevList()
        {
            DisplayAllDevs();

            Console.WriteLine("Enter the ID of the Developer you would like to update:");

            int oldId = int.Parse(Console.ReadLine());

            Developer updatedDev = new Developer();
            Console.WriteLine("Enter the new ID of the developer:");
            string idAsString = Console.ReadLine();
            updatedDev.DevId = int.Parse(idAsString);

            Console.WriteLine("Enter the name of the Developer");
            updatedDev.DevName = Console.ReadLine();

            Console.WriteLine("Does the developer have access to PluralSight? (y/n)");
            string hasPluralSight = Console.ReadLine().ToLower();

            if (hasPluralSight == "y")
            {
                updatedDev.HasPluralSight = true;
                bool wasUpdated = _devRepo.UpdateExistingDevList(oldId, updatedDev);
                if (wasUpdated)
                {
                    Console.WriteLine("Successfully Updated");
                }
                else
                {
                    Console.WriteLine("Could not update content");
                }
            }
            else if (hasPluralSight == "n")
            {
                updatedDev.HasPluralSight = false;
                bool wasUpdated = _devRepo.UpdateExistingDevList(oldId, updatedDev);
                if (wasUpdated)
                {
                    Console.WriteLine("Successfully Updated");
                }
                else
                {
                    Console.WriteLine("Could not update content");
                }
            }
            else
            {
                Console.WriteLine("Could not update.  Try again");
            }
        }

        private void DeleteExistingDev()
        {
            DisplayAllDevs();

            Console.WriteLine("\nEnter the ID of the developer you would like to remove:");

            int input = int.Parse(Console.ReadLine());

            bool wasDeleted = _devRepo.RemoveDevFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully deleted");
            }
            else
            {
                Console.WriteLine("The Developer could not be deleted");
            }
        }

        private void TeamMenu()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Team\n" +
                    "2. View All Developer Teams\n" +
                    "3. View Teams by ID\n" +
                    "4. Update Existing Developer Teams\n" +
                    "5. Delete Existing Developer Teams\n" +
                    "6. Return to Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddTeams();
                        break;
                    case "2":
                        DisplayAllTeams();
                        break;
                    case "3":
                        DisplayTeamById();
                        break;
                    case "4":
                        UpdateExistingTeamList();
                        break;
                    case "5":
                        DeleteExistingTeam();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddTeams()
        {
            Console.Clear();

            DevTeam newTeam = new DevTeam();

            Console.WriteLine("Create Unique Team ID:");
            string uniqueId = Console.ReadLine();
            newTeam.DevTeamId = int.Parse(uniqueId);

            _teamRepo.AddTeamToList(newTeam);
        }

        private void DisplayAllTeams()
        {
            Console.Clear();

            List<DevTeam> listOfDevTeams = _teamRepo.GetDevTeams();
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Team Name: {devTeam.DevTeamName}\n" +
                    $"ID: {devTeam.DevTeamId}");
            }
        }
        private void DisplayTeamById()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the Developer Team:");
            int idAsString = int.Parse(Console.ReadLine());

            DevTeam devTeam = _teamRepo.GetTeamById(idAsString);


            if (devTeam != null)
            {
                Console.WriteLine($"ID: {devTeam.DevTeamId}\n" +
                    $"Name: {devTeam.DevTeamName}\n");

                foreach (Developer devTeam1 in devTeam.ListOfDevelopers)
                {
                    Console.WriteLine($"Members: {devTeam1.DevName}");
                }

            }
            else
            {
                Console.WriteLine("No Developer Team by that ID.");
            }
        }
        private void UpdateExistingTeamList()
        {
            DisplayAllTeams();

            Console.WriteLine("Enter the ID of the Team you would like to update:");

            int oldId = int.Parse(Console.ReadLine());

            DevTeam updatedTeam = new DevTeam();
            Console.WriteLine("Enter the new ID of the team:");
            string iDAsString = Console.ReadLine();
            updatedTeam.DevTeamId = int.Parse(iDAsString);

            Console.WriteLine("Enter the name of the Developer");
            updatedTeam.DevTeamName = Console.ReadLine();

            bool wasUpdated = _teamRepo.UpdateExistingDevTeam(oldId, updatedTeam);

            if (wasUpdated)
            {
                Console.WriteLine("Successfully Updated");
            }
            else
            {
                Console.WriteLine("Could not update content");
            }
        }
        private void DeleteExistingTeam()
        {
            DisplayAllTeams();

            Console.WriteLine("\nEnter the ID of the Team you would like to remove:");

            int input = int.Parse(Console.ReadLine());

            bool wasDeleted = _teamRepo.RemoveTeamFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Team was successfully deleted");
            }
            else
            {
                Console.WriteLine("The Team could not be deleted");
            }
        }
        private void AddDeveloperToTeam()
        {

            DisplayAllDevs();

            List<DevTeam> listOfDevTeams = _teamRepo.GetDevTeams();
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"\nTeam Name: {devTeam.DevTeamName.PadRight(15)} ID: {devTeam.DevTeamId}");
            }
            Console.WriteLine("\nChoose a Developer Team ID to add developers to:\n");
            string idAsString = Console.ReadLine();
            var idAsInt = int.Parse(idAsString);
            bool doesExist = true;
            foreach (DevTeam devTeam1 in listOfDevTeams)
            {
                if (idAsInt != devTeam1.DevTeamId)
                {
                    doesExist = !doesExist;
                }
            }
           
            if (doesExist)
            {
                DevTeam devTeamOne = _teamRepo.GetTeamById(idAsInt);

                Console.WriteLine("Choose a Developer to add to the Team:\n");
                int teamAsString = int.Parse(Console.ReadLine());
                if (teamAsString == 0)
                {
                    Console.WriteLine("Please try again");
                }
                Developer developer = _devRepo.GetDevById(teamAsString);

                _teamRepo.AddDevsToTeam(developer, devTeamOne);

                bool keepAdding = true;
                while (keepAdding)
                {
                    Console.WriteLine("Add another? Press y/n to continue");
                    string yes = Console.ReadLine().ToLower();

                    if (yes == "y")
                    {
                        DisplayAllDevs();

                        List<DevTeam> listOfDevTeams1 = _teamRepo.GetDevTeams();
                        foreach (DevTeam devTeam in listOfDevTeams1)
                        {
                            Console.WriteLine($"\nTeam Name: {devTeam.DevTeamName}\n" +
                                $"ID: {devTeam.DevTeamId}");
                        }

                        Console.WriteLine("\nChoose a Developer Team ID to add developers to:\n");
                        string idAsString1 = Console.ReadLine();
                        int idAsInt1 = int.Parse(idAsString1);
                        DevTeam devTeamOne1 = _teamRepo.GetTeamById(idAsInt1);

                        Console.WriteLine("Choose a Developer to add to the Team:\n");
                        int teamAsString1 = int.Parse(Console.ReadLine());
                        Developer developer1 = _devRepo.GetDevById(teamAsString1);

                        _teamRepo.AddDevsToTeam(developer1, devTeamOne1);
                    }
                    else
                    {
                        Console.WriteLine("Press any key to continue");
                        keepAdding = false;
                    }

                }
            }
            else
            {
                Console.WriteLine("Wrong ID. Please try again");
                Thread.Sleep(750); // in miliseconds
            }
        }
        private void RemoveDeveloperFromTeam()
        {
            DisplayAllDevs();

            List<DevTeam> listOfDevTeams = _teamRepo.GetDevTeams();
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Team Name: {devTeam.DevTeamName}\n" +
                    $"ID: {devTeam.DevTeamId}");
            }

            Console.WriteLine("Choose a Developer Team ID to remove developers from:\n");
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);
            DevTeam devTeamOne = _teamRepo.GetTeamById(idAsInt);

            Console.WriteLine("Choose a Developer to remove from the Team:\n");
            int teamAsString = int.Parse(Console.ReadLine());
            Developer developer = _devRepo.GetDevById(teamAsString);

            _teamRepo.RemoveDevFromTeam(developer, devTeamOne);
        }
        private void PluralSightRequest()
        {
            Console.Clear();
            Console.WriteLine("The following developers require PluralSight Access:\n");
            List<Developer> devs = _devRepo.GetDevByBool();
            foreach (Developer developer in devs)
            {
                if (developer != null)
                {

                    Console.WriteLine($"Name: {developer.DevName}");

                }
                else
                {
                    Console.WriteLine("No Developer require PluralSight at this time.");
                    Console.ReadLine();
                }

            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void SeedList()
        {
            Developer joshua = new Developer("Joshua Nall", 1, true);
            Developer holly = new Developer("Holly MacBook", 2, false);
            Developer janet = new Developer("Janet Roberts", 3, false);
            Developer tim = new Developer("Tim Holland", 4, true);
            Developer juan = new Developer("Juan Lo", 5, false);
            DevTeam red = new DevTeam(123, "Red");
            DevTeam blue = new DevTeam(456, "Blue");
            DevTeam yellow = new DevTeam(789, "Yellow");

            _devRepo.AddDevToList(joshua);
            _devRepo.AddDevToList(holly);
            _devRepo.AddDevToList(janet);
            _devRepo.AddDevToList(tim);
            _devRepo.AddDevToList(juan);

            _teamRepo.AddTeamToList(red);
            _teamRepo.AddTeamToList(blue);
            _teamRepo.AddTeamToList(yellow);
        }
    }
}
