public static class Prog
{
	public static void Main()
	{
		Console.Write( "Digite seu nome: " );
		string name = Console.ReadLine();

		for(int i = 0; i < 100; i++)
		{
			Console.WriteLine( name );
		}
	}
}