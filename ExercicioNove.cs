using System;
using System.IO;

class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }

    public Produto(string nome, int quantidade, decimal preco)
    {
        Nome = nome;
        Quantidade = quantidade;
        Preco = preco;
    }

    public override string ToString()
    {
        return $"Produto: {Nome} | Quantidade: {Quantidade} | Preço: R$ {Preco:F2}";
    }
}

class ExercicioNove
{
    private static string caminhoArquivo = "estoque.txt";
    private static Produto[] produtos = new Produto[5];
    private static int contadorProdutos = 0;

    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine(" Exercício 9: Controle de Estoque via Linha de Comando\n");

        while (true)
        {
            ExibirMenu();

            string? opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    InserirProduto();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    ExibirArquivoTexto();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine(" Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void ExibirMenu()
    {
        Console.WriteLine("\n Escolha uma opção:");
        Console.WriteLine("1 - Inserir Produto");
        Console.WriteLine("2 - Listar Produtos");
        Console.WriteLine("3 - Listar Produtos pelo Arquivo estoque.txt"); //Opção simples para ver a lista de produtos no arquivo txt, formatada de acordo com o enunciado.
        Console.WriteLine("4 - Sair");
    }

    private static void InserirProduto()
    {
        if (contadorProdutos >= 5)
        {
            Console.WriteLine(" Limite de produtos atingido!");
            return;
        }

        Console.Write(" Nome do Produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write(" Quantidade em Estoque: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade))
        {
            Console.WriteLine(" Quantidade inválida.");
            return;
        }

        Console.Write(" Preço Unitário: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
        {
            Console.WriteLine(" Preço inválido.");
            return;
        }

        Produto produto = new Produto(nome, quantidade, preco);
        produtos[contadorProdutos] = produto;
        contadorProdutos++;

        SalvarProdutoNoArquivo(produto);
        Console.WriteLine(" Produto inserido com sucesso!");
    }

    private static void ListarProdutos()
    {
        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine(" Nenhum produto cadastrado.");
            return;
        }

        try
        {
            string[] linhas = File.ReadAllLines(caminhoArquivo);
            if (linhas.Length == 0)
            {
                Console.WriteLine(" Nenhum produto cadastrado.");
            }
            else
            {
                Console.WriteLine("\n Produtos cadastrados:");
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(',');
                    if (partes.Length != 3)
                    {
                        Console.WriteLine(" Erro ao ler um dos produtos. Formato inválido.");
                        continue;
                    }

                    string nome = partes[0];
                    if (!int.TryParse(partes[1], out int quantidade) || !decimal.TryParse(partes[2], out decimal preco))
                    {
                        Console.WriteLine(" Produto corrompido: " + linha);
                        continue;
                    }

                    Console.WriteLine($" Produto: {nome} |  Quantidade: {quantidade} |  Preço: R$ {preco:F2}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Erro ao ler o arquivo: {ex.Message}");
        }
    }

    private static void ExibirArquivoTexto()
    {
        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine(" O arquivo estoque.txt ainda não foi criado.");
            return;
        }

        Console.WriteLine("\n Conteúdo do Arquivo estoque.txt:");
        try
        {
            string conteudo = File.ReadAllText(caminhoArquivo);
            Console.WriteLine(conteudo);
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Erro ao ler o arquivo: {ex.Message}");
        }
    }

    private static void SalvarProdutoNoArquivo(Produto produto)
    {
        try
        {
            using (StreamWriter sw = File.AppendText(caminhoArquivo))
            {
                sw.WriteLine($"{produto.Nome},{produto.Quantidade},{produto.Preco:F2}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Erro ao salvar no arquivo: {ex.Message}");
        }
    }
}
