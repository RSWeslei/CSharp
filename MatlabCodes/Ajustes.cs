using System;
using Fractions;

public class Ajustes
{
    public string name;

    public float SomatorioNaPotencia(float[] array, int potencia = 1)
    {
        float somatorio = 0;
        for (int i = 0; i < array.Length; i++)
        {
            somatorio += (float)Math.Pow(array[i], potencia);
        }
        return somatorio;
    }

    public float SomatorioXY(float[] x, float[] y)
    {
        float somatorio = 0;
        for (int i = 0; i < x.Length; i++)
        {
            somatorio += x[i] * y[i];
            Console.WriteLine("SmX * Y: " + x[i] + " * " + y[i]);
        }
        return somatorio;
    }

    public float Determinante(float sX, float sX2, float n)
    {
        float determinante = 0;
        determinante = ((sX2 * n) - (sX * sX));
        Console.WriteLine("1/"+determinante);
        determinante = 1 / determinante;
        return determinante;
    }

    public float SomatorioXYNaPotenciaX(float[] x, float[] y, int potencia = 1)
    {
        float somatorio = 0;
        for (int i = 0; i < x.Length; i++)
        {
            somatorio += (float)Math.Pow(x[i], potencia) * y[i];
        }
        return somatorio;
    }

    public float[] YAjustadoLinear(float[] x, float a0)
    {
        float[] y = new float[x.Length];
        for (int i = 0; i < x.Length; i++)
        {
            y[i] =  1 * x[i] + a0;
        }
        return y;
    }

    public float[] YAjustadoQuadratico(float[] x, float a2, float a1, float a0)
    {
        float[] y = new float[x.Length];
        for (int i = 0; i < x.Length; i++)
        {
            y[i] = a2 * (float)Math.Pow(x[i], 2) + (a1 * x[i]) + a0;
        }
        return y;
    }

    public float SomatorioYMenosYAjustadoNaPotencia(float[] y, float[] yAjustado, float potencia = 1)
    {
        float somatorio = 0;
        float temp = 0;
        for (int i = 0; i < y.Length; i++)
        {
            temp = (y[i] - yAjustado[i]);
            somatorio += (float)Math.Pow(temp, potencia);
            Console.WriteLine("Y - Y Ajustado: " + (float)Math.Pow(temp, potencia));
        }
        return somatorio;
        
    }

    public float R2Quadratico(float somatorioYYA2, float somatorioY2, float somatorioY, float n)
    {
        float passo1 = n * somatorioYYA2;
        float passo2 = (n * somatorioY2) - ((float)Math.Pow(somatorioY, 2));
        return 1 - passo1 / passo2;
    }   

    public float R2Linear(float somatorioYYA2, float somatorioY2, float somatorioY, float n)
    {
        float passo1 = n * somatorioYYA2;
        float passo2 = (n * somatorioY2) - ((float)Math.Pow(somatorioY, 2));
        Console.WriteLine("Passo 1: " + passo1);
        Console.WriteLine("Passo 2: " + passo2);
        return 1 - passo1 / passo2;
    }

    public void PrintMatriz2D(float[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void PrintMatriz1D(float[] matriz)
    {
        for (int i = 0; i < matriz.Length; i++)
        {
            Console.Write(matriz[i] + " ");
        }
        Console.WriteLine();
    }

}
    
