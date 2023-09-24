double n = 50000.00;

double sum = 0;
for (double i = 1.00; i < n; i++)
{
    sum = sum + (1/i);
}

Console.WriteLine("from left-to-right "+sum);

double sum2 = 0;
for (double i = n; i > 0; i--)
{
    sum2 = sum2 + (1/i);
}

Console.WriteLine("from right-to-left " + sum2);

double sub = sum - sum2;
Console.WriteLine("difference: "+sub);