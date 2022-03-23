﻿using System;

class AjusteLinear: Ajustes
{
    float[] x = {1, 2, 3, 4, 5, 6, 7, 8};
    float[] y = {0.5f, 0.6f, 0.9f, 0.8f, 1.2f, 1.5f, 1.7f, 2.0f};

    // float[] x = {1f, 2f, 3f, 4f};
    // float[] y = {1f, 2.5f, 3.5f, 4f};
    
    float somatorioX = 0;
    float somatorioX2 = 0;
    float somatorioYX = 0;
    float somatorioY = 0;

    float n;
    float[,] matrizA;
    float[,] matrizAInversa;
    float[] matrizB;
    float determinanteA;

    float a1, a0;

    public void Ajuste()
    { 
        n = x.Length;

        somatorioX = SomatorioNaPotencia(x);
        somatorioX2 = SomatorioNaPotencia(x, 2);

        somatorioY = SomatorioNaPotencia(y);
        somatorioYX = SomatorioXY(y, x);

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

        determinanteA = Determinante(somatorioX, somatorioX2, n);

        float[] resultado = new float[2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                resultado[i] += matrizAInversa[i, j] * matrizB[j];
            }
        }

        a1 = resultado[0] * determinanteA;
        a0 = resultado[1] * determinanteA;

        // Debugs
        Console.WriteLine("Somatorio de x²: " + somatorioX2);
        Console.WriteLine("Somatorio de x: " + somatorioX);
        Console.WriteLine("Somatorio de y: " + somatorioY);
        Console.WriteLine("Somatorio de x*y: " + somatorioYX);
        Console.WriteLine("Determinante de A: " + determinanteA);
        Console.WriteLine("N: " + n);
        
        Console.WriteLine("\nMatriz A");
        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                Console.Write(matrizA[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nMatriz A Inversa");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write(matrizAInversa[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nMatriz B");
        for (int i = 0; i < 2; i++)
        {
            Console.Write(matrizB[i] + "\n");
        }

        Console.WriteLine("\nResultado");
        for (int i = 0; i < 2; i++)
        {
            Console.Write(resultado[i] + "\n");
        }

        Console.WriteLine("\nA1: " + a1);
        Console.WriteLine("A0: " + a0);

        Console.WriteLine("\nO modelo ajustado eh: y(x) = " + a1 + "x + " + a0);
    }

    static void Main(string[] args)
    {  
        AjusteLinear ajusteLinear = new AjusteLinear();
        AjusteQuadratico ajusteQuadratico = new AjusteQuadratico();
        ajusteLinear.Ajuste(); 
        ajusteQuadratico.Ajuste();
    }
}

