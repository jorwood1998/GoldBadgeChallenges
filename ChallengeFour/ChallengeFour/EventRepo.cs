using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour
{
        public class EventRepos
        {
            protected readonly List<Event> _events = new List<Event>();
            public bool AddEvent(Event events)
            {
                if (events is null)
                {
                    return false;
                }
                else
                {
                    _events.Add(events);
                    return true;
                }
            }
            public List<Event> GetEvents()
            {
                return _events;
            }
            public decimal GetTotalCostOfEvent()
            {
                decimal Costs = 0;
                foreach (var item in _events)
                {
                    Costs += item.CostPerEvent;

                }
                return Costs;
            }
            public decimal GetToalCostOfEvent(EventType eventType)
            {
                decimal Costs = 0;
                foreach (var item in _events)
                {
                    if (item.EventType == eventType)
                    {
                        Costs += item.CostPerEvent;
                    }
                }
                return Costs;
            }
        }
    }
