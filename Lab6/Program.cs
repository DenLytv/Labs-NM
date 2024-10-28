Console.WriteLine("Euler Method:");
Euler(0.16, 0, 1, 20);

Console.WriteLine("\nHeun Method:");
Heun(0.16, 0, 1, 20);

Console.WriteLine("\nRunge-Kutta 4th Order Method:");
RungeKutta4(0.16, 0, 1, 20);


double Fun(double x, double y)
{
    return -0.7 * y;
}


void Euler(double y0, double x0, double x1, int n)
{
    double y1 = y0;
    double x = x0;
    double h = (x1 - x0) / n;
    double y = 0;
    Console.WriteLine($"0 {y1} {x}");

    for (int i = 1; i <= n; i++)
    {
        double k1 = Fun(x, y1);
        y1 = y1 + k1 * h;
        x = x + h;
        Console.WriteLine($"{i} {k1} {y1} {x}");

        y = 0.16 * Math.Exp(-0.7 * x);
        Console.WriteLine(y);
        Console.WriteLine(Math.Abs(y - y1));
    }
}

void Heun(double y0, double x0, double x1, int n)
{
    double y2 = y0;
    double x = x0;
    double h = (x1 - x0) / n;
    double y = 0;
    Console.WriteLine($"0 {y2} {x}");

    for (int i = 1; i <= n; i++)
    {
        double k1 = Fun(x, y2);
        double k2 = Fun(x + h, y2 + h * k1);
        y2 = y2 + (k1 + k2) * h / 2;
        x = x + h;
        Console.WriteLine($"{i} {k1} {k2} {y2} {x}");

        y = 0.16 * Math.Exp(-0.7 * x);
        Console.WriteLine(y);
        Console.WriteLine(Math.Abs(y-y2));
    }
}

void RungeKutta4(double y0, double x0, double x1, int n)
{
    double y4 = y0;
    double x = x0;
    double h = (x1 - x0) / n;
    double y = 0;
    Console.WriteLine($"0 {y4} {x}");

    for (int i = 1; i <= n; i++)
    {
        double k1 = Fun(x, y4);
        double k2 = Fun(x + h / 2, y4 + k1 * h / 2);
        double k3 = Fun(x + h / 2, y4 + k2 * h / 2);
        double k4 = Fun(x + h, y4 + k3 * h);
        y4 = y4 + (k1 + 2 * k2 + 2 * k3 + k4) * h / 6;
        x = x + h;
        Console.WriteLine($"{i} {k1} {k2} {k3} {k4} {y4} {x}");

        y = 0.16 * Math.Exp(-0.7 * x);
        Console.WriteLine(y);
        Console.WriteLine(Math.Abs(y-y4));
    }
}