using Alura.Adopet.Console.Util;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informações de ajuda.\nadopet help <NOME_COMANDO> para acessar a ajuda de um comando especifico.")]
internal class Help : IComando
{
    private Dictionary<string, DocComando> docs;

    public Help()
    {
        docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
    }

    public Task ExecutarAsync(string[] args)
    {
        ExibeDocumentacao(args);
        return Task.CompletedTask;
    }

    private void ExibeDocumentacao(string[] args)
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
        System.Console.WriteLine(doc.Documentacao);
    }
}
