using System;

namespace Raiz;

public static class Raiz
{
	public static double Parse( string prompt, string err )
	{
		while ( true )
		{
			Console.Write( prompt );
			if ( double.TryParse( Console.ReadLine(), out double result ) && result >= 0 ) return result;
			Console.WriteLine( err );
		}
	}

	static double Sqrt( double n, double tolerance )
	{
		if (n < 0) throw new ArgumentException( "Numero negativo" );

		double x = n * 0.5D;
		double last;

		do
		{
			last = x;
			x = 0.5 * (x + n / x);
		}
		while ( Math.Abs( x - last ) > tolerance );

		return x;
	}

	public static void Main()
	{
		double num = Parse( "Digite o numero do qual quer ver a raiz quadrada: ", "Digite um NUMERO POITIVO!" );
		double margin = Parse( "Digite a margem de erro tolerada: ", "Digite um NUMERO POITIVO!" );

		Console.WriteLine( $"A raiz quadrada de { num } com margem de erro { margin } é: { Sqrt( num, margin ) }" );
	}
}