namespace Area;

public abstract class Shape
{
	public virtual double Area() { return 0; }
	public virtual void LogArea() {}
};

public abstract class BaseHeight : Shape
{
	protected double b;
	protected double h;

	public BaseHeight( double _b, double _h )
	{
		b = _b;
		h = _h;
	}
};

public class Square : BaseHeight
{
	public Square( double sides ) : base( sides, sides ) {}
	public double GetSides()
	{
		return h;
	}
	public override double Area()
	{
		return Math.Pow( GetSides(), 2 );
	}

	public override void LogArea()
	{
		Console.WriteLine( $"A area de um quadrado com lados medindo { GetSides() }u é de: { Area() }u²" );
	}
}

public class Rectangle : BaseHeight
{
	public override double Area()
	{
		return b*h;
	}

	public Rectangle( double _b, double _h ) : base( _b, _h ) {}

	public override void LogArea()
	{
		Console.WriteLine( $"A area de um retangulo de base { b }u e altura { h }u é de: { Area() }u²" );
	}
}

public class Triangle : BaseHeight
{
	public override double Area()
	{
		return b*h*0.5;
	}

	public Triangle( double _b, double _h ) : base( _b, _h ) {}

	public override void LogArea()
	{
		Console.WriteLine( $"A area de um triangulo de base { b }u e altura { h }u é de: { Area() }u²" );
	}
}

public class Circle : Shape
{
	private double r;
	public override double Area()
	{
		return Math.PI*r*r;
	}

	public override void LogArea()
	{
		Console.WriteLine( $"A area de um circulo de raio { r }u é de: { Area() }u²" );
	}

	public Circle( double _r )
	{
		r = _r;
	}

	public double Radius()
	{
		return r;
	}

	public double Diameter()
	{
		return r*2;
	}
}

public static class Program
{
	public static void Main()
	{
		Square sq = new( 4 );
		Circle cr = new( 5 );
		Rectangle rc = new( 5, 8 );
		Triangle tr = new( 4, 9 );

		sq.LogArea();
		cr.LogArea();
		rc.LogArea();
		tr.LogArea();
	}
}