using Proyect_Community.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_Community.Domain
{
    internal class Piso
    {
        public int Id { set; get; }
        public int portal { set; get; }
        public int high { set; get; }
        public char letter { set; get; }
        public PisoManage pm { set; get; }
        public int stair { set; get; }
        public int parking { set; get; }
        public int storageroom { set; get; }

        public Piso(int portal, int stair, int high, char letter)
        {
            this.portal = portal;
            this.stair = stair;
            this.high = high;
            this.letter = letter;
            pm = new PisoManage();
        }

        public Piso(int iD)
        {
            this.Id = iD;
        }

        public override bool Equals(object obj)
        {
            return obj is Piso piso &&
                   portal == piso.portal &&
                   high == piso.high &&
                   letter == piso.letter;
        }
    }
}
