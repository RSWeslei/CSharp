using System;

namespace Estatistica
{
    class Program
    {
        static void Main(string[] args)
        {
            Medias medias = new Medias();
            float[] pesos = {3, 2, 4, 2, 2, 3, 4};
            float[] x = {8.2f, 10f, 9.5f, 7.8f, 10f, 9.5f, 6.7f};
            Console.WriteLine(medias.MediaPonderada(pesos, x));
        }
    }
}
