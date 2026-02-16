using System;

namespace Juros;

public static class Juros
{
	public static float ParseF( string prompt, string err, float min = 0, float max = float.MaxValue )
	{
		while ( true )
		{
			Console.Write(prompt);
			if ( float.TryParse( Console.ReadLine(), out float result ) && result >= min && result <= max ) return result;
			Console.WriteLine(err);
		}
	}

	public static char ParseSN( string prompt, string err )
	{
		while ( true )
		{
			Console.WriteLine(prompt);
			if ( char.TryParse( Console.ReadLine(), out char result ) &&  "sn".Contains( char.ToLower( result ) ) ) return result;
			Console.WriteLine(err);
		}
	}
	public static void Main()
	{
		char cont;
		float J;
		float C;
		float i;
		float M;
		float t = 1;

		C = ParseF("Quanto voce deseja investir por mes? ", "Digite um numero positivo!");
		i = ParseF("Qual sera a taxa (%) de juros mensal? ", "Digite um numero positivo!", 0, 100);
		J = C * i * 0.01f * 12;
		M = J;

		Console.WriteLine($"Após 1 ano, seu investimento de R${ C } por mês rendeu: R${ J }");
		cont = ParseSN("Deseja continuar por mais 1 ano (S/N)? ", "Digite apenas S ou N");

		while ( char.ToLower(cont) == 's')
		{
			t++;
			C = ParseF("Quanto voce deseja investir por mes? ", "Digite um numero positivo!");
			J = C * i * 0.01f * 12;
			M += J;
			Console.WriteLine($"Após 1 ano, seu investimento de R${ C } por mês rendeu: R${ J }");

			Console.WriteLine($"Total em { t } anos: R${ M }");
			cont = ParseSN("Deseja continuar por mais 1 ano (S/N)? ", "Digite apenas S ou N");
		}
	}
}