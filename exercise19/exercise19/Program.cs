public class exercise19
{
    static void Main()
    {
        int num = GetRandom(0,99);
        Console.WriteLine("Key in your guess:");
        String ans = Console.ReadLine();
        int con = 0;
        while(int.Parse(ans) != num) {
            if (int.Parse(ans) < num)
            {
                Console.WriteLine("Try Higher");
            }
            if(int.Parse(ans) > num)
            {
                Console.WriteLine("Try Lower");
            }
            con++;
            ans = Console.ReadLine();
        }
        Console.WriteLine("You got it in " + con + " trials!");
    }
    public static int GetRandom(int min, int max)
    {
        System.Random r = new System.Random();
        return r.Next(min, max);
    }
}