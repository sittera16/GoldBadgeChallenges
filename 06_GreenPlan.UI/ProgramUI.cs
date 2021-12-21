using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan.UI
{
    internal class ProgramUI
    {
        private readonly VehiclesRepository _vehicleRepo;

        public ProgramUI()
        {
            _vehicleRepo = new VehiclesRepository();
        }

        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo's vehicle app\n" +
                    "1. Add a Vehicle\n" +
                    "2. View All Existing Vehicles\n" +
                    "3. View an Existing Vehicle\n" +
                    "4. View Vehicles by Engine Type\n" +
                    "5. Update an Existing Vehicle\n" +
                    "6. Delete an Existing Vehicle\n" +
                    "500. Exit Komodo's vehicle app");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddAVehicle();
                        break;
                    case "2":
                        ViewAllExistingVehicles();
                        break;
                    case "3":
                        ViewAnExistingVehicle();
                        break;
                    case "4":
                        ViewVehiclesByEngineType();
                        break;
                    case "5":
                        UpdateAnExistingVehicle();
                        break;
                    case "6":
                        DeleteAnExistingVehicle();
                        break;
                    case "500":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        WaitForKey();
                        break;
                }
            }
        }

        private void AddAVehicle()
        {
            Console.Clear();
            Vehicles vehicle = new Vehicles();

            Console.Write("Please enter vehicle's Make: ");
            string make = Console.ReadLine();
            vehicle.Make = make;

            Console.Write("Please enter vehicle's Model: ");
            string model = Console.ReadLine();
            vehicle.Model = model;

            Console.Write("Please enter vehicle's Year: ");
            string vehicleYear = Console.ReadLine();
            int vehicleYearNum = Convert.ToInt32(vehicleYear);
            vehicle.Year = vehicleYearNum;

            Console.WriteLine("Please enter the vehicle's Engine Type: \n" +
                "1. Gas\n" +
                "2. Hybrid\n" +
                "3. Electric\n");
            string engineString = Console.ReadLine();
            int engineNumber = Convert.ToInt32(engineString);
            vehicle.EngineType = (EngineType)engineNumber;

            Console.Write("Please enter vehicle's MPG rating: ");
            string vehicleMPG = Console.ReadLine();
            int vehicleMPGNum = Convert.ToInt32(vehicleMPG);
            vehicle.Year = vehicleMPGNum;

            _vehicleRepo.AddVehicleToDirectory(vehicle);
        }

        private void ViewAllExistingVehicles()
        {
            Console.Clear();
            Console.WriteLine("All existing vehicles: ");
            List<Vehicles> vehicles = _vehicleRepo.GetAllVehiclesList();
            foreach (Vehicles vehicle in vehicles)
            {
                DisplayVehicleListItem(vehicle);
            }
            WaitForKey();
        }

        private void ViewAnExistingVehicle()
        {
            Console.Clear();
            Console.Write("Please enter vehicle ID: \n");
            int index = 0;
            List<Vehicles> vehicles = _vehicleRepo.GetAllVehiclesList();
            foreach (Vehicles vehicle in vehicles)
            {
                Console.Write($"{index + 1}. ");
                DisplayVehicleListItem(vehicle);
                index++;
            }

            string inputID = Console.ReadLine();
            int vehID = Convert.ToInt32(inputID);
            Vehicles vehInfo = _vehicleRepo.GetVehicleByID(vehID);

            if (vehInfo == null)
            {
                Console.WriteLine("Vehicle not found.");
            }
            else
            {
                DisplayVehicleDetails(vehInfo);
            }

            WaitForKey();
        }

        private void ViewVehiclesByEngineType()
        {
            Console.Clear();
            Console.Write("Please select an engine type:\n" +
                "1. Gas\n" +
                "2. Hybrid\n" +
                "3. Electric\n ");
            string userInput = Console.ReadLine();
            EngineType engineTypeNum = (EngineType)Convert.ToInt32(userInput);
            List<Vehicles> contentItem = _vehicleRepo.GetVehiclesByEngineType(engineTypeNum);
            Console.Clear();
            foreach (Vehicles vehicle in contentItem)
            {
                DisplayVehicleDetails(vehicle);
            }

            Console.WriteLine($"The current average MPG of all vehicles with {engineTypeNum} engines is {_vehicleRepo.GetAverageMPGByEngineType(engineTypeNum)}\n" +
                $"======================================================================= ");
            WaitForKey();
        }

        private void UpdateAnExistingVehicle()
        {
            Console.Clear();
            var vehicle = new Vehicles();  
            var cars = _vehicleRepo.GetAllVehiclesList();
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.ID} {car.VehicleName}");
            }
            Console.WriteLine("Select ID of vehicle you would like to update: ");
            int userInput = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("What is the correct vehicle Make?");
            string make = Console.ReadLine();
            vehicle.Make = make;

            Console.WriteLine("What is the correct vehicle Model?");
            string model = Console.ReadLine();
            vehicle.Model = model;

            Console.WriteLine("What is the correct vehicle Year?");
            string yearString = Console.ReadLine();
            int yearInt = Convert.ToInt32(yearString);
            vehicle.Year = yearInt;

            Console.WriteLine("What is the correct vehicle Engine Type?\n" +
                "1. Gas\n" +
                "2. Hybrid\n" +
                "3. Eectric\n");
            string engineTypeString = Console.ReadLine();
            int engineTypeNum = Convert.ToInt32(engineTypeString);
            vehicle.EngineType = (EngineType)engineTypeNum;

            Console.WriteLine("What is the correct vehicle MPG rating?");
            string vehicleMPGString = Console.ReadLine();
            int vehicleMPGInt = Convert.ToInt32(vehicleMPGString);
            vehicle.Year = vehicleMPGInt;

            _vehicleRepo.UpdateExistingVehicle(userInput, vehicle);

            Console.Clear();
            Console.WriteLine("Update completed");
            WaitForKey();

        }


        private void DeleteAnExistingVehicle()
        {
            Console.Clear();
            Console.WriteLine("Which vehicle would you like to remove?");

            int index = 0;
            List<Vehicles> vehicle = _vehicleRepo.GetAllVehiclesList();
            foreach (Vehicles item in vehicle)
            {
                Console.Write($"{index + 1}. ");
                DisplayVehicleListItem(item);
                index++;
            }
            string optionString = Console.ReadLine();
            int option = Convert.ToInt32(optionString);

            Vehicles vehicleToDelete = vehicle[option - 1];

            Console.WriteLine("Are you sure you want to delete this? (y/n)");
            DisplayVehicleDetails(vehicleToDelete);
            if (Console.ReadLine() == "y")
            {
                _vehicleRepo.DeleteExistingVehicle(vehicleToDelete);
                Console.WriteLine("Item deleted!");
            }
            else
            {
                Console.WriteLine("Canceled");
            }
            WaitForKey();
        }
        private void DisplayVehicleListItem(Vehicles vehicle)
        {
            Console.WriteLine($"{vehicle.ID}.) {vehicle.VehicleName}\n" +
                $"=======================================================================");
        }

        private void DisplayVehicleDetails(Vehicles vehicle)
        {
            Console.WriteLine($"{vehicle.ID}.) {vehicle.VehicleName}\n" +
                $"Engine Type: {vehicle.EngineType}\n" +
                $"MPG Rating: {vehicle.VehicleMPG}\n" +
                $"=======================================================================");
        }

        private void WaitForKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void Seed()
        {
            Vehicles lamboHuracan = new Vehicles();
            lamboHuracan.Make = "Lamborghini";
            lamboHuracan.Model = "Huracan";
            lamboHuracan.Year = 2020;
            lamboHuracan.EngineType = EngineType.Gas;
            lamboHuracan.VehicleMPG = 15;
            _vehicleRepo.AddVehicleToDirectory(lamboHuracan);

            Vehicles jeepWrangler = new Vehicles();
            jeepWrangler.Make = "Jeep";
            jeepWrangler.Model = "Wrangler";
            jeepWrangler.Year = 2019;
            jeepWrangler.EngineType = EngineType.Gas;
            jeepWrangler.VehicleMPG = 18;
            _vehicleRepo.AddVehicleToDirectory(jeepWrangler);

            Vehicles mclarenP1 = new Vehicles();
            mclarenP1.Make = "McLaren";
            mclarenP1.Model = "P1";
            mclarenP1.Year = 2015;
            mclarenP1.EngineType = EngineType.Hybrid;
            mclarenP1.VehicleMPG = 17;
            _vehicleRepo.AddVehicleToDirectory(mclarenP1);

            Vehicles rimacNevera = new Vehicles();
            rimacNevera.Make = "Rimac";
            rimacNevera.Model = "Nevera";
            rimacNevera.Year = 2021;
            rimacNevera.EngineType = EngineType.Electric;
            rimacNevera.VehicleMPG = 96;
            _vehicleRepo.AddVehicleToDirectory(rimacNevera);

        }
    }
}
