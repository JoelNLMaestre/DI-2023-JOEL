using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] votos = repatirVotos(4127969,37);
        for(int i= 0; i < votos.Length; i++)
        {
            Console.WriteLine("sillas partido "+i+" "+votos[i]);
        }
    }
    public static int[] repatirVotos(int votos, int sillas)
    {
        int[] ans = {0,0,0,0,0,0,0,0,0,0};
        double[] votosperc = { 35.25, 24.75, 15.75, 14.25, 3.75, 3.25, 1.5, 0.5, 0.25, 0.25, 0.50 };
        double[] votosXpartido = new double[votosperc.Length];
        double umbral = votos * 0.03;
        int count = 0;
        for (int i = 0; i < votosperc.Length; i++)
        {
            if (votosperc[i] > 3.00)
            {
                count++;
            }
            votosXpartido[i] = votosperc[i] / 100 * votos;
        }
        double[,] divisiones = new double[count, sillas];
        List<double> numvotos = new List<double>();
        for (int i = 0; i < ((sillas / 2) + 1); i++)
        {
            for (int j = 0; j < count; j++)
            {
                divisiones[j, i] = votosXpartido[j] / (i + 2);
                numvotos.Add(votosXpartido[j] / (i + 2));
            }
        }
        for (int i = 0; i < 37;i++)
        {
            double maximo = numvotos.Max();
            
            for (int j = 0;j < ((sillas / 2) + 1); j++)
            {
                for (int k = 0; k < count; k++)
                {
                    if (divisiones[k,j] == maximo)
                    {
                        numvotos.Remove(maximo);
                        ans[k]++;
                    }
                    
                }
            }
        }
        return ans;
    }
}