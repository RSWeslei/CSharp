using System;
using System.IO;
using System.Windows.Media;

class AjusteLinear: Ajustes
{
    // float[] x = {1, 2, 3, 4, 5, 6, 7, 8};
    // float[] y = {0.5f, 0.6f, 0.9f, 0.8f, 1.2f, 1.5f, 1.7f, 2.0f};

    // float[] x = {1f, 2f, 3f, 4f};
    // float[] y = {1f, 2.5f, 3.5f, 4f};

    // 5 e 6
    // float[] x = {1, 3, 5, 10, 15, 25};
    // float[] y = {0.04049f, 0.02604f, 0.01912f, 0.01142f, 0.00741f, 0.00521f}; 

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

    // 14
    // float[] x = {0f, 2f, 4f, 6f, 8f, 10f, 12f};
    // float[] y = {1f, 0.79f, 0.63f, 0.5f, 0.4f, 0.32f, 0.25f};

    // 16
    // float[] x = {0.0f, 0.5f, 1f, 2.5f, 3f};
    // float[] y = {2.0f, 2.6f, 3.7f, 13.2f, 21f};

    // 17
    // float[] x = {0f, 0.5f, 1.0f, 1.5f, 2.0f, 2.5f};
    // float[] y = {5.02f, 5.21f, 6.49f, 9.54f, 16.02f, 24.53f};

    // 22
    // float[] x = {0.1f, 0.3f, 0.5f, 0.5f, 0.7f, 0.8f, 0.8f, 1.10f, 1.30f, 1.80f};
    // float[] y = {0.833f, 0.625f, 0.500f, 0.510f, 0.416f, 0.384f, 0.395f, 0.312f, 0.277f, 0.217f};

    // 24
    // float[] x = {1.0f, 1.2f, 1.4f, 1.6f, 1.8f, 2.0f, 2.2f, 2.4f, 2.6f, 2.8f, 3.0f};
    // float[] y = {0.525f, 0.8448f, 1.2807f, 1.8634f, 2.6326f, 3.6386f, 4.944f, 6.6258f, 8.7768f, 11.5076f, 14.9484f};

    // 25
    // float[] x = {13, 15, 16, 21, 23, 25, 29, 30, 31, 36, 40, 42, 55, 60, 62, 64, 70, 72, 100, 130};
    // float[] y = {11, 10, 11, 12, 13, 13, 12, 14, 16, 17, 13, 14, 22, 14, 21, 21, 24, 17, 23, 34};

    // 28
    float[] x = {0.1f, 0.2f, 0.4f, 0.6f, 0.9f, 1.3f, 1.5f, 1.7f, 1.8f};
    float[] y = {0.75f, 1.25f, 1.45f, 1.25f, 0.85f, 0.55f, 0.35f, 0.28f, 0.18f};

    float n;
    float a1, a0;

