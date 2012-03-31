using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class Source
    {
        public string Name { get; set; }
        public bool IsPlayer { get; set; }
        public Int64 ID { get; set; }

        public void GetSource(EventLine el, String firstLine)
        {
            string preSourceName = firstLine.Split(']')[1].Remove(0, 2);
            if (preSourceName.Contains('@'))
            {
                el.Source.IsPlayer = true;
                el.Source.Name = preSourceName.Replace("@", "");
            }
            else
            {
                el.Source.IsPlayer = false;

                //This part will have to change after we see non-players
                el.Source.Name = preSourceName;
            }
        }
    }

}
