public class Point
{
	private double x;
	private double y;

	public double GetX() { return x; }
	public double GetY() { return y; }

	public Point()
	{
		x = 0;
		y = 0;
	}

	public Point( double _x, double _y )
	{
		x = _x;
		y = _y;
	}

	public Point( Point other )
	{
		x = other.GetX();
		y = other.GetY();
	}
}