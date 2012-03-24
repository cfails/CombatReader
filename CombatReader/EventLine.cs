using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class EventLine
    {
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string AbilityName { get; set; }
        public string ResourceEvent { get; set; }
        public string EffectName { get; set; }
        public int Value { get; set; }
        public int Threat { get; set; }
    }
}
