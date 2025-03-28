using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Escolha um exercício para executar (1 a 12) ou 0 para sair:");
            string? opcao = Console.ReadLine();

            if (opcao == "0")
                break;

            switch (opcao)
            {
                case "1":
                    ExercicioUm.Executar();
                    break;
                case "2":
                    ExercicioDois.Executar();
                    break;
                case "3":
                    ExercicioTres.Executar();
                    break;
                case "4":
                    ExercicioQuatro.Executar();
                    break;
                case "5":
                    ExercicioCinco.Executar();
                    break;
                case "6":
                    ExercicioSeis.Executar();
                    break;
                case "7":
                    ExercicioSete.Executar();
                    break;
                case "8":
                    ExercicioOito.Executar();
                    break;
                case "9":
                    ExercicioNove.Executar();
                    break;
                //case "10":
                //    ExercicioDez.Executar();
                //    break;
                //case "11":
                //    ExercicioOnze.Executar();
                //    break;
                //case "12":
                //    ExercicioDoze.Executar();
                //    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}