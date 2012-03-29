using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class Value
    {
        public int Amount { get; set; }
        public bool IsCrit { get; set; }
        public string Name { get; set; }
        public Int64 ID { get; set; }

        public void GetValue(EventLine el, string firstLine)
        {
            int valAmount;
            string preVal = firstLine.Split(']')[5].Remove(0, 2);
            bool hasID = preVal.Contains('{');
            if (hasID)
            {
                Int64 valID;
                string preValAmount = preVal.Split(' ')[0];
                if (preValAmount.Contains('*'))
                {
                    el.Value.IsCrit = true;
                }
                bool valAmountParse = int.TryParse(preValAmount
                        .Replace("*", ""), out valAmount);
                el.Value.Amount = valAmount;
                el.Value.Name = preVal.Split(' ')[1];
                string preValID = preVal.Split(' ')[2]
                    .Remove(0, 1).Replace("}", "");
                bool valIDparse = Int64.TryParse(preValID, out valID);
                el.Value.ID = valID;
            }
        }
    }
}
