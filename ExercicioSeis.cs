using System;

class Aluno
{
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Curso { get; set; }
    public double MediaNotas { get; set; }

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Média das Notas: {MediaNotas:F2}");
    }

    public string VerificarAprovacao()
    {
        return MediaNotas >= 7 ? "Aprovado" : "Reprovado";
    }
}

class ExercicioSeis
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("Exercício 6: Cadastro de Alunos\n");

        Aluno aluno = new Aluno
        {
            Nome = "Sandy Sousa",  
            Matricula = "123456", 
            Curso = "Engenharia de Software",
            MediaNotas = 9.0
        };

        aluno.ExibirDados();

        string statusAprovacao = aluno.VerificarAprovacao();
        Console.WriteLine($"\nStatus: {statusAprovacao}");
    }
}