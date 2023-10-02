public class Matrix
{

    public static void Main(String[] args)
    {
        // in this exercise i will use two arrays filled with 1s to check if the methods work correctly.
        double[,] m1 = new double[3, 3];
        double[,] m2 = new double[2, 2];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                m1[i, j] = 1.0;
            }
        }
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            { 
                m2[i, j] = 1.0;
            }
        }
        double[,] sum = Addition(m1, m2);
        Console.WriteLine("Addition:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(sum[i, j]);
            }
            Console.WriteLine();
        }
        double[,] sub = Subtraction(m1, m2);
        Console.WriteLine("Subtraction:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(sub[i, j]);
            }
            Console.WriteLine();
        }
        double[,] m3 = { { 1.0, 1.0, 1.0},{ 1.0, 1.0, 1.0} };
        double[,] m4 = { { 1.0, 1.0 }, { 1.0, 1.0 }, { 1.0, 1.0 } };
        Console.WriteLine("Multiplication:");
        double[,] mul = Multiplication(m3,m4);
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write(mul[i, j]);
            }
            Console.WriteLine();
        }

    }

    public static double[,] Addition(double[,] m1, double[,] m2)
    {
        int i, j;
        char alt, anch;
        if (m1.GetLength(0) > m2.GetLength(0))
        {
            i = m1.GetLength(0);
            alt = '1';
        }
        else
        {
            i = m2.GetLength(0);
            alt = '2';
        }
        if (m1.GetLength(1) > m2.GetLength(1))
        {
            j = m1.GetLength(1);
            anch = '1';
        }
        else
        {
            j = m2.GetLength(1);
            anch = '2';
        }
        double[,] sum = new double[i, j];
        for (int a = 0; a < sum.GetLength(0); a++)
        {
            for (int b = 0; b < sum.GetLength(1); b++)
            {
                try
                {
                    sum[a, b] = m1[a, b] + m2[a, b];
                }
                catch (IndexOutOfRangeException)
                {
                    if (alt == '1')
                    {
                        sum[a, b] = m1[a, b];
                    }
                    else
                    {
                        sum[a, b] = m2[a, b];
                    }
                    if (anch == '1')
                    {
                        sum[a, b] = m1[a, b];
                    }
                    else
                    {
                        sum[a, b] = m2[a, b];
                    }
                }
            }
        }
        return sum;
    }
    public static double[,] Subtraction(double[,] m1, double[,] m2)
    {
        int i, j;
        char alt, anch;
        if (m1.GetLength(0) > m2.GetLength(0))
        {
            i = m1.GetLength(0);
            alt = '1';
        }
        else
        {
            i = m2.GetLength(0);
            alt = '2';
        }
        if (m1.GetLength(1) > m2.GetLength(1))
        {
            j = m1.GetLength(1);
            anch = '1';
        }
        else
        {
            j = m2.GetLength(1);
            anch = '2';
        }
        double[,] sum = new double[i, j];
        for (int a = 0; a < sum.GetLength(0); a++)
        {
            for (int b = 0; b < sum.GetLength(1); b++)
            {
                try
                {
                    sum[a, b] = m1[a, b] - m2[a, b];
                }
                catch (IndexOutOfRangeException)
                {
                    if (alt == '1')
                    {
                        sum[a, b] = m1[a, b];
                    }
                    else
                    {
                        sum[a, b] = m2[a, b];
                    }
                    if (anch == '1')
                    {
                        sum[a, b] = m1[a, b];
                    }
                    else
                    {
                        sum[a, b] = m2[a, b];
                    }
                }
            }
        }
        return sum;
    }
    public static double[,] Multiplication(double[,] m1, double[,] m2)
    {
        if (m1.GetLength(1) == m2.GetLength(0))
        {
            double[,] ans = new double[m1.GetLength(0), m2.GetLength(1)];
            for (int a = 0; a < ans.GetLength(0); a++)
            {
                for (int b = 0; b < ans.GetLength(1); b++)
                {
                    double sum = 0;
                    for (int c = 0; c < ans.GetLength(1); c++)
                    {
                        sum += m1[a,c] * m2[c,b];
                    }
                    ans[a, b] = sum;
                }
            }
            return ans;
        }
        else
        {
            Console.WriteLine("the matrix are incompatible");
            return null;
        }
    }
}