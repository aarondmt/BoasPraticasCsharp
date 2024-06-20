namespace Alura.Adopet.Console.Comandos;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DocComando : Attribute
{
    public DocComando(string instrucao, string documentacao)
    {
        Instrucao = instrucao;
        Documentacao = documentacao;
    }

    public string Instrucao { get; }
    public string Documentacao { get; }
}
