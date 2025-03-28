using System;

class ExercicioQuatro
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("Exercício 4: Manipulação de Datas - Dias até o Próximo Aniversário\n");

        DateTime dataNascimento = SolicitarDataNascimento();

        DateTime proximoAniversario = CalcularProximoAniversario(dataNascimento);

        TimeSpan diferenca = proximoAniversario - DateTime.Now;

        if (diferenca.Days <= 7)
        {
            Console.WriteLine($"\nEba!! Seu próximo aniversário será em {diferenca.Days} dias! ");
        }
        else
        {
            Console.WriteLine($"\nFaltam {diferenca.Days} dias para o seu próximo aniversário.");
        }
    }

    private static DateTime SolicitarDataNascimento()
    {
        DateTime dataNascimento;
        bool validInput;
        do
        {
            Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
            validInput = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento);
            if (!validInput)
                Console.WriteLine("Formato inválido. Por favor, insira a data no formato correto (dd/MM/yyyy).");
        } while (!validInput);

        return dataNascimento;
    }

    private static DateTime CalcularProximoAniversario(DateTime dataNascimento)
    {
        DateTime aniversarioEsteAno = new DateTime(DateTime.Now.Year, dataNascimento.Month, dataNascimento.Day);

        if (aniversarioEsteAno < DateTime.Now)
        {
            aniversarioEsteAno = aniversarioEsteAno.AddYears(1);
        }

        return aniversarioEsteAno;
    }
}
