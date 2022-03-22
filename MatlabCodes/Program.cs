using System;

namespace MatlabCodes
{
    class Program
    {
        // g = y
        // o = x
        static void Main(string[] args)
        {
            float[] x = {1, 2, 3, 4, 5, 6, 7, 8};
            float[] y = {0.5f, 0.6f, 0.9f, 0.8f, 1.2f, 1.5f, 1.7f, 2.0f};
           
            float somatorioX2 = 0;
            float somatorioX = 0;
            float somatorioYX = 0;
            float somatorioY = 0;
            float n = x.Length;
            float[,] matrizA;
            float[,] matrizAInversa;
            float[] matrizB;

            for (int i = 0; i < x.Length; i++)
            {
                somatorioX2 += (float)Math.Pow(x[i], 2);
                somatorioYX += x[i] * y[i];
                somatorioX += x[i];
                somatorioY += y[i];
            }

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

           // multiply matrixAInversa BY matrizB
            float[] resultado = new float[2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    resultado[i] += matrizAInversa[i, j] * matrizB[j];
                }
            }

            Console.WriteLine("Somatorio de x²: " + somatorioX2);
            Console.WriteLine("Somatorio de x: " + somatorioX);
            Console.WriteLine("Somatorio de y: " + somatorioY);
            Console.WriteLine("Somatorio de x*y: " + somatorioYX);
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

        }
    }
}
