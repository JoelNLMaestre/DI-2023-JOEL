public class execise22
{
    public static void Main() {
        Console.WriteLine("Give me the number a, ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Give me the number b, please remember that a must be greater than b");
        int b = int.Parse(Console.ReadLine());
        while (a<b) {
            Console.WriteLine("please remember that a must be greater than b, introduce b again");
            b = int.Parse(Console.ReadLine());
        }
        int div = GCD(a,b);
        Console.WriteLine("the greatest factor that divides both a and b is: " + div);
    }
    public static int GCD(int a, int b)
    {
        int ans = 0;
        if(b == 0)
        {
            ans = a;
        }
        else
        {
            ans = GCD(b, (a % b));
        }
        return ans;
    }
}