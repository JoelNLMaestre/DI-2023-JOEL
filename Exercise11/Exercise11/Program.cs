Console.WriteLine("Enter a Binary String");
String binary = Console.ReadLine();
int dec = 0;
int[] num = new int[binary.Length];
for (int i = 1; i <= binary.Length; i++)
{
    for (int j = 0; j < i; j++)
    {
        if (binary[binary.Length-i] == '1' && j != 0)
        {
            dec = dec * 2;

        }else if (binary[binary.Length - i] == '1')
        {
            dec = 1;
        }
    }
    num[i-1] = dec;
    dec = 0;
}
int decF = 0;
for (int i = 0; i < num.Length; i++)
{
    decF = decF + num[i];
}
Console.WriteLine("The equivalent decimla number for binary: " + binary + " is: " + decF);