using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[100];
        Random random = new Random();

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(0, 1000);
        }

        Console.WriteLine("Array original:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }

        Array.Sort(arr);

        Console.WriteLine("\n\nArray ordenado:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
    }
}