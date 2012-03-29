using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class Effect
    {
        public string Name { get; set; }
        public Int64 ID { get; set; }

        public void GetEffectNameAndID(EventLine el, string firstLine)
        {
            string preEffectSplit = firstLine.Split(']')[4].Remove(0, 2);
            string preEffect = preEffectSplit.Split(':')[1];
            int efEffctIndex = preEffect.IndexOf('{');
            el.Effect.Name = preEffect.Remove(efEffctIndex).Trim();
            bool hasID = preEffect.Contains('{');
            if (hasID)
            {
                Int64 efID;
                int efIDindex = preEffect.IndexOf('}');
                bool idParse = Int64.TryParse(preEffect.Remove(efIDindex)
                    .Split('{')[1], out efID);
                el.Effect.ID = efID;
            }
        }
    }
}
