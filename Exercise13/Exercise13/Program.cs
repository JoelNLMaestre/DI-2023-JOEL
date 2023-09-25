Console.WriteLine("Enter the number of students: ");
String numstu = Console.ReadLine();
int students = int.Parse(numstu);
float[] scores = new float[students];
int cont = 0;
while (cont < students)
{
    Console.WriteLine("Enter the score of the student " + (cont + 1) + " : ");
    scores[cont] = float.Parse(Console.ReadLine());
    while (scores[cont] < 0 || scores[cont] > 100 || scores[cont] == null)
    {
        Console.WriteLine("Invalid score, please try again...");
        scores[cont] = 0;
        Console.WriteLine("Enter the score of the student " + (cont + 1) + " : ");
        scores[cont] = float.Parse(Console.ReadLine());
    }
    cont++;
}
float sum = 0;
for (int i = 0; i < scores.Length; i++)
{
    sum += scores[i];
}
float avg = sum/students;
Console.WriteLine("Average score is: " + avg);