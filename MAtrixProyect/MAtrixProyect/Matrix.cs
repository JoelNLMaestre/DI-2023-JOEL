using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAtrixProyect
{
    internal class Matrix : Interface1
    {
        int cont;
        Character[,] matrix;
        Cell SmithCell;
        Cell NeoCell;
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


        // methods to be implemented
        public void characterTurn(Character c)
        {
            c.setPDeath((c.getPDeath()+10));
        }
        public void smithTurn()
        {
            // to be implemented
        }
        public void neoTurn()
        {
            // to be implemented
        }
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
