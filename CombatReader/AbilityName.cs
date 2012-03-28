using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class AbilityName
        {
            public string Name { get; set; }
            public Int64 ID { get; set; }
            public void GetAbilityName(EventLine el, string firstLine)
            {
                string  preAilityName = firstLine.Split(']')[3].Remove(0, 2);
                int abNameIndex = preAilityName.IndexOf('{');
                if (abNameIndex != -1) 
                { 
                el.AbilityName.Name = preAilityName.Remove(abNameIndex).Trim();
                }
                else
                {
                    el.AbilityName.Name = preAilityName;
                }
                bool hasID = preAilityName.Contains('{');
                if (hasID)
                {
                    Int64 abNameID;
                    bool idParse = Int64.TryParse(preAilityName.Split('{')[1].Replace("}", ""), out abNameID);
                    el.AbilityName.ID = abNameID;
                }

            }
        }
}
