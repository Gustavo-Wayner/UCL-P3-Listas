/* 
1) Desenvolva uma classe Lâmpada, a qual pode ser ligada e desligada. Também deve ser possível 
		observar o estado da lâmpada (se desligada ou ligada).
X	Desenvolva uma nova classe para a lâmpada de forma a incluir as características
		de potência e voltagem. Garanta que seja possível tanto ler quanto alterar os valores de potência e voltagem
		de uma lâmpada.
•	Crie uma classe Teste com um método main para testar as classes desenvolvidas nos
		exercícios 1 e 2. Crie uma lâmpada, apresente no console as informações de estado
		(se ligada ou desligada, potência e voltagem), ligue a lâmpada e apresente novamente as informações de estado.
•	Modifique a classe da lâmpada criada anteriormente para incluir o caso de uma
		lâmpada queimar ao ser ligada. Sabe-se que existe uma chance de 15% da lâmpada queimar ao
		ser ligada. Dica: neste exercício é importante pesquisar na biblioteca de classes fornecida pela
		linguagem de programação uma classe que dê suporte à geração de números aleatórios
 */

public class Lamp
{
	private bool is_on;
	private float power;
	private float voltage;

	public void SetPower(float p) { power = p; }
	public float GetPower() { return power; }

	public void SetVoltage(float v) { voltage = v; }
	public float GetVoltage() { return voltage; }

	public bool IsOn()
	{
		return is_on;
	}

	public Lamp( float _power, float _voltage )
	{
		power = _power;
		voltage = _voltage;
		is_on = false;
	}

	public override string ToString()
	{
		return $"Lampada {(is_on ? "ligada" : "desligada")} | Voltagem: { voltage }V | Potência: { power }W";
	}

	public void Switch()
	{
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

		lamp.Switch();
		Console.WriteLine( lamp );

		lamp.Switch();
		Console.WriteLine( lamp );
	}
}