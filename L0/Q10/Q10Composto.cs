using System;

namespace Juros;

public static class Juros
{
	public static float ParseF( string prompt, string err, float min = 0, float max = float.MaxValue )
	{
		while ( true )
		{
			Console.Write( prompt );
			if ( float.TryParse( Console.ReadLine(), out float result ) && result >= min && result <= max ) return result;
			Console.WriteLine( err );
		}
	}

	public static char ParseSN( string prompt, string err )
	{
		while ( true )
		{
			Console.WriteLine( prompt );
			if ( char.TryParse( Console.ReadLine(), out char result ) &&  "sn".Contains( char.ToLower( result ) ) ) return result;
			Console.WriteLine(err);
		}
	}
	public static void Main()
	{
		char cont;
		float C;
		float i;
		float revenue;
		float t = 1;

		C = ParseF( "Quanto voce deseja investir por mes? ", "Digite um numero positivo!" );
		i = ParseF( "Qual sera a taxa (%) de juros mensal? ", "Digite um numero positivo!", 0, 100 );
		revenue = 0f;

		for ( int month = 1; month <= 12; month++ )
		{
			revenue += C;
			revenue *= 1 + ( i * 0.01f );
		}

		Console.WriteLine( $"Saldo do investimento após 1 ano: {revenue}" );
		cont = ParseSN( "Deseja continuar por mais 1 ano (S/N)? ", "Digite apenas S ou N" );

		while ( char.ToLower( cont ) == 's' )
		{
			t++;
			C = ParseF( "Quanto voce deseja investir por mes? ", "Digite um numero positivo!" );
			for ( int month = 1; month <= 12; month++ )
			{
				revenue += C;
				revenue *= 1 + ( i * 0.01f );
			}
			Console.WriteLine( $"Saldo do investimento após {t} anos: {revenue}" );
			cont = ParseSN( "Deseja continuar por mais 1 ano (S/N)? ", "Digite apenas S ou N" );
		}
	}
}