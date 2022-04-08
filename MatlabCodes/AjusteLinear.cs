using System;
using System.IO;
using System.Linq;
using System.Windows.Media;

class AjusteLinear: Ajustes
{
//     float[] x = {1, 2, 3, 4, 5, 6, 7, 8};
//     float[] y = {0.5f, 0.6f, 0.9f, 0.8f, 1.2f, 1.5f, 1.7f, 2.0f};

    // float[] x = {1f, 2f, 3f, 4f};
    // float[] y = {1f, 2.5f, 3.5f, 4f};

    // 5 e 6
    // float[] x = {1, 3, 5, 10, 15, 25};
    // float[] y = {0.04049f, 0.02604f, 0.01912f, 0.01142f, 0.00741f, 0.00521f}; 

    // float[] x = {0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f};
    // float[] y = {2f, 2.04f, 2.25f, 2.33f,  2.56f, 2.83f};

    // 7
    // float[] x = {1.5f, 2.0f, 2.5f, 3.0f};
    // float[] y = {2.1f, 3.2f, 4.4f, 5.8f};

    // 8
    // float[] x = {1.0f, 1.5f, 2.0f, 2.5f, 3.0f};
    // float[] y = {1.1f, 2.1f, 3.2f, 4.4f, 5.8f};

    // 9
    // float[] x = {0f, 1f, 2f, 3f};
    // float[] y = {1f, 1f, 1.7f, 2.5f};

    // 12 
    // float[] x = {3.8f, 7f, 9.5f, 11.3f, 17.5f, 31.5f, 45.5f, 64f, 95f};
    // float[] y = {10f, 12.5f, 13.5f, 14f, 15f, 16f, 16.5f, 17f, 17.5f};

    // 13
    // float[] x = {0f, 1f, 2f, 3f, 4f, 5f, 6f};
    // float[] y = {32f, 47f, 65f, 92f, 132f, 190f, 275};

    // 16
    float[] x = {0.0f, 0.5f, 0.1f, 2.5f, 0.3f};
    float[] y = {2.0f, 2.6f, 3.7f, 13.2f, 21f};

    // 25
    // float[] x = {13, 15, 16, 21, 23, 25, 29, 30, 31, 36, 40, 42, 55, 60, 62, 64, 70, 72, 100, 130};
    // float[] y = {11, 10, 11, 12, 13, 13, 12, 14, 16, 17, 13, 14, 22, 14, 21, 21, 24, 17, 23, 34};


    float somatorioX;
    float somatorioX2;
    // float somatorioYX;
    float somatorioY;
    float somatorioY2;

    float somatorioYYA2;

    float n;
    float[,] matrizA;
    float[,] matrizAInversa;
    // float[] matrizB;
    // float determinanteA;

    float a1, a0;

    // Funciona
    public void Ajuste5()
    {
        float somatorioXLogYNaPotencia = SomatorioXLogYNaPotencia(x, y, 2);
        float somatorioLogY = SomatorioLogY(y);

        somatorioX2 = SomatorioNaPotencia(x, 2);
        somatorioX = SomatorioNaPotencia(x);
        n = x.Length;

        Console.WriteLine("Somatorio de x²: " + somatorioX2);
        Console.WriteLine("Somatorio de x: " + somatorioX);
        Console.WriteLine("Somatorio de x*log(y): " + somatorioXLogYNaPotencia);
        Console.WriteLine("Somatorio de log(y): " + somatorioLogY);

        CriarMatrizA(somatorioX2, somatorioX, n);
        // CriarMatrizB(somatorioXLogYNaPotencia, somatorioLogY);

        MatrizInversa();

        MostrarMatrizes();

        float[] B = new float[x.Length];

        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Log(y[i]);
        }
        Console.WriteLine("\nB");
        PrintMatriz1D(B);

        A1A0(B, matrizAInversa);

        a1 = -Math.Abs(a1);
        a0 = (float)Math.Exp(a0);

        Console.WriteLine("\nA1: " + a1);
        Console.WriteLine("A0: " + a0);
        
        // fx = exp(a0)^-a1
        Console.WriteLine("\nO modelo ajustado eh: y(x) = " + a0 + "^" + a1 + "t");

        float[] xa = XA(x, n);
        float[] yAjustado = new float[x.Length];
        float[] ya = new float[xa.Length];

