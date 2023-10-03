// See https://aka.ms/new-console-template for more information\
using Hello;
try
{
    Calculate cal = new Calculate();
    int a1 = 3, b1 = 4;
    Console.WriteLine($"Result of {a1} + {b1}");
    int c = cal.Add(ref a1 , ref b1);
    Console.WriteLine($"Result of {a1} + {b1} = {c}");
    Console.WriteLine($"Result of {a1} = {cal.Sub(a1)}");
    int d = cal.Sub(b: 4, a: 10);
    Console.WriteLine($"Result = {d}");
}
catch(OverflowException e)
{
    Console.WriteLine(e.Message);
}

