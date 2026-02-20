using System;

class Livro
{
    private string titulo;

    public Livro(string titulo)
    {
        this.titulo = titulo;
    }

    public string GetTitulo()
    {
        return titulo;
    }
}

class Pessoa
{
    private string nome;

    public Pessoa(string nome)
    {
        this.nome = nome;
    }

    public string GetNome()
    {
        return nome;
    }
}

class Emprestimo
{
    private Livro livro;
    private Pessoa pessoa;

    public Emprestimo(Livro livro, Pessoa pessoa)
    {
        this.livro = livro;
        this.pessoa = pessoa;
    }

    public void MostrarEmprestimo()
    {
        Console.WriteLine("\nEmpréstimo realizado com sucesso.");
        Console.WriteLine("Pessoa: " + pessoa.GetNome());
        Console.WriteLine("Livro: " + livro.GetTitulo());
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Digite o nome da pessoa: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o nome do livro: ");
        string titulo = Console.ReadLine();

        Pessoa pessoa = new Pessoa(nome);
        Livro livro = new Livro(titulo);

        Emprestimo emprestimo = new Emprestimo(livro, pessoa);
        emprestimo.MostrarEmprestimo();
    }
}