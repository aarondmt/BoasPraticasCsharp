using Alura.Adopet.Console.Servicos.Abstracoes;
using Moq;

namespace Alura.Adopet.Testes.Builder;

internal static class ApiServiceMockBuilder
{
    public static Mock<IApiService<T>> GetMock<T>()
    {
        var httpClientPet = new Mock<IApiService<T>>(MockBehavior.Default);
        return httpClientPet;
    }

    public static Mock<IApiService<T>> GetMockList<T>(List<T> lista)
    {
        var httpClientPet = new Mock<IApiService<T>>(MockBehavior.Default);
        httpClientPet.Setup(_ => _.ListAsync())
            .ReturnsAsync(lista);
        return httpClientPet;
    }

}
