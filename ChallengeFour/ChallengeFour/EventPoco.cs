namespace ChallengeFour
{
        public enum EventType
        {
            Dinner = 1,
            Vacation = 2,
            Cruise = 3,
            Indy500 = 4
        }    
        public class Event
        {
            public Event() { }
            public Event(EventType eventType, decimal costPerEvent, int numberOfPeople, decimal costPerPerson, DateTime date)
            {
                CostPerEvent = costPerEvent;
                NumberOfPeople = numberOfPeople;
                Date = date;
                CostPerPerson = costPerPerson;
                EventType = eventType;
            }
            public EventType EventType { get; set; }
            public int NumberOfPeople { get; set; }
            public DateTime Date { get; set; }
            public decimal CostPerPerson { get; set; }
            public decimal CostPerEvent { get; set; }
            public override string ToString()
            {

                return $"{EventType} \n" +
                       $"{NumberOfPeople}\n" +
                       $"{Date}\n" +
                       $"{CostPerPerson}\n" +
                       $"{CostPerEvent}";
            }
        }
}