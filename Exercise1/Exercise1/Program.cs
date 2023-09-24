// See https://aka.ms/new-console-template for more information
Console.WriteLine("Exercise 1");
Console.WriteLine("Introduce the mark");
int mark;
mark = Console.Read();
if (mark < 50)
{
    Console.WriteLine("FAIL");
}
else
{
    Console.WriteLine("PASS");
}