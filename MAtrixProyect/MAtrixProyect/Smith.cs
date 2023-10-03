using Pathfinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAtrixProyect
{
    internal class Smith : Character
    {
        int maxDeaths;
        public Smith(string name, Location city, int maxDeaths) : base(name, city)
        {
            this.maxDeaths = maxDeaths;
        }
        public void setmaxDeaths(int maxDeaths)
        {
            this.maxDeaths=maxDeaths;
        }
        public int getmaxDeaths()
        {
            return this.maxDeaths;
        }
        public int infectThisTurn()
        {
           int num = RandomNumber.random_Number(0,this.maxDeaths);
           return num;
        }

    }
}
