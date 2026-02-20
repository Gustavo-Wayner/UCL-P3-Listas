using System;
using System.Numerics;
using System.Reflection;

namespace Produtos;

public static class Program
{
    public static T Parse<T>( string prompt, string err, T min, T max )
        where T : IParsable<T>, IComparable<T>
    {
        while ( true )
        {
            Console.Write( prompt );
            string? input = Console.ReadLine();

            if ( T.TryParse( input, null, out T? result ) && result.CompareTo( min ) >= 0 && result.CompareTo( max ) <= 0 ) return result;

            Console.WriteLine( err );
        }
    }
    
	private static string[] paymentMethods = new string[3]{ "cartão", "dinheiro", "cheque" };

    public static void Main()
    {
        Purchase purchase = new();
        Product product1 = new( 10.0f, 3, "produto 1" );
        Product product2 = new( 25.0f, 23, "produto 2" );
        Product product3 = new( 100.0f, 10, "produto 3" );
		Product product4 = new( 1050.99f, 1, "produto 3" );

        int cont = 0;
        while ( cont == 0 )
        {
            string list = string.Empty;
            for ( int i = 0; i < Product.all.Count; i++ )
            {
                list += $"{ i } - { Product.all[i].GetTitle() }: R${ Product.all[i].GetPrice() }; Qtd: { Product.all[i].GetStock() }\n";
            }
            int id = Parse( $"Digite um numero de 0 a { Product.all.Count - 1 } entre os seguintes:\n{ list }", $"Digite um NUMERO ENTRE 0 E { Product.all.Count - 1 }!", 0, Product.all.Count - 1 );

            if ( Product.all[id].GetStock() >= 1 )
            {
				if ( purchase.Search(Product.all[id], out int i ) )
				{
					purchase.LowerStock( i );
					purchase.IncreaseAmount( i );
				}

				else
				{
					purchase.AddProduct( Product.all[id] );
					purchase.LowerStock( purchase.GetCount() - 1 );
					purchase.IncreaseAmount( purchase.GetCount() - 1 );
				}
            }
            else Console.WriteLine( $"Produto [ {Product.all[id].GetTitle()} ] esgotado!" );

            cont = Parse( "Digite 0 para continuar comprando e 1 para saír: ", "Digite apénas 0 ou 1!", 0, 1 );
        }

		int met = Parse( "Escolha um método de pagamento:\n0 - Cartão\n1 - Dinheiro\n2 - Cheque\n", "Digite um NUMERO DE 0 A 2!", 0, 2 );
        purchase.LogRecipt( paymentMethods[met] );
    }
}

public class Product
{
    public static List<Product> all = new List<Product>();
    private float price;
    private int stock;
    private string title;

    public Product( float _price, int _stock, string _title )
    {
        price = _price;
        stock = _stock;
        title = _title;

        all.Add( this );
    }

	public string GetTitle() { return title; }
	public int GetStock() { return stock; }
	public float GetPrice() { return price; }

	public void LowerStock() { stock--; }
}

public class Purchase
{
    private List<Product> products = new List<Product>();
	private List<int> amount = new List<int>();

    public void LowerStock( int id )
    {
        products[id].LowerStock();
    }
	public void AddProduct( Product prod )
	{
		products.Add( prod );
	}

	public int GetCount()
	{
		return products.Count();
	}

	public void IncreaseAmount( int id )
	{
		try
		{
			amount[id]++;
		}
		catch( ArgumentOutOfRangeException )
		{
			amount.Add( 1 );
		}
	}

	public void LogRecipt( string met )
	{
		float total = 0;
		for ( int i = 0; i < products.Count; i++)
		{
			total += products[i].GetPrice() * amount[i];
			Console.WriteLine( $"{ products[i].GetTitle() } | Unidade: R${ products[i].GetPrice() } - Subtotal: R${ products[i].GetPrice() * amount[i] } | Qtd: { amount[i]} " );
		}
		Console.WriteLine( $"Método de pagamento: { met }" );
		Console.WriteLine( $"Custo total: R${ total }" );
	}

	public bool Search(Product prod, out int index)
	{
		for ( int i = 0; i < products.Count; i++ )
		{
			if( products[i].GetTitle() == prod.GetTitle() )
			{
				index = i;
				return true;
			}
		}

		index = 0;
		return false;
	}
}