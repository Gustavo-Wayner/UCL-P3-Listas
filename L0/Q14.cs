using System;

class Program
{
    static void Main()
    {
        int size = 50;
        int[] arr1 = new int[size];
        int[] arr2 = new int[size];
        int[] arrFinal = new int[size * 2];
        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            arr1[i] = random.Next(0, 1000);
            arr2[i] = random.Next(0, 1000);
        }

        Array.Sort(arr1);
        Array.Sort(arr2);

        int i1 = 0, i2 = 0, iFinal = 0;

        while (i1 < size && i2 < size)
        {
            if (arr1[i1] <= arr2[i2])
            {
                arrFinal[iFinal++] = arr1[i1++];
            }
            else
            {
                arrFinal[iFinal++] = arr2[i2++];
            }
        }

        while (i1 < size)
        {
            arrFinal[iFinal++] = arr1[i1++];
        }

        while (i2 < size)
        {
            arrFinal[iFinal++] = arr2[i2++];
        }

        Console.WriteLine("Array final ordenado:");
        foreach (int num in arrFinal)
        {
            Console.Write(num + " ");
        }
    }
}