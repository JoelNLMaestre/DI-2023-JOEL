using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Domain
{
    internal class Portal
    {
        public int numeroPortal { get; set; }
        public int stairs { get; set; }
        public int highs { get; set; }
        public char initialLetter { get; set; }
        public char finalLetter { get; set; }

        public Portal(int numportal, int stairs, int highs, char initialLetter, char finalLetter)
        {
            this.numeroPortal = numportal;
            this.stairs = stairs;
            this.highs = highs;
            this.initialLetter = initialLetter;
            this.finalLetter = finalLetter;
        }
    }
}
