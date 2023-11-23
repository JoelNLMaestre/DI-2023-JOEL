using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squid_Game
{
    class Menu
    {
        public static void Main(string[] args)
        {
            Matrix matriz;
            Figures figura = new Figures();
            Random r = new Random();
        Console.WriteLine("Please introduce the first parameter for the matrix");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please introduce the second parameter for the matrix");
            int b = Int32.Parse(Console.ReadLine());

            matriz = new Matrix(a, b);

            Console.WriteLine("Please choose the figure you want to play");
            Console.WriteLine("valid figures: Bishop, Tower, Queen, Horse");
            String figure = Console.ReadLine(); 

            figure = checkString(figure);

            int posX = r.Next(0, a);
            int posY = r.Next(0, b);

            switch (figure)
            {
                case "Bishop":
                    matriz.tabla[posX, posY] = 'B';
                    figura.Bishop(matriz.tabla);
                    matriz.printTabla();
                    break;
                case "Tower":
                    matriz.tabla[posX, posY] = 'T';
                    figura.Tower(matriz.tabla);
                    matriz.printTabla();
                    break;
                case "Queen":
                    matriz.tabla[posX, posY] = 'Q';
                    figura.Queen(matriz.tabla);
                    matriz.printTabla();
                    break;
                case "Horse":
                    matriz.tabla[posX, posY] = 'H';
                    figura.Horse(matriz.tabla);
                    matriz.printTabla();
                    break;
            }
        }

        private static String checkString(String figure)
        {
            while(!figure.Equals("Bishop") && !figure.Equals("Tower") && !figure.Equals("Queen") && !figure.Equals("Horse"))
            {
                Console.WriteLine("Please choose the figure you want to play");
                Console.WriteLine("valid figures: Bishop, Tower, Queen, Horse");
                figure = Console.ReadLine();
            }
            return figure;
        }
    }
}