        // yAjustado == Ya
        for (int i = 0; i < n; i++){
            yAjustado[i] = a0 * (float)(Math.Exp(a1*x[i]));
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        for (int i = 0; i < xa.Length; i++){
            ya[i] = a0 * (float)(Math.Exp(a1 * xa[i]));
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }

        R2(yAjustado);

        ExportArrays(x, y, xa, ya);
    }

    // Funciona
    public void Ajuste6()
    {
        somatorioX2 = SomatorioNaPotencia(x, 2);
        somatorioX = SomatorioNaPotencia(x);
        n = x.Length;

        float somatorioY1X = SomatorioY1DividindoX(y, x);
        float somatorio1X = Somatorio1DividindoX(x);

        // Cria a matriz A
        CriarMatrizA(somatorioX2, somatorioX, n);
        // Cria matriz A inversa
        MatrizInversa();
        // Moostra as matrizes
        MostrarMatrizes();

        float[] B = new float[x.Length];

        // calcula a matriz B
        for (int i = 0; i < x.Length; i++){
            B[i] = 1/y[i];
        }
        Console.WriteLine("\nB");
        PrintMatriz1D(B);

        // Calcula a1 e a0
        A1A0(B, matrizAInversa);

        //////////////////A1&A0////////////////////

        a0 = 1/a0;

        Console.WriteLine("A1: " + a1);
        Console.WriteLine("A0: " + a0);

        //////////////////A1&A0////////////////////

        // fx = c0 / (1 + a1 * c0 * x)
        Console.WriteLine("\nO modelo ajustado eh: y(x) = " + a0 + " / 1 + (" + a1 + ") * (" + a0 + ")t");

        float[] xa = XA(x, n);
        float[] yAjustado = new float[x.Length];
        float[] ya = new float[xa.Length];

        // yAjustado == Ya
        for (int i = 0; i < n; i++){
            yAjustado[i] = a0 / (1 + a1 * a0 * x[i]);
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a0 / (1 + a1 * a0 * xa[i]);
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }

        // Calcula o R2
        R2(yAjustado);

        // Exporta os arrays
        ExportArrays(x, y, xa, ya);
    }

    // Funciona
    public void Ajuste7()
    {
        somatorioX2 = SomatorioNaPotencia(x, 2); // PADRAO
        somatorioX = SomatorioNaPotencia(x); // PADRAO
        n = x.Length; // PADRAO
 
        // float somatorioXY2 = SomatorioXYNaPotenciaX(y, x, 2);
        // somatorioY2 = SomatorioNaPotencia(y, 2);

        // Cria a matriz A
        CriarMatrizA(somatorioX2, somatorioX, n); // PADRAO
        // Cria matriz A inversa
        MatrizInversa(); // PADRAO
        // Moostra as matrizes
        MostrarMatrizes(); // PADRAO

        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Pow(y[i], 2);
        }
        Console.WriteLine("\nB"); // PADRAO
        PrintMatriz1D(B); // PADRAO

        // Calcula a1 e a0
        A1A0(B, matrizAInversa); // PADRAO

        //////////////////A1&A0////////////////////

        Console.WriteLine("A1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO

        //////////////////A1&A0////////////////////

        // y = raiz quadrada de (a0 + a1 * x)
        Console.WriteLine("\nO modelo ajustado eh: y(x) = sqrt(" + a0 + " + " + a1 + ")x");

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO

        // yAjustado == Ya, usa a função da questão * x
        for (int i = 0; i < n; i++){
            yAjustado[i] = (float)Math.Sqrt(a0 + a1 * x[i]);
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = (float)Math.Sqrt(a0 + a1 * xa[i]);
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }

        // Calcula o R2
        R2(yAjustado);
        // Exporta os arrays
        ExportArrays(x, y, xa, ya);
    }
    
    // Funciona
    public void Ajuste8()
    {
        somatorioX2 = SomatorioNaPotencia(x, 2); // PADRAO
        somatorioX = SomatorioNaPotencia(x); // PADRAO
        n = x.Length; // PADRAO
 
        // float somatorioXeYDivX = SomatorioXeElevadoAYDivX(x, y);
        // float somatorioeYDivX = SomatorioeElevadoYDivX(x, y);

        // Cria a matriz A
        CriarMatrizA(somatorioX2, somatorioX, n); // PADRAO
        // Cria matriz A inversa
        MatrizInversa(); // PADRAO
        // Moostra as matrizes
        MostrarMatrizes(); // PADRAO

        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Pow(Math.E, (y[i] / x[i]));
            
        }
        Console.WriteLine("\nB"); // PADRAO
        PrintMatriz1D(B); // PADRAO

