using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorePizzaCSharp
{
    public class type
    {
        public int id { get; set; }
        public int numberOfSlice { get; set; }
        public type(int id, int numberOfSlice)
        {
            this.id = id;
            this.numberOfSlice = numberOfSlice;
        }
    }
}
