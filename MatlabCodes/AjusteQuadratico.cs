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




        Console.WriteLine("SomatorioX4: " + somatorioX4);
        Console.WriteLine("SomatorioX3: " + somatorioX3);
        Console.WriteLine("SomatorioX2: " + somatorioX2);
        Console.WriteLine("SomatorioX: " + somatorioX);
        Console.WriteLine("SomatorioX2Y: " + somatorioX2Y);
        Console.WriteLine("SomatorioXY: " + somatorioXY);
        Console.WriteLine("SomatorioY: " + somatorioY);

        Console.WriteLine("\nMatriz A: ");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrizA[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nMatriz B: ");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(matrizB[i] + "\n");
        }
    }

    private void Gauss()
    {

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