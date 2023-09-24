int aux1=1,aux2=1,aux3=2;
int next = 0;
int cont = 3;
Console.Write(aux1+" "+aux2+" "+aux3);
while (cont<20)
{
    next = aux1 + aux2 + aux3;
    Console.Write(" "+next);
    aux1 = aux2;
    aux2 = aux3;
    aux3 = next;
    cont++;
}