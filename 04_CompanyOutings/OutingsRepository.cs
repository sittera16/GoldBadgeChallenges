using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyOutings
{
    public class OutingsRepository
    {
        public List<Outings> _outings = new List<Outings>();

        public bool AddOutingtoDirectory(Outings outing)
        {
            int startingCount = _outings.Count;
            _outings.Add(outing);

            bool wasAdded = (_outings.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Outings> GetAllOutings()
        {
            return _outings;
        }

        public int GetTotalOutingsCost()
        {
            int totalCost = 0;
            List<Outings> outings = GetAllOutings();
            foreach(Outings outing in outings)
            {
                totalCost+=outing.EventCost;
            }
            return totalCost;
        }
        public int GetTotalCostByOutingType(EventType eventType)
        {
            int totalCost = 0;
            List<Outings> outings = GetAllOutings();
            foreach (Outings outing in outings)
            {
                if (outing.EventType == eventType)
                {
                    totalCost += outing.EventCost;
                }
            }
            return totalCost;
        }
    }
}
