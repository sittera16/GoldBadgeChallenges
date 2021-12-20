using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyOutings
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert,
    }

    public class Outings
    {
        public Outings() { }
        public Outings (EventType eventType, int attendeeCount, DateTime date, int eventCost) 
        {
            EventType = eventType;
            AttendeeCount = attendeeCount;
            Date = date;
            EventCost = eventCost;
        }

        public EventType EventType { get; set; }
        public int AttendeeCount { get; set; }
        public DateTime Date { get; set; }
        public int EventCost { get; set; }
        public int CostPerPerson
        {
            get
            {
                int quotient = EventCost / AttendeeCount;
                return quotient;
            }
        }
    }
}
