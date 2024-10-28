double a = 0.045;
for (int m = 100; m < 10000; m += 100)
{
    Summa(a, m);
}

void Summa(double a, int n)
{
    double s = 0;
    double Na = 0;
    for (int i = 0; i < n; i++)
    {
        s += a;
    }
    Console.WriteLine($"{n} {s}");
    Na = n * a;
    Console.WriteLine(Na);
    Console.WriteLine(Math.Abs(Na - s));
    Console.WriteLine(Math.Abs(Na - s) / Na * 100);
    Console.WriteLine();
}