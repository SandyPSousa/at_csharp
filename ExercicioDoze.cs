using System;
using System.Collections.Generic;
using System.IO;

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public Contato(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
}

// Classe base para formatadores de exibição de contatos.
abstract class ContatoFormatter
{
    public abstract void ExibirContatos(List<Contato> contatos);
}

// Exibição no formato Markdown.
class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("## Lista de Contatos\n");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.Nome}");
            Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
            Console.WriteLine($"- 📧 Email: {contato.Email}\n");
        }
    }
}

// Exibição no formato de tabela.
class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("| Nome          | Telefone      | Email              |");
        Console.WriteLine("----------------------------------------");

        foreach (var contato in contatos)
        {
            Console.WriteLine($"| {contato.Nome,-12} | {contato.Telefone,-12} | {contato.Email,-18} |");
        }
        Console.WriteLine("----------------------------------------");
    }
}

// Exibição no formato "texto puro".
class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        foreach (var contato in contatos)
        {
            Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
        }
    }
}

// Classe que gerencia a leitura e escrita dos contatos no arquivo "contatos.txt".
class GerenciadorContatos
{
    private static string caminhoArquivo = "contatos.txt";

    public static void SalvarContato(Contato contato)
    {
        using (StreamWriter sw = File.AppendText(caminhoArquivo))
        {
            sw.WriteLine($"{contato.Nome},{contato.Telefone},{contato.Email}");
        }
    }

    public static List<Contato> CarregarContatos()
    {
        List<Contato> contatos = new List<Contato>();

        if (!File.Exists(caminhoArquivo))
        {
            File.Create(caminhoArquivo).Close();
            return contatos;
        }

        try
        {
            string[] linhas = File.ReadAllLines(caminhoArquivo);
            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(',');
                if (partes.Length == 3)
                {
                    contatos.Add(new Contato(partes[0], partes[1], partes[2]));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar contatos: {ex.Message}");
        }

        return contatos;
    }
}

// Exibe o menu e acompanha o fluxo do programa.
class ExercicioDoze
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("Exercício 12: Gerenciamento de Contatos\n");

        while (true)
        {
            ExibirMenu();
            string? opcao = Console.ReadLine();

            if (opcao == "1")
            {
                CadastrarContato();
            }
            else if (opcao == "2")
            {
                ExibirContatos();
            }
            else if (opcao == "3")
            {
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
        Console.WriteLine("\nEscolha uma opção:");
        Console.WriteLine("1 - Cadastrar Contato");
        Console.WriteLine("2 - Exibir Contatos");
        Console.WriteLine("3 - Sair");
    }

    private static void CadastrarContato()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? string.Empty;

        Contato contato = new Contato(nome, telefone, email);
        GerenciadorContatos.SalvarContato(contato);

        Console.WriteLine("Contato cadastrado com sucesso!");
    }

    private static void ExibirContatos()
    {
        List<Contato> contatos = GerenciadorContatos.CarregarContatos();

        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("\nEscolha o formato de exibição:");
        Console.WriteLine("1 - Markdown");
        Console.WriteLine("2 - Tabela");
        Console.WriteLine("3 - Texto Puro");

        string? escolha = Console.ReadLine();
        ContatoFormatter formatter;

        if (escolha == "1")
            formatter = new MarkdownFormatter();
        else if (escolha == "2")
            formatter = new TabelaFormatter();
        else
            formatter = new RawTextFormatter();

        formatter.ExibirContatos(contatos);
    }
}
