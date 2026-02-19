namespace Area;

public static class Prog
{
    public static float parse( string prompt )
    {
        while ( true )
        {
            Console.Write( prompt );
            if ( float.TryParse(Console.ReadLine(), out float f ) ) return f;
            Console.WriteLine( "Digite um número!" );
        }
    }
	public static void Main()
	{
		Rectangle rect = new Rectangle( parse( "Informe o cumprimento da base do retangulo: " ), parse( "Informe a altura do retangulo: " ) );

        rect.log();
	}
}

public class Rectangle
{
    private float b;
    private float h;

    public Rectangle( float _b, float _h )
    {
        b = _b;
        h = _h;
    }

    public float getArea()
    {
        return b * h;
    }

    public void log()
    {
        Console.WriteLine( $"Base: { b }\nAltura: { h }\nArea: { getArea() }m²" );
    }
}