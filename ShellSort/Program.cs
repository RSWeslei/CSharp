using System;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = CreateRandomArray(8);
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
            int n = array.Length;
            while(n != 1)
            {

            }
            return array;
        }
    }
}
