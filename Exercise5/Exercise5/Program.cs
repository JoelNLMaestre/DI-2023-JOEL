double pi = 1;
double aux = -3;
while(aux<10000)
{
    pi = pi + ((1 / aux));
    if (aux < 0)
    {
        aux = ((aux)*(-1))+2;
    }
    else
    {
        aux = (aux + 2) * (-1);
    }
}
pi = pi * 4;
Console.WriteLine(pi);