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
        Console.WriteLine("Exercício 9: Controle de Estoque via Linha de Comando\n");

        while (true)
        {
            ExibirMenu();

            string? opcao = Console.ReadLine();
            if (opcao == "1")
            {
                InserirProduto();
            }
            else if (opcao == "2")
            {
                ListarProdutos();
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
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Inserir Produto");
        Console.WriteLine("2 - Listar Produtos");
        Console.WriteLine("3 - Sair");
    }

    private static void InserirProduto()
    {
        if (contadorProdutos >= 5)
        {
            Console.WriteLine("Limite de produtos atingido!");
            return;
        }

        Console.Write("Nome do Produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Quantidade em Estoque: ");
        int quantidade = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Preço Unitário: ");
        decimal preco = decimal.Parse(Console.ReadLine() ?? "0");

        Produto produto = new Produto(nome, quantidade, preco);
        produtos[contadorProdutos] = produto;
        contadorProdutos++;

        try
        {
            SalvarProdutoNoArquivo(produto);
            Console.WriteLine("Produto inserido com sucesso!");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro ao tentar salvar o produto no arquivo: {ex.Message}");
        }
    }

    private static void ListarProdutos()
    {
        try
        {
            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                if (linhas.Length == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                }
                else
                {
                    Console.WriteLine("Produtos cadastrados:");
                    foreach (string linha in linhas)
                    {
                        string[] partes = linha.Split(',');

                        if (partes.Length != 3)
                        {
                            Console.WriteLine("Formato inválido de dados no arquivo.");
                            continue;
                        }

                        string nome = partes[0];
                        int quantidade = int.Parse(partes[1]);
                        decimal preco = decimal.Parse(partes[2]);

                        Console.WriteLine($"Produto: {nome} | Quantidade: {quantidade} | Preço: R$ {preco:F2}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro ao tentar ler o arquivo de produtos: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Erro no formato dos dados ao listar os produtos: {ex.Message}");
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
        catch (IOException ex)
        {
            Console.WriteLine($"Erro ao salvar o produto no arquivo: {ex.Message}");
        }
    }
}
