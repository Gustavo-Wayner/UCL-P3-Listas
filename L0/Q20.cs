using System;
using System.Collections.Generic;

class Contact
{
    private string name;
    private string phone;
    private string email;

    public Contact( string _name, string _phone, string _email = "" )
    {
        name = _name;
        phone = _phone;
        email = _email;
    }

    public override string ToString()
    {
        string info = $"Nome: { name } | Telefone: { phone }";
        if ( !string.IsNullOrEmpty( email ) )
            info += $" | Email: {email}";
        return info;
    }

    public string GetName()
    {
        return name;
    }

    public string GetPhone()
    {
        return phone;
    }

    public string GetEmail()
    {
        return email;
    }
}

class Schedule
{
    private List<Contact> contacts = new List<Contact>();

    public void Add( Contact cont )
    {
        contacts.Add( cont );
        Console.WriteLine( $"Contato '{ cont.GetName() }' adicionado com sucesso." );
    }

    public void Remove( string nome )
    {
        Contact? found = Search( nome );
        if (found != null)
        {
            contacts.Remove( found );
            Console.WriteLine( $"Contato '{ nome }' removido." );
        }
        else
        {
            Console.WriteLine( $"Contato '{ nome }' não encontrado." );
        }
    }

    public Contact? Search(string nome)
    {
        return contacts.Find( c => c.GetName().Equals( nome, StringComparison.OrdinalIgnoreCase ) );
    }

    public void List()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine( "Agenda vazia." );
            return;
        }
        Console.WriteLine( "\n--- Agenda ---" );
        foreach ( var contato in contacts )
            Console.WriteLine( contato );
        Console.WriteLine( "--------------" );
    }
}

class Program
{
    static void Main()
    {
        Schedule sched = new Schedule();

        while (true)
        {
            Console.WriteLine( "\n1. Adicionar  2. Buscar  3. Remover  4. Listar  5. Sair" );
            Console.Write( "Opção: " );
            string option = Console.ReadLine()!;

            switch ( option )
            {
                case "1":
                    Console.Write( "Nome: " );
                    string name = Console.ReadLine()!;
                    Console.Write( "Telefone: " );
                    string phone = Console.ReadLine()!;
                    Console.Write( "Email (opcional): " );
                    string email = Console.ReadLine()!;
                    sched.Add( new Contact( name, phone, email ) );
                    break;

                case "2":
                    Console.Write( "Nome a buscar: " );
                    Contact? found = sched.Search( Console.ReadLine()! );
                    Console.WriteLine( found != null ? found.ToString() : "Não encontrado." );
                    break;

                case "3":
                    Console.Write( "Nome a remover: " );
                    sched.Remove( Console.ReadLine()! );
                    break;

                case "4":
                    sched.List();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}