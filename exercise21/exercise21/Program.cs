using System.Buffers;
using System.Collections;
using System.Security;

public class exercise21
{
    public static void Main()
    {
        Console.WriteLine("Enter the upper bound");
        int upper = int.Parse(Console.ReadLine());
        ArrayList perfects = new ArrayList();
        ArrayList neither = new ArrayList();
        for (int i = 2; i < upper; i++)
        {
            if (isPerfect(i))
            {
                perfects.Add(i);
            }else if (!isDeficient(i))
            {
                neither.Add(i);
            }
        }
        object[] arrP = perfects.ToArray();
        object[] arrN = neither.ToArray();
        Console.WriteLine("These are the perfect numbers");
        foreach (int i in arrP)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine("["+arrP.Length+" perfect numbers found]");
        Console.WriteLine("");
        Console.WriteLine("These numbers are neither deficient nor perfect:");
        foreach(int i in arrN)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine("[" + arrN.Length + " numbers found]");
    }

    public static bool isPerfect(int num)
    {
        ArrayList array = new ArrayList();
        bool perfect = false;
        int con = 1;
        while (con <= num/2)
        {
            if (num%con == 0)
            {
                array.Add(con);
            }
            con++;
        }
        int sum = 0;
        object[] ints = array.ToArray();
        foreach (int e in ints)
        {
            sum = sum + e;
        }
        if (sum == num)
        {
            perfect = true;
        }
        return perfect;
    }
    public static bool isDeficient(int num)
    {
        ArrayList array = new ArrayList();
        bool deficient = false;
        int con = 1;
        while (con <= num / 2)
        {
            if (num % con == 0)
            {
                array.Add(con);
            }
            con++;
        }
        int sum = 0;
        object[] ints = array.ToArray();
        foreach (int e in ints)
        {
            sum = sum + e;
        }
        if (sum < num)
        {
            deficient = true;
        }
        return deficient;
    }
}