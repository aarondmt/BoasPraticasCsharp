using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Testes.Servicos;
public class ClientesDoJsonTest : IDisposable
{
    private readonly string caminhoArquivo;

    public ClientesDoJsonTest()
    {
        //Setup
        string conteudo = @"
            [
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
                ""Nome"": ""Mancha"",
                ""Email"": ""mancha@teste.com""
              },
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511672e0"",
                ""Nome"": ""Alvo"",
                ""Email"": ""alvo@teste.com""
              },
              {
                ""Id"": ""68286fbf-f6f4-1234-adab-0637511672e0"",
                ""Nome"": ""Pinta"",
                ""Email"": ""pinta@teste.com""
              }
            ]
        ";

        string nomeRandomico = $"{Guid.NewGuid()}.json";

        File.WriteAllText(nomeRandomico, conteudo);
        caminhoArquivo = Path.GetFullPath(nomeRandomico);
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDeClientes()
    {
        //Arrange            
        //Act
        var lista = new LeitorDeArquivosJson<Cliente>(caminhoArquivo).RealizaLeitura()!;
        //Assert
        Assert.NotNull(lista);
        Assert.Equal(3, lista.Count());
    }

    public void Dispose()
    {
        File.Delete(caminhoArquivo);
    }
}
