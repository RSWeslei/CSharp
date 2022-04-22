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

        public float Mediana(float[] array)
        {
            if (!IsSorted(array)){
                Array.Sort(array);
            }
            if (array.Length % 2 == 0)
            {
                return (array[array.Length / 2] + array[array.Length / 2 - 1]) / 2;
            }
            else
            {
                return array[array.Length / 2];
            }
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

        public float SeparatrizIntervalar(SeparatrizType separatriz, int index, float[] array1, float[] array2, float[] frequencia, bool debug = false)
        {
            int n = array1.Length;
            int s = SeparatrizValue(separatriz);

            float[] cumulativo = new float[n];
            cumulativo[0] = frequencia[0];
            for (int i = 1; i < n; i++){
                cumulativo[i] = cumulativo[i - 1] + frequencia[i];
            }

            float fa = cumulativo[cumulativo.Length-1] * (index / 100f);
            float limiteInferior=0f;
            float limiteSuperior=0f;

            int fpos = 0;
            for (int i = 0; i < n; i++){
                if (cumulativo[i] >= fa){
                    limiteInferior = array1[i];
                    limiteSuperior = array2[i];
                    fpos = i;
                    break;
                }
            }

            float res = limiteInferior + ((fa - cumulativo[fpos-1]) / frequencia[fpos]) * (limiteSuperior - limiteInferior);

            if (debug){
                Console.Write("\nFrequencia cumulativa: ");
                for (int i = 0; i < n; i++){
                    Console.Write(cumulativo[i] + " ");
                }
                Console.WriteLine("\nFrequencia acumulada: " + fa);
                Console.WriteLine("Limite inferior: " + limiteInferior);
                Console.WriteLine("Limite superior: " + limiteSuperior + "\n");
            }

            return res;
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

        private static bool IsSorted(float[] arr)
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

        public void ClasseIntervalar(float[] array1, float[] array2, float[] frequencia)
        {
            int n = array1.Length;
            float[] xi = new float[n];
            float[] xf = new float[n];

            for (int i = 0; i < n; i++)
            {
                xi[i] = array1[i] + ((array2[i] - array1[i]) / 2);
                xf[i] = xi[i] * frequencia[i];
                
            }

            Console.WriteLine("\nXi: ");
            for (int i = 0; i < n; i++){
                Console.Write(xi[i] + " ");
            }
            Console.WriteLine("\nXf: ");
            for (int i = 0; i < n; i++){
                Console.Write(xf[i] + " ");
            }

        }

        #endregion
    
    }
    
}
