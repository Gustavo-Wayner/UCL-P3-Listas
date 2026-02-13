using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Insira um número:");
        string number = Console.ReadLine();
        int digits = number.Length;
        Console.WriteLine($"\nNúmero de dígitos: {digits}");
    }
}