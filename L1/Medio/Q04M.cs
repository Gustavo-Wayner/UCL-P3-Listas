public class Animal
{
	public static List<Animal> All = new();
	private string name;
	private string type;

	public string GetSpecies() { return type; }

	public Animal(string _name, string _type)
	{
		_type = _type.ToLower();

		// string[] options = new string[3]{ "peixe", "gato", "cachorro" };
		// O vs code disse que a exprssão podia ser simplificada e fez isso aí embaixo. Nem sabia que isso era C# valido
		string[] options = [ "peixe", "gato", "cachorro" ];

		if ( !options.Contains( _type ) ) { throw new Exception("Tipo inválido! Os único tipos validos são cachorro, gato e peixe");}

		name = _name;
		type = _type;
		All.Add( this );
	}

	public override string ToString()
	{
		return $"Nome: { name } | Tipo { type }";
	}
}

public static class Program
{
	public static void Main()
	{
		Animal c1 = new("ze", "gato");
		Animal c2 = new("Destruidor de mundos", "gato");
		Animal d1 = new("Princesa", "cachorro");
		Animal d2 = new("cachorro", "cachorro"); // To sem ideias
		Animal p = new("Douglas", "peixe"); // Eu disse que tava sem ideias

		// Tudo antes de portugues!!!!!!!!!!!!!!!!!!!!!
		var perros = Animal.All.Where( c => c.GetSpecies() == "cachorro");
		var cats = Animal.All.Where( c => c.GetSpecies() == "gato");
		var sakana = Animal.All.Where( c => c.GetSpecies() == "peixe");

		Console.WriteLine($"Existem {cats.Count()} gatos entre os animais declarados");
		foreach ( Animal car in cats )
		{
			Console.WriteLine(car);
		}

		Console.WriteLine($"Existem {perros.Count()} cachorros entre os animais declarados");
		foreach ( Animal perro in perros )
		{
			Console.WriteLine(perro);
		}

		Console.WriteLine($"Existem {sakana.Count()} peixes entre os animais declarados");
		foreach ( Animal pisci in sakana )
		{
			Console.WriteLine(pisci);
		}
	}
}