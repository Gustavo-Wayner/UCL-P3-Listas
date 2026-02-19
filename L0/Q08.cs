using System;

namespace Program;

public static class Fibonacci
{
    public static string ToCommaNoation( ulong n )
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
        int n;

        while ( true )
        {
            Console.Write( "Quantos numeros de fibonacci voce quer ver? " );
            if ( int.TryParse( Console.ReadLine(), out n ) && n >= 0 )
            {
                if( n == 0 )
                {
                    Console.WriteLine( "Ok flw!" );
                    return;
                }
                if ( n < 95 ) break;
                
                Console.WriteLine( "Um uint ( 64 bits ) é incapáz de representar um numero tão grande" );
            }
            else Console.WriteLine( "Digite um número natural!" );
        }

        Console.WriteLine( "0" );
        ulong f = 1;
        ulong prev = 0;

        for ( int i = 0; i < n-1; i++ )
        {
            Console.WriteLine( ToCommaNoation( f ) );
            f += prev;
            prev = f - prev;
        }
    }
}