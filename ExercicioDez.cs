using System;

class ExercicioDez
{
    public static void Executar()
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 51);
        int tentativasRestantes = 5;
        bool acertou = false;

        Console.WriteLine("Jogo de Adivinhação!");
        Console.WriteLine("Tente adivinhar o número entre 1 e 50.");

        while (tentativasRestantes > 0)
        {
            Console.Write($"Você tem {tentativasRestantes} tentativas. Digite um número: ");

            try
            {
                int palpite = int.Parse(Console.ReadLine() ?? "0");

                if (palpite < 1 || palpite > 50)
                {
                    Console.WriteLine("Erro: O número deve estar entre 1 e 50.");
                    continue;
                }

                if (palpite == numeroSecreto)
                {
                    Console.WriteLine("Parabéns! Você acertou o número.");
                    acertou = true;
                    break;
                }
                else if (palpite < numeroSecreto)
                {
                    Console.WriteLine("O número é maior.");
                }
                else
                {
                    Console.WriteLine("O número é menor.");
                }

                tentativasRestantes--;
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Digite um número válido.");
            }
        }

        if (!acertou)
        {
            Console.WriteLine($"Fim de jogo! O número era {numeroSecreto}.");
        }
    }
}