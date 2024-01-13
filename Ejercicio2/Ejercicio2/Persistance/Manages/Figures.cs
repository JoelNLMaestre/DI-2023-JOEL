using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Persistance.Manages
{
    class Figures
    {
        public void Bishop(char[,] tabla)
        {
            int a = 0, b = 0;

            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (tabla[i, j] == 'B')
                    {
                        a = i; b = j; break;
                    }
                }
                Console.WriteLine();
            }
            for (int i = 1; i < tabla.GetLength(1); i++)
            {
                CheckPos(tabla, a - i, b - i);
                CheckPos(tabla, a + i, b - i);
                CheckPos(tabla, a - i, b + i);
                CheckPos(tabla, a + i, b + i);
            }
        }
        public void Tower(char[,] tabla)
        {
            int a = 0, b = 0;

            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (tabla[i, j] == 'T')
                    {
                        a = i; b = j; break;
                    }
                }
                Console.WriteLine();
            }
            for (int i = 1; i < tabla.GetLength(1); i++)
            {
                CheckPos(tabla, a - i, b);
                CheckPos(tabla, a + i, b);
                CheckPos(tabla, a, b + i);
                CheckPos(tabla, a, b - i);
            }
        }
        public void Queen(char[,] tabla)
        {
            int a = 0, b = 0;

            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (tabla[i, j] == 'Q')
                    {
                        a = i; b = j; break;
                    }
                }
                Console.WriteLine();
            }
            for (int i = 1; i < tabla.GetLength(1); i++)
            {
                CheckPos(tabla, a - i, b);
                CheckPos(tabla, a + i, b);
                CheckPos(tabla, a, b + i);
                CheckPos(tabla, a, b - i);
                CheckPos(tabla, a - i, b - i);
                CheckPos(tabla, a + i, b - i);
                CheckPos(tabla, a - i, b + i);
                CheckPos(tabla, a + i, b + i);
            }
        }
        public void Horse(char[,] tabla)
        {
            int a = 0, b = 0;

            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (tabla[i, j] == 'H')
                    {
                        a = i; b = j; break;
                    }
                }
                Console.WriteLine();
            }
            CheckPos(tabla, a - 2, b - 1);
            CheckPos(tabla, a - 1, b - 2);
            CheckPos(tabla, a + 2, b - 1);
            CheckPos(tabla, a + 1, b - 2);

            CheckPos(tabla, a + 2, b + 1);
            CheckPos(tabla, a + 1, b + 2);
            CheckPos(tabla, a - 2, b + 1);
            CheckPos(tabla, a - 1, b + 2);
        }

        private static bool CheckPos(char[,] tabla, int a, int b)
        {
            bool ans = false;
            try
            {
                if (tabla[a, b] == '-')
                {
                    tabla[a, b] = '*';
                }
                ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
    }
}
