using System.Collections;
using System.Text;

Console.WriteLine("Enter a word");
String str=Console.ReadLine();
String strl = str.ToLower();

for (int i = 0; i <= ((strl.Length/2)-1); i++)
{
    if (!strl[i].Equals(strl[strl.Length - 1 - i]))
    {
        Console.WriteLine(str + " is not a palindrome");
        break;
    }else if (i == ((strl.Length / 2) - 1))
    {
        Console.WriteLine(str + " is a palindrome");
    }
}


// Mod: now make it posible to introduce a phrase

Console.WriteLine("Introduce a phrase");
String phrase = Console.ReadLine();
String phraseL = phrase.ToLower();
StringBuilder sb = new StringBuilder();

for (int i = 0; i < phraseL.Length; i++)
{
    if (char.IsLetter(phraseL[i]))
    {
        sb.Append(phraseL[i]);
    }
}

for (int i = 0; i <= ((sb.Length / 2) - 1); i++)
{
    if (!phraseL[i].Equals(sb[sb.Length - 1 - i]))
    {
        Console.WriteLine(phrase + " is not a palindrome");
        break;
    }
    else if (i == ((sb.Length / 2) - 1))
    {
        Console.WriteLine(phrase + " is a palindrome");
    }
}