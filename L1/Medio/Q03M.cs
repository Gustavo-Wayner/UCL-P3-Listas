using System;

class Person
{
    private string name;
    private int age;

    public Person()
    {
        name = "";
        age = 0;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string GetName()
    {
        return name;
    }

    public int GetAge()
    {
        return age;
    }

	// variavel em portugues pq pediu na questao
    public void ExibirDados()
    {
        Console.WriteLine("Nome: " + name);
        Console.WriteLine("Idade: " + age);
    }
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Insira o nome: ");
            string name = Console.ReadLine();

            Console.Write("Insira a idade: ");
			int age;
			while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
			{
    			Console.Write("Idade inválida. Insira novamente: ");
			}

            people[i] = new Person(name, age);
            Console.WriteLine();
        }

        Person oldestPerson = people[0];

        for (int i = 1; i < 3; i++)
        {
            if (people[i].GetAge() > oldestPerson.GetAge())
            {
                oldestPerson = people[i];
            }
        }

        Console.WriteLine("Pessoa mais velha:");
        oldestPerson.ExibirDados();
    }
}