/* Crie uma classe chamada CorpoCeleste (massa, densidade, posiçãoX, posiçãoY).
Após a criação da classe, crie um programa que preencha os dados de 10 CorposCelestes e
ao final do processo, liste na tela o corpo de maior massa, o de maior raio e os dois
mais distantes entre si (considerando o eixo X). O código deve fazer uso das boas práticas de
Programação Orientada a Objetos, criando os métodos adequados e fazendo uso de encapsulamento.
Obs.: Lembre-se de que o raio do corpo é calculado a partir da massa e da densidade. */


public class CorpoCeleste
{
	public static List<CorpoCeleste> All = new List<CorpoCeleste>();
	private string title;
	private double posX;
	private double posY;

	private double massa;
	private double densidade;

	public CorpoCeleste( string _title, double _posX, double _posY, double _massa, double _densidade )
	{
		title = _title;
		posX = _posX;
		posY = _posY;
		massa = _massa;
		densidade = _densidade;
		All.Add( this );
	}

	public double GetRadius()
	{
		return Math.Pow( ( 3 * massa ) / ( 4 * Math.PI * densidade ), 1.0 / 3.0 );
	}
	public double GetMass() { return massa; }
	public double GetPosX() { return posX; }
	public double GetPosY() { return posY; }

	public override string ToString() => $"{ title } (pos: { posX }, { posY } | massa: {massa:E2} | raio: {GetRadius():F2}m)";
}

public static class Program
{
	public static void Main()
	{
		CorpoCeleste c1  = new CorpoCeleste( "Corpo 1", 120.5,  340.0,  5.972e24,  5514.0 );
		CorpoCeleste c2  = new CorpoCeleste( "Corpo 2", 800.0,  150.3,  1.989e30,  1410.0 );
		CorpoCeleste c3  = new CorpoCeleste( "Corpo 3", 450.7,  920.1,  7.342e22,  3346.0 );
		CorpoCeleste c4  = new CorpoCeleste( "Corpo 4", 33.0,   670.5,  6.39e23,   3933.0 );
		CorpoCeleste c5  = new CorpoCeleste( "Corpo 5", 1200.0, 88.4,   1.898e27,  1326.0 );
		CorpoCeleste c6  = new CorpoCeleste( "Corpo 6", 560.2,  430.9,  5.683e26,  687.0 );
		CorpoCeleste c7  = new CorpoCeleste( "Corpo 7", 75.0,   510.0,  8.681e25,  1271.0 );
		CorpoCeleste c8  = new CorpoCeleste( "Corpo 8", 990.3,  220.7,  1.024e26,  1638.0 );
		CorpoCeleste c9  = new CorpoCeleste( "Corpo 9", 310.0,  760.5,  1.303e22,  2000.0 );
		CorpoCeleste c10 = new CorpoCeleste( "Corpo 10", 640.8,  55.2,   3.301e23,  5427.0 );

		CorpoCeleste maiorMassa = CorpoCeleste.All.OrderByDescending(c => c.GetMass()).First();

		CorpoCeleste maiorRaio = CorpoCeleste.All.OrderByDescending(c => c.GetRadius()).First();

		CorpoCeleste? corpA = null, corpB = null;
		double maiorDistancia = -1;

		for (int i = 0; i < CorpoCeleste.All.Count; i++)
		{
			for (int j = i + 1; j < CorpoCeleste.All.Count; j++)
			{
				var a = CorpoCeleste.All[i];
				var b = CorpoCeleste.All[j];

				double dx = a.GetPosX() - b.GetPosX();
				double dy = a.GetPosY() - b.GetPosY();
				double dist = Math.Sqrt(dx * dx + dy * dy);

				if (dist > maiorDistancia)
				{
					maiorDistancia = dist;
					corpA = a;
					corpB = b;
				}
			}
		}

		Console.WriteLine($"Maior massa: { maiorMassa }");
		Console.WriteLine($"Maior raio: { maiorRaio }");
		Console.WriteLine($"Mais distantes: { corpA } e { corpB } ({maiorDistancia:F2} unidades)");
	}
}