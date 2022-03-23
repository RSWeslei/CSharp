using System;

class Ajustes
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

    public float SomatorioXY(float[] arrayA, float[] arrayB)
    {
        float somatorio = 0;
        for (int i = 0; i < arrayA.Length; i++)
        {
            somatorio += arrayA[i] * arrayB[i];
        }
        return somatorio;
    }

    public float Determinante(float sX, float sX2, float n)
    {
        float determinante = 0;
        determinante = 1 / ((sX2 * n) - (sX * sX));
        return determinante;
    }
}
    
