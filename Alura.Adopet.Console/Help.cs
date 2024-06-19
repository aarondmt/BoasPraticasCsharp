using System.Reflection;

namespace Alura.Adopet.Console;

[DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informações de ajuda.\nadopet help <NOME_COMANDO> para acessar a ajuda de um comando especifico.")]
internal class Help
{
    private Dictionary<string, DocComando> docs;

    public Help()
    {
        docs = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetCustomAttributes<DocComando>().Any())
            .Select(t => t.GetCustomAttribute<DocComando>()!)
            .ToDictionary(d => d.Instrucao);
    }

    public void ExibeDocumentacao(string[] args)
    {
        // se não passou mais nenhum argumento mostra help de todos os comandos
        if (args.Length == 1)
        {
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            foreach (var doc in docs.Values)
            {
                ExibirDocumentacao(doc);
            }
        }
        // exibe o help daquele comando específico
        else if (args.Length == 2)
        {
            string comandoASerExibido = args[1];
            if (docs.ContainsKey(comandoASerExibido))
            {
                var comando = docs[comandoASerExibido];
                ExibirDocumentacao(comando);
            }
            else
                System.Console.WriteLine("O comando não existe.");
        }
    }

    private static void ExibirDocumentacao(DocComando doc)
    {
        foreach (var descricao in doc.Documentacao)
        {
            System.Console.WriteLine(descricao);
        }
    }
}
