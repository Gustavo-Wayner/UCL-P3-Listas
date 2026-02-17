using System;
using System.Numerics;
using System.Reflection;

namespace Produtos;

public static class Program
{
    public static T Parse<T>(string prompt, string err, T min, T max)
        where T : IParsable<T>, IComparable<T>
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (T.TryParse(input, null, out T? result) && result.CompareTo(min) >= 0 && result.CompareTo(max) <= 0) return result;

            Console.WriteLine(err);
        }
    }
    
    public static void Main()
    {
        Purchase purchase = new();
        Product product1 = new(10.0f, 13, "produto 1");
        Product product2 = new(25.0f, 23, "produto 2");
        Product product3 = new(100.0f, 10, "produto 3");

        int cont = 0;
        while ( cont == 0 )
        {
            string list = string.Empty;
            for ( int i = 0; i < Product.all.Count; i++)
            {
                list += $"{i} - {Product.all[i].title}: R${Product.all[i].price}; Qtd: {Product.all[i].stock}\n";
            }
            int id = Parse($"Digite um numero de 0 a {Product.all.Count - 1} entre os seguintes:\n{list}", $"Digite um NUMERO ENTRE 0 E {Product.all.Count - 1}!", 0, Product.all.Count - 1);

            for ( int i = 0; i < Product.all.Count; i++)
            {
                if ( id == i )
                {
                    if ( Product.all[i].stock >= 1 )
                    {
                        purchase.products.Add(Product.all[i]);
                        purchase.products[i].stock--;
                    }
                    else Console.WriteLine("Quantidade insuficiente!");
                    break;
                }
            }

            cont = Parse("Digite 0 para continuar comprando e 1 para saír: ", "Digite apénas 0 ou 1!", 0, 1);
        }

        foreach(Product prod in Product.all)
        {
            Console.WriteLine($"{prod.title}: R${prod.price}; Qtd: {prod.stock}");
        }
    }
}

public class Product
{
    public static List<Product> all = new List<Product>();
    public float price;
    public int stock;
    public string title;

    public Product(float _price, int _stock, string _title)
    {
        price = _price;
        stock = _stock;
        title = _title;

        all.Add(this);
    }
}

public class Purchase
{
    public List<Product> products = new List<Product>();
}

enum PaymentMethod
{
    Card,
    Cash,
    Check
}