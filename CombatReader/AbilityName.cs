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
            string preAbilityName = firstLine.Split(']')[3].Remove(0, 2);
            int abNameIndex = preAbilityName.IndexOf('{');
            if (abNameIndex != -1)
            {
                el.AbilityName.Name = preAbilityName.Remove(abNameIndex).Trim();
            }
            else
            {
                el.AbilityName.Name = preAbilityName;
            }
            
            bool hasID = preAbilityName.Contains('{');
            if (hasID)
            {
                Int64 abNameID;
                bool idParse = Int64.TryParse(preAbilityName.Split('{')[1]
                    .Replace("}", ""), out abNameID);
                el.AbilityName.ID = abNameID;
            }
        }
    }
}