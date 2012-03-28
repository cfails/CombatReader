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

            using (TextReader tr = new StreamReader("..\\..\\ComLog1.txt"))

            {
                //int counter = 0;
                bool isEOF = false;
                do
                {
                    //counter++;
                    EventLine el;
                    el = new EventLine();
                    string firstLine = tr.ReadLine();
                    if (firstLine != null)
                    {
                        el.TimeStamp = Convert.ToDateTime(firstLine.Split(']')[0].Remove(0, 1));
                        Console.WriteLine(el.TimeStamp);

                        el.SourceName.GetSourceName(el, firstLine);
                        Console.WriteLine(el.SourceName.Name);

                        el.TargetName.GetTargetName(el, firstLine);
                        Console.WriteLine(el.TargetName.Name);

                        string ee = firstLine.Split(']')[4].Remove(0, 2);

                        el.AbilityName.GetAbilityName(el, firstLine);
                        Console.WriteLine(el.AbilityName.Name + " " + el.AbilityName.ID);

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

                        el.Mitigation.GetMitigation(el, firstLine);
                        bool isThreat = firstLine.Contains('<');
                        if (isThreat)
                        {
                            string preThreat = firstLine.Split('<')[1].Replace(">", "");
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
                int counter = 0;
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

                        el.AbilityName.GetAbilityName(el, firstLine);
                        Console.WriteLine(el.AbilityName.Name + " " + el.AbilityName.ID);

                        el.Event.GetEventNameAndID(el, firstLine);
                        Console.WriteLine(el.Event.Name + " " + el.Event.ID);

                        //el.Effect = ee.Split(':')[1].Remove(0, 1);
                        //Console.WriteLine(el.Effect);
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
                        
                        int eVal;
                        bool isNumber = int.TryParse(preVal, out eVal);
                        el.Value = eVal;
                        Console.WriteLine(el.Value);
                        el.Mitigation.GetMitigation(el, firstLine);
                        Console.WriteLine(el.Mitigation.Value);
                        bool isThreat = firstLine.Contains('<');
                        if (isThreat)
                        {
                            string preThreat = firstLine.Split('<')[1].Replace(">", "");
                            int eThreat;
                            bool isNumber2 = int.TryParse(preThreat, out eThreat);
                            el.Threat = eThreat;
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
                //3191
            }
        }
    }
}
