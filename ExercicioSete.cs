using System;

class ContaBancaria
{
    public string Titular { get; set; }
    private decimal Saldo { get; set; }  // Tornando o atributo "Saldo" privado 

    // Método para depositar valores na conta
    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
        }
        else
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
        }
    }

    // Método para sacar valor da conta
    public void Sacar(decimal valor)
    {
        if (valor > Saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
        }
        else
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
        }
    }

    // Método para exibir o saldo atual da conta
    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: R$ {Saldo:F2}");
    }
}

class ExercicioSete
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("Exercício 7: Banco Digital (Encapsulamento)\n");

        // Criando o objeto "ContaBancaria"
        ContaBancaria conta = new ContaBancaria
        {
            Titular = "Sandy Sousa"
        };

        // Exibindo o titular da conta
        Console.WriteLine($"Titular: {conta.Titular}\n");

        // Realizando depósitos
        conta.Depositar(500); 
        conta.Depositar(-500);// Teste para o depósito de valor negativo
        conta.ExibirSaldo();

        // Tentando realizar um saque maior que o saldo
        Console.WriteLine("\nTentativa de saque: R$ 700,00");
        conta.Sacar(700); 
        conta.ExibirSaldo();

        // Realizando um saque válido
        conta.Sacar(200); 
        conta.ExibirSaldo();
    }
}
