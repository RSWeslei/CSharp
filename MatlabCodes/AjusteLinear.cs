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
    float[] x = {1, 3, 5, 10, 15, 25};
    float[] y = {0.04049f, 0.02604f, 0.01912f, 0.01142f, 0.00741f, 0.00521f}; 

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
    // float[] matrizB;
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

        // Console.WriteLine("\nMatriz B");
        // PrintMatriz1D(matrizB);

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

        float r2 = R2Linear(somatorioYYA2, somatorioY2, somatorioY, n);
        
        Console.WriteLine("\nR2: " + r2);


        Console.WriteLine("\nO modelo ajustado eh: y(x) = " + a1 + "x + " + a0 + "\n\n");
    }

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
            Console.WriteLine("ya[" + i + "] = " + ya[i]);
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
        Matrix matrizAInvertida = new Matrix(matrizA[0, 0], matrizA[0, 1], matrizA[1, 0], matrizA[1, 1], 1, 1);
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
        ajusteLinear.Ajuste5(); 
        // ajusteQuadratico.Ajuste();
    }


}

