using System;

class Program
{
    static void Main()
    {
    double a = readNumber("Digite o valor de A: "); if (a == 0) { Console.WriteLine("Não é uma equação do 2º grau."); return; }
        double b = readNumber("Digite o valor de B: ");
        double c = readNumber("Digite o valor de C: ");
        double delta = (b * b) - (4 * a * c);
        Console.WriteLine($"\nDelta = {delta}");

        if (delta > 0)
        {
            double deltaSqrt = Math.Sqrt(delta);
            double x1 = (-b + deltaSqrt) / (2 * a);
            double x2 = (-b - deltaSqrt) / (2 * a);

            Console.WriteLine($"x1 = {x1}");
            Console.WriteLine($"x2 = {x2}");
        }
        else if (delta == 0.0)
        {
            double x = -b / (2 * a);

            Console.WriteLine("Existe uma raiz real:");
            Console.WriteLine($"x = {x}");
        }
        else
        {
            Console.WriteLine("Não existem raízes reais.");
        }
    }

    static double readNumber(string message)
    {
        double number;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out number)) { return number; }
            Console.WriteLine("Valor inválido. Digite um número válido.\n");
        }
    }
}