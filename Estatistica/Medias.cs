using System;

namespace Estatistica
{
    class Medias
    {
        public float MediaPonderada(float[] pesos, float[] x)
        {
            if (pesos.Length != x.Length){
                Console.WriteLine("Arays devem ter o mesmo tamanho!");
                Console.WriteLine(x.Length + " " + pesos.Length);
                return 0f;
            }
            float media=0;
            float somaPesos=0;
            for (int i = 0; i < x.Length; i++)
            {
                media += x[i] * pesos[i];
                somaPesos += pesos[i];
            }
            return media / somaPesos;
        }
    }
}
