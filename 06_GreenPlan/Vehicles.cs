using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public enum EngineType
    {
        Gas=1,
        Hybrid,
        Electric,
    }
    public class Vehicles
    {
        public Vehicles()
        {

        }

        public Vehicles (int id, string make, string model, double year, EngineType engineType, decimal vehicleMPG)
        {
            ID = id;
            Make = make;
            Model = model;
            Year = year;
            EngineType = engineType;
            VehicleMPG = vehicleMPG;
        }

        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Year { get; set; }
        public EngineType EngineType { get; set; }
        public string VehicleName
        {
            get
            {
                return $"{Year} {Make} {Model}";
            }
        }
        public decimal VehicleMPG { get; set; }
    }
}
