using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squid_Game
{
    public class Matrix
    {
        private int a { set; get; }
        private int b { set; get; }

        public char[,] tabla;
        public Matrix(int a, int b)
        {
            this.a = a; this.b = b;
            this.tabla = new char[a,b];

            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    tabla[i, j] = '-';
                }
                Console.WriteLine();
            }
        }

        public void printTabla()
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for(int j = 0; j < tabla.GetLength(1); j++)
                {
                    Console.Write(tabla[i,j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
