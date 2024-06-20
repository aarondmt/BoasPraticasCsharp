using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Tests;

public class HttpClientPetTest
{
    [Fact]
    public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
    {
        //Arrange
        var httpClientPet = new HttpClientPet();

        //Act
        var lista = await httpClientPet.ListPetsAsync();

        //Assert
        Assert.NotNull(lista);
        Assert.NotEmpty(lista);
    }

    [Fact]
    public async Task QuandoAPIForaDeveREtornarUmaExcecao()
    {
        //Arrange
        var httpClientPet = new HttpClientPet(uri: "http://localhost:1111");

        //Act + Assert
        await Assert.ThrowsAnyAsync<Exception>(httpClientPet.ListPetsAsync);
    }
}