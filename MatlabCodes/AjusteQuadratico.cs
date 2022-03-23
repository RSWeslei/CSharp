using System;

class AjusteQuadratico: Ajustes
{
    float[] x = {-2f, -1f, 0f, 1f, 2f, 3f};
    float[] y = {-0.1f, 0.5f, 0.8f, 0.9f, 0.8f, 0.4f};

    float somatorioX4;
    float somatorioX3;
    float somatorioX2;
    float somatorioX;

    float somatorioX2Y;
    float somatorioXY;

    float somatorioY;

    float n;

    float[,] matrizA;
    float[] matrizB;
    float[,] sistema;

    float[] resultado;

    public void Ajuste()
    {
        n = x.Length;

        somatorioX4 = SomatorioNaPotencia(x, 4);
        somatorioX3 = SomatorioNaPotencia(x, 3); 
        somatorioX2 = SomatorioNaPotencia(x, 2);
        somatorioX = SomatorioNaPotencia(x);

        somatorioX2Y = SomatorioXYNaPotenciaX(x, y, 2);
        somatorioXY = SomatorioXY(x, y);

        somatorioY = SomatorioNaPotencia(y);

        matrizA = CriarMatrizA();
        matrizB = CriarMatrizB();

        sistema = new float[,] {
            {matrizA[0, 0], matrizA[0, 1], matrizA[0, 2], matrizB[0]},
            {matrizA[1, 0], matrizA[1, 1], matrizA[1, 2], matrizB[1]},
            {matrizA[2, 0], matrizA[2, 1], matrizA[2, 2], matrizB[2]}
        };

        Gauss(sistema);

        resultado = new float[]{
            sistema[0, 3],
            sistema[1, 3],
            sistema[2, 3]
        };

        Console.WriteLine("SomatorioX4: " + somatorioX4);
        Console.WriteLine("SomatorioX3: " + somatorioX3);
        Console.WriteLine("SomatorioX2: " + somatorioX2);
        Console.WriteLine("SomatorioX: " + somatorioX);
        Console.WriteLine("SomatorioX2Y: " + somatorioX2Y);
        Console.WriteLine("SomatorioXY: " + somatorioXY);
        Console.WriteLine("SomatorioY: " + somatorioY);

        Console.WriteLine("\nMatriz A:");
        PrintMatriz2D(matrizA);

        Console.WriteLine("\nMatriz B:");
        PrintMatriz1D(matrizB);

        Console.WriteLine("\nSistema:");
        PrintMatriz2D(sistema);

        Console.WriteLine("\nResultado: ");
        PrintMatriz1D(resultado);

        Console.WriteLine("\nY = " + resultado[0] + "x² + " + resultado[1] + "x + " + resultado[2]);
    }

    public bool Gauss(float[,] M)
    {
        // input checks
        int rowCount = M.GetUpperBound(0) + 1;
        if (M == null || M.Length != rowCount * (rowCount + 1))
          throw new ArgumentException("The algorithm must be provided with a (n x n+1) matrix.");
        if (rowCount < 1)
          throw new ArgumentException("The matrix must at least have one row.");

        // pivoting
        for (int col = 0; col + 1 < rowCount; col++) if (M[col, col] == 0)
        // check for zero coefficients
        {
            // find non-zero coefficient
            int swapRow = col + 1;
            for (;swapRow < rowCount; swapRow++) if (M[swapRow, col] != 0) break;

            if (M[swapRow, col] != 0) // found a non-zero coefficient?
            {
                // yes, then swap it with the above
                float[] tmp = new float[rowCount + 1];
                for (int i = 0; i < rowCount + 1; i++)
                  { tmp[i] = M[swapRow, i]; M[swapRow, i] = M[col, i]; M[col, i] = tmp[i]; }
            }
            else return false; // no, then the matrix has no unique solution
        }

        // elimination
        for (int sourceRow = 0; sourceRow + 1 < rowCount; sourceRow++)
        {
            for (int destRow = sourceRow + 1; destRow < rowCount; destRow++)
            {
                float df = M[sourceRow, sourceRow];
                float sf = M[destRow, sourceRow];
                for (int i = 0; i < rowCount + 1; i++)
                  M[destRow, i] = M[destRow, i] * df - M[sourceRow, i] * sf;
            }
        }

        // back-insertion
        for (int row = rowCount - 1; row >= 0; row--)
        {
            float f = M[row,row];
            if (f == 0) return false;

            for (int i = 0; i < rowCount + 1; i++) M[row, i] /= f;
            for (int destRow = 0; destRow < row; destRow++)
              { M[destRow, rowCount] -= M[destRow, row] * M[row, rowCount]; M[destRow, row] = 0; }
        }
        return true;
    }

    private float[,] CriarMatrizA()
    {
        float[,] matriz = new float[,]{
            {somatorioX4, somatorioX3, somatorioX2},
            {somatorioX3, somatorioX2, somatorioX},
            {somatorioX2, somatorioX, n}
        };
        return matriz;
    }

    private float[] CriarMatrizB()
    {
        float[] matriz = new float[]{
            somatorioX2Y, somatorioXY, somatorioY
        };
        return matriz;
    }
}