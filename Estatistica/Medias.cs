using System;

namespace Estatistica
{
    class Medias
    {
        public enum SeparatrizType {
            Quartis,
            Decis,
            Percentis
        }

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

        public void Separatriz(SeparatrizType separatriz, float index, float[] array)
        {
            float n = array.Length;
            Console.WriteLine("\nN: " + n);
            if (!IsSorted(array)){
                Array.Sort(array);
                Console.WriteLine("Array ordenado com sucesso");
            }
            Console.WriteLine("Array ordenado: ");
            for (int i = 0; i < n; i++) {
                Console.Write(array[i] + " ");
            }

            int s = SeparatrizValue(separatriz);
            float pos = (index * (n + 1)) / s;
            float mediana = (1 * (n)) / 2;
            if (n % 2 == 0) {
                mediana = ((array[(int)mediana] - array[(int)mediana-1]) / 2) + (array[(int)mediana-1]);
            }
            else {
                mediana = array[(int)mediana]; 
            }

            int floor = (int)Math.Floor(pos);
            float rest = (float)(pos - Math.Floor(pos));
            // Console.WriteLine("\nFloor: " + floor);
            // Console.WriteLine("rest: " + rest);

            Console.WriteLine("\nMediana: " + mediana);

            if (floor >= n) {
                Console.WriteLine("P"+index+": "+array[(int)n-1]); 
                return;
            }
            if (pos < 1){
                pos = 1;
            }
            else
                pos = ((array[floor] - array[floor-1]) * rest) + array[floor-1];
            
            // Console.WriteLine("\nPosition: " + pos);

            switch (separatriz)
            {
                case SeparatrizType.Quartis: Console.WriteLine("Q"+index + " :" + Math.Round(pos, 1));
                break;
                case SeparatrizType.Decis: Console.WriteLine("D"+index + " :" + Math.Round(pos, 1));
                break;
                case SeparatrizType.Percentis: Console.WriteLine("P"+index + " :" + Math.Round(pos, 2));
                break;
            }
        }

        public void SeparatrizIntervalar(SeparatrizType separatriz, int index, float[] array1, float[] array2)
        {
            int n = array1.Length;
            int s = SeparatrizValue(separatriz);
            float pos = (index * n) / s;

            float mediana = (1 * n) / 2;
            
        }
        
        #region methods

        private int SeparatrizValue(SeparatrizType type)
        {
            switch (type)
            {
                case SeparatrizType.Quartis: return 4;
                case SeparatrizType.Decis: return 10;
                case SeparatrizType.Percentis: return 100;
            }
            return 0;
        }

        public static bool IsSorted(float[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    
    }
    
}
