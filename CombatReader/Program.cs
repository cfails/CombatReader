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
            List<EventLine> list;
            //TextWriter tw = new TextWriter()
            string fileName = "..\\..\\ComLog1.txt";
            var Parser = new Parser();
            Parser.Parse(new StreamReader(fileName));
            
        }
    }
}
