using Pathfinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MAtrixProyect
{
    public class Simulation
    {
        public static readonly Location DEFLOC = new Location(0,0,"None");
        public static void Main(string[] args)
        {
            Queue<Character> characters = new Queue<Character>();
            Matrix matriz;
            String rows;
            String columns;
            // matrix creation 
            Console.WriteLine("Would you like to use the default matrix, or create a new one, please respond: default for option 1 or: new for option two ");
            String ans = Console.ReadLine();
            while (!ans.Equals("default") &&  !ans.Equals("new"))
            {
                Console.WriteLine("the response is not valid, please write as indicated above");
                Console.WriteLine("Would you like to use the default matrix, or create a new one, please respond: default for option 1 or: new for option two ");
                ans = Console.ReadLine();
            }
            if (ans.Equals("default"))
            {
                matriz = new Matrix();
            }
            else
            {
                Console.WriteLine("how many row do you want in the matrix?");
                rows = Console.ReadLine();
                Console.WriteLine("how many columns do you want in the matrix?");
                columns = Console.ReadLine();
                matriz = new Matrix(Convert.ToInt32(rows), Convert.ToInt32(columns));
            }
            // filling queue
            for (int i = 0; i < 200; i++)
            {
                Location l = new Location(RandomNumber.random_Number(0, 100), RandomNumber.random_Number(0, 100), Character.CITIES[RandomNumber.random_Number(0, Character.CITIES.Length - 1)]);
                Character c = new Character(Character.NAMES[RandomNumber.random_Number(0, Character.NAMES.Length - 1)], l);
                characters.Enqueue(c);
            }
            // filling matrix
            for (int i = 0; i < matriz.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.matrix.GetLength(1); j++)
                {
                    matriz.matrix[i, j] = characters.Dequeue();
                }
            }
            // creation and introdution smith and neo in matrix
            Neo neo = new Neo("Neo", DEFLOC, RandomNumber.random_Number(0, 100));
            Smith smith = new Smith("Smith", DEFLOC, RandomNumber.random_Number(1, 8));
            Cell cellneo = new Cell(RandomNumber.random_Number(0, matriz.matrix.GetLength(0)), RandomNumber.random_Number(0, matriz.matrix.GetLength(1)));
            Cell cellsmith = new Cell(RandomNumber.random_Number(0, matriz.matrix.GetLength(0)), RandomNumber.random_Number(0, matriz.matrix.GetLength(1)));
            matriz.setNeoCell(cellneo);
            matriz.setSmithCell(cellsmith);
            matriz.matrix[cellneo.getX(), cellneo.getY()] = neo;
            matriz.matrix[cellsmith.getX(), cellsmith.getY()] = smith;


            // making test
            printMatrix(matriz);
            Console.WriteLine("Distance between neo and smith :" + CalculateDistance(cellsmith, cellneo));
        }




        public static int CalculateDistance(Cell cells, Cell celln)
        {
            int ans;
            ans = Maximum(Absolute(celln.getY(), cells.getY()), Absolute(celln.getX(), cells.getX()));
            return ans;
        }
        static int Absolute(int a, int b)
        {
            int ans = a - b;
            if(ans < 0){
                ans = ans * -1;
            }
            return ans;
        }
        static int Maximum(int a, int b)
        {
            int ans = b;
            if (a > b)
            {
                ans = a;
            }
            return ans;
        }
        public static void printMatrix(Matrix matriz)
        {
            for(int i=0; i < matriz.matrix.GetLength(0); i++)
            {
                for (int j=0; j<matriz.matrix.GetLength(1); j++)
                {
                    if (matriz.matrix[i, j].GetType() == typeof(Character))
                    {
                        Console.Write("C ");
                    }
                    if (matriz.matrix[i, j].GetType() == typeof(Neo))
                    {
                        Console.Write("N ");
                    }
                    if (matriz.matrix[i, j].GetType() == typeof(Smith))
                    {
                        Console.Write("S ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
