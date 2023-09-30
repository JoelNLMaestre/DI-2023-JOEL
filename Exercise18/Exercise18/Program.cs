
public class TrigonometricSeries
{
    static void Main()
    {
        Console.WriteLine("Introduce de radiants that you want to compute, following the next pattern: (x/y)pi");
        String rads = Console.ReadLine();
        String radsX = rads.Substring(1,1);
        double x = double.Parse(radsX);
        String radsY = rads.Substring(3, 1);
        double y = double.Parse(radsY);

        double z = (x/y)*Math.PI;
        double sin = z, cos = 1;
        double s;
        double con = 2;
        int c = 2;
        while(con<50) {
            s = ((Math.Pow(z, con)) / Factorial(con));
            if (c%2 ==  0) { s = s * (-1); }
            if (con%2 == 0 )
            {
                cos = cos + s;
            }
            con+=2;
            c++;
        }
        Console.WriteLine("cos: "+ Math.Round(cos, 8));
        con = 3;
        c = 2;
        while (con < 50)
        {
            s = ((Math.Pow(z, con)) / Factorial(con));
            if (c % 2 == 0) { s = s * (-1); }
            if (con % 2 != 0)
            {
                sin = sin + s;
            }
            con += 2;
            c++;
        }
        
        Console.WriteLine("sin: " + Math.Round(sin, 8));
    }
    public static double Factorial(double d)
    {
        double devolver = 1;
        for (int i = 1; i <= d; i++)
        {
            devolver = devolver * i;
        }
        return devolver;
    }

}