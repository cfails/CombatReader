using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class EventLine
    {
        public EventLine()
        {
            Event = new Event();
            Mitigation = new Mitigation();
            AbilityName = new AbilityName();
            SourceName = new Source();
            TargetName = new Target();
        }
        public EventLine()
        {
            Mitigation = new Mitigation();
            AbilityName = new AbilityName();
            Event = new Event();
        }
        public DateTime TimeStamp { get; set; }
        public Source SourceName { get; set; }
        public Target TargetName { get; set; }
        public AbilityName AbilityName { get; set; }
        public string Event { get; set; }
        public string Effect { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public AbilityName AbilityName { get; set; }
        public Event Event { get; set; }
        public string Effect { get; set; }
        public int Value { get; set; }
        public Mitigation Mitigation { get; set; }
        public int Threat { get; set; }
     
    }
}
