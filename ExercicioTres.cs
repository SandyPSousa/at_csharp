using System;

class ExercicioTres
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("Exercício 3: Calculadora de Operações Matemáticas\n");

        double num1 = SolicitarNumero("Digite o primeiro número: ");
        double num2 = SolicitarNumero("Digite o segundo número: ");

        Console.WriteLine("\nEscolha uma operação:");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");

        int opcao = SolicitarOpcao();

        double resultado = 0;
        switch (opcao)
        {
            case 1:
                resultado = num1 + num2;
                Console.WriteLine($"\nResultado: {num1} + {num2} = {resultado}");
                break;
            case 2:
                resultado = num1 - num2;
                Console.WriteLine($"\nResultado: {num1} - {num2} = {resultado}");
                break;
            case 3:
                resultado = num1 * num2;
                Console.WriteLine($"\nResultado: {num1} * {num2} = {resultado}");
                break;
            case 4:
                if (num2 != 0)
                {
                    resultado = num1 / num2;
                    Console.WriteLine($"\nResultado: {num1} / {num2} = {resultado}");
                }
                else
                {
                    Console.WriteLine("\nErro: Não é possível dividir por zero.");
                }
                break;
            default:
                Console.WriteLine("\nOpção inválida.");
                break;
        }
    }

    private static double SolicitarNumero(string mensagem)
    {
        double numero;
        bool validInput;
        do
        {
            Console.Write(mensagem);
            validInput = double.TryParse(Console.ReadLine(), out numero);
            if (!validInput)
                Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
        } while (!validInput);
        return numero;
    }

    private static int SolicitarOpcao()
    {
        int opcao;
        bool validInput;
        do
        {
            Console.Write("\nDigite o número da operação desejada (1-4): ");
            validInput = int.TryParse(Console.ReadLine(), out opcao);
            if (!validInput || opcao < 1 || opcao > 4)
                Console.WriteLine("Opção inválida. Por favor, escolha entre 1 e 4.");
        } while (!validInput || opcao < 1 || opcao > 4);
        return opcao;
    }
}
