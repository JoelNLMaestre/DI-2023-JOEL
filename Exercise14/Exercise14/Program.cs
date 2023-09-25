Console.WriteLine("Enter a Hexadecimal line: ");
String hexa = Console.ReadLine();
String hexal = hexa.ToLower();
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
    for (int i = 0; i < hexal.Length; i++)
    {
        char c = hexal[i];
        switch (c)
        {
            case '1':
                Console.Write("0001 ");
                break;
            case '2':
                Console.Write("0010 ");
                break;
            case '3':
                Console.Write("0011 ");
                break;
            case '4':
                Console.Write("0010 ");
                break;
            case '5':
                Console.Write("0011 ");
                break;
            case '6':
                Console.Write("0110 ");
                break;
            case '7':
                Console.Write("0111 ");
                break;
            case '8':
                Console.Write("1000 ");
                break;
            case '9':
                Console.Write("1001 ");
                break;
            case 'a':
                Console.Write("1010 ");
                break;
            case 'b':
                Console.Write("1011 ");
                break;
            case 'c':
                Console.Write("1100 ");
                break;
            case 'd':
                Console.Write("1101 ");
                break;
            case 'e':
                Console.Write("1110 ");
                break;
            case 'f':
                Console.Write("1111 ");
                break;
        }
    }

}