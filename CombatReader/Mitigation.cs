<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class Mitigation
    {
        public int Value { get; set; }
        public void GetMitigation(EventLine el, string firstLine)
        {
            bool isMit = firstLine.Contains("))");
            int mitVal;
            if (isMit)
            {
                string preMit = firstLine.Split('(')[2];
                int indexMit = preMit.IndexOf(' ');
                bool isNumber = int.TryParse(preMit.Remove(indexMit), out mitVal);
                el.Mitigation.Value = mitVal;
                Console.WriteLine(el.Mitigation.Value);
            }
        }

    }
}

=======
using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatReader
{
    public class Mitigation
    {
        public int Value { get; set; }

        public void GetMitigation(EventLine el, string firstLine)
        {
            bool isMit = firstLine.Contains("))");
            int mitVal;
            if (isMit)
            {
                string preMit = firstLine.Split('(')[2];
                int indexMit = preMit.IndexOf(' ');
                bool isNumber = int.TryParse(preMit.Remove(indexMit), out mitVal);
                el.Mitigation.Value = mitVal;
                
            }
        }
    }
}
>>>>>>> begining to split up work
