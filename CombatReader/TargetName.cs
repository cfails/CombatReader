using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class Target
    {
        public string Name { get; set; }
        public bool IsPlayer { get; set; }
        public Int64 ID { get; set; }
        public void GetTargetName(EventLine el, String firstLine)
        {
            string preTargetName = firstLine.Split(']')[2].Remove(0, 2);
            if (preTargetName.Contains('@'))
            {
                el.SourceName.IsPlayer = true;
                int isTargetName = preTargetName.IndexOf('@', 0, 1);
                if (isTargetName != -1)
                {
                    el.TargetName.Name = preTargetName.Split('@')[1];
                }
            }
            else
            {
                el.SourceName.IsPlayer = false;
                el.TargetName.Name = preTargetName;
            }
        }
    }
}
