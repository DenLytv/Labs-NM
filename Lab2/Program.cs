Func<double, double> lagrange1 = x => 0.8 * x - 0.18;
Func<double, double> lagrange2 = x => 20 * Math.Pow(x, 2) - 8 * x + 0.8;
Func<double, double> lagrange3 = x => -40 * Math.Pow(x, 3) + 60 * Math.Pow(x, 2) - 18 * x + 0.4;
Func<double, double> lagrange4 = x => 1566.66667 * Math.Pow(x, 4) - 1620 * Math.Pow(x, 3) + 504.33333 * Math.Pow(x, 2) - 39.8 * x + 0.4;

double xmin = 0.0, xmax = 0.5;
int points = 50;
double h = (xmax - xmin) / points;
double x, y1, y2, y3, y4;
for (int i = 0; i < points + 1; i++)
{
    x = xmin + i * h;
    y1 = lagrange1(x);
    y2 = lagrange2(x);
    y3 = lagrange3(x);
    y4 = lagrange4(x);
    Console.WriteLine($"{x} {y1} {y2} {y3} {y4}");
}