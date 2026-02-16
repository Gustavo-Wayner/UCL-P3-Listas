import java.util.Scanner; 
public class Main 
{ 
	public static void main(String[] args) 
	{ 
		Scanner teclado = new Scanner(System.in); 
		double x1, y1, x2, y2, distancia; 
		System.out.println("Entre com as coordenadas x e y dos pontos nesta ordem:"); 
		x1 = teclado.nextFloat(); 
		y1 = teclado.nextFloat(); 
		x2 = teclado.nextFloat(); 
		y2 = teclado.nextFloat(); 

		teclado.close();

		// distancia = Math.pow(Math.pow(x2-x1, 2) + Math.pow(y2-y1, 2), 1/2); 
		// 
		// A distancia sempre retornava 1, pois na parte de 1/2, ja que ambos são inteiros,
		// o resultado também era inteiro e 0.5 era truncado para 0. Todos os numeros elevados
		// a 0 são iguais a 1
		//
		// Soluções: escrever diretamente 0.5, fazer a divisão com doubles (1.0/2.0)
		//		ou simplesmente usar a função sqrt

		distancia = Math.sqrt(Math.pow(x2-x1, 2) + Math.pow(y2-y1, 2));

		System.out.println("A distância é: " + distancia);
	}
}