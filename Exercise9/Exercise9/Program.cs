Console.WriteLine("Enter a String:");
String str = Console.ReadLine();
char[] letters = str.ToCharArray();
for (int i = str.Length-1; i >= 0; i--)
{
    Console.Write(letters[i]);
}