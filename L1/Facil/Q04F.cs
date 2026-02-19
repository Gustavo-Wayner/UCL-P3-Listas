using System;

namespace Program;

public static class Fibonacci
{
    public static string ToCommaNoation( int n )
    {
        string n_str = n.ToString();
        int l = n_str.Length;

        for ( int i = l - 3; i > 0; i -= 3 )
        {
            n_str = n_str.Insert( i, "." );
        }

        return n_str;
    }

    public static void Main()
    {
        Console.WriteLine( "0" );
        int f = 1;
        int prev = 0;

        for ( int i = 0; i < 29; i++ )
        {
            Console.WriteLine( ToCommaNoation( f ) );
            f += prev;
            prev = f - prev;
        }
    }
}