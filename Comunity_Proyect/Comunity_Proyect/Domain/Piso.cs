using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity_Proyect.Domain
{
    internal class Piso
    {
        private int portal { set; get; }
        private int high { set; get; }
        private char letter { set; get; }
        private int parking { set; get; }
        private int storageroom { set; get; }

        public Piso(int portal, int high, char letter)
        {
            this.portal = portal;
            this.high = high;
            this.letter = letter;
        }

        public override bool Equals(object? obj)
        {
            return obj is Piso piso &&
                   portal == piso.portal &&
                   high == piso.high &&
                   letter == piso.letter;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(portal, high, letter);
        }


    }
}
