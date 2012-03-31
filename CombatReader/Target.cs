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

        public void GetTarget(EventLine el, String firstLine)
        {
            string preTargetName = firstLine.Split(']')[2].Remove(0, 2);
            if (preTargetName.Contains('@'))
            {
                el.Source.IsPlayer = true;
                el.Target.Name = preTargetName.Replace("@", "");
            }
            else
            {
                el.Source.IsPlayer = false;

                //This part will have to change after we see non-players
                el.Target.Name = preTargetName;
            }
        }
    }
}
