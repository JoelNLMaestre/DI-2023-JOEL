public class Matrix
{
    public static void Main(String[] args)
    {
        Console.WriteLine("please introduce de figure you want to print");
        String elec = Console.ReadLine();
        switch (elec[0])
        {
            case 'a':
                printA();
                break;
            case 'b':
                printB();
                break;
            case 'c':
                printC();
                break;
            case 'd':
                printD();
                break;
            case 'e':
                printE();
                break;
            case 'f':
                printF();
                break;
            case 'g':
                printG();
                break;
            case 'h':
                printH();
                break;
            case 'i':
                printI();
                break;
            case 'j':
                printJ();
                break;
            case 'k':
                printK();
                break;
            case 'l':
                printL();
                break;
            case 'm':
                printM();
                break;
            case 'n':
                printN();
                break;
            case 'o':
                printO();
                break;
            case 'p':
                printP();
                break;
            case 's':
                printS();
                break;

        }

    }
    public static void printA()
    {
        String p = "";
        for (int i = 0; i < 8; i++) {
            p = p + "# ";
            Console.WriteLine(p);
        }
    }
    public static void printB()
    {
        for(int i = 8;i > 0;i--)
        {
            for (int j = 0; j < i; j++) {
                Console.Write("# ");
            }
            Console.WriteLine("");
        }
    }
    public static void printC() {
        char[] car = { '#','#','#','#','#','#','#','#'};
        for (int i = 0; i < car.Length; i++)
        {
            for (int j = 0; j < car.Length; j++)
            {
                Console.Write(car[j]+" ");
            }
            car[i] = ' ';
            Console.WriteLine("");
        }
    }
    public static void printD()
    {
        char[] car = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        for (int i = 0; i < car.Length; i++)
        {
            for (int j = 0; j < car.Length; j++)
            {
                Console.Write(car[j] + " ");
            }
            car[car.Length-i-1] = '#';
            Console.WriteLine("");
        }
    }
    public static void printE()
    {
        char[] car = { '#', '#', '#', '#', '#', '#', '#'};
        char[] car2 = { '#', ' ', ' ', ' ', ' ', ' ', '#' };
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
        Console.WriteLine("");
        for (int i = 0; i < car.Length-2; i++)
        {
            for (int j = 0; j < car.Length; j++)
            {
                Console.Write(car2[j]);
            }
            Console.WriteLine("");
        }
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
    }
    public static void printF()
    {
        char[] car = { '#', '#', '#', '#', '#', '#', '#' };
        char[] car2 = { ' ', '#', ' ', ' ', ' ', ' ', ' ' };
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
        Console.WriteLine("");
        for (int i = 0; i < car.Length - 2; i++)
        {
            for (int j = 0; j < car.Length; j++)
            {
                Console.Write(car2[j]);
            }
            car2[i + 1] = ' ';
            car2[i + 2] = '#';
            Console.WriteLine("");
        }
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
    }
    public static void printG()
    {
        char[] car = { '#', '#', '#', '#', '#', '#', '#' };
        char[] car2 = { ' ', '#', ' ', ' ', ' ', ' ', ' ' };
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
        Console.WriteLine("");
        for (int i = 0; i < car.Length - 2; i++)
        {
            for (int j = car.Length-1; j > 0; j--)
            {
                Console.Write(car2[j]);
            }
            car2[i + 1] = ' ';
            car2[i + 2] = '#';
            Console.WriteLine("");
        }
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
    }
    public static void printH()
    {
        char[] car = { '#', '#', '#', '#', '#', '#', '#'};
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
        Console.WriteLine("");
        for (int i = 0; i < car.Length - 2; i++)
        {
            for (int j = 0; j < car.Length; j++)
            {
                if (j==i+1 || j==car.Length-i-2) {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine("");
        }
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
    }
    public static void printI()
    {
        char[] car = { '#', '#', '#', '#', '#', '#', '#' };
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
        Console.WriteLine("");
        for (int i = 0; i < car.Length - 2; i++)
        {
            for (int j = 0; j < car.Length; j++)
            {
                if (j == i + 1 || j == car.Length - i - 2 || j == 0 || j == car.Length-1)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine("");
        }
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
    }
    public static void printJ()
    {
        char[] car = { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' };
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
        Console.WriteLine("");
        for (int i = 0; i < car.Length - 2; i++)
        {
            for (int j = 0; j < car.Length; j++)
            {
                if (j==i)
                {
                    car[j] = ' ';
                    car[car.Length-j-1] = ' ';
                }
                Console.Write(car[j]);
            }
            Console.WriteLine("");
        }
    }
    public static void printK()
    {
        char[] car = { ' ', ' ', ' ', ' ', ' '};
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
        Console.WriteLine("");
        for (int i = 0; i < car.Length; i++)
        {
            for (int j = 0; j < car.Length; j++)
            {
                Console.Write(car[j]);
            }
            Console.Write("#");
            for (int j = car.Length-1; j > 0; j--)
            {
                Console.Write(car[j]);
            }
            car[car.Length - i - 1] = '#';
            Console.WriteLine("");
        }
        for (int j = 0; j < car.Length; j++)
        {
            Console.Write(car[j]);
        }
        Console.Write("#");
        for (int j = car.Length - 1; j >= 0; j--)
        {
            Console.Write(car[j]);
        }

    }
    public static void printL()
    {
        char[] car = { ' ', ' ', ' ', ' ', ' ' };
        for (int i = 0; i < car.Length; i++)
        {
            Console.Write(car[i]);
        }
        Console.WriteLine("");
        for (int i = 0; i < car.Length; i++)
        {
            for (int j = 0; j < car.Length; j++)
            {
                Console.Write(car[j]);
            }
            Console.Write("#");
            for (int j = car.Length - 1; j > 0; j--)
            {
                Console.Write(car[j]);
            }
            car[car.Length - i - 1] = '#';
            Console.WriteLine("");
        }
        printJ();
    }
    public static void printM()
    {
        String p = "";
        for (int i = 0; i < 8; i++)
        {
            p = p + (i+1)+" ";
            Console.WriteLine(p);
        }
    }
    public static void printN()
    {
        char[] car = { '1', '2', '3', '4', '5', '6', '7', '8' };
        for (int i = 0; i < car.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write(" ");
            }
            for (int j = 0; j < car.Length; j++)
            {
                Console.Write(car[j]);
            }
            car[car.Length-i-1] = ' ';
            Console.WriteLine("");
        }
    }
    public static void printO()
    {
        char[] car2 = { '1', '2', '3', '4', '5', '6', '7', '8' };
        char[] car = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        for (int i = 0;i < 8;i++)
        {
            car[i] = car2[i];
            for (int j=car.Length-1; j>=0; j--)
            {
                Console.Write(car[j]);
            }
            Console.WriteLine("");
        }
    }
    public static void printP()
    {
        int lon = 8;
        char[] car2 = { '1', '2', '3', '4', '5', '6', '7', '8' };
        char[] car=car2;
        while(lon>=1){
            for (int j = car.Length - 1; j >= 0; j--)
            {
                Console.Write(car[j]);
            }
            lon--;
            car = new char[lon];
            for (int j=0; j < lon; j++)
            {
                car[j] = car2[j];
            }
            Console.WriteLine("");
        }
    }
    public static void printS()
    {
        
    }
}