using Alura.Adopet.Console;
using System.Net.Http.Headers;

// cria instância de HttpClient para consumir API Adopet
HttpClient client = ConfiguraHttpClient("http://localhost:5057");
Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    switch (comando)
    {
        case "import":
            var import = new Import(client);
            await import.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
            break;
        case "help":
            var help = new Help();
            help.ExibeDocumentacao(args);
            break;
        case "show":
            var show = new Show();
            show.ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]);
            break;
        case "list":
            var list = new List(client);
            await list.ListaDadosPetsDaAPIAsync();
            break;
        default:
            // exibe mensagem de comando inválido
            Console.WriteLine("Comando inválido!");
            break;
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}

HttpClient ConfiguraHttpClient(string url)
{
    HttpClient _client = new HttpClient();
    _client.DefaultRequestHeaders.Accept.Clear();
    _client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    _client.BaseAddress = new Uri(url);
    return _client;
}