    // Funciona 2.0
    public void Ajuste5()
    {
        n = x.Length; // PADRAO
        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Log(y[i]); // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp
        
        a1 = -Math.Abs(a1);
        a0 = (float)Math.Exp(a0);

        // fx = exp(a0)^-a1
        Console.WriteLine("\nO modelo ajustado eh: y(x) = " + a0 + "^" + a1 + "t");

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] = a0 * (float)(Math.Exp(a1*x[i]));
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a0 * (float)(Math.Exp(a1 * xa[i]));
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }

    // Funciona 2.0
    public void Ajuste6()
    {
        n = x.Length; // PADRAO
        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = 1/y[i]; // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp
        a0 = 1/a0; // MUTAVEL

        // fx = exp(a0)^-a1
        Console.WriteLine("\nO modelo ajustado eh: y(x) = " + a0 + "^" + a1 + "t");

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] = a0 / (1 + a1 * a0 * x[i]);
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a0 / (1 + a1 * a0 * xa[i]);
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }

    // Funciona 2.0
    public void Ajuste7()
    {
        n = x.Length; // PADRAO
        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Pow(y[i], 2); // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] = (float)Math.Sqrt(a0 + a1 * x[i]);
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = (float)Math.Sqrt(a0 + a1 * xa[i]);
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }
    
    // Funciona 2.0
    public void Ajuste8()
    {
        n = x.Length; // PADRAO
        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Pow(Math.E, (y[i] / x[i])); // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  x[i] * (float)Math.Log(a1 * x[i] + a0);
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = xa[i] * (float)Math.Log(a1 * xa[i] + a0);
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }

    public void Ajuste9()
    {
        n = x.Length; // PADRAO

        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = y[i];
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp
        
        a1 = 1/a1;
        a0 = a0/a1;

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  (a1 + (float)Math.Pow(x[i], 2)) /  (a0 + x[i]); // MUTAVEL
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = (a1 + (float)Math.Pow(xa[i], 2)) /  (a0 + xa[i]); // MUTAVEL
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }
    
    // Funciona 2.0
    public void Ajuste12A()
    {
        n = x.Length; // PADRAO

        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Log(y[i]); // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp
        a0 = (float)Math.Exp(a0); // MUTAVEL
        a1 = (float)Math.Exp(a1); // MUTAVEL

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  a0 * (float)Math.Pow(a1, x[i]); // MUTAVEL
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a0 * (float)Math.Pow(a1, xa[i]); // MUTAVEL
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }

    // Funciona 2.0
    public void Ajuste13()
    {
        n = x.Length; // PADRAO

        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Log(y[i]); // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp
        a1 = (float)Math.Exp(a1);
        a0 = (float)Math.Exp(a0); // MUTAVEL

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  a0 * (float)Math.Pow(a1, x[i]); // MUTAVEL
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a0 * (float)Math.Pow(a1, xa[i]); // MUTAVEL
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }
    
    // Funciona 2.0
    public void Ajuste14()
    {
        n = x.Length; // PADRAO

        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Log(y[i]); // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp
        
        a0 = (float)Math.Exp(a0); // MUTAVEL

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  a0 * (float)Math.Pow(Math.E, (x[i] * a1));
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a0 * (float)Math.Pow(Math.E, (xa[i] * a1));
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }
    
    // Funciona 2.0
    public void Ajuste16()
    {
        n = x.Length; // PADRAO
        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Log(y[i] - 1); // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        a0 =  (float)Math.Exp(a0); // MUTAVEL

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  1 + a0 * (float)Math.Pow(Math.E, a1 * x[i]); // MUTAVEL
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = 1 + a0 * (float)Math.Pow(Math.E, a1 * xa[i]); // MUTAVEL
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }
    
    public void Ajuste17()
    {
        n = x.Length; // PADRAO
        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Pow(Math.E, x[i]) * y[i]; // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO
        // a1 = 1.9996f; // MUTAVEL
        // a0 = 3.81623f; // MUTAVEL

        // Se ln de a1 ou a0, usa-se exp

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  a1 * (float)Math.Pow(Math.E, x[i]) + a0 * (float)Math.Pow(Math.E, -Math.Abs(x[i]));
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a1 * (float)Math.Pow(Math.E, xa[i]) + a0 * (float)Math.Pow(Math.E, -Math.Abs(xa[i]));
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }
    
    public void Ajuste22()
    {
        n = x.Length; // PADRAO
        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Log(1/y[i] - 1); // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  1 / (1 + (float)Math.Pow(Math.E, 1 * x[i]) );
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a1 * xa[i] + a0;
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }
    
    // Funciona 2.0
    public void Ajuste24A()
    {
        n = x.Length; // PADRAO
        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = y[i];
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  a0 + a1 * x[i];
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a0 + a1 * xa[i];
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }

    // Funciona 2.0
    public void Ajuste25()
    {
        n = x.Length; // PADRAO
        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = y[i]; // MUTAVEL
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  a1 * x[i] + a0;
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a1 * xa[i] + a0;
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }

    public void Ajuste28()
    {
        n = x.Length; // PADRAO
        float[,] A = CreateA(x); // PADRAO
        float[] B = new float[x.Length]; // PADRAO

        // calcula a matriz B, usando o y ou fx da funçao linearizada
        for (int i = 0; i < x.Length; i++){
            B[i] = (float)Math.Log(y[i] - x[i]); // MUTAVEL
            Console.WriteLine("B[" + i + "] = " + B[i]);
        }

        //////////////////A1&A0////////////////////
        CreateX(A, B); // PADRAO

        // Se ln de a1 ou a0, usa-se exp
        a0 = (float)Math.Exp(a0);

        Console.WriteLine("\nA1: " + a1); // PADRAO
        Console.WriteLine("A0: " + a0); // PADRAO
        //////////////////A1&A0////////////////////

        float[] xa = XA(x, n); // PADRAO
        float[] yAjustado = new float[x.Length]; // PADRAO
        float[] ya = new float[xa.Length]; // PADRAO
        
        // yAjustado == Ya, usa a função da questão NAO linearizada * x
        for (int i = 0; i < n; i++){
            yAjustado[i] =  a1 * x[i] * (float)(Math.Pow(Math.E, a0*x[i]));
            // Console.WriteLine("yAjustado[" + i + "] = " + yAjustado[i]);
        }

        // ya, usa a função da questão NAO linearizada * xa
        for (int i = 0; i < xa.Length; i++){
            ya[i] = a1 * xa[i] * (float)(Math.Pow(Math.E, a0*xa[i]));
            // Console.WriteLine("ya[" + i + "] = " + ya[i]);
        }
        
        R2(yAjustado); // PADRAO
        ExportArrays(x, y, xa, ya); // PADRAO
    }
    #region Metodos

    public void R2(float[] yAjustado)
    {
        float somatorioYYA2 = SomatorioYMenosYAjustadoNaPotencia(y, yAjustado, 2);
        float somatorioY2 = SomatorioNaPotencia(y, 2);
        float somatorioY = SomatorioNaPotencia(y);

        float r2 = R2Linear(somatorioYYA2, somatorioY2, somatorioY, n);

        Console.WriteLine("\nR2: " + r2 + "");
    }

    public float[,] Inversa(float[,] matriz)
    {
        double a00 = matriz[0, 0];
        double a01 = matriz[0, 1];
        double a10 = matriz[1, 0];
        double a11 = matriz[1, 1];
        
        Matrix matrizAInvertida = new Matrix(a00, a01, a10, a11, 1, 1);
        float[,] inversa = new float[2, 2];
  
        matrizAInvertida.Invert();

        inversa[0, 0] = (float)matrizAInvertida.M11;
        inversa[0, 1] = (float)matrizAInvertida.M12;
        inversa[1, 0] = (float)matrizAInvertida.M21;
        inversa[1, 1] = (float)matrizAInvertida.M22;

        return inversa;
    }

    public void CreateX(float[,] A, float[] B)
    {
        // X = inv(A'*A) * (A'*B)
        float[,] ATransposta = new float[2, x.Length];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < x.Length; j++)
            {
                ATransposta[i, j] = A[j, i];
            }
        }

        // Console.WriteLine("\nMatriz A Transposta");
        // PrintMatriz2D(ATransposta);

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

        // Console.WriteLine("\nMatriz A Transposta x B");
        // PrintMatriz2D(ATranspostaB);

        // multiplicar ATransposta por A
        float[,] ATranspostaA = new float[2, 2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                ATranspostaA[i, j] = 0;
                for (int k = 0; k < x.Length; k++)
                {
                    ATranspostaA[i, j] += ATransposta[i, k] * A[k, j];
                }
            }
        }

        // Console.WriteLine("\nMatriz A Transposta x A");
        // PrintMatriz2D(ATranspostaA);

        float[,] InversaATranpostaA = Inversa(ATranspostaA);

        // Console.WriteLine("\nMatriz Inversa de A Transposta x A");
        // PrintMatriz2D(InversaATranpostaA);

        float[,] X = new float[2, 1];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                X[i, j] = 0;
                for (int k = 0; k < 2; k++)
                {
                    X[i, j] += InversaATranpostaA[i, k] * ATranspostaB[k, j];
                }
            }
        }
        
        a1 = X[0, 0];
        a0 = X[1, 0];
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

    #endregion

    static void Main(string[] args)
    {  
        AjusteLinear ajusteLinear = new AjusteLinear();
        AjusteQuadratico ajusteQuadratico = new AjusteQuadratico();
        ajusteLinear.Ajuste28(); 
        // ajusteQuadratico.Ajuste();
    }


}

