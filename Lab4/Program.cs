double[][] A = new double[][]
{
     new double[] {1, 1, 1, 1, 1},
     new double[] {0, 2.1, -0.8, -0.6, -0.8},
     new double[] {-1, -0.3, 1.4, -0.5, -0.5},
     new double[] {-0.9, -0.6, -0.3, 2, -0.7},
     new double[] {-0.8, -0.8, 0, -0.1, 2.2}
};



double[] B = { 8, -0.16, -1.44, -0.8, 0.8 };
double[] X0 = new double[5];
double delta = 1e-10;

Gauss(A, B);
GaussSeidel(A, B, X0, delta);

void Gauss(double[][] AA, double[] BB)
{
    int n = BB.Length;
    double[][] A = new double[n][];
    double[] B = new double[n];

    for (int i = 0; i < n; i++)
    {
        A[i] = new double[n];
        Array.Copy(AA[i], A[i], n);
    }
    Array.Copy(BB, B, n);

    for (int k = 0; k < n - 1; k++)
    {
        double value = 0;
        int index = 0;
        for (int i = k; i < n; i++)
        {
            if (Math.Abs(A[i][k]) > value)
            {
                value = Math.Abs(A[i][k]);
                index = i;
            }
        }

        var tempRow = A[k];
        A[k] = A[index];
        A[index] = tempRow;

        double tempValue = B[k];
        B[k] = B[index];
        B[index] = tempValue;

        if (A[k][k] == 0)
        {
            Console.WriteLine("Error: A[k][k] == 0");
            return;
        }

        for (int i = k + 1; i < n; i++)
        {
            double m = A[i][k] / A[k][k];
            for (int j = k; j < n; j++)
            {
                A[i][j] -= A[k][j] * m;
            }
            B[i] -= B[k] * m;
        }
    }

    double[] X = new double[n];
    X[n - 1] = B[n - 1] / A[n - 1][n - 1];
    for (int i = n - 2; i >= 0; i--)
    {
        X[i] = B[i];
        for (int j = i + 1; j < n; j++)
        {
            X[i] -= A[i][j] * X[j];
        }
        X[i] /= A[i][i];
    }

    Console.WriteLine("[{0}]", string.Join(", ", X));
}

void GaussSeidel(double[][] A, double[] B, double[] X0, double delta)
{
    int dimension = X0.Length;
    double[] X = new double[dimension];
    Array.Copy(X0, X, dimension);

    Console.WriteLine(0 + " [" + string.Join(", ", X) + "]");

    for (int k = 1; k <= 40; k++)
    {
        for (int i = 0; i < dimension; i++)
        {
            X[i] = B[i];
            for (int j = 0; j < dimension; j++)
            {
                if (i != j)
                {
                    X[i] -= A[i][j] * X[j];
                }
            }
            X[i] /= A[i][i];
        }

        double epsMax = 0;
        double ksiMax = 0;
        for (int i = 0; i < dimension; i++)
        {
            double eps = Math.Abs(X[i] - X0[i]);
            double ksi = eps / (Math.Abs(X[i]) + delta);

            if (epsMax < eps) epsMax = eps;
            if (ksiMax < ksi) ksiMax = ksi;
        }

        Console.WriteLine(k + " [" + string.Join(", ", X) + "]");

        Array.Copy(X, X0, dimension);

        if (epsMax < delta && ksiMax < delta)
        {
            break;
        }
    }
}