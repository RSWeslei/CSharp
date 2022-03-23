using System;

class AjusteLinear: Ajustes
{
    // float[] x = {1, 2, 3, 4, 5, 6, 7, 8};
    // float[] y = {0.5f, 0.6f, 0.9f, 0.8f, 1.2f, 1.5f, 1.7f, 2.0f};

    float[] x = {1f, 2f, 3f, 4f};
    float[] y = {1f, 2.5f, 3.5f, 4f};

    // 5E
    // float[] x = {1, 3, 5, 10, 15, 25};
    // float[] y = {4.049f * 0.01f, 2.604f * 0.01f, 1.912f * 0.01f, 1.142f * 0.01f, 0.741f * 0.01f, 0.521f * 0.01f}; 

    // float[] x = {0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f};
    // float[] y = {2f, 2.04f, 2.25f, 2.33f,  2.56f, 2.83f};

    // 7
    // float[] x = {1.5f, 2.0f, 2.5f, 3.0f};
    // float[] y = {2.1f, 3.2f, 4.4f, 5.8f};


    float somatorioX;
    float somatorioX2;
    float somatorioYX;
    float somatorioY;
    float somatorioY2;

    float somatorioYYA2;

    float n;
    float[,] matrizA;
    float[,] matrizAInversa;
    float[] matrizB;
    float determinanteA;
    float[] resultado;

    float a1, a0;

    public void Ajuste()
    { 
        n = x.Length;

        somatorioX = SomatorioNaPotencia(x);
        somatorioX2 = SomatorioNaPotencia(x, 2);

        somatorioY = SomatorioNaPotencia(y);
        somatorioY2 = SomatorioNaPotencia(y, 2);
        somatorioYX = SomatorioXY(y, x);

        CriarMatrizes();

        determinanteA = Determinante(somatorioX, somatorioX2, n);

        resultado = Resultado();

        a1 = resultado[0] * determinanteA;
        a0 = resultado[1] * determinanteA;

        // Debugs
        Console.WriteLine("Somatorio de x²: " + somatorioX2);
        Console.WriteLine("Somatorio de x: " + somatorioX);
        Console.WriteLine("Somatorio de y: " + somatorioY);
        Console.WriteLine("Somatorio de y²: " + somatorioY2);
        Console.WriteLine("Somatorio de x*y: " + somatorioYX);
        Console.WriteLine("Determinante de A: " + determinanteA);
        Console.WriteLine("N: " + n);
        
        Console.WriteLine("\nMatriz A");
        PrintMatriz2D(matrizA);

        Console.WriteLine("\nMatriz A Inversa");
        PrintMatriz2D(matrizAInversa);

        Console.WriteLine("\nMatriz B");
        PrintMatriz1D(matrizB);

        Console.WriteLine("\nResultado");
        PrintMatriz1D(resultado);

        Console.WriteLine("\nA1: " + a1);
        Console.WriteLine("A0: " + a0);

        //---------------------------------R2---------------------------------
        float[] yAjustado = YAjustadoLinear(x, a0);
        Console.WriteLine("\nY Ajustado");
        PrintMatriz1D(yAjustado);

        somatorioYYA2 = SomatorioYMenosYAjustadoNaPotencia(y, yAjustado, 2);
        Console.WriteLine("\nSomatorio Y - Y Ajustado²: " + somatorioYYA2);

        float r2 = R2(somatorioYYA2, somatorioY2, somatorioY, n);
        Console.WriteLine("\nR2: " + r2);


        Console.WriteLine("\nO modelo ajustado eh: y(x) = " + a1 + "x + " + a0 + "\n\n");
    }

    private void CriarMatrizes()
    {
        matrizA = new float[,]{
            {somatorioX2, somatorioX},
            {somatorioX, n}
        };

        matrizAInversa = new float[,]{
            {n, -somatorioX},
            {-somatorioX, somatorioX2}
        };

        matrizB = new float[]{
            somatorioYX,
            somatorioY
        };
    }

    private float[] Resultado()
    {
        float[] resultado = new float[2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                resultado[i] += matrizAInversa[i, j] * matrizB[j];
            }
        }
        return resultado;
    }

    static void Main(string[] args)
    {  
        AjusteLinear ajusteLinear = new AjusteLinear();
        AjusteQuadratico ajusteQuadratico = new AjusteQuadratico();
        // ajusteLinear.Ajuste(); 
        ajusteQuadratico.Ajuste();
    }


}

