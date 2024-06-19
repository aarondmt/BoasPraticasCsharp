using System.Net.Http.Json;

namespace Alura.Adopet.Console;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
internal class List : CommonAbstract
{
    public List(HttpClient client) : base(client)
    { }

    public async Task ListaDadosPetsDaAPIAsync()
    {
        var pets = await ListPetsAsync();
        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }

    async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
