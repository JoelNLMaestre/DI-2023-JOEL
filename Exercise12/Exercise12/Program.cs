Console.WriteLine("Enter a Hexadecimal line: ");
String hexaO = Console.ReadLine();
String hexa = hexaO.ToLower();
int[] num = new int[hexa.Length];
bool seguir = true;
for (int i = 0; i < hexa.Length; i++)
{
    if (hexa[i] is not '1' and not '2' and not '3' and not '4' and not '5' and not '5' and not '7'
        and not '8' and not '9' and not 'a' and not 'b' and not 'c' and not 'd' and not 'e' and not 'f')
    {
        Console.WriteLine("Error this line is not Hexadecimal");
        seguir = false;
        break;
    }
}
if (seguir)
{
    for (int i = 0; i <= hexa.Length - 1; i++)
    {
        char c = hexa[hexa.Length - i - 1];
        if (c >= '0' && c <= '9')
        {
            num[i] = (int)char.GetNumericValue(c);
        }
        else
        {
            switch (c)
            {
                case 'a':
                    num[i] = 10;
                    break;
                case 'b':
                    num[i] = 11;
                    break;
                case 'c':
                    num[i] = 12;
                    break;
                case 'd':
                    num[i] = 13;
                    break;
                case 'e':
                    num[i] = 14;
                    break;
                case 'f':
                    num[i] = 15;
                    break;

            }
        }
        for (int j = 0; j < i; j++)
        {
            if (i != 0)
            {
                num[i] = num[i] * 16;
            }
            else
            {
                num[i] = 1;
            }
        }
    }
    int hex = 0;
    for (int i = 0; i < num.Length; i++)
    {
        hex = hex + num[i];
    }
    Console.WriteLine("the equivalent decimal line is : " + hex);
}