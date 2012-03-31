using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class EventLine
    {
        public EventLine()
        {
            Source = new Source();
            Target = new Target();
            AbilityName = new AbilityName();
            Event = new Event();
            Effect = new Effect();
            Value = new Value();
            Mitigation = new Mitigation();
        }
        public DateTime TimeStamp { get; set; }
        public Source Source { get; set; }
        public Target Target { get; set; }
        public AbilityName AbilityName { get; set; }
        public Event Event { get; set; }
        public Effect Effect { get; set; }
        public Value Value{ get; set; }
        public Mitigation Mitigation { get; set; }
        public int Threat { get; set; }
     
    }
}
