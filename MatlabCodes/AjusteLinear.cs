using System;
using System.IO;
using System.Linq;

class AjusteLinear: Ajustes
{
//     float[] x = {1, 2, 3, 4, 5, 6, 7, 8};
//     float[] y = {0.5f, 0.6f, 0.9f, 0.8f, 1.2f, 1.5f, 1.7f, 2.0f};

    // float[] x = {1f, 2f, 3f, 4f};
    // float[] y = {1f, 2.5f, 3.5f, 4f};

    // 5E
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
    
    float somatorioXLogYNaPotencia;
    float somatorioLogY;

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

        float r2 = R2Linear(somatorioYYA2, somatorioY2, somatorioY, n);
        
        Console.WriteLine("\nR2: " + r2);


        Console.WriteLine("\nO modelo ajustado eh: y(x) = " + a1 + "x + " + a0 + "\n\n");
    }

    public void Ajuste5()
    {
        somatorioX2 = SomatorioNaPotencia(x, 2);
        somatorioX = SomatorioNaPotencia(x);
        somatorioXLogYNaPotencia = SomatorioXLogYNaPotencia(x, y, 2);
        somatorioLogY = SomatorioLogY(y);
        n = x.Length;

        Console.WriteLine("Somatorio de x²: " + somatorioX2);
        Console.WriteLine("Somatorio de x: " + somatorioX);
        Console.WriteLine("Somatorio de x*log(y): " + somatorioXLogYNaPotencia);
        Console.WriteLine("Somatorio de log(y): " + somatorioLogY);

        CriarMatrizAEInversa(somatorioX2, somatorioX, n);
        CriarMatrizB(somatorioXLogYNaPotencia, somatorioLogY);

        Console.WriteLine("\nMatriz A");
        PrintMatriz2D(matrizA);

        Console.WriteLine("\nMatriz A Inversa");
        PrintMatriz2D(matrizAInversa);

        Console.WriteLine("\nMatriz B");
        PrintMatriz1D(matrizB);

        determinanteA = Determinante(somatorioX, somatorioX2, n);
        resultado = Resultado();

        Console.WriteLine("\nResultado");
        PrintMatriz1D(resultado);

        a1 = resultado[0] * determinanteA;
        a0 = resultado[1] * determinanteA;

        Console.WriteLine("\nA1Antes: " + a1);
        Console.WriteLine("A0Antes: " + a0);

        a0 = (float)Math.Exp(a0);

        Console.WriteLine("\nA1: " + a1);
        Console.WriteLine("A0: " + a0);

        Console.WriteLine("\nDeterminante de A: " + determinanteA);
        

        // fx = exp(a0)^-a1
        Console.WriteLine("\nO modelo ajustado eh: y(x) = " + a0 + "^" + a1 + "");

        float[] yAjustado = new float[x.Length];

        for (int i = 0; i < n; i++){
            yAjustado[i] = a0 * (float)(Math.Exp(a1*x[i]));
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        somatorioYYA2 = SomatorioYMenosYAjustadoNaPotencia(y, yAjustado, 2);
        somatorioY2 = SomatorioNaPotencia(y, 2);
        somatorioY = SomatorioNaPotencia(y);

        // Console.WriteLine("\nSomatorio Y - Y Ajustado²: " + somatorioYYA2);
        // Console.WriteLine("Somatorio Y²: " + somatorioY2);
        float r2 = R2Linear(somatorioYYA2, somatorioY2, somatorioY, n);

        Console.WriteLine("\nR2: " + r2 + "\n");

        float[] xa = XA(x, n);

        ExportArrays(x, y, xa, yAjustado);

        // // print y
        // Console.WriteLine("\nY");
        // PrintMatriz1D(y);

        // // print yAjustado
        // Console.WriteLine("\nY Ajustado");
        // PrintMatriz1D(yAjustado);

    }

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
            writer.Write(x[i].ToString() + " ");
        }
        writer.WriteLine();
        for (int i = 0; i < y.Length; i++){
            writer.Write(y[i].ToString() + " ");
        }
        writer.WriteLine();
        for (int i = 0; i < xa.Length; i++){
            writer.Write(xa[i].ToString() + " ");
        }
        writer.WriteLine();
        for (int i = 0; i < ya.Length; i++){
            writer.Write(ya[i].ToString() + " ");
        }


        writer.Close();
        return true;
    }

    public void CriarMatrizAEInversa(float a, float b, float n)
    {
        matrizA = new float[,]{
            {a, b},
            {b, n}
        };

        matrizAInversa = new float[,]{
            {n, -b},
            {-b, a}
        };
    }

    public void CriarMatrizB(float a, float b)
    {
        matrizB = new float[]{
            a,
            b
        };
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
        ajusteLinear.Ajuste5(); 
        // ajusteQuadratico.Ajuste();
    }


}

