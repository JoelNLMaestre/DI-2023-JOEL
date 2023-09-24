int mult = 0;
for (int i = 1; i<=9; i++) {
    Console.WriteLine("");
    for (int j = 1; j <= 9; j++)
    {
        mult = i * j;
        Console.Write(mult);
        Console.Write(" ");
    }
}