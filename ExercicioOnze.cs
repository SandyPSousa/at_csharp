using System;
using System.IO;

class ExercicioOnze
{
    private static string caminhoArquivo = "contatos_exercicio11.txt";

    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("=== Gerenciador de Contatos ===\n");

        while (true)
        {
            ExibirMenu();

            string? opcao = Console.ReadLine();
            if (opcao == "1")
            {
                AdicionarContato();
            }
            else if (opcao == "2")
            {
                ListarContatos();
            }
            else if (opcao == "3")
            {
                Console.WriteLine("Encerrando programa...");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }

    private static void ExibirMenu()
    {
        Console.WriteLine("1 - Adicionar novo contato");
        Console.WriteLine("2 - Listar contatos cadastrados");
        Console.WriteLine("3 - Sair");
        Console.Write("Escolha uma opção: ");
    }

    private static void AdicionarContato()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? string.Empty;

        using (StreamWriter sw = File.AppendText(caminhoArquivo))
        {
            sw.WriteLine($"{nome},{telefone},{email}");
        }

        Console.WriteLine("Contato cadastrado com sucesso!");
    }

    private static void ListarContatos()
    {
        if (!File.Exists(caminhoArquivo) || new FileInfo(caminhoArquivo).Length == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("Contatos cadastrados:\n");

        string[] linhas = File.ReadAllLines(caminhoArquivo);
        foreach (string linha in linhas)
        {
            string[] partes = linha.Split(',');
            if (partes.Length == 3)
            {
                Console.WriteLine($"Nome: {partes[0]} | Telefone: {partes[1]} | Email: {partes[2]}");
            }
            else
            {
                Console.WriteLine("Erro ao ler um contato. Verifique o arquivo.");
            }
        }
    }
}
