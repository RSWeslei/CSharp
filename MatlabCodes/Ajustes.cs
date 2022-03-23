using System;

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
        }
        return somatorio;
    }

    public float Determinante(float sX, float sX2, float n)
    {
        float determinante = 0;
        determinante = 1 / ((sX2 * n) - (sX * sX));
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
    
