Console.WriteLine("Enter the radius:____m");

String rad = Console.ReadLine();
double radius = Convert.ToDouble(rad);
Console.WriteLine("The radius is "+radius+" m");
double radius3 = radius*radius*radius;
double volume = ((4/3)*Math.PI)*radius3;
Console.WriteLine("The volume is " + volume + " m^3");

double radius2 = radius*radius;
double surface = 4*Math.PI*radius2;

Console.WriteLine("The surface is " + surface + " m^2");