using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyOutings.UI
{
    public class ProgramUI
    {
        private readonly OutingsRepository _outingRepo;

        public ProgramUI()
        {
            _outingRepo = new OutingsRepository();
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
                Console.WriteLine("Welcome to Komodo's Company Outing UI\n" +
                    "1. Add a New Company Outing\n" +
                    "2. View All Existing Company Outings\n" +
                    "3. Display Current Company Outings Cost Total\n" +
                    "4. Display Current Company Outings Cost by Outing Type\n" +
                    "500. Exit Komodo's Company Outing UI");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddANewCompanyOuting();
                        break;
                    case "2":
                        ShowAllOutings();
                        break;
                    case "3":
                        ViewCurrentOutingCostTotal();
                        break;
                    case "4":
                        ViewCurrentOutingCostByType();
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

        private void AddANewCompanyOuting()
        {
            Console.Clear();
            Outings outings = new Outings();

            Console.Write("Select an outing type: \n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            string eventTypeString = Console.ReadLine();
            int eventTypeNumber = Convert.ToInt32(eventTypeString);
            outings.EventType = (EventType)eventTypeNumber;

            Console.Write("Please enter the number of attendees: ");
            string attendeeCount = Console.ReadLine();
            int attendeeCountNum = Convert.ToInt32(attendeeCount);
            outings.AttendeeCount = attendeeCountNum;

            Console.Write("Please enter the date of the event (YYYY/MM/DD): ");
            string date = Console.ReadLine();
            var parsedDate = DateTime.Parse(date);
            outings.Date = parsedDate;

            Console.Write("Please enter the total cost of the new event: ");
            string eventCost = Console.ReadLine();
            int eventCostNum = Convert.ToInt32(eventCost);
            outings.EventCost = eventCostNum;

            _outingRepo.AddOutingtoDirectory(outings);
        }

        private void ShowAllOutings()
        {
            Console.Clear();
            Console.WriteLine("Current list of company outings:");
            List<Outings> outings = _outingRepo.GetAllOutings();
            foreach (Outings outing in outings)
            {
                DisplayOutingsList(outing);
            }
            WaitForKey();
        }

        private void ViewCurrentOutingCostTotal()
        {
            Console.Clear();
            Console.WriteLine($"Current total outings cost is ${_outingRepo.GetTotalOutingsCost()}.");
            WaitForKey();
        }

        private void ViewCurrentOutingCostByType()
        {
            Console.Clear();
            Console.Write("Select an event type: \n" +
                            "1. Golf\n" +
                            "2. Bowling\n" +
                            "3. Amusement Park\n" +
                            "4. Concert\n");
            string outingType = Console.ReadLine();
            EventType outing = (EventType)Convert.ToInt32(outingType);

            Console.Clear();
            Console.WriteLine($"The current total of all {outing} events is ${_outingRepo.GetTotalCostByOutingType(outing)}.");
            WaitForKey();
        }

        private void DisplayOutingsList(Outings outings)
        {
            Console.WriteLine($"Event Type: {outings.EventType}\n" +
                $"Aaattendee Count: {outings.AttendeeCount}\n" +
                $"Date: {outings.Date}\n" +
                $"Event Cost: {outings.EventCost}\n" +
                $"Cost Per Person: {outings.CostPerPerson}\n" +
                $"=======================================================================");
        }

        private void WaitForKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void Seed()
        {
            Outings golfOuting = new Outings();
            golfOuting.EventType = EventType.Golf;
            golfOuting.AttendeeCount = 55;
            golfOuting.Date = new DateTime (2020/10/10);
            golfOuting.EventCost = 15000;
            _outingRepo.AddOutingtoDirectory(golfOuting);

            Outings concertOuting = new Outings();
            concertOuting.EventType = EventType.Golf;
            concertOuting.AttendeeCount = 80;
            concertOuting.Date = new DateTime (2020/11/11);
            concertOuting.EventCost = 25000;
            _outingRepo.AddOutingtoDirectory(concertOuting);

            Outings parkOuting = new Outings();
            parkOuting.EventType = EventType.AmusementPark;
            parkOuting.AttendeeCount = 100;
            parkOuting.Date = new DateTime (2020/12/12);
            parkOuting.EventCost = 30000;
            _outingRepo.AddOutingtoDirectory(parkOuting);
        }
    }
}
