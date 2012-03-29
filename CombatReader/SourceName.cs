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

        public void GetSourceName(EventLine el, String firstLine)
        {
            string preSourceName = firstLine.Split(']')[1].Remove(0, 2);
            if (preSourceName.Contains('@'))
            {
                el.SourceName.IsPlayer = true;
                int isSourceName = preSourceName.IndexOf('@', 0, 1);
                if (isSourceName != -1)
                {
                    el.SourceName.Name = preSourceName.Split('@')[1];
                }
            }
            else
            {
                el.SourceName.IsPlayer = false;
                el.SourceName.Name = preSourceName;
            }
        }
    }

}
