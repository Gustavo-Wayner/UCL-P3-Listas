public class Lamp
{
	private Random rand = new();
	private bool is_burned;
	private bool is_on;
	private float power;
	private float voltage;

	public void SetPower(float p) { power = p; }
	public float GetPower() { return power; }

	public void SetVoltage(float v) { voltage = v; }
	public float GetVoltage() { return voltage; }

	public bool IsOn()
	{
		if ( is_burned ) Console.WriteLine("A lampada ta queimada fi");
		return is_on;
	}

	public bool IsBurned() { return is_burned; }

	public Lamp( float _power, float _voltage )
	{
		power = _power;
		voltage = _voltage;
		is_burned = false;
		is_on = false;
	}

	public override string ToString()
	{
		return $"{(is_burned ? "Queimada" : is_on ? "Ligada" : "Desligada")} | Voltagem: { voltage }V | Potência: { power }W";
	}

	public void Switch()
	{
		if ( ( is_on && rand.NextDouble() <= 0.15 ) || is_burned )
		{
			Console.WriteLine("A lampada queimou");
			is_burned = true;
			is_on = false;
			return;
		}
		is_on = !is_on;
		Console.WriteLine($"A lampada {(is_on ? "foi ligada" : "foi desligada")}");
	}
}

public static class Test
{
	public static void Main()
	{
		Lamp lamp = new( 120, 120 );
		Console.WriteLine( lamp );

		while ( !lamp.IsBurned() )
		{
			lamp.Switch();
		}

		lamp.Switch();
		Console.WriteLine( lamp );

		lamp.Switch();
		Console.WriteLine( lamp );

		Console.WriteLine( lamp.IsOn() );
	}
}