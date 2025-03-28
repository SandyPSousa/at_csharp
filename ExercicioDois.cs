using System;

class ExercicioDois
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("Exercício 2: Manipulação de Strings - Cifrador de Nome\n");

        Console.Write("Digite seu nome completo: ");
        string nome = Console.ReadLine() ?? "";

        string nomeCifrado = CifrarNome(nome);

        Console.WriteLine($"\nNome cifrado: {nomeCifrado}");
    }

    private static string CifrarNome(string nome)
    {
        char[] resultado = new char[nome.Length];

        for (int i = 0; i < nome.Length; i++)
        {
            char caractere = nome[i];

            if (char.IsLetter(caractere))
            {
                char baseLetra = char.IsUpper(caractere) ? 'A' : 'a';
                resultado[i] = (char)(baseLetra + (caractere - baseLetra + 2) % 26);
            }
            else
            {
                resultado[i] = caractere;
            }
        }

        return new string(resultado);
    }
}