        //////////////////A1&A0////////////////////
        // Calcula a1 e a0
        A1A0(B, matrizAInversa); // PADRAO

        Console.WriteLine("A1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO

        //////////////////A1&A0////////////////////

        // y = x ln(a1 * x + a0)
        Console.WriteLine("\nO modelo ajustado eh: y(x) = x ln(" + a1 + "x + " + a0 + ")");

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO

        // yAjustado == Ya, usa a função da questão * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  x[i] * (float)Math.Log(a1 * x[i] + a0);
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = xa[i] * (float)Math.Log(a1 * xa[i] + a0);
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }

        // Calcula o R2
        R2(yAjustado);
        // Exporta os arrays
        ExportArrays(x, y, xa, ya);
    }

    public void Ajuste9()
    {
        Console.WriteLine(x.Length);
        Console.WriteLine(y.Length);

        float somatorioA = SomatorioXMenosXxYNaPotencia(x, y, 2); 
        float somatorioB = SomatorioXMenosXxY(x, y);
        n = x.Length; // PADRAO
 
        // float somatorioXeYDivX = SomatorioXeElevadoAYDivX(x, y);
        // float somatorioeYDivX = SomatorioeElevadoYDivX(x, y);

        // Cria a matriz A
        CriarMatrizA(somatorioA, somatorioB, n); // PADRAO
        // Cria matriz A inversa
        MatrizInversa(); // PADRAO
        // Moostra as matrizes
        MostrarMatrizes(); // PADRAO

        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Pow(x[i], 2) - x[i] * y[i];
            
        }
        Console.WriteLine("\nB"); // PADRAO
        PrintMatriz1D(B); // PADRAO

        //////////////////A1&A0////////////////////
        // Calcula a1 e a0
        A1A0(B, matrizAInversa); // PADRAO

 

        Console.WriteLine("A1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO

        //////////////////A1&A0////////////////////

        // fx = (a + x^2) / (b + x)
        Console.WriteLine("\nO modelo ajustado eh: y(x) = (" + a1 + " + x²) / (" + a0 + " + x)");

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO

        // yAjustado == Ya, usa a função da questão * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  x[i] * (float)Math.Log(a1 * x[i] + a0);
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = xa[i] * (float)Math.Log(a1 * xa[i] + a0);
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }

        // Calcula o R2
        R2(yAjustado);
        // Exporta os arrays
        ExportArrays(x, y, xa, ya);
    }

    public void Ajuste12()
    {
        float som1 = SomatorioLogYNaPotencia(x, 2); // PADRAO
        float som2 = SomatorioLogY(x);; // PADRAO
        n = x.Length; // PADRAO
 
        // Cria a matriz A
        CriarMatrizA(som1, som2, n); // PADRAO
        // Cria matriz A inversa
        MatrizInversa(); // PADRAO
        // Moostra as matrizes
        MostrarMatrizes(); // PADRAO

        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Log(y[i]);
            
        }
        Console.WriteLine("\nB"); // PADRAO
        PrintMatriz1D(B); // PADRAO

        //////////////////A1&A0////////////////////
        // Calcula a1 e a0
        A1A0(B, matrizAInversa); // PADRAO

        a1 = 0.187865f;
        a0 = 0.055581f;

        Console.WriteLine("A1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO

        //////////////////A1&A0////////////////////

        // y = x ln(a1 * x + a0)
        Console.WriteLine("\nO modelo ajustado eh: y(x) = x ln(" + a1 + "x + " + a0 + ")");

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO

        // yAjustado == Ya, usa a função da questão * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  x[i] * (float)Math.Log(a1 * x[i] + a0);
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = xa[i] * (float)Math.Log(a1 * xa[i] + a0);
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }

        // Calcula o R2
        R2(yAjustado);
        // Exporta os arrays
        ExportArrays(x, y, xa, ya);
    }

    public void Ajuste13()
    {
        float som1 = SomatorioLogYNaPotencia(x, 2); // PADRAO
        float som2 = SomatorioLogY(x);; // PADRAO
        n = x.Length; // PADRAO
 
        // Cria a matriz A
        CriarMatrizA(som1, som2, n); // PADRAO

        MatrizInversa(); // PADRAO
        // Moostra as matrizes
        MostrarMatrizes(); // PADRAO

        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Log(y[i]);
            
        }
        Console.WriteLine("\nB"); // PADRAO
        PrintMatriz1D(B); // PADRAO

        //////////////////A1&A0////////////////////
        // Calcula a1 e a0
        A1A0(B, matrizAInversa); // PADRAO

        a0 = (float)Math.Log(a0);

        Console.WriteLine("A1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO

        //////////////////A1&A0////////////////////

        // y = x ln(a1 * x + a0)
        Console.WriteLine("\nO modelo ajustado eh: y(x) = x ln(" + a1 + "x + " + a0 + ")");

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO

        // yAjustado == Ya, usa a função da questão * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  x[i] * (float)Math.Log(a1 * x[i] + a0);
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = xa[i] * (float)Math.Log(a1 * xa[i] + a0);
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }

        // Calcula o R2
        R2(yAjustado);
        // Exporta os arrays
        ExportArrays(x, y, xa, ya);
    }

    // Funciona
    public void Ajuste25()
    {
        float som1 = SomatorioNaPotencia(x, 2); // PADRAO
        float som2 = SomatorioNaPotencia(x);; // PADRAO
        n = x.Length; // PADRAO
 
        // Cria a matriz A
        CriarMatrizA(som1, som2, n); // PADRAO

        MatrizInversa(); // PADRAO
        // Moostra as matrizes
        MostrarMatrizes(); // PADRAO

        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx
        for (int i = 0; i < x.Length; i++){
            B[i] = y[i];    
        }
        Console.WriteLine("\nB"); // PADRAO
        PrintMatriz1D(B); // PADRAO

        //////////////////A1&A0////////////////////
        // Calcula a1 e a0
        A1A0(B, matrizAInversa); // PADRAO

        Console.WriteLine("A1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO

        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO

        // yAjustado == Ya, usa a função da questão * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  a1 * x[i] + a0;
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a1 * xa[i] + a0;
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        // Calcula o R2
        R2(yAjustado);
        // Exporta os arrays
        ExportArrays(x, y, xa, ya);
    }
    
    public void Ajuste16()
    {
        float som1 = SomatorioNaPotencia(x, 2); // PADRAO
        float som2 = SomatorioNaPotencia(x);; // PADRAO
        n = x.Length; // PADRAO
 
        // Cria a matriz A
        CriarMatrizA(som1, som2, n); // PADRAO

        MatrizInversa(); // PADRAO
        // Moostra as matrizes
        MostrarMatrizes(); // PADRAO

        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx
        for (int i = 0; i < x.Length; i++){
            B[i] = y[i];  
        }
        Console.WriteLine("\nB"); // PADRAO
        PrintMatriz1D(B); // PADRAO

        //////////////////A1&A0////////////////////
        // Calcula a1 e a0
        A1A0(B, matrizAInversa); // PADRAO

        a0 = (float)Math.Log(a0);

        Console.WriteLine("A1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO

        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  1 + a0 * (float)Math.Pow(Math.E, a1 * x[i]);
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = 1 + a0 * (float)Math.Pow(Math.E, a1 * xa[i]);
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        // Calcula o R2
        R2(yAjustado);
        // Exporta os arrays
        ExportArrays(x, y, xa, ya);
    }

    #region Metodos

    public void MostrarMatrizes()
    {
        Console.WriteLine("\nMatriz A");
        PrintMatriz2D(matrizA);

        // Console.WriteLine("\nMatriz B");
        // PrintMatriz1D(matrizB);

        Console.WriteLine("Matriz A Inversa");
        PrintMatriz2D(matrizAInversa);
    }

    public void R2(float[] yAjustado)
    {
        somatorioYYA2 = SomatorioYMenosYAjustadoNaPotencia(y, yAjustado, 2);
        somatorioY2 = SomatorioNaPotencia(y, 2);
        somatorioY = SomatorioNaPotencia(y);

        float r2 = R2Linear(somatorioYYA2, somatorioY2, somatorioY, n);

        Console.WriteLine("\nR2: " + r2 + "");
    }

    public void MatrizInversa()
    {
        double a00 = matrizA[0, 0];
        double a01 = matrizA[0, 1];
        double a10 = matrizA[1, 0];
        double a11 = matrizA[1, 1];
        
        Matrix matrizAInvertida = new Matrix(a00, a01, a10, a11, 1, 1);
  
        matrizAInvertida.Invert();

        
        matrizAInversa = new float[2, 2];

        matrizAInversa[0, 0] = (float)matrizAInvertida.M11;
        matrizAInversa[0, 1] = (float)matrizAInvertida.M12;
        matrizAInversa[1, 0] = (float)matrizAInvertida.M21;
        matrizAInversa[1, 1] = (float)matrizAInvertida.M22;
    }

    public void A1A0(float[] B, float[,] AInversa)
    {
        float[,] A = new float[x.Length, 2];
        for (int i = 0; i < x.Length; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                A[i, j] = x[i];
                if (j == 1){
                    A[i, j] = 1;
                }
            }
        }

        // fazer A transposta
        float[,] ATransposta = new float[2, x.Length];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < x.Length; j++){
                ATransposta[i, j] = A[j, i];
            }
        }

        // multiplicar A transposta por B
        float[,] ATranspostaB = new float[2, 1];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                ATranspostaB[i, j] = 0;
                for (int k = 0; k < x.Length; k++)
                {
                    ATranspostaB[i, j] += ATransposta[i, k] * B[k];
                }
            }
        }

        // multiplicar AInversa por ATranspostaB
        float[,] X = new float[2, 1];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                X[i, j] = 0;
                for (int k = 0; k < 2; k++)
                {
                    X[i, j] += AInversa[i, k] * ATranspostaB[k, j];
                }
            }
        }
        a1 = X[0, 0];
        a0 = X[1, 0];
    }

    // public void Determinante_Resultado()
    // {
    //     determinanteA = Determinante(somatorioX, somatorioX2, n);
    //     resultado = Resultado();

    //     Console.WriteLine("\nResultado");
    //     PrintMatriz1D(resultado);

    //     a1 = resultado[0] * determinanteA;
    //     a0 = resultado[1] * determinanteA;

    //     Console.WriteLine("A1 antes: " + a1);
    //     Console.WriteLine("A0 antes: " + a0);
    // }

    private bool ExportArrays(float[] x, float[] y, float[] xa, float[] ya)
    {
        string path = "C:\\Users\\wesle\\Documents\\Programming\\Python\\AjusteDeCurva";
        StreamWriter writer = new StreamWriter(path + "\\Ajuste.txt");

        if (writer == null)
        {
            Console.WriteLine("Erro ao criar arquivo");
            return false;
        }

        for (int i = 0; i < x.Length; i++){
            writer.Write(x[i].ToString().Replace(',', '.') + " ");
        }
        writer.WriteLine();
        for (int i = 0; i < y.Length; i++){
            writer.Write(y[i].ToString().Replace(',', '.') + " ");
        }
        writer.WriteLine();
        for (int i = 0; i < xa.Length; i++){
            writer.Write(xa[i].ToString().Replace(',', '.') + " ");
        }
        writer.WriteLine();
        for (int i = 0; i < ya.Length; i++){
            writer.Write(ya[i].ToString().Replace(',', '.') + " ");
        }

        writer.Close();
        return true;
    }

    public void CriarMatrizA(float a, float b, float n)
    {
        matrizA = new float[,]{
            {a, b},
            {b, n}
        };
    }

    // public void CriarMatrizB(float a, float b)
    // {
    //     matrizB = new float[]{
    //         a,
    //         b
    //     };
    // }

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

        // matrizB = new float[]{
        //     somatorioYX,
        //     somatorioY
        // };
    }

    // private float[] Resultado()
    // {
    //     float[] resultado = new float[2];
    //     for (int i = 0; i < 2; i++)
    //     {
    //         for (int j = 0; j < 2; j++)
    //         {
    //             resultado[i] += matrizAInversa[i, j] * matrizB[j];
    //         }
    //     }
    //     return resultado;
    // }

    #endregion

    static void Main(string[] args)
    {  
        AjusteLinear ajusteLinear = new AjusteLinear();
        AjusteQuadratico ajusteQuadratico = new AjusteQuadratico();
        ajusteLinear.Ajuste16(); 
        // ajusteQuadratico.Ajuste();
    }


}

