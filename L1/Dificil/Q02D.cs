using System;

// A questao pede muitos nomes em portugues entao vou deixar quase tudo em pt-br
class Extrato
{
    private DateTime dataMovimentacao;
    private double valorMovimentado;

    public Extrato(DateTime dataMovimentacao, double valorMovimentado)
    {
        this.dataMovimentacao = dataMovimentacao;
        this.valorMovimentado = valorMovimentado;
    }

    public DateTime ObterData() => dataMovimentacao;
    public double ObterValor() => valorMovimentado;
}

class Cartao
{
    private string numeroCartao;
    private string validadeCartao;

    public Cartao(string numeroCartao, string validadeCartao)
    {
        this.numeroCartao = numeroCartao;
        this.validadeCartao = validadeCartao;
    }

    public string ObterNumeroCartao() => numeroCartao;
    public string ObterValidadeCartao() => validadeCartao;
}

class Conta
{
    private string nomeCliente;
    private int numeroConta;
    private double saldo;
    private Extrato[] extratos = new Extrato[1000];
    private int quantidadeExtratos = 0;
    private Cartao cartao;

    public Conta(string nomeCliente, int numeroConta, double saldo, Cartao cartao)
    {
        this.nomeCliente = nomeCliente;
        this.numeroConta = numeroConta;
        this.saldo = saldo;
        this.cartao = cartao;
    }

    public void Depositar(double valor)
    {
        if (valor > 0)
        {
            saldo += valor;
            extratos[quantidadeExtratos++] = new Extrato(DateTime.Now, valor);
        }
    }

    public void Sacar(double valor)
    {
        if (valor > 0 && valor <= saldo)
        {
            saldo -= valor;
            extratos[quantidadeExtratos++] = new Extrato(DateTime.Now, -valor);
        }
    }

    public double obterSaldo() => saldo;
    public int obterNumero() => numeroConta;
    public string obterNomeCliente() => nomeCliente;
    public Cartao ObterCartao() => cartao;

    public void ExibirExtrato()
    {
        for (int i = 0; i < quantidadeExtratos; i++)
            Console.WriteLine(extratos[i].ObterData() + " | " + extratos[i].ObterValor());
    }
}

class Program
{
    static void Main()
    {
        Conta[] contas = new Conta[3]
        {
            new Conta("Felipe", 1001, 1000, new Cartao("1111", "12/30")),
            new Conta("Carlos", 1002, 2000, new Cartao("2222", "11/29")),
            new Conta("Ana", 1003, 3000, new Cartao("3333", "10/28"))
        };

        contas[0].Depositar(500); contas[0].Sacar(200);
        contas[1].Depositar(1000); contas[1].Sacar(1500);
        contas[2].Depositar(700); contas[2].Sacar(100);

        Console.Write("Insira o número do cartão para saque: ");
        string numero = Console.ReadLine();

        Console.Write("Insira a validade do cartão: ");
        string validade = Console.ReadLine();

        Console.Write("Insira o valor do saque: ");
        double valor;
        while (!double.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            Console.Write("Valor inválido. Insira novamente: ");

        foreach (var conta in contas)
            if (conta.ObterCartao().ObterNumeroCartao() == numero &&
                conta.ObterCartao().ObterValidadeCartao() == validade)
                conta.Sacar(valor);

        Console.WriteLine("\nRelatório final\n");

        foreach (var conta in contas)
        {
            Console.WriteLine("Conta: " + conta.obterNumero());
            Console.WriteLine("Titular: " + conta.obterNomeCliente());
            Console.WriteLine("Saldo: " + conta.obterSaldo());
            Console.WriteLine("Extrato:");
            conta.ExibirExtrato();
            Console.WriteLine();
        }
    }
}