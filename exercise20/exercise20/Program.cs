public class exercise20
{
    static void Main()
    {
        String[] str = { "testing", "water", "keyboard", "smartphone", "food" };
        int num = GetRandom(1,5);
        String ans = str[num];
        int con = 0;
        Console.WriteLine("Key in one character or your guess word: ");
        String guess = Console.ReadLine();
        char[] p = new char[ans.Length];
        for(int i = 0; i < ans.Length; i++)
        {
            p[i]='_';
        }
        while (!ans.Equals(guess))
        {
            if (ans.Contains(guess[0]))
            {
                for(int i = 0; i < ans.Length; i++)
                {
                    if (ans[i] == guess[0])
                    {
                        p[i] = (char) ans[i];
                    }
                }
            }
            con++;
            Console.Write("Trail "+con+": ");
            for(int i = 0;i < p.Length;i++) { Console.Write(p[i]); }
            Console.WriteLine("");
            Console.WriteLine("Key in one character or your guess word: ");
            guess = Console.ReadLine();
        }
        Console.WriteLine("Congratulations!");
        Console.WriteLine("You got it in " + con + " trials");
    }
    public static int GetRandom(int min, int max)
    {
        System.Random r = new System.Random();
        return r.Next(min, max);
    }
}