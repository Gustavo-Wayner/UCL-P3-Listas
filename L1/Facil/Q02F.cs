using System;

public static class Prog
{
	public static void Main()
	{
		Console.WriteLine( "Os numeros pares entre 1 e 100 são:" );

		for( int i = 2; i <= 100; i += 2 )
		{
			Console.WriteLine( i );
		}
	}
}