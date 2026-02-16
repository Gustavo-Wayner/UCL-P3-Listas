// Programa	A
import java.util.Scanner;
public class Main 
{
    public static void main(String[] args) 
    {
        Scanner teclado = new Scanner(System.in);
        int codigo;

        System.out.println("Informe o código: ");
        codigo = teclado.nextInt();
        while (codigo != -1)
        {
            System.out.println("Código: " + codigo);
            System.out.println("Informe o código: ");
            codigo = teclado.nextInt();
        }

        teclado.close();
    }
}

// Programa	B
/* import java.util.Scanner;
public class Main 
{
    public static void main(String[] args)
    {
        Scanner teclado = new Scanner(System.in);
        int codigo;

        do
        {
            System.out.print("Informe o código: ");
            codigo = teclado.nextInt();
            System.out.println("Código: " + codigo);
        } while (codigo != -1);

        teclado.close();
    }
}


O erro da solução B é que, no trecho:
    do
    {
        System.out.print("Informe o código: ");
        codigo = teclado.nextInt();
        System.out.println("Código: " + codigo);
    } while (codigo != -1);
o código é escrito antes de verificar se ele é igual a -1.
Para corrigir, basta fazer como na solução A, em que o usuário digita primeiro, o programa checa se o código é -1 e se não, procede a o escrever
*/