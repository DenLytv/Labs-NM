for (double i = 1; i >= 0.0000000000000001; i /= 10)
{
    Derivative(0, i);
}

Console.WriteLine();

for (int i = 10; i <= 10000000; i *= 10)
{
    Integral(0, 10000, i);
}

void Derivative(double x, double h)
{
    double df_dx = -0.064;
    double d2 = (Fun(x + h) - Fun(x - h)) / (2 * h);
    double d4 = (-Fun(x + 2 * h) + 8 * Fun(x + h) - 8 * Fun(x - h) + Fun(x - 2 * h)) / (12 * h);
    Console.WriteLine($"{h} {d2} {d4}");
    Console.WriteLine($"{Math.Abs((df_dx - d2) / df_dx) * 100}");
    Console.WriteLine($"{Math.Abs((df_dx - d4) / df_dx) * 100}");
    Console.WriteLine();
}

void Integral(double u, double v, int n)
{
    double s1 = 0;
    double s2 = 0;
    double h = (v - u) / n;
    double s = 2.5;

    for (int i = 1; i < n; i++)
    {
        s1 += Fun(u + i * h);
    }
    s1 = (s1 + (Fun(u) - Fun(v)) / 2) * h;

    for (int i = 1; i < n / 2; i++)
    {
        s2 += (4 * Fun(u + (2 * i - 1) * h) + 2.0 * Fun(u + (2 * i) * h));
    }
    s2 = (s2 + Fun(u) - Fun(v)) * h / 3;

    Console.WriteLine($"{n} {s1} {s2}");
    Console.WriteLine($"{Math.Abs((s - s1) / s) * 100}");
    Console.WriteLine($"{Math.Abs((s - s2) / s) * 100}");
    Console.WriteLine();
}

double Fun(double x)
{
    return 0.4 * Math.Exp(-0.16 * x);
}