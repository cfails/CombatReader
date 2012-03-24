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
                int counter = 0;
                do
                {
                    counter++;
                    EventLine el = new EventLine();
                    string firstLine = tr.ReadLine();
                    el.TimeStamp = Convert.ToDateTime(firstLine.Split(']')[0].Remove(0, 1));
                    Console.WriteLine(el.TimeStamp);
                    el.Source = firstLine.Split(']')[1].Remove(0, 2);
                    Console.WriteLine(el.Source);
                    el.Target = firstLine.Split(']')[2].Remove(0, 2);
                    Console.WriteLine(el.Target);
                    el.AbilityName = firstLine.Split(']')[3].Remove(0, 2);
                    Console.WriteLine(el.AbilityName);
                    string ee = firstLine.Split(']')[4].Remove(0, 2);
                    el.Event = ee.Split(':')[0];
                    Console.WriteLine(el.Event);
                    el.Effect = ee.Split(':')[1].Remove(0, 1);
                    Console.WriteLine(el.Effect);
                    string valSplit = firstLine.Split('(')[1];
                    string preVal = valSplit.Split(')')[0];
                    int intVal;
                    bool isANumber = int.TryParse(preVal, out intVal);
                    el.Value = intVal;
                    Console.WriteLine(el.Value);
                    bool isThreat = valSplit.Contains('<');
                    if (isThreat)
                    {
                        string preThreat = valSplit.Split('<')[1].Replace(">", "");
                        int threat;
                        bool isANumber2 = int.TryParse(preThreat, out threat);
                        el.Threat = threat;
                    }
                    Console.WriteLine(el.Threat);	
                } while (counter < 30);
                
                Console.ReadLine();
            }
        }
    }
}
