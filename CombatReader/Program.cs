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
                string preEventTime = tr.ReadLine().Split(']')[0];
                DateTime eventTime = Convert.ToDateTime(preEventTime.Remove(0, 1));
                Console.WriteLine(preEventTime);
                Console.WriteLine(eventTime);
                string preSource = tr.ReadLine().Split(']')[1];
                Console.WriteLine(preSource.Remove(0, 2));
                Console.ReadLine();
            }
        }
    }
}
