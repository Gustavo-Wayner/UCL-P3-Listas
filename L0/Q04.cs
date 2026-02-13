using System;

class Program
{
    static void Main()
    {
        Console.Write("produto: "); string productName = Console.ReadLine();
        Console.Write("preço: "); double price = double.Parse(Console.ReadLine());
        Console.Write("quantidade: "); int qty = int.Parse(Console.ReadLine());
        double total = price * qty;
        double discount;

        if (qty <= 10) discount = 0;
        else if (qty <= 20) discount = 10;
        else if (qty <= 50) discount = 20;
        else discount = 25;

        double totalWithDiscount = total - (total * discount / 100);

        Console.WriteLine($"\nproduto: {productName}");
        Console.WriteLine($"total: {total:C}");
        Console.WriteLine($"desconto: {discount}%");
        Console.WriteLine($"total com desconto: {totalWithDiscount:C}");
    }
}