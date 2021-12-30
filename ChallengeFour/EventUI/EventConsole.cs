using ChallengeFour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUI
{
    class ProgramUI
    {
        private readonly EventRepos _eventsrepo = new EventRepos();

        public void Run()
        {
            Seed();
            ShowMenu();

        }

        private void ShowMenu()
        {
            bool Run = true;
            while (Run)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the option you'd like to select:\n" +
                    "1. See All Events\n" +
                    "2. Add Event\n" +
                    "3. Combined Event Costs\n" +
                    "4. Individual Event Costs\n" +
                    "5. Exit\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        GetEvents();
                        break;
                    case "2":
                        AddNewEvent();
                        break;
                    case "3":
                        GetTotalCost();
                        break;
                    case "4":
                        GetToalCostPerEvent();
                        break;
                    case "5":
                        Run = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 5");
                        WaitForKeyPress();
                        break;
                }
            }
        }

        private void GetToalCostPerEvent()
        {
            Console.Clear();
            Console.WriteLine("Cost Per Event type: \n" +
              "1. Golf\n" +
              "2. Bowling\n" +
              "3. Amusment Park\n" +
              "4. Concert");
            int value = int.Parse(Console.ReadLine());
            var eventType = (EventType)value;

            decimal total = _eventsrepo.GetToalCostOfEvent(eventType);
            Console.WriteLine($"Total Cost: {total}");
            Console.ReadKey();
        }

        private void GetTotalCost()
        {
            Console.Clear();
            Console.WriteLine("Total Cost of Outing: ");
            decimal outings = _eventsrepo.GetTotalCostOfEvent();
            Console.WriteLine($"Total Cost: {outings}");
            Console.ReadKey();
        }

        private void WaitForKeyPress()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void GetEvents()
        {
            Console.Clear();
            Console.WriteLine(": ");
            List<Event> outing = _eventsrepo.GetEvents();
            foreach (Event item in outing)
            {
                {
                    Console.WriteLine(item.ToString());
                }
                {
                    WaitForKeyPress();
                }
            }
            Console.ReadKey();
        }
        private void AddNewEvent()
        {
            Console.Clear();
            Event events = new Event();

            Console.WriteLine("Enter the Event type: \n" +
               "1. Golf\n" +
               "2. Bowling\n" +
               "3. Amusment Park\n" +
               "4. Concert");
            int value = int.Parse(Console.ReadLine());
            events.EventType = (EventType)value;

            Console.WriteLine("Number of People Attended: ");
            events.NumberOfPeople = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Date of Event: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            events.Date = date;

            Console.WriteLine("Cost Per Person: ");
            events.CostPerPerson = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Cost Per Event: ");
            events.CostPerEvent = Convert.ToDecimal(Console.ReadLine());

            var success = _eventsrepo.AddEvent(events);
            if (success)
            {
                Console.WriteLine("Added");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
        private void Seed()
        {
            Event event1 = new Event(EventType.Cruise, 900.00m, 30, 150.00m, new DateTime(2022, 06, 01));
            Event event2 = new Event(EventType.Dinner, 400.00m, 10, 40.00m, new DateTime(2021, 12, 25));
            Event event3 = new Event(EventType.Vacation,7000.00m, 7, 1000.00m, new DateTime(2024, 5, 15));
            Event event4 = new Event(EventType.Indy500, 100.00m, 10, 1000.00m, new DateTime(2022, 05, 25));
            _eventsrepo.AddEvent(event1);
            _eventsrepo.AddEvent(event2);
            _eventsrepo.AddEvent(event3);
            _eventsrepo.AddEvent(event4);
        }
    }
}
