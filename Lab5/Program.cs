Bisection(0, 0.35, 1e-10);
Console.WriteLine();
Newton(0, 1e-10);

double Fun(double x)
{
    return x * x + 0.54 * x - 0.112;
}
double DFun(double x)
{
    return 2 * x + 0.54;
}

void Bisection(double a, double b, double delta)
{
    double fa = Fun(a);
    int signa = Math.Sign(fa);
    double fb = Fun(b);
    int signb = Math.Sign(fb);
    double eps0 = 0;

    for (int i = 0; i < 60; i++)
    {
        double c = (a + b) / 2;
        double fc = Fun(c);
        int signc = Math.Sign(fc);
        double eps = Math.Abs(a - b);

        Console.WriteLine($"{i} {a} {signa} {b} {signb} {c} {signc}");

        if (eps < delta)
            break;

        if (signb * signc > 0)
        {
            b = c;
            signb = signc;
        }
        else
        {
            a = c;
            signa = signc;
        }

        eps0 = eps;
    }
}

void Newton(double x, double delta)
{
    double eps0 = 0;

    Console.WriteLine($"0 {x}");

    for (int i = 1; i < 20; i++)
    {
        double f = Fun(x);
        double df = DFun(x);
        double x1 = x - f / df;
        double eps = Math.Abs(x1 - x);
        double ksi = 2 * eps / (Math.Abs(x1) + delta);

        Console.WriteLine($"{i} {f} {df} {x1}");

        if (eps < delta || ksi < delta)
            break;

        eps0 = eps;
        x = x1;
    }
}