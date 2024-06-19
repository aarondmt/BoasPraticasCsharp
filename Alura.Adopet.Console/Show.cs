namespace Alura.Adopet.Console;

[DocComando(instrucao: "show", documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show
{
    public void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
    {
        LeitorDeArquivo leitorDeArquivo = new();
        var listaDePets = leitorDeArquivo.RealizaLeitura(caminhoDoArquivoASerExibido);
        foreach (var pet in listaDePets)
        {
            System.Console.WriteLine(pet);
        }
    }
}
