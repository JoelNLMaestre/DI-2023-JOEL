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
        public static readonly Character NULLCHAR = new Character("", DEFLOC, 99);
        public static void Main(string[] args)
        {
            Queue<Character> characters = new Queue<Character>();
            Matrix matriz;
            String rows;
            String columns;
            // matrix creation 
            Console.WriteLine("Would you like to use the default matrix, or create a new one");
            Console.WriteLine("please respond:   default   for option 1 or:   new   for option two ");
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
                matriz = crearMatriz();
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

            // simulation initialization
            int max_time = 20;
            int time = 1;
            bool stillcharacters = true; // controls if there is still characters in the queue
            bool fin = false; // controls if smith has caugth Neo;
            do
            {

                // characteres turn
                if (time % 1 == 0)
                {
                    // check for characters about to die and remove them
                    // if not reday to die, then the character's death percentage is increased
                    printMatrix(matriz);
                    smith.setPDeath(0);
                    neo.setPDeath(0);
                    Console.WriteLine("Character turn");
                    stillcharacters = characTurn(characters, matriz, stillcharacters);
                }
                // smith's turn
                if (time % 2 == 0)
                {
                    Console.WriteLine("smith's turn");
                    fin = smithTurn(matriz, smith, characters);
                }
                // neo's turn
                if (time % 5 == 0)
                {
                    Console.WriteLine("Neo's turn");
                    neoTurn(matriz, neo, characters);
                }
                // wait 1 second
                Thread.Sleep(1000);
                time += 1;
            } while (time <= max_time && fin == false);

            if (time == 21)
            {
                Console.WriteLine("the game has run out of time");
                Console.WriteLine("number of people in the simulation: " + matriz.cont + "\n");
            }
            else
            {
                Console.WriteLine("Smith has captured Neo, the simulation has ended");
                Console.WriteLine("number of people in the simulation: "+matriz.cont+"\n");
            }
        }

        // CONTROL CREATION METHODS

        /** this method controls that the matrix is created correctly 
         */
        private static Matrix crearMatriz()
        {
            Matrix ans;
            try
            {
                Console.WriteLine("how many row do you want in the matrix?");
                String rows = Console.ReadLine();
                Console.WriteLine("how many columns do you want in the matrix?");
                String columns = Console.ReadLine();
                ans = new Matrix(Convert.ToInt32(rows), Convert.ToInt32(columns));
            }catch(FormatException)
            {
                Console.WriteLine("please you need to introduce numbers ");
                Console.WriteLine("please try again");
                ans = crearMatriz();
            }
            return ans;
        }


        // TURNS IN THE SIMULATION

        /**
         * changes the death percentage of the characters in the matrix and checks if the percentage is over 70 percent
         * if thats the case the character is replaced with another one from the queue
         * @param the queue where are the characters and the matrix where are needed to be used
        */
        public static bool characTurn(Queue<Character> characters, Matrix matriz, bool stillcharacters)
        {
            bool ans = true;
            try
            {
                
                for (int i = 0; i < matriz.matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.matrix.GetLength(1); j++)
                    {
                        if ((matriz.matrix[i, j] is Character && matriz.matrix[i, j].getPDeath() <= 70) && matriz.matrix[i, j] != NULLCHAR)
                        {
                            matriz.characterTurn(matriz.matrix[i, j]); // increase the death percentage
                        }
                        else if (matriz.matrix[i, j] is Character && matriz.matrix[i, j].getPDeath() > 70)
                        {
                            matriz.matrix[i, j] = characters.Dequeue();
                            matriz.cont += 1;
                        }else if(stillcharacters == false)
                        {
                            matriz.matrix[i, j] = NULLCHAR;
                        }
                    }
                }
            }catch(InvalidOperationException ioe) // controling the queue, if run out of characters the exception will prohibit the using of the queue
            {
                ans = false;
            }
            return ans;
        }
        /**
         * method to calcualte smith's turn, it will change the position of the agent and end the game if he reaches Neo
         * @param the matrix for the simulation, agent smith and the character's queue
         * @return true if the agent is in reach of Neo, otherwise false
         */
        public static bool smithTurn(Matrix matriz, Smith smith, Queue<Character> characters)
        {
            bool ans = false;
            int kills;
            kills = matriz.smithTurn(smith) ;
            if (checkForNeo(matriz))
            {
                ans = true;
            }
            smithMovement(matriz, smith, characters);
            return ans;
        }
        /**
         * method to calcualte neo's turn, also it will change the position of him
         * @param the matrix for the simulation, Neo and the queue of characters
         * @return true if the agent is in reach of Neo, otherwise false
         */
        public static void neoTurn(Matrix matriz, Neo neo, Queue<Character> characters)
        {
            bool belive = matriz.neoTurn(neo) ;
            if (belive)
            {
                changeAdjacentCharac(matriz, characters);
            }
            int num = RandomNumber.random_Number(1, 8);
            neoMovement(matriz, num, characters, neo);
        }






        // NEO'S MOVEMENT METHODS


        /**
         * this method changes the adjacent characters and if posible (position in null) it change them for new ones
         * @param the matrix and the queue of characters to import new ones
         */
        private static void changeAdjacentCharac(Matrix matriz, Queue<Character> characters)
        {
            for(int i = 0; i < 8;i++)
            {
                switch (i)
                {
                    case 0:
                        if (siNM(matriz))
                        {
                            if(matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY() - 1] == null)
                            {
                                matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY() - 1] = characters.Dequeue();
                            }
                        }
                        break;
                    case 1:
                        if (sdNM(matriz))
                        {
                            if (matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY() + 1] == null)
                            {
                                matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY() + 1] = characters.Dequeue();
                            }
                        }
                        break;
                    case 2:
                        if (iiNM(matriz))
                        {
                            if (matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY() - 1] == null)
                            {
                                matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY() - 1] = characters.Dequeue();
                            }
                        }
                        break;
                    case 3:
                        if (idNM(matriz))
                        {
                            if (matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY() + 1] == null)
                            {
                                matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY() + 1] = characters.Dequeue();
                            }
                        }
                        break;
                    case 4:
                        if (arribaNM(matriz))
                        {
                            if (matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY()] == null)
                            {
                                matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY()] = characters.Dequeue();
                            }
                        }
                        break;
                    case 5:
                        if (abajoNM(matriz))
                        {
                            if (matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY()] == null)
                            {
                                matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY()] = characters.Dequeue();
                            }
                        }
                        break;
                    case 6:
                        if (izqNM(matriz))
                        {
                            if (matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY() - 1] == null)
                            {
                                matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY() - 1] = characters.Dequeue();
                            }
                        }
                        break;
                    case 7:
                        if (derchNM(matriz))
                        {
                            if (matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY() + 1] == null)
                            {
                                matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY() + 1] = characters.Dequeue();
                            }
                        }
                        break;
                }
            }
        }
        /**
         * this method calculates the movement of Neo, 
         * @param the matrix, queue and the object Neo, IMPORTANT -> int num is used to calculate whether it is posible to move 
         * to one space or not
         */
        private static void neoMovement(Matrix matriz, int num, Queue<Character> characters, Neo neo)
        {
            switch (num) {
                case 1:
                    if (siNM(matriz))
                    {
                        matriz.NeoCell.setX(matriz.NeoCell.getX() - 1);
                        matriz.NeoCell.setY(matriz.NeoCell.getY() - 1);
                        Character aux = matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()];
                        matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()] = neo;
                        matriz.matrix[matriz.NeoCell.getX()+1, matriz.NeoCell.getY()+1] = aux;
                    }
                    else
                    {
                        neoMovement(matriz, RandomNumber.random_Number(1, 8), characters, neo);
                    }
                    break;
                case 2:
                    if (sdNM(matriz))
                    {
                        matriz.NeoCell.setX(matriz.NeoCell.getX() - 1);
                        matriz.NeoCell.setY(matriz.NeoCell.getY() + 1);
                        Character aux = matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()];
                        matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()] = neo;
                        matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY() - 1] = aux;
                    }
                    else
                    {
                        neoMovement(matriz, RandomNumber.random_Number(1, 8), characters, neo);
                    }
                    break;
                case 3:
                    if (iiNM(matriz))
                    {
                        matriz.NeoCell.setX(matriz.NeoCell.getX() + 1);
                        matriz.NeoCell.setY(matriz.NeoCell.getY() - 1);
                        Character aux = matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()];
                        matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()] = neo;
                        matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY() + 1] = aux;
                    }
                    else
                    {
                        neoMovement(matriz, RandomNumber.random_Number(1, 8), characters, neo);
                    }
                    break;
                case 4:
                    if (idNM(matriz))
                    {
                        matriz.NeoCell.setX(matriz.NeoCell.getX() + 1);
                        matriz.NeoCell.setY(matriz.NeoCell.getY() + 1);
                        Character aux = matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()];
                        matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()] = neo;
                        matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY() - 1] = aux;
                    }
                    else
                    {
                        neoMovement(matriz, RandomNumber.random_Number(1, 8), characters, neo);
                    }
                    break;
                case 5:
                    if (arribaNM(matriz))
                    {
                        matriz.NeoCell.setX(matriz.NeoCell.getX() - 1);
                        matriz.NeoCell.setY(matriz.NeoCell.getY());
                        Character aux = matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()];
                        matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()] = neo;
                        matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY()] = aux;
                    }
                    else
                    {
                        neoMovement(matriz, RandomNumber.random_Number(1, 8), characters, neo);
                    }
                    break;
                case 6:
                    if (abajoNM(matriz))
                    {
                        matriz.NeoCell.setX(matriz.NeoCell.getX() + 1);
                        matriz.NeoCell.setY(matriz.NeoCell.getY());
                        Character aux = matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()];
                        matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()] = neo;
                        matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY()] = aux;
                    }
                    else
                    {
                        neoMovement(matriz, RandomNumber.random_Number(1, 8), characters, neo);
                    }
                    break;
                case 7:
                    if (izqNM(matriz))
                    {
                        matriz.NeoCell.setX(matriz.NeoCell.getX());
                        matriz.NeoCell.setY(matriz.NeoCell.getY() - 1);
                        Character aux = matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()];
                        matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()] = neo;
                        matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY() + 1] = aux;
                    }
                    else
                    {
                        neoMovement(matriz, RandomNumber.random_Number(1, 8), characters, neo);
                    }
                    break;
                case 8:
                    if (derchNM(matriz))
                    {
                        matriz.NeoCell.setX(matriz.NeoCell.getX());
                        matriz.NeoCell.setY(matriz.NeoCell.getY() + 1);
                        Character aux = matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()];
                        matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY()] = neo;
                        matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY() - 1] = aux;
                    }
                    else
                    {
                        neoMovement(matriz, RandomNumber.random_Number(1, 8), characters, neo);
                    }
                    break;
            }
        }

        /** this methods checks if Neo can move to the left superior side
         * @param the matrix to be checked
         * @return true if Neo can move, otherwise false
         */
        private static bool siNM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY() - 1].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Neo can move to the right superior side
         * @param the matrix to be checked
         * @return true if Neo can move, otherwise false
         */
        private static bool sdNM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY() + 1].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Neo can move to the left inferior side
         * @param the matrix to be checked
         * @return true if Neo can move, otherwise false
         */
        private static bool iiNM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY() - 1].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Neo can move to the right inferior side
         * @param the matrix to be checked
         * @return true if Neo can move, otherwise false
         */
        private static bool idNM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY() + 1].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Neo can move to the inmediate superior side
        * @param the matrix to be checked
        * @return true if Neo can move, otherwise false
        */
        private static bool arribaNM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.NeoCell.getX() - 1, matriz.NeoCell.getY()].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Neo can move to the inmediate inferior side
       * @param the matrix to be checked
       * @return true if Neo can move, otherwise false
       */
        private static bool abajoNM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.NeoCell.getX() + 1, matriz.NeoCell.getY()].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Neo can move to the inmediate left side
       * @param the matrix to be checked
       * @return true if Neo can move, otherwise false
       */
        private static bool izqNM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY() - 1].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Neo can move to the inmediate right side
       * @param the matrix to be checked
       * @return true if Neo can move, otherwise false
       */
        private static bool derchNM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.NeoCell.getX(), matriz.NeoCell.getY() + 1].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }



        // SMITH'S MOVEMENT METHODS


        /**
         * this method checks if Neo is in range form smith to capture/kill him
         * @param the matrix where the simulation is being computated
         * @return true if Neo is in range, false otherwise
         */
        private static bool checkForNeo(Matrix matriz)
        {
            bool ans = false;
            if (si(matriz) || sd(matriz) || ii(matriz) || id(matriz))
            {
                ans = true;
            }
            return ans;
        }
        /** this methods checks if Neo is in range from Smith tom be caugth
         * @param the matrix to be checked
         * @return true if neo is in range, otherwise false
         */
        private static bool si(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.SmithCell.getX() - 1, matriz.SmithCell.getY() - 1].GetType() == typeof(Neo))
                    ans = true; 
            }catch(IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Neo is in range from Smith tom be caugth
         * @param the matrix to be checked
         * @return true if neo is in range, otherwise false
         */
        private static bool sd(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.SmithCell.getX() - 1, matriz.SmithCell.getY() + 1].GetType() == typeof(Neo))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Neo is in range from Smith tom be caugth
         * @param the matrix to be checked
         * @return true if neo is in range, otherwise false
         */
        private static bool ii(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.SmithCell.getX() + 1, matriz.SmithCell.getY() - 1].GetType() == typeof(Neo))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Neo is in range from Smith tom be caugth
         * @param the matrix to be checked
         * @return true if neo is in range, otherwise false
         */
        private static bool id(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.SmithCell.getX() + 1, matriz.SmithCell.getY() + 1].GetType() == typeof(Neo))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /**
         * method to calculate teh movement of the agent smith
         * @param the matrix and the agent smith
         */
        public static void smithMovement(Matrix matriz, Smith smith, Queue<Character> characters)
        {
            int rowssmith = matriz.SmithCell.getX();
            int columnssmith = matriz.SmithCell.getY();
            if ((matriz.NeoCell.getX() - matriz.SmithCell.getX()) < 0)
            {
                matriz.SmithCell.setX((matriz.SmithCell.getX() - 1));
            }
            else if ((matriz.NeoCell.getX() - matriz.SmithCell.getX()) > 0)
            {
                matriz.SmithCell.setX((matriz.SmithCell.getX() + 1));
            }
            else if ((matriz.NeoCell.getX() - matriz.SmithCell.getX()) == 0)
            {
                String ans = "";
                if (siSM(matriz))
                    ans += "a";
                if (sdSM(matriz))
                    ans += "b";
                if (iiSM(matriz))
                    ans += "c";
                if (idSM(matriz))
                    ans += "d";
                int num = RandomNumber.random_Number(0, 100);
                switch (ans)
                {
                    case "a":
                        matriz.SmithCell.setX((matriz.SmithCell.getX() - 1));
                        break;
                    case "b":
                        matriz.SmithCell.setX((matriz.SmithCell.getX() - 1));
                        break;
                    case "c":
                        matriz.SmithCell.setX((matriz.SmithCell.getX() + 1));
                        break;
                    case "d":
                        matriz.SmithCell.setX((matriz.SmithCell.getX() + 1));
                        break;
                    case "ab":
                        matriz.SmithCell.setX((matriz.SmithCell.getX() - 1));
                        break;
                    case "cd":
                        matriz.SmithCell.setX((matriz.SmithCell.getX() + 1));
                        break;
                    default:
                        if (num < 51)
                        {
                            matriz.SmithCell.setX((matriz.SmithCell.getX() + 1));
                        }
                        else
                        {
                            matriz.SmithCell.setX((matriz.SmithCell.getX() - 1));
                        }
                        break;
                }
            }

            if ((matriz.NeoCell.getY() - matriz.SmithCell.getY()) < 0)
            {
                matriz.SmithCell.setY((matriz.SmithCell.getY() - 1));
            }
            else if ((matriz.NeoCell.getY() - matriz.SmithCell.getY()) > 0)
            {
                matriz.SmithCell.setY((matriz.SmithCell.getY() + 1));
            }
            else if ((matriz.NeoCell.getY() - matriz.SmithCell.getY()) == 0)
            {
                String ans = "";
                int num = RandomNumber.random_Number(0, 100);
                if (siSM(matriz))
                    ans += "a";
                if (sdSM(matriz))
                    ans += "b";
                if (iiSM(matriz))
                    ans += "c";
                if (idSM(matriz))
                    ans += "d";
                switch (ans)
                {
                    case "a":
                        matriz.SmithCell.setY((matriz.SmithCell.getY() - 1));
                        break;
                    case "b":
                        matriz.SmithCell.setY((matriz.SmithCell.getY() + 1));
                        break;
                    case "c":
                        matriz.SmithCell.setY((matriz.SmithCell.getY() - 1));
                        break;
                    case "d":
                        matriz.SmithCell.setY((matriz.SmithCell.getY() + 1));
                        break;
                    case "ac":
                        matriz.SmithCell.setY((matriz.SmithCell.getY() - 1));
                        break;
                    case "bd":
                        matriz.SmithCell.setY((matriz.SmithCell.getY() + 1));
                        break;
                    default:
                        if (num < 51)
                        {
                            matriz.SmithCell.setY((matriz.SmithCell.getY() + 1));
                        }
                        else
                        {
                            matriz.SmithCell.setY((matriz.SmithCell.getY() - 1));
                        }
                        break;
                }
            }
            matriz.matrix[(matriz.SmithCell.getX()), (matriz.SmithCell.getY())] = smith;
            matriz.matrix[rowssmith, columnssmith] = NULLCHAR;
        }
        /** this methods checks if Smith can move to the left superior side
         * @param the matrix to be checked
         * @return true if smith can move, otherwise false
         */
        private static bool siSM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.SmithCell.getX() - 1, matriz.SmithCell.getY() - 1].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Smith can move to the right superior side
         * @param the matrix to be checked
         * @return true if smith can move, otherwise false
         */
        private static bool sdSM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.SmithCell.getX() - 1, matriz.SmithCell.getY() + 1].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Smith can move to the left inferior side
         * @param the matrix to be checked
         * @return true if smith can move, otherwise false
         */
        private static bool iiSM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.SmithCell.getX() + 1, matriz.SmithCell.getY() - 1].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /** this methods checks if Smith can move to the right inferior side
         * @param the matrix to be checked
         * @return true if smith can move, otherwise false
         */
        private static bool idSM(Matrix matriz)
        {
            bool ans = false;
            try
            {
                if (matriz.matrix[matriz.SmithCell.getX() + 1, matriz.SmithCell.getY() + 1].GetType() == typeof(Character))
                    ans = true;
            }
            catch (IndexOutOfRangeException iore)
            {
                ans = false;
            }
            return ans;
        }
        /**
         * method used to calculate the distance between Neo and smith
         * @param the Cells where Neo and Smith are in each moment of the simulation
         * @return the number of steps between Neo and Smith
         */
        public static int CalculateDistance(Cell cells, Cell celln)
        {
            int ans;
            ans = Maximum(Absolute(celln.getY(), cells.getY()), Absolute(celln.getX(), cells.getX()));
            return ans;
        }
        /**
         * method use to calculate the absolute value of a subtraction
         * @param the numbers used in the subtraction
         * @return the absolute value of the subtraction result
         */
        static int Absolute(int a, int b)
        {
            int ans = a - b;
            if(ans < 0){
                ans = ans * -1;
            }
            return ans;
        }
        /**
         * method used to calculate the greater number of a couple
         * @param the number that are needed to be compared
         * @return the greater number of the two
         */
        static int Maximum(int a, int b)
        {
            int ans = b;
            if (a > b)
            {
                ans = a;
            }
            return ans;
        }
        /**
         * method to print the matrix in a determined moment 
         * @param the matrix to be printed
         */
        public static void printMatrix(Matrix matriz)
        {
            for(int i=0; i < matriz.matrix.GetLength(0); i++)
            {
                for (int j=0; j<matriz.matrix.GetLength(1); j++)
                {
                    if (matriz.matrix[i, j].GetType() == typeof(Character) && matriz.matrix[i, j] != NULLCHAR)
                    {
                        Console.Write("C ");
                    }
                    else if (matriz.matrix[i, j].GetType() == typeof(Neo) && matriz.matrix[i, j] != NULLCHAR)
                    {
                        Console.Write("N ");
                    }
                    else if (matriz.matrix[i, j].GetType() == typeof(Smith) && matriz.matrix[i, j] != NULLCHAR)
                    {
                        Console.Write("S ");
                    }
                    else if (matriz.matrix[i, j] == NULLCHAR)
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
