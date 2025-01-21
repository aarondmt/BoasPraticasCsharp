using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Testes.Builder;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Sockets;

namespace Alura.Adopet.Testes.Servicos;
public class ClienteServiceTest
{
    [Fact]
    public async Task ListaClientesDeveRetornarUmaListaNaoVazia()
    {
        //Arrange
        var mock = HttpClientMockBuilder.GetMock(@"
            [
                {
                    ""id"": ""ed48920c-5adb-4684-9b8f-ba8a94775a11"",
                    ""nome"": ""Sábio"",
                    ""email"": ""sabio@teste.com"",
                    ""cpf"": ""000.000.000-00""
                },
                {
                    ""id"": ""456b24f4-19e2-4423-845d-4a80e8854a41"",
                    ""nome"": ""Lima Limão"",
                    ""email"": ""lima@teste.com"",
                    ""cpf"": ""000.000.000-00""
                }
            ]
        ");
        var service = new ClienteService(mock.Object);

        //Act
        var lista = await service.ListAsync();

        //Assert
        Assert.NotNull(lista);
        Assert.NotEmpty(lista);
        Assert.Equal(2, lista.Count());
    }

    [Fact]
    public async Task QuandoAPIForaDeveRetornarUmaExcecao()
    {
        //Arrange
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
           .Protected()
           .Setup<Task<HttpResponseMessage>>(
              "SendAsync",
              ItExpr.IsAny<HttpRequestMessage>(),
              ItExpr.IsAny<CancellationToken>())
           .ThrowsAsync(new SocketException());

        var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);
        httpClient.Object.BaseAddress = new Uri("http://localhost:5057");

        var clienteService = new ClienteService(httpClient.Object);

        //Act+Assert
        await Assert.ThrowsAnyAsync<Exception>(clienteService.ListAsync);
    }
}
