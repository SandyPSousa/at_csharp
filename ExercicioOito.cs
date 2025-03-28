using System;

class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal SalarioBase { get; set; }

    public Funcionario(string nome, string cargo, decimal salarioBase)
    {
        Nome = nome;
        Cargo = cargo;
        SalarioBase = salarioBase;
    }

    public virtual decimal CalcularSalario()
    {
        return SalarioBase;
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Salário Base: R$ {SalarioBase:F2}");
        Console.WriteLine($"Salário com Bônus: R$ {CalcularSalario():F2}");
    }
}

class Gerente : Funcionario
{
    public Gerente(string nome, decimal salarioBase)
        : base(nome, "Gerente", salarioBase)
    {
    }

    public override decimal CalcularSalario()
    {
        return SalarioBase * 1.2m; // Bônus de 20% no salário
    }
}

class ExercicioOito
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("Exercício 8: Cadastro de Funcionários (Herança)\n");

        // Criando um objeto da classe "Funcionario"
        Funcionario funcionario = new Funcionario("Sandy Sousa", "Estagiário", 2000);
        funcionario.ExibirDados();

        Console.WriteLine("\n");

        // Criando um objeto da classe "Gerente"
        Gerente gerente = new Gerente("Thais Sousa", 7000);
        gerente.ExibirDados();
    }
}