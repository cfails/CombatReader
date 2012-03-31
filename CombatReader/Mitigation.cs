using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class Mitigation
    {
        public string Name { get; set; }
        public Int64 ID { get; set; }
        public int Value { get; set; }

        public void GetMitigation(EventLine el, string firstLine)
        {
            bool isMit = firstLine.Contains("))");
            int mitVal;
            if (isMit)
            {
                string preMit = firstLine.Split(']')[5];
                string preMit2 = preMit.Split('(')[2];
                int indexMit = preMit2.IndexOf(' ');
                bool isNumber = int.TryParse(preMit2.Remove(indexMit), out mitVal);
                el.Mitigation.Value = mitVal;
                int mitIDindex = preMit2.IndexOf('}');
                Int64 mitID;
                bool mitIDparse = Int64.TryParse(preMit2.Remove(mitIDindex)
                    .Split('{')[1], out mitID);
                el.Mitigation.ID = mitID;
                el.Mitigation.Name = preMit2.Split(' ')[1];
            }
        }
    }
}
