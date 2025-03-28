using System;

class ExercicioCinco
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("Exercício 5: Tempo Restante para Conclusão do Curso - Diferença Entre Datas\n");

        DateTime dataFormatura = new DateTime(2025, 6, 15);

        DateTime dataAtual = SolicitarDataAtual();

        if (dataAtual > DateTime.Now)
        {
            Console.WriteLine("\nErro: A data informada não pode ser no futuro!");
            return;
        }

        if (dataAtual > dataFormatura)
        {
            Console.WriteLine("\nParabéns! Você já deveria estar formado!");
            return;
        }

        TimeSpan diferenca = dataFormatura - dataAtual;
        int anos = diferenca.Days / 365;
        int meses = (diferenca.Days % 365) / 30;
        int dias = (diferenca.Days % 365) % 30;

        Console.WriteLine($"\nFaltam {anos} ano(s), {meses} mês(es) e {dias} dia(s) para a sua formatura!");

        if (anos == 0 && meses < 6)
        {
            Console.WriteLine("\nA reta final chegou! Prepare-se para a formatura!");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    private static DateTime SolicitarDataAtual()
    {
        DateTime dataAtual;
        bool validInput;
        do
        {
            Console.Write("Digite a data atual (dd/MM/yyyy): ");
            validInput = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataAtual);
            if (!validInput)
                Console.WriteLine("Formato inválido. Por favor, insira a data no formato correto (dd/MM/yyyy).");
        } while (!validInput);

        return dataAtual;
    }
}
