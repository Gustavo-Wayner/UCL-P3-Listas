using System;

class Pessoa
{
    private string nome;
    private int idade;
    private Pessoa pai;
    private Pessoa mae;

    public Pessoa(string nome, int idade, Pessoa pai = null, Pessoa mae = null)
    {
        this.nome = nome;
        this.idade = idade;
        this.pai = pai;
        this.mae = mae;
    }

    public string GetNome() { return nome; }
    public int GetIdade() { return idade; }
    public Pessoa GetPai() { return pai; }
    public Pessoa GetMae() { return mae; }

    public void SetNome(string nome) { this.nome = nome; }
    public void SetIdade(int idade) { this.idade = idade; }
    public void SetPai(Pessoa pai) { this.pai = pai; }
    public void SetMae(Pessoa mae) { this.mae = mae; }

    public void MostrarArvore()
    {
        Console.WriteLine($"Nome: {nome}, idade: {idade}");
        if (pai != null)
            Console.WriteLine($"Pai: {pai.GetNome()}");
        if (mae != null)
            Console.WriteLine($"Mãe: {mae.GetNome()}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Digite o nome do filho: ");
        string nomeFilho = Console.ReadLine();

        Console.Write("Digite a idade do filho: ");
        int idadeFilho = int.Parse(Console.ReadLine());

        Console.Write("Digite o nome do pai: ");
        string nomePai = Console.ReadLine();

        Console.Write("Digite a idade do pai: ");
        int idadePai = int.Parse(Console.ReadLine());

        Console.Write("Digite o nome da mãe: ");
        string nomeMae = Console.ReadLine();

        Console.Write("Digite a idade da mãe: ");
        int idadeMae = int.Parse(Console.ReadLine());

        Pessoa pai = new Pessoa(nomePai, idadePai);
        Pessoa mae = new Pessoa(nomeMae, idadeMae);
        Pessoa filho = new Pessoa(nomeFilho, idadeFilho, pai, mae);

        Console.WriteLine("\n- Árvore Genealógica -");
        filho.MostrarArvore();
    }
}