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
            var list = new List<EventLine>();
            //TextWriter tw = new TextWriter()
            using (TextReader tr = new StreamReader(@"C:\source\CombatReader\ComLogTest.txt"))
            {
                //int counter = 0;
                bool isEOF = false;
                do
                {
                    //counter++;
                    EventLine el = new EventLine();
                    string firstLine = tr.ReadLine();
                    if (firstLine != null)
                    {
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
                        int index = valSplit.IndexOf(' ');
                        string preVal; 
                        if (index != -1)
                        {
                            preVal = valSplit.Remove(index).Replace(")", "").Replace("*", "");
                        }
                        else
                        {
                            preVal = valSplit.Split(')')[0].Replace("*", "");
                        }
                        int intVal;
                        bool isNumber = int.TryParse(preVal, out intVal);
                        el.Value = intVal;
                        Console.WriteLine(el.Value);
                        bool isThreat = valSplit.Contains('<');
                        if (isThreat)
                        {
                            string preThreat = valSplit.Split('<')[1].Replace(">", "");
                            int threat;
                            bool isNumber2 = int.TryParse(preThreat, out threat);
                            el.Threat = threat;
                            Console.WriteLine(el.Threat);
                        }
                    }
                    else
                    {
                        isEOF = true;
                    }
                    list.Add(el);
                } while (isEOF == false);
                //Console.WriteLine(list.Count);
                Console.ReadLine();
            }
        }
    }
}
