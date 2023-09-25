using System.Runtime.Intrinsics.X86;

public class Scores { 
    static void Main()
    {
        Console.WriteLine("Enter the number of students: ");
        String numstu = Console.ReadLine();
        int students = int.Parse(numstu);
        double[] scores = new double[students];
        int cont = 0;
        while (cont < students)
        {
            Console.WriteLine("Enter the score of the student " + (cont + 1) + " : ");
            scores[cont] = double.Parse(Console.ReadLine());
            while (scores[cont] < 0 || scores[cont] > 100 || scores[cont] == null)
            {
                Console.WriteLine("Invalid score, please try again...");
                scores[cont] = 0;
                Console.WriteLine("Enter the score of the student " + (cont + 1) + " : ");
                scores[cont] = double.Parse(Console.ReadLine());
            }
            cont++;
        }
        Console.WriteLine("Average score is: " + Average(scores));
        Console.WriteLine("the Minimum score is: " + Min(scores));
        Console.WriteLine("the Maximum score is: " + Max(scores));
        Console.WriteLine("the Standart deviation is: " + StandartDev(scores));

    }
    public static double Average(double[] scores)
    {
        double sum = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            sum += scores[i];
        }
        double avg = sum / scores.Length;
        return avg;

    }
    public static double Min(double[] scores)
    {
        double min = scores[0];
        for (int i = 0; i < scores.Length; i++)
        {
            if (min > scores[i])
            {
                min = scores[i];
            }
        }
        return min;

    }
    public static double Max(double[] scores) 
    {
        double max = scores[0];
        for (int i = 0; i < scores.Length; i++)
        {
            if (max < scores[i])
            {
                max = scores[i];
            }
        }
        return max;
    }
    public static double StandartDev(double[] scores)
    {
        double mean = Average(scores); ;
        double sum = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            sum = (Math.Pow(scores[i],2))-(Math.Pow(mean,2));
        }
        sum = Math.Sqrt(sum/scores.Length);
        return sum;
    }
}