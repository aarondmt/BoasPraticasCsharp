using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
internal class List : IComando
{
    public async Task ExecutarAsync(string[] args)
    {
        await ListaDadosPetsDaAPIAsync();
    }

    private async Task ListaDadosPetsDaAPIAsync()
    {
        var httpClientPet = new HttpClientPet();
        var pets = await httpClientPet.ListPetsAsync();
        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
}
