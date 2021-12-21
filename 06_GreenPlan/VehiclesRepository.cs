using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public class VehiclesRepository
    {
        private readonly List<Vehicles> _vehicles = new List<Vehicles>();
        private int _count = 0;

        public bool AddVehicleToDirectory(Vehicles vehicle)
        {
            if (vehicle is null)
            {
                return false;
            }
            else
            {
                _count++;
                vehicle.ID = _count;
                _vehicles.Add(vehicle);
                return true;
            }
        }

        public List<Vehicles> GetAllVehiclesList()
        {
            return _vehicles;
        }

        public Vehicles GetVehicleByID(int id)
        {
            foreach (Vehicles vehicle in _vehicles)
            {
                if (vehicle.ID == id)
                {
                    return vehicle;
                }
            }
            return null;
        }

        public List<Vehicles> GetVehiclesByEngineType(EngineType engineType)
        {
            List<Vehicles> foundVehicles = new List<Vehicles>();
            foreach (Vehicles vehicle in _vehicles)
            {
                if (vehicle.EngineType == engineType)
                {
                    foundVehicles.Add(vehicle);
                }
            }
            return foundVehicles;
        }

        public bool UpdateExistingVehicle(int originalVehicleID, Vehicles vehicle)
        {
            Vehicles oldVehicle = GetVehicleByID(originalVehicleID);

            if (oldVehicle != null)
            {
                oldVehicle.Make = vehicle.Make;
                oldVehicle.Model = vehicle.Model;
                oldVehicle.Year = vehicle.Year;
                oldVehicle.EngineType = vehicle.EngineType;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExistingVehicle(Vehicles existingVehicle)
        {
            bool deleteVehicle = _vehicles.Remove(existingVehicle);
            return deleteVehicle;
        }
    }
}
