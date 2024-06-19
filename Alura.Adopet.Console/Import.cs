using System.Net.Http.Json;

namespace Alura.Adopet.Console;

[DocComando(instrucao: "import", documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
internal class Import : CommonAbstract
{
    public Import(HttpClient client) : base(client)
    { }

    public async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        LeitorDeArquivo leitorDeArquivo = new();
        List<Pet> listaDePet = leitorDeArquivo.RealizaLeitura(caminhoDoArquivoDeImportacao);
        foreach (var pet in listaDePet)
        {
            System.Console.WriteLine(pet);
            try
            {
                var resposta = await CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        System.Console.WriteLine("Importação concluída!");
    }

    Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }
    }
}
