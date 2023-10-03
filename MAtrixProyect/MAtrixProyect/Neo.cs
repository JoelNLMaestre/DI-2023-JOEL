using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAtrixProyect
{
    internal class Neo : Character
    {
        int perc;
        public Neo(string name, Location city, int perc) : base(name, city)
        {
            this.perc = perc;
        }
        public void setPercent(int percent)
        {
            this.perc = percent;
        }
        public int getPercent()
        {
            return this.perc;
        }
        public bool belive()
        {
            bool belive = false;
            if (this.perc > 50)
            {
                belive = true;
            }
            return belive;
        }
    }
}
