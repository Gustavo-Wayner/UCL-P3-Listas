using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[100];
        Random random = new Random();

        // gerando 100 numeros aleatorios de 0 a 999
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(0, 1000);
        }

        Console.WriteLine("Array original:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }

        // ordenando array
        Array.Sort(arr);

        Console.WriteLine("\n\nArray ordenado:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
    }
}