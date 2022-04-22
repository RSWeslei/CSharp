using System;

namespace Estatistica
{
    class Program
    {
        static void Main(string[] args)
        {
            Medias medias = new Medias();

            // float[] pesos = {3, 2, 4, 2, 2, 3, 4};
            // float[] x = {8.2f, 10f, 9.5f, 7.8f, 10f, 9.5f, 6.7f};
            // Console.WriteLine(medias.MediaPonderada(pesos, x) + "\n");

            // PROVA
            // float[] array = {8.6f, 8.5f, 7.9f, 7.9f, 8.1f, 7.6f, 7.7f, 7.5f, 7.6f, 6.8f, 8.2f, 8.5f, 9.0f, 8.9f};
            // Console.WriteLine(medias.Mediana(array) + "\n");

            // float[] array = {3, 5, 8, 9, 10, 10, 7, 3, 12};
            // float[] array = {1, 2, 3 , 4, 5 ,6 ,7 ,8, 9, 10, 11, 12, 13, 13, 13, 15};
            // for (int i = 1; i < 10; i++)
            // {
            //     medias.Separatriz(Medias.SeparatrizType.Decis, index: i, array);
            // }

            // // PROVA 8
            // float[] array1 = {160f, 162f, 164f, 166f, 169f};
            // float[] array2 = {162f, 164f, 166f, 168f, 170f};
            // float[] fequencia = {7f, 4f, 8f, 9f, 12f};

            // Console.WriteLine("SeparatrizAgrupada: " + medias.SeparatrizIntervalar(Medias.SeparatrizType.Percentis, 20, array1, array2, fequencia));

            // PROVA 4
            float[] array1 = {2.5f, 7.5f, 12.5f, 17.5f, 22.5f};
            float[] array2 = {7.5f, 12.5f, 17.5f, 22.5f, 27.5f};
            float[] fequencia = {3f, 9f, 13f, 11f, 4f};

            medias.ClasseIntervalar(array1, array2, fequencia);
        }
        
    }
}
