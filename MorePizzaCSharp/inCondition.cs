using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorePizzaCSharp
{
    public class inCondition
    {
        private int MaxSlicePermitted { get; set; }
        private int MaxAvailableType { get; set; }
        private List<type> types = new List<type>();

        public inCondition(string inFilePath)
        {
            string[] allLine=File.ReadAllLines(inFilePath);
            MaxSlicePermitted = Convert.ToInt32(allLine[0].Split(' ')[0]);
            MaxAvailableType = Convert.ToInt32(allLine[0].Split(' ')[1]);

            //Assinging id and number of slice
            for(int i=0;i<allLine[1].Split(' ').Length;i++)
            {
                type type = new type(i, Convert.ToInt32(allLine[1].Split(' ')[i]));
                types.Add(type);
                
            }

            //Sort types based on number of slices it contain decending
            //types = types.OrderByDescending(x => x.numberOfSlice).ToList();
        }


        public int getMaxSlicePermitted()
        {
            return MaxSlicePermitted;
        }
        public int getMaxAvailableType()
        {
            return MaxAvailableType;
        }
        public List<type> getTypes()
        {
            return types;
        }
    }
}
