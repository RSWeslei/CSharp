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
            Console.WriteLine(medias.MediaPonderada(pesos, x) + "\n");

            // float[] array = {3, 5, 8, 9, 10, 10, 7, 3, 12};
            float[] array = {1, 2, 3 , 4, 5 ,6 ,7 ,8, 9, 10, 11, 12, 13, 13, 13, 15};
            for (int i = 1; i < 10; i++)
            {
                medias.Separatriz(Medias.SeparatrizType.Decis, index: i, array);
            }
        }
        
    }
}
