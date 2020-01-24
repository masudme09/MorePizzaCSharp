using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorePizzaCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read from file and generate required object
            while (true)
            {
                Console.WriteLine("Give me test data Path:");
                string filePath = Console.ReadLine();
                inCondition inCond = new inCondition(filePath);
                List<type> typesDecending = inCond.getTypes().OrderByDescending(x => x.numberOfSlice).ToList();
                List<type> selectedPizza = new List<type>();
                int MaxLimit= inCond.getMaxSlicePermitted();
                //int MaxLimit = 100;
                double MaxSlice=0;
                int count = 1;

                //while (count <= 2)
                //{
                    MaxSlice = (int)(MaxLimit * 0.7);
                    //int MaxType = inCond.getMaxAvailableType();

                    //Selection of pizza based on maximum number of slice but can not be more slice than required

                    int totalSelectedSlice = 0;
                    for (int i = 0; i < typesDecending.Count; i++)
                    {
                        if (totalSelectedSlice == 0)
                        {
                            if (typesDecending[i].numberOfSlice < MaxSlice)
                            {
                                selectedPizza.Add(typesDecending[i]);
                                totalSelectedSlice = typesDecending[i].numberOfSlice;
                                typesDecending.Remove(typesDecending[i]);
                            }
                        }
                        else
                        {
                            if (totalSelectedSlice + typesDecending[i].numberOfSlice < MaxSlice)
                            {
                                selectedPizza.Add(typesDecending[i]);
                                totalSelectedSlice = totalSelectedSlice + typesDecending[i].numberOfSlice;
                                typesDecending.Remove(typesDecending[i]);
                            }
                        }
                    }
                    //count++;
                //}

                if (score(selectedPizza) < MaxLimit)
                {
                    MaxSlice = MaxLimit - (int)score(selectedPizza);
                                    
                        
                    //Selection of pizza based on maximum number of slice but can not be more slice than required

                    totalSelectedSlice = 0;
                    for (int i = 0; i < typesDecending.Count; i++)
                    {
                        if (totalSelectedSlice == 0)
                        {
                            if (typesDecending[i].numberOfSlice < MaxSlice)
                            {
                                selectedPizza.Add(typesDecending[i]);
                                totalSelectedSlice = typesDecending[i].numberOfSlice;
                                typesDecending.Remove(typesDecending[i]);
                            }
                        }
                        else
                        {
                            if (totalSelectedSlice + typesDecending[i].numberOfSlice < MaxSlice)
                            {
                                selectedPizza.Add(typesDecending[i]);
                                totalSelectedSlice = totalSelectedSlice + typesDecending[i].numberOfSlice;
                                typesDecending.Remove(typesDecending[i]);
                            }
                        }
                        
                    }
                }

                
                //Write the output to a file same location with .out extension
                selectedPizza = selectedPizza.OrderBy(x => x.numberOfSlice).ToList();
                string outputPath = filePath.Replace(".in", ".out");
                File.WriteAllText(outputPath, Convert.ToString(selectedPizza.Count));
                string secondLine = "";
                foreach (type pizza in selectedPizza)
                {
                    secondLine = secondLine + pizza.id + " ";
                }
                secondLine = "\n" + secondLine;
                File.AppendAllText(outputPath, secondLine);
                Console.WriteLine("\n Output Written to" + outputPath + "\n");
                Console.WriteLine("\n Score: " + score(selectedPizza));
            }
        }

        private static long score(List<type> selectedPizza)
        {
            long scoreAchieved=0;

            foreach(type pizza in selectedPizza)
            {
                scoreAchieved = scoreAchieved + pizza.numberOfSlice;
            }

            return scoreAchieved;
        }
        

    }
}
