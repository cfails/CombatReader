using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class Event
    {
        public string Name { get; set; }
        public Int64 ID { get; set; }

        public void GetEvent(EventLine el, string firstLine)
        {
            string preEvent = firstLine.Split(']')[4].Remove(0, 2);
            int evNameIndex = preEvent.IndexOf('{');
            if (evNameIndex != -1)
            {
                el.Event.Name = preEvent.Remove(evNameIndex).Trim();
            }
            else
            {
                el.Event.Name = preEvent.Split(':')[0];
            }

            bool hasID = preEvent.Contains('{');
            if (hasID)
            {
                Int64 evID;
                int evIDindex = preEvent.IndexOf('}');
                bool idParse = Int64.TryParse(preEvent.Remove(evIDindex)
                    .Split('{')[1], out evID);
                el.Event.ID = evID;
            }
        }
    }
}
