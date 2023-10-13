using Pathfinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAtrixProyect
{
    public class Matrix : Interface1
    {
        public int cont;
        public Character[,] matrix;
        public Cell SmithCell;
        public Cell NeoCell;
        public Matrix() { // this is the default constructor for the class matrix 
            this.matrix = new Character[5,5];
            this.cont = (5*5) - 2;
        }
        public Matrix(int rows, int columns) {
            if (rows > 4 && columns > 4)
            {
                this.matrix = new Character[rows, columns];
                this.cont = (rows * columns) - 2;
            }
            else
            {
                Console.WriteLine("the matrix have to be composed of at least 5 rows and 5 columns");
            }
        }

        public void setSmithCell(Cell cell) // set the coordinates for the character smith 
        {
            try
            {
                this.SmithCell = new Cell(cell.getX(), cell.getY());
            }
            catch (IndexOutOfRangeException iore)
            {
                Console.WriteLine("the cordinates of the cell are not in the matrix, please try again");
            }
        }
        public void setNeoCell(Cell cell) // set the coordinates for the character neo
        {
            try
            {
                this.NeoCell = new Cell(cell.getX(), cell.getY());
            }
            catch (IndexOutOfRangeException iore)
            {
                Console.WriteLine("the cordinates of the cell are not in the matrix, please try again");
            }
        }
        public void characterTurn(Character c)
        {
            c.setPDeath((c.getPDeath() + 10));
        }
        public int smithTurn(Smith s)
        {
            int ans;
            ans = RandomNumber.random_Number(1, s.getmaxDeaths());
            return ans;
        }
        public bool neoTurn(Neo n)
        {
            bool ans;
            n.setPercent(RandomNumber.random_Number(1, 100));
            ans = n.belive();
            return ans;
        }

        // methods to be implemented

        public void Generate()
        {
            throw new NotImplementedException();
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public void prompt()
        {
            throw new NotImplementedException();
        }
    }
}
