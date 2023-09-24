Console.WriteLine("Introduce the upperbound");
int upperbound = int.Parse(Console.ReadLine());
int sum = 0;
double avg;
Console.WriteLine("For loop: ");
for (int i = 0; i <= upperbound; i++)
{
    sum = sum + i;
}
avg = sum / upperbound;

Console.WriteLine("Total sum:" + sum);
Console.WriteLine("Average: " + avg);

int sum1 = 0;
int aux = 0;
double avg1;
Console.WriteLine("while-do loop: ");
while (aux <= upperbound)
{
    sum1 = sum1 + aux;
    aux++;
}
avg1 = sum1 / upperbound;

Console.WriteLine("Total sum:" + sum1);
Console.WriteLine("Average: " + avg1);

int sum2 = 0;
int aux1 = 0;
double avg2;
Console.WriteLine("do-while loop: ");
do
{
    sum2 = sum2 + aux1;
    aux1++;
} while (aux1 <= upperbound);
avg2 = sum2 / upperbound;
Console.WriteLine("Total sum:" + sum2);
Console.WriteLine("Average: " + avg2);

int sum3 = 0;
int aux2 = 0;
double avg3;
Console.WriteLine("odd number between 1 to 100");
do
{
    if (aux2 % 2 != 0)
    {
        sum3 = sum3 + aux2;
    }
    aux2++;
} while (aux2 <= 100);
avg3 = sum3 / 100;
Console.WriteLine("Total sum: " + sum3);
Console.WriteLine("Average: " + avg2);

int sumatotal = 0;
int cont = 0;
for (int i = 0; i <= 100; i++)
{
    if (i % 7 == 0)
    {
        sumatotal = i + sumatotal;
        cont++;
    }
}

Console.WriteLine("Total sum: " + sumatotal);
int avgsumtotal = sumatotal / cont;
Console.WriteLine("average: " + avgsumtotal);

int sumatotal2 = 0;
for (int i = 0; i <= 100; i++)
{
    sumatotal2 = (i * i) + sumatotal2;
}

Console.WriteLine("Total sum: " + sumatotal2);