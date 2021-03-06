using System;
using System.Collections.Generic;


public class Ajustes
{
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

    public float SomatorioXYNaPotenciaX(float[] x, float[] y, int potencia = 1)
    {
        float somatorio = 0;
        for (int i = 0; i < x.Length; i++)
        {
            somatorio += (float)Math.Pow(x[i], potencia) * y[i];
        }
        return somatorio;
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
        for (int i = 0; i < y.Length; i++)
        {
            somatorio += (float)Math.Pow((y[i] - yAjustado[i]), potencia);
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
        float s1 = somatorioYYA2;
        float s2 = somatorioY2;
        float s3 = (float)Math.Pow(somatorioY, 2);

        float r2 = 1 - (n * s1 / (n  * s2 - s3));

        return r2;
    }

    public float[] XA(float[] x, float n)
    {
        float maxX = x[x.Length-1];
        float size = x[x.Length-1] - x[0];
        List<float> xa = new List<float>();
        float add = x[0];
        while (add <= (size))
        {
            xa.Add(add / 100);
            add = add + 1;     
            // Console.WriteLine("XA: " + add);
        }
        foreach (float item in xa)
        {
            // Console.WriteLine("Xa: " + item);
        }
        float sum = xa[xa.Count-1];
        
        List<float> list = new List<float>();
        float count = x[0];
        list.Add(count);

        while (count < maxX){
            // Console.WriteLine("Count: " + count);
            count += sum;
            count = (float)Math.Round(count, 4, MidpointRounding.AwayFromZero);
            list.Add(count);
        }
        foreach (float item in list)
        {
            // Console.WriteLine("List: " + item);
        }
        return list.ToArray();
    }

    public float[,] CreateA(float[] x){
        float[,] a = new float[x.Length, 2];
        for (int i = 0; i < x.Length; i++){
            a[i, 0] = x[i];
            a[i, 1] = 1;
        }
        return a;
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
            Console.Write(matriz[i] + "\n");
        }
        Console.WriteLine();
    }

}
    
