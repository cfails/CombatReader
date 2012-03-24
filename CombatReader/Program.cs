using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CombatReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //TextWriter tw = new TextWriter()
            using (TextReader tr = new StreamReader(@"C:\source\CombatReader\ComLog1.txt"))
            {
                EventLine el = new EventLine();
                string firstLine = tr.ReadLine();
                el.TimeStamp  = Convert.ToDateTime(firstLine.Split(']')[0].Remove(0, 1));
                Console.WriteLine(el.TimeStamp);
                el.Source = firstLine.Split(']')[1].Remove(0, 2);
                Console.WriteLine(el.Source);
                el.Target = firstLine.Split(']')[2].Remove(0, 2);
                Console.WriteLine(el.Target);
                el.AbilityName = firstLine.Split(']')[3].Remove(0, 2);
                Console.WriteLine(el.AbilityName);
                el.ResourceEvent = firstLine.Split(']')[4].Remove(0, 2);
                Console.WriteLine(el.ResourceEvent);
                el.EffectName = firstLine.Split(']')[5].Remove(0, 2);
                Console.WriteLine(el.EffectName);
                int intVal;
                bool elValInt = int.TryParse(firstLine.Split(']')[6].Remove(0, 2), out intVal);
                el.Value = intVal;
                Console.WriteLine(el.Value);
                int intThreat;
                bool elThreatInt = int.TryParse(firstLine.Split(']')[7].Remove(0, 2), out intThreat);
                el.Threat = intThreat;
                Console.WriteLine(el.Threat);
                Console.ReadLine();
            }
        }
    }
}
