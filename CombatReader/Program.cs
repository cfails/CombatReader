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
            using (TextReader tr = new StreamReader("ComLog1.txt"))
            {
                EventLine el = new EventLine();
                string firstLine = tr.ReadLine();
                el.eventTime = Convert.ToDateTime(firstLine.Split(']')[0].Remove(0, 1));
                Console.WriteLine(el.eventTime);
                el.Source = firstLine.Split(']')[1].Remove(0, 2);
                Console.WriteLine(el.Source);
                el.Target = firstLine.Split(']')[2].Remove(0, 2);
                Console.WriteLine(el.Target);
                Console.ReadLine();
            }
        }
    }
}
