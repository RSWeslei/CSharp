using System;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = CreateRandomArray(12);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " "); 
            }
            Console.WriteLine();
            array = ShellSort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " "); 
            }
        }

        private static int[] CreateRandomArray(int length)
        {
            int[] array = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = (int)random.Next(1, 100);
            }
            return array;
        }

        private static int[] ShellSort(int[] array)
        {
            int n = array.Length / 2;

            while(n != 1)
            {
                for (int i = 0; i < 6; i++)
                {
                    // Console.WriteLine(i+n);
                    if (array[i] > array[i+n])
                    {
                        int aux = array[i];
                        array[i] = array[i+n];
                        array[i+n] = aux;
                        Console.WriteLine("Trocou "+array[i]+" por "+array[i+n]);
                    }
                }

                n/=2;
            }
            return array;
        }
    }
